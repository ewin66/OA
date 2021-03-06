using System;
using System.Net;
 
namespace SMT.SAAS.Platform.Core.Modularity
{
    /// <summary>
    /// 定义资源文件下载接口.
    /// </summary>
    public interface IFileDownloader
    {
        /// <summary>
        /// 文件下载进度发送变更时触发。
        /// 在使用WebClient实现下载的时候，此方法需要使用。
        /// </summary>
        event EventHandler<DownloadProgressChangedEventArgs> DownloadProgressChanged;

        /// <summary>
        /// 文件下载完成后触发。
        /// </summary>
        event EventHandler<DownloadCompletedEventArgs> DownloadCompleted;

        /// <summary>
        /// 根据给定的文件地址<paramref name="uri"/>，开始启动异步下载文件。
        /// </summary>
        /// <param name="uri">
        /// 文件地址。
        /// </param>
        /// <param name="userToken">
        /// 提供异步任务的用户指定的标识符。
        /// </param>
        void DownloadAsync(Uri uri, object userToken);

        /// <summary>
        /// 根据给定的文件名称，开始启动异步下载文件。
        /// </summary>
        /// <param name="fileName">
        /// 文件名称。
        /// </param>
        /// <param name="userToken">
        /// 提供异步任务的用户指定的标识符。
        /// </param>
        void DownloadAsync(string fileName, object userToken);
    }
}