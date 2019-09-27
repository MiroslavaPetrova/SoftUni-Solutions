using OnlineRadioDatabase.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineRadioDatabase
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<RadioStation> songs = new List<RadioStation>();
            try
            {
                int numberOfSongs = int.Parse(Console.ReadLine());

                for (int i = 0; i < numberOfSongs; i++)
                {
                    string[] input = Console.ReadLine().Split(';');

                    if (input.Length != 3)
                    {
                        throw new InvalidSongException();
                    }
                    string artist = input[0];
                    string songName = input[1];
                    string[] length = input[2].Split(':');

                    int minutes = 0;
                    int seconds = 0;

                    if (!int.TryParse(length[0], out minutes))
                    {
                        throw new InvalidSongLengthException();
                    }
                    if (!int.TryParse(length[1], out seconds))
                    {
                        throw new InvalidSongLengthException();
                    }
                    RadioStation song = new RadioStation(artist, songName, minutes, seconds);
                    songs.Add(song);
                    Console.WriteLine("Song added.");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            int totalSeconds = songs.Sum(s => s.Minutes * 60 + s.Seconds);
            TimeSpan duration = TimeSpan.FromSeconds(totalSeconds);

            Console.WriteLine($"Songs added: {songs.Count}");
            Console.WriteLine($"Playlist length: " +
                $"{duration.Hours}h {duration.Minutes}m {duration.Seconds}s");
        }
    }
}
