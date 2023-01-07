using System;
using System.IO;
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
        }

        public string Base64Content
        {
            get => _base64Content;
        }

        public EmailAttachment() { 
        

        }

        internal string GetBase64String(string fullpathfilename)
        {
            string result = string.Empty;
            byte[] arrayOfBytes = new byte[10000000];
            FileStream fileStream = new FileStream(fullpathfilename, FileMode.Open, FileAccess.Read);
            int total = fileStream.Read(arrayOfBytes);
            if(total > 0)
            {
                result = Convert.ToBase64String(arrayOfBytes);
            }
            return result;
        }

        public EmailAttachment(string fullpathfilename, string contentType )
        {
            _filename = Path.GetFileName(fullpathfilename);
            _contentTYpe = contentType;
            _base64Content = GetBase64String(fullpathfilename);
        }
    }
}
