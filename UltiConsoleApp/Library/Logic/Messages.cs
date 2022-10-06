using Library.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Library.Logic
{
    public class Messages : IMessages
    {
        private readonly ILogger<Messages> _log;

        public Messages(ILogger<Messages> log)
        {
            _log = log;
        }

        public string Greeting(string language)
        {
            string output = LookUpText("Greeting", language);
            return output;
        }

        private string LookUpText(string key, string language)
        {
            JsonSerializerOptions options = new()
            {
                PropertyNameCaseInsensitive = true
            };
            try
            {
                List<Text>? messageSets = JsonSerializer
                .Deserialize<List<Text>>
                (
                    File.ReadAllText("Text.json"), options
                );

                Text? message = messageSets?.Where(x => x.Language == language).FirstOrDefault();

                if (message is null)
                {
                    throw new NullReferenceException("The specified language was not found");
                }

                return message.Translations[key];
            }
            catch (Exception ex)
            {
                _log.LogError("Error looking up the text", ex);
                throw;
            }
        }
    }
}
