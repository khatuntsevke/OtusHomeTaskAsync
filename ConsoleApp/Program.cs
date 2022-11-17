
public class Program
{
    public static void Main()
    {
        var imageDowloader = new ImageDownloader("https://effigis.com/wp-content/uploads/2015/02/Iunctus_SPOT5_5m_8bit_RGB_DRA_torngat_mountains_national_park_8bits_1.jpg");
        imageDowloader.ImageStarted += DisplayMessageStartedDowload;
        imageDowloader.ImageCompleted += DisplayMessageCompletedDowload;

        imageDowloader.Download();

        Console.WriteLine("Нажмите любую клавишу для выхода\n");
        Console.ReadKey(true);

        var imageDowloaderAsync = new ImageDownloaderAsync("https://effigis.com/wp-content/uploads/2015/02/Iunctus_SPOT5_5m_8bit_RGB_DRA_torngat_mountains_national_park_8bits_1.jpg");
        imageDowloaderAsync.ImageStarted += DisplayMessageStartedDowload;
        imageDowloaderAsync.ImageCompleted += DisplayMessageCompletedDowload;

        Task dowloading = imageDowloaderAsync.DownloadAsync();

        Console.WriteLine("Нажмите клавишу A для выхода"); 
        while (Console.ReadKey(true).KeyChar != 'A')
        {
            Console.WriteLine(dowloading.IsCompleted? "Загружена" : "Не загружена");
        }
        
    }
    
    private static void DisplayMessageStartedDowload(string fileName, string uri)
    {
        Console.WriteLine("Качаю \"{0}\" из \"{1}\" .......\n\n", fileName, uri);
        //Console.WriteLine("Скачивание файла началось");
    }

    private static void DisplayMessageCompletedDowload(string fileName, string uri)
    {
        Console.WriteLine("Успешно скачал \"{0}\" из \"{1}\"\n", fileName, uri);
    }   
}