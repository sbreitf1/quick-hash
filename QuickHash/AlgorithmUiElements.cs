using System.Windows.Forms;

namespace QuickHash
{
    enum HashAlgorithms
    {
        MD5 = 1,
        SHA1 = 2,
        SHA256 = 3
    }

    enum AlgorithmStates
    {
        None = 0,
        Issued = 1,
        Computing = 2,
        Ready = 3
    }


    class AlgorithmUiElements
    {
        private Label titleLabel;
        public Label TitleLabel { get { return this.titleLabel; } }
        private TextBox hashBox;
        public TextBox HashBox { get { return this.hashBox; } }
        private Button computeButton;
        public Button ComputeButton { get { return this.computeButton; } }

        private AlgorithmStates state;
        public AlgorithmStates State { get { return this.state; } }
        private byte[] hash;
        public byte[] Hash { get { return this.hash; } }


        public AlgorithmUiElements(Label titleLabel, TextBox hashBox, Button computeButton)
        {
            this.titleLabel = titleLabel;
            this.hashBox = hashBox;
            this.computeButton = computeButton;

            Reset();
        }

        public void Reset()
        {
            this.state = AlgorithmStates.None;
            this.hash = null;
        }


        public void SetIsIssued()
        {
            this.state = AlgorithmStates.Issued;
        }
        public void SetIsComputing()
        {
            this.state = AlgorithmStates.Computing;
        }
        public void SetHash(byte[] hash)
        {
            this.state = AlgorithmStates.Ready;
            this.hash = hash;
        }
    }
}
