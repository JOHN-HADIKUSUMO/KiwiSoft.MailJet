using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System;
using System.IO;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

namespace KiwiSoft.MailJet
{
    public class EMailBroker
    {
        private readonly string _apiurl = "ttps://api.mailjet.com/v3.1/send";
        private readonly string _appsettings = "appsettings.json";
        private readonly string _section = "KiwiSoft.MailJet";
        private readonly string? _app_key = string.Empty;
        private readonly string? _secret_key = string.Empty;
        public EMailBroker() {

            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(_appsettings)
                .Build();

            IConfigurationSection section = config.GetSection(_section);
            _app_key = section.GetSection("API_KEY").Value;
            _secret_key = section.GetSection("SECRET_KEY").Value;
        }

        public EMailBroker(string jsonPath)
        {
            _appsettings = jsonPath;
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(_appsettings)
                .Build();

            IConfigurationSection section = config.GetSection(_section);
            _app_key = section.GetSection("API_KEY").Value;
            _secret_key = section.GetSection("SECRET_KEY").Value;
        }

        public EMailBroker(string jsonfilepath, string sectionName)
        {
            _appsettings = jsonfilepath;
            _section = sectionName;
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(_appsettings)
                .Build();

            IConfigurationSection section = config.GetSection(_section);
            _app_key = section.GetSection("API_KEY").Value;
            _secret_key = section.GetSection("SECRET_KEY").Value;
        }
    }
}