using FileGateway;

namespace FileGateway
{
    public class Program
    {
        public static void Main(string[] args) {
            string filePath = Path.Combine(AppContext.BaseDirectory, "Data", "albums.csv");

            List<Album> albums = AlbumParser.ParseCSV(filePath);
            foreach(Album a in albums) {
                Console.WriteLine(a);
            }
        }
    }
}