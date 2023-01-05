using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
