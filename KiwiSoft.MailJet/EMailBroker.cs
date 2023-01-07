using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System;
using System.Text;
using System.IO;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using KiwiSoft.MailJet.Models;
using KiwiSoft.MailJet.Constants;
using System.Net.Http.Json;
using System.Text;

namespace KiwiSoft.MailJet
{
    public class eMailBroker
    {
        private readonly EmailMessage _message;
        private readonly string _api_url = "https://api.mailjet.com/v3.1/send";
        private readonly string _appsettings = "appsettings.json";
        private readonly string _section = "KiwiSoft.MailJet";
        private readonly string? _app_key = string.Empty;
        private readonly string? _secret_key = string.Empty;
        public eMailBroker() {

            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(_appsettings)
                .Build();

            IConfigurationSection section = config.GetSection(_section);
            _app_key = section.GetSection("API_KEY").Value;
            _secret_key = section.GetSection("SECRET_KEY").Value;
        }

        public eMailBroker(string jsonfilepath)
        {
            _appsettings = jsonfilepath;
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(_appsettings)
                .Build();

            IConfigurationSection section = config.GetSection(_section);
            _app_key = section.GetSection("API_KEY").Value;
            _secret_key = section.GetSection("SECRET_KEY").Value;
        }

        public eMailBroker(string jsonfilepath, string sectionName)
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

        public eMailBroker(EmailMessage message)
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(_appsettings)
                .Build();

            IConfigurationSection section = config.GetSection(_section);
            _app_key = section.GetSection("API_KEY").Value;
            _secret_key = section.GetSection("SECRET_KEY").Value; _message = message;
        }

        public bool Send(EmailMessage emailMessage)
        {
            bool status = false;
            try
            {
                var payload = new
                {
                    Messages = new List<EmailMessage>() { emailMessage }
                };

                string strMessage = JsonSerializer.Serialize(payload);
                StringContent content = new StringContent(strMessage, Encoding.UTF8, FileTypes.Json);
                string securityToken = _app_key + ":" + _secret_key;
                byte[] arrayOfbytes = Encoding.ASCII.GetBytes(securityToken);
                string base64String = Convert.ToBase64String(arrayOfbytes);
                HttpRequestMessage request = new HttpRequestMessage();
                request.Method = HttpMethod.Post;
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64String);
                request.Content = content;

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_api_url);
                HttpResponseMessage response = client.Send(request);
                status = true;
            }
            catch (Exception ex)
            {
                string errMsg = ex.GetBaseException().ToString();
            }
            return status;
        }
    }
}