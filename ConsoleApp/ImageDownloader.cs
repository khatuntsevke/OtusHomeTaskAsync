using System.Net;
using static ImageDownloader;

internal class ImageDownloader
{
    private string _remoteUri;
    private string _fileName;

    public delegate void ImageStartedHandler(string filename, string uri);
    public delegate void ImageCompletedHandler(string filename, string uri);

    public event ImageStartedHandler ImageStarted;
    public event ImageCompletedHandler ImageCompleted;

    public ImageDownloader(string uri)
    {
        _remoteUri = uri;
        _fileName = "bigimage.jpg";
    }

    public void Download()
    {
        // Качаем картинку в текущую директорию
        var myWebClient = new WebClient();
        ImageStarted?.Invoke(_fileName, _remoteUri);
        myWebClient.DownloadFile(_remoteUri, _fileName);
        ImageCompleted?.Invoke(_fileName, _remoteUri);
    }
}