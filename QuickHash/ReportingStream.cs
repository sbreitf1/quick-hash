using System.IO;

namespace QuickHash
{
    delegate void ReportPositionHandler(ReportingStream sender, long newPosition);


    class ReportingStream : Stream
    {
        public override bool CanRead { get { return this.baseStream.CanRead; } }
        public override bool CanSeek { get { return this.baseStream.CanSeek; } }
        public override bool CanWrite { get { return this.baseStream.CanWrite; } }

        public override long Length { get { return this.baseStream.Length; } }
        public override long Position
        {
            get { return this.baseStream.Position; }
            set
            {
                this.baseStream.Position = value;
                DoReportPosition();
            }
        }

        private bool isOpen;
        public bool IsOpen { get { return this.isOpen; } }

        public event ReportPositionHandler ReportPosition;


        protected Stream baseStream;
        public ReportingStream(Stream baseStream)
        {
            this.baseStream = baseStream;
            this.isOpen = true;
        }


        protected void DoReportPosition()
        {
            if (ReportPosition != null)
                this.ReportPosition(this, this.baseStream.Position);
        }


        public override void Close()
        {
            this.isOpen = false;
            this.baseStream.Close();
        }

        public override void Flush()
        {
            this.baseStream.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int result = this.baseStream.Read(buffer, offset, count);
            DoReportPosition();
            return result;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            long result = this.baseStream.Seek(offset, origin);
            DoReportPosition();
            return result;
        }

        public override void SetLength(long value)
        {
            this.baseStream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            this.baseStream.Write(buffer, offset, count);
            DoReportPosition();
        }
    }
}
