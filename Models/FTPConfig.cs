
namespace Caliburn.Micro.Hello
{
    /// <summary>
    /// 
    /// </summary>
    public class FTPConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public FTPConfig()
        {
            IsUpload = false;
            FtpServerIP = "127.0.0.1";
            FtpRemotePath = "";
            FtpUserID = "ftpTest";
            FtpPassword = "a123456.";
        }

        /// <summary>
        /// 是否上传
        /// </summary>
        public bool IsUpload { get; set; }

        /// <summary>
        /// FTP的IP地址
        /// </summary>
        public string FtpServerIP { get; set; }

        /// <summary>
        /// 上传FTP目录
        /// </summary>
        public string FtpRemotePath { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string FtpUserID { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string FtpPassword { get; set; }
    }
}
