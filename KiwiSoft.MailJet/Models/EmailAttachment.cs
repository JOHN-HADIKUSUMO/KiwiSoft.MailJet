using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using KiwiSoft.MailJet.Constants;

namespace KiwiSoft.MailJet.Models
{
    public class EmailAttachment
    {
        private string _contentTYpe;
        private string _filename;
        private string _base64Content;
        public string ContentType {
            get => _contentTYpe;

            set {
                _contentTYpe = value;
            } 
        }

        public string Filename {
            get => _filename;

            set
            {
                _filename = value;
            }
        }
        public string Base64Content
        {
            get => _base64Content;

            set
            {
                _base64Content = value;
            }
        }

        public EmailAttachment() { 
        

        }

        internal string GetBase64String(string filename)
        {
            string result = string.Empty;
            byte[] arrayOfBytes = new byte[10000000];
            FileStream fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
            int total = fileStream.Read(arrayOfBytes);
            if(total > 0)
            {
                result = Convert.ToBase64String(arrayOfBytes);
            }
            return result;
        }

        public EmailAttachment(string filename, string contentType )
        {

            _filename = filename;
            _contentTYpe = contentType;
            _base64Content = GetBase64String(filename);
        }
    }
}
