using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.Extensions.Configuration;
using KiwiSoft.MailJet.Models;
using KiwiSoft.MailJet.Constants;

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

        public eMailBroker(EmailMessage message)
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(_appsettings)
                .Build();

            IConfigurationSection section = config.GetSection(_section);
            _app_key = section.GetSection("API_KEY").Value;
            _secret_key = section.GetSection("SECRET_KEY").Value; 
            _message = message;
        }

        public Tuple<bool,string?> Send()
        {
            try
            {
                var payload = new
                {
                    Messages = new List<EmailMessage>() { _message }
                };

                string strMessage = JsonSerializer.Serialize(payload);
                StringContent content = new StringContent(strMessage, Encoding.UTF8, FileTypes.Json);
                string securityToken = _app_key + ":" + _secret_key;
                byte[] arrayOfbytes = Encoding.ASCII.GetBytes(securityToken);
                string base64String = Convert.ToBase64String(arrayOfbytes);
                HttpRequestMessage request = new HttpRequestMessage();
                request.Method = HttpMethod.Post;
                request.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64String);
                request.Content = content;

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_api_url);
                HttpResponseMessage response = client.Send(request);
                if(response.StatusCode == HttpStatusCode.OK)
                {
                    return new Tuple<bool, string?>(true, "Successful");
                }
                else
                {
                    return new Tuple<bool, string?>(false, response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string?>(false, ex.GetBaseException().ToString());
            }
        }

        public async Task<Tuple<bool, string?>> SendAsync()
        {
            try
            {
                var payload = new
                {
                    Messages = new List<EmailMessage>() { _message}
                };

                string strMessage = JsonSerializer.Serialize(payload);
                StringContent content = new StringContent(strMessage, Encoding.UTF8, FileTypes.Json);
                string securityToken = _app_key + ":" + _secret_key;
                byte[] arrayOfbytes = Encoding.ASCII.GetBytes(securityToken);
                string base64String = Convert.ToBase64String(arrayOfbytes);
                HttpRequestMessage request = new HttpRequestMessage();
                request.Method = HttpMethod.Post;
                request.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64String);
                request.Content = content;

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_api_url);
                HttpResponseMessage response = await client.SendAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return new Tuple<bool, string?>(true, "Successful");
                }
                else
                {
                    return new Tuple<bool, string?>(false, response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string?>(false, ex.GetBaseException().ToString());
            }
        }
    }
}