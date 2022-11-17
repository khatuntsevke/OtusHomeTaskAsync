using System;
using System.Net;

internal class ImageDownloaderAsync
{
    private string _remoteUri;
    private string _fileName;

    public delegate void ImageStartedHandler(string filename, string uri);
    public delegate void ImageCompletedHandler(string filename, string uri);

    public event ImageStartedHandler ImageStarted;
    public event ImageCompletedHandler ImageCompleted;

    public ImageDownloaderAsync(string uri)
    {
        _remoteUri = uri;
        _fileName = "bigimageasync.jpg";
    }

    public async Task DownloadAsync()
    {
        // Качаем картинку в текущую директорию
        var myWebClient = new WebClient();
        ImageStarted?.Invoke(_fileName, _remoteUri);        
        await myWebClient.DownloadFileTaskAsync(new Uri(_remoteUri), _fileName);
        ImageCompleted?.Invoke(_fileName, _remoteUri);
    }
}