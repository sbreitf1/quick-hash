using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
using System.Text;
using QuickHash.Properties;

namespace QuickHash
{
    public partial class MainForm : Form
    {
        #region UI
        Dictionary<HashAlgorithms, AlgorithmUiElements> hashUiElements;
        bool ignoreCheckedChange = false;


        public MainForm()
        {
            InitializeComponent();
            this.Icon = Resources.quickhash;

            this.hashUiElements = new Dictionary<HashAlgorithms, AlgorithmUiElements>(3);
            this.hashUiElements.Add(HashAlgorithms.MD5, new AlgorithmUiElements(this.lblMD5, this.tbxMD5, this.btnComputeMD5));
            this.hashUiElements.Add(HashAlgorithms.SHA1, new AlgorithmUiElements(this.lblSHA1, this.tbxSHA1, this.btnComputeSHA1));
            this.hashUiElements.Add(HashAlgorithms.SHA256, new AlgorithmUiElements(this.lblSHA256, this.tbxSHA256, this.btnComputeSHA256));
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            AbortComputations();

            Settings.Default.SelectedEncoding = this.cbxHashEncoding.SelectedIndex;
            Settings.Default.Save();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.cbxSendTo.Left = btnClose.Left - cbxSendTo.Width - 12;
            this.MinimumSize = new Size(cbxHashEncoding.Right + cbxSendTo.Width + btnClose.Width + 48, this.Height);
            this.MaximumSize = new Size(int.MaxValue, this.Height);

            this.cbxHashEncoding.SelectedIndex = Settings.Default.SelectedEncoding;

            this.ignoreCheckedChange = true;
            this.cbxSendTo.Checked = ShortcutManager.ShortcutExists(Environment.SpecialFolder.ApplicationData, "Microsoft\\Windows\\SendTo", "Quick Hash");
            this.ignoreCheckedChange = false;

            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                SelectFile(args[1]);
            }
        }


