namespace MusicHub
{
    using System;
    using System.Linq;
    using System.Text;
    using Data;
    using MusicHub.Initializer;
    using Data.Models;
    using System.Globalization;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            string output = ExportAlbumsInfo(context, 9);

            Console.WriteLine(output);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albumsInfo = context
                .Albums
                .Where(x => x.ProducerId == producerId)
                .ToArray()
                .OrderByDescending(x=>x.Price)
                .Select(x => new
                {
                    AlbumName = x.Name,
                    ReleaseDate = x.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = x.Producer.Name,
                    AlbumPrice = $"{x.Price:f2}",
                    AlbumSongs = x.Songs.ToArray().Select(s => new
                    {
                        SongName = s.Name,
                        SongPrice = $"{s.Price:f2}",
                        WriterName = s.Writer.Name
                    }).OrderByDescending(s => s.SongName).
                    ThenBy(s => s.WriterName).
                    ToArray()
                })
                .ToList();

            var sb = new StringBuilder();

            foreach (var album in albumsInfo)
            {
                sb.AppendLine($"-AlbumName: {album.AlbumName}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine($"-Songs:");
                var i = 0;

                foreach (var song in album.AlbumSongs)
                {
                    i++;
                    sb.AppendLine($"---#{i}");
                    sb.AppendLine($"---SongName: {song.SongName}");
                    sb.AppendLine($"---Price: {song.SongPrice}");
                    sb.AppendLine($"---Writer: {song.WriterName}");
                }
                sb.AppendLine($"-AlbumPrice: {album.AlbumPrice}");
            }

            return sb.ToString().TrimEnd();

            
        }
    }
}

