namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var xRoot = new XmlRootAttribute();
            xRoot.ElementName = "Plays";
            var serializer = new XmlSerializer(typeof(PlayImportModel[]), xRoot);
            var playsDto = (PlayImportModel[])serializer.Deserialize(new StringReader(xmlString));

            var plays = new List<Play>();

            foreach (var play in playsDto)
            {
                if (!IsValid(play))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Genre genre;
                var isValidGenre = Enum.TryParse<Genre>(play.Genre, out genre);

                if (!isValidGenre)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                TimeSpan duration;
                var isValidDuration = TimeSpan.TryParseExact(play.Duration, "c", CultureInfo.InvariantCulture,out duration);

                if (duration.Hours < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var playDb = new Play
                {
                    Title = play.Title,
                    Screenwriter = play.Screenwriter,
                    Description = play.Description,
                    Duration = duration,
                    Genre = genre,
                    Rating = play.Rating,
                };

                plays.Add(playDb);
                sb.AppendLine(String.Format(SuccessfulImportPlay,playDb.Title,playDb.Genre.ToString(),playDb.Rating));
            }

            context.Plays.AddRange(plays);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var xRoot = new XmlRootAttribute();
            xRoot.ElementName = "Casts";
            var serializer = new XmlSerializer(typeof(CastImportModel[]), xRoot);
            var castsDto = (CastImportModel[])serializer.Deserialize(new StringReader(xmlString));

            var casts = new List<Cast>();

            foreach (var cast in castsDto)
            {
                if (!IsValid(cast))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var castDb = new Cast
                {
                    FullName = cast.FullName,
                    IsMainCharacter = cast.IsMainCharacter,
                    PhoneNumber = cast.PhoneNumber,
                    PlayId = cast.PlayId,
                };

                string role;
                if (castDb.IsMainCharacter)
                {
                    role = "main";
                }
                else 
                {
                    role = "lesser";
                }

                casts.Add(castDb);
                sb.AppendLine(String.Format(SuccessfulImportActor, castDb.FullName, role));
            }

            context.Casts.AddRange(casts);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var theatresDto = JsonConvert.DeserializeObject<TheatreImportModel[]>(jsonString);

            var theatres = new List<Theatre>();
            var playIds = context.Plays.Select(x => x.Id).ToArray();

            foreach (var theatre in theatresDto)
            {
                if (!IsValid(theatre))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                if (theatre.Tickets.Any(x => playIds.Contains(x.PlayId)))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var theatreDb = new Theatre
                {
                    Name = theatre.Name,
                    Director = theatre.Director,
                    NumberOfHalls = theatre.NumberOfHalls
                };

                //bool isValidPlay = true;

                foreach (var ticket in theatre.Tickets)
                {
                    //if (!playIds.Contains(ticket.PlayId))
                    //{
                    //    sb.AppendLine(ErrorMessage);
                    //    isValidPlay = false;
                    //    break;
                    //}
                    if (!IsValid(ticket))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    var ticketDb = new Ticket
                    {
                        Price = ticket.Price,
                        RowNumber = ticket.RowNumber,
                        PlayId = ticket.PlayId,
                    };
                    theatreDb.Tickets.Add(ticketDb);
                }
                //if (!isValidPlay)
                //{
                //    continue;
                //}

                theatres.Add(theatreDb);
                sb.AppendLine(String.Format(SuccessfulImportTheatre, theatreDb.Name, theatreDb.Tickets.Count()));
            }

            context.Theatres.AddRange(theatres);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