        private void MainForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }


        private HashEncodings GetSelectedEncoding()
        {
            switch (this.cbxHashEncoding.SelectedIndex)
            {
                case 0: return HashEncodings.HexLowerCase;
                case 1: return HashEncodings.HexUpperCase;
                case 2: return HashEncodings.BlockyHex;
                case 3: return HashEncodings.Base64;
                default: return HashEncodings.HexLowerCase;
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void cbxHashEncoding_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUiElements();
        }


        private void cbxSendTo_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ignoreCheckedChange)
                return;

            if (cbxSendTo.Checked)
            {
                ShortcutManager.CreateShortcut(Environment.SpecialFolder.ApplicationData, "Microsoft\\Windows\\SendTo", "Quick Hash", Environment.GetCommandLineArgs()[0]);
            }
            else
            {
                ShortcutManager.DeleteShortcut(Environment.SpecialFolder.ApplicationData, "Microsoft\\Windows\\SendTo", "Quick Hash");
            }

            // maybe there were errors...
            this.ignoreCheckedChange = true;
            this.cbxSendTo.Checked = ShortcutManager.ShortcutExists(Environment.SpecialFolder.ApplicationData, "Microsoft\\Windows\\SendTo", "Quick Hash");
            this.ignoreCheckedChange = false;
        }

        
        private void btnComputeMD5_Click(object sender, EventArgs e)
        {
            IssueComputeHash(HashAlgorithms.MD5);
            btnSelectFile.Focus();
        }
        private void btnComputeSHA1_Click(object sender, EventArgs e)
        {
            IssueComputeHash(HashAlgorithms.SHA1);
            btnSelectFile.Focus();
        }
        private void btnComputeSHA256_Click(object sender, EventArgs e)
        {
            IssueComputeHash(HashAlgorithms.SHA256);
            btnSelectFile.Focus();
        }


        private void hashBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }
        private void hashBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (((TextBox)sender).SelectionLength == 0)
                ((TextBox)sender).SelectAll();
        }


        private void MainForm_Resize(object sender, EventArgs e)
        {
            // shorten file string to fit into the window
            UpdateFileLabel();
        }
        #endregion

        #region Hash source selection
        string selectedFile = null;
        long fileLength;

        EnterStringForm enterStringForm = null;


        private void btnSetFromText_Click(object sender, EventArgs e)
        {
            if (this.enterStringForm == null || this.enterStringForm.IsDisposed)
            {
                this.enterStringForm = new EnterStringForm(this);
                this.enterStringForm.Owner = this;
            }
            this.enterStringForm.Show();
            this.enterStringForm.Activate();
        }

        public void SetHashesFromText(string str)
        {
            SelectFile(null);
            lock (this.hashUiElements)
            {
                foreach (KeyValuePair<HashAlgorithms, AlgorithmUiElements> kvp in this.hashUiElements)
                {
                    kvp.Value.SetHash(ComputeHash(str, kvp.Key));
                }
            }
            UpdateUiElements();
        }


        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            //TODO select file
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Move;
        }
        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (e.Data.GetData(DataFormats.FileDrop) as string[]);
                if (files != null && files.Length > 0)
                    SelectFile(files[0]);
            }
        }

        protected void ResetHashes()
        {
            foreach (AlgorithmUiElements elements in this.hashUiElements.Values)
                elements.Reset();
        }
        protected void SelectFile(string file)
        {
            //TODO check for file and directory

            // change selected file first, so the compuation can detect the change and discard their results
            this.selectedFile = file;
            AbortComputations();
            ResetHashes();
            UpdateFileLabel();

            if (this.selectedFile != null)
            {
                this.Text = Path.GetFileName(this.selectedFile) + " - Quick Hash";
                FileInfo fi = new FileInfo(this.selectedFile);
                this.fileLength = fi.Length;
                if (this.fileLength < 1048576)
                {
                    // automatically compute all hashes for small files
                    lock (this.hashUiElements)
                    {
                        foreach (KeyValuePair<HashAlgorithms, AlgorithmUiElements> kvp in this.hashUiElements)
                        {
                            IssueComputeHash(kvp.Key);
                        }
                    }
                }
            }
            else
            {
                this.Text = "Quick Hash";
            }

            UpdateUiElements();
        }

        private string ShortenPath(string path, int maxWidth, Graphics g, Font font)
        {
            string pathStr = path;

            List<string> parts = new List<string>(path.Split(Path.DirectorySeparatorChar));
            // use center of path as start point of the "..." gap - biased so the back will be shortened first
            int frontPartsCount = (int)Math.Ceiling(parts.Count / 2.0f);
            int backPartsStart = frontPartsCount;
            // string larger than max width and still removable parts in the list?
            // force drive letter and full file-name to be visible
            while ((frontPartsCount > 1 || backPartsStart < (parts.Count - 1)) && g.MeasureString(pathStr, font).Width > maxWidth)
            {
                // count removable parts from the back and the front
                int frontRemaining = frontPartsCount;
                int backRemaining = (parts.Count - backPartsStart);
                // remove from the side with more parts (biased to remove more from the back)
                if (backRemaining > 1 && (backRemaining + 1) >= frontRemaining)
                {
                    backPartsStart++;
                }
                else
                {
                    frontPartsCount--;
                }

                // assemble new path string with "..." gap
                string frontStr = string.Join(Path.DirectorySeparatorChar.ToString(), parts.ToArray(), 0, frontPartsCount);
                string backStr = string.Join(Path.DirectorySeparatorChar.ToString(), parts.ToArray(), backPartsStart, parts.Count - backPartsStart);
                pathStr = frontStr + Path.DirectorySeparatorChar + "..." + Path.DirectorySeparatorChar + backStr;
            }

            if (g.MeasureString(pathStr, font).Width > maxWidth)
            {
                pathStr = parts[parts.Count - 1];

                if(g.MeasureString(pathStr, font).Width > maxWidth)
                {
                    pathStr = pathStr.Substring(0, pathStr.Length - 1) + "...";
                    while (pathStr.Length > 0 && g.MeasureString(pathStr, font).Width > maxWidth)
                    {
                        pathStr = pathStr.Substring(0, pathStr.Length - 4) + "...";
                    }
                }
            }
            
            return pathStr;
        }
        protected void UpdateFileLabel()
        {
            if (this.selectedFile == null)
                this.lblFile.Text = "-";
            else
            {
                this.lblFile.Text = ShortenPath(this.selectedFile, this.btnSetFromText.Left - this.lblFile.Left - 12, this.CreateGraphics(), this.lblFile.Font);
            }
        }

        protected void UpdateUiElements()
        {
            lock (this.hashUiElements)
            {
                HashEncodings encoding = GetSelectedEncoding();
                foreach (KeyValuePair<HashAlgorithms, AlgorithmUiElements> kvp in this.hashUiElements)
                {
                    kvp.Value.ComputeButton.Enabled = (this.selectedFile != null && kvp.Value.State == AlgorithmStates.None);
                    switch (kvp.Value.State)
                    {
                        case AlgorithmStates.None:
                            if (this.selectedFile != null)
                                kvp.Value.HashBox.Text = "Press compute -->";
                            else
                                kvp.Value.HashBox.Text = "";
                            break;
                        case AlgorithmStates.Issued:
                            kvp.Value.HashBox.Text = "[Waiting for other computation]";
                            break;
                        case AlgorithmStates.Computing:
                            kvp.Value.HashBox.Text = "[Computation running...]";
                            break;
                        case AlgorithmStates.Ready:
                            kvp.Value.HashBox.Text = HashConverter.ToString(kvp.Value.Hash, encoding);
                            break;
                    }
                }
            }
        }
        #endregion

        #region Async hash computation
        class ComputationProgress
        {
            HashAlgorithms algorithm;
            public HashAlgorithms Algorithm { get { return this.algorithm; } }
            
            public ReportingStream Stream { get; set; }
            public long Position
            {
                get
                {
                    if (this.Stream != null && this.Stream.IsOpen)
                        return this.Stream.Position;
                    return 0;
                }
            }
            public long Length
            {
                get
                {
                    if (this.Stream != null && this.Stream.IsOpen)
                        return this.Stream.Length;
                    return 0;
                }
            }


            public ComputationProgress(HashAlgorithms algorithm)
            {
                this.algorithm = algorithm;
                this.Stream = null;
            }


            public void Abort()
            {
                if (this.Stream != null)
                    this.Stream.Close();
            }
        }
        List<ComputationProgress> computations = new List<ComputationProgress>();
        const int UiUpdateInterval = 10;


        void IssueComputeHash(HashAlgorithms algorithm)
        {
            lock (this.computations)
            {
                ComputationProgress computation = new ComputationProgress(algorithm);

                Thread thread = new Thread(AsyncComputeHash);
                thread.IsBackground = true;
                thread.Start(computation);

                this.computations.Add(computation);
            }
        }

        void AbortComputations()
        {
            lock(this.computations)
            {
                foreach(ComputationProgress computation in this.computations)
                {
                    computation.Abort();
                }
            }
            UpdateComputationProgress();
        }

        HashAlgorithm GetHasher(HashAlgorithms algorithm)
        {
            switch (algorithm)
            {
                case HashAlgorithms.MD5: return MD5.Create();
                case HashAlgorithms.SHA1: return SHA1.Create();
                case HashAlgorithms.SHA256: return SHA256.Create();
                default: return null;
            }
        }

        void AsyncComputeHash(object obj)
        {
            ComputationProgress computation = (obj as ComputationProgress);
            if (computation == null)
                return;

            lock (this.hashUiElements)
                this.hashUiElements[computation.Algorithm].SetIsComputing();
            // notify UI
            this.Invoke(new Action(() =>
            {
                UpdateUiElements();
            }));

            // choose hashing algorithm
            HashAlgorithm hasher = GetHasher(computation.Algorithm);

            // save selected file to detect changes during computation
            string file = this.selectedFile;
            // initialize stream for status reporting
            FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);
            computation.Stream = new ReportingStream(fileStream);
            int lastUiUpdate = 0;
            computation.Stream.ReportPosition += new ReportPositionHandler((sender, newPosition) =>
            {
                if (computation.Position >= computation.Length || (Environment.TickCount - lastUiUpdate) >= UiUpdateInterval)
                {
                    lastUiUpdate = Environment.TickCount;
                    UpdateComputationProgress();
                }
            });

            // compute and save hash
            byte[] hash;
            try
            {
                hash = hasher.ComputeHash(computation.Stream);
            }
            catch (ObjectDisposedException)
            {
                // stream has been closed -> user requested abort
                return;
            }
            finally
            {
                //hasher.Dispose();
            }

            lock (this.computations)
            {
                computation.Stream.Close();
                computation.Stream = null;
            }

            lock (this.hashUiElements)
            {
                // file has changed? discard the result
                if (this.selectedFile != file)
                    return;

                this.hashUiElements[computation.Algorithm].SetHash(hash);
            }

            // notify UI
            this.Invoke(new Action(() =>
            {
                UpdateUiElements();
            }));
        }
        
        void UpdateComputationProgress()
        {
            long fullSize = 0;
            long fullPosition = 0;

            lock (this.computations)
            {
                foreach (ComputationProgress computation in this.computations)
                {
                    fullSize += computation.Length;
                    fullPosition += computation.Position;
                }
            }

            this.Invoke(new Action(() =>
            {
                if (fullSize > 0 && fullPosition < fullSize)
                {
                    progressBar1.Value = (int)((double)progressBar1.Maximum * (double)fullPosition / (double)fullSize);
                }
                else
                {
                    progressBar1.Value = 0;
                }
            }));
        }


        byte[] ComputeHash(string str, HashAlgorithms algorithm)
        {
            HashAlgorithm hasher = GetHasher(algorithm);
            byte[] buffer = Encoding.UTF8.GetBytes(str);
            byte[] hash = hasher.ComputeHash(buffer);
            //hasher.Dispose();
            return hash;
        }
        #endregion
    }
}
