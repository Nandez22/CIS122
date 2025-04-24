using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileGateway
{
    public class Album {
        public string Title { get; set; }
        public string Artist { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public double Duration { get; set; }
        public int NumSongs { get; set; }
        

        public Album() : this("N/A", "N/A", DateOnly.MinValue, -1, -1){}

        public Album(string title, string artist, DateOnly releaseDate, double duration, int numSongs) {
            Title = title;
            Artist = artist;
            ReleaseDate = releaseDate;
            Duration = duration;
            NumSongs = numSongs;
        }

        public override string ToString() {
            return $"{Title}\nBy: {Artist}\nReleased: {ReleaseDate}\nDuration: {Duration}\nSongs: {NumSongs}\n\n";
        }
    }
}
