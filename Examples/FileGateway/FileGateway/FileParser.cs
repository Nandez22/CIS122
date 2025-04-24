using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace FileGateway
{
    public class AlbumParser {
        public static List<Album> ParseCSV(string filepath) {
            List<Album> albums = new();
            string[] rows = File.ReadAllLines(filepath);
            string[] album;

            DateOnly releaseDate;
            double duration;
            int numSongs;


            for(int i = 1; i < rows.Length; i++) {
                album = rows[i].Split(',');

                releaseDate = DateOnly.Parse(album[2]);
                duration = Convert.ToDouble(album[3]);
                numSongs = Convert.ToInt32(album[4]);
                albums.Add(new Album(album[0], album[1], releaseDate, duration, numSongs));
            }

            return albums;
        }
    }
}
