using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiwiSoft.MailJet.Models
{
    public class EmailAddress
    {
        private string _email;
        private string _name;
        public string Email {
            get => _email;

            set {
                _email = value;
            } 
        }

        public string Name {
            get => _name;

            set
            {
                _name = value;
            }
        }
        public EmailAddress() { 
        

        }
        public EmailAddress(string email, string name)
        {
            _email = email;
            _name = name;
        }
    }
}
