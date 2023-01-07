using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiwiSoft.MailJet.Models
{
    public class EmailMessage
    {
        private EmailAddress _from;
        private List<EmailAddress> _to;
        private List<EmailAddress> _cc;
        private List<EmailAddress> _bcc;
        private string _subject;
        private string _textPart;
        private string _htmlPart;
        private List<EmailAttachment> _attachments;
        public EmailAddress From
        {
            get { return _from; }
            set { _from = value; }
        }
        public List<EmailAddress> To
        {
            get { return _to; }
            set { _to = value; }
        }

        public List<EmailAddress> Cc
        {
            get { return _cc; }
            set { _cc = value; }
        }

        public List<EmailAddress> Bcc
        {
            get { return _bcc; }
            set { _bcc = value; }
        }

        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        public string TextPart
        {
            get { return _textPart; }
            set { _textPart = value; }
        }

        public string HtmlPart
        {
            get { return _htmlPart; }
            set { _htmlPart = value; }
        }

        public List<EmailAttachment> InlinedAttachments
        {
            get { return _attachments; }
            set { _attachments = value; }
        }
        public EmailMessage() {
            _subject = string.Empty;
            _textPart = string.Empty;
            _htmlPart = string.Empty;
            _cc = new List<EmailAddress>();
            _bcc = new List<EmailAddress>();
            _attachments = new List<EmailAttachment>();
        }
        public EmailMessage(EmailAddress from, List<EmailAddress> to)
        {
            _subject = string.Empty;
            _textPart = string.Empty;
            _htmlPart = string.Empty;
            _from = from;
            _to = to;
            _cc = new List<EmailAddress>();
            _bcc = new List<EmailAddress>();
            _attachments = new List<EmailAttachment>();
        }
        public EmailMessage(EmailAddress from, List<EmailAddress> to, List<EmailAddress> cc, List<EmailAddress> bcc)
        {
            _subject = string.Empty;
            _textPart = string.Empty;
            _htmlPart = string.Empty;
            _from = from;
            _to = to;
            _cc = cc;
            _bcc = bcc;
            _attachments = new List<EmailAttachment>();
        }
        public EmailMessage(EmailAddress from, List<EmailAddress> to, List<EmailAddress> cc, List<EmailAddress> bcc, List<EmailAttachment> attachments)
        {
            _subject = string.Empty;
            _textPart = string.Empty;
            _htmlPart = string.Empty;
            _from = from;
            _to = to;
            _cc = cc;
            _bcc = bcc;
            _attachments = attachments;
        }
    }
}
