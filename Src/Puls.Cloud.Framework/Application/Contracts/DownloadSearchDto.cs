namespace Puls.Cloud.Framework.Application.Contracts
{
    public class DownloadSearchDto
    {
        public byte[] Output { get; set; }

        public string FileContentType { get; set; }
        public string FileName { get; set; }
    }
}