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
        private EmailAddress _to;
        private List<EmailAddress> _cc;
        private List<EmailAddress> _bcc;
        private string _subject;
        private string _textContent;
        private string _htmlContent;
        private List<EmailAttachment> _attachments;
        public EmailAddress From
        {
            get { return _from; }
            set { _from = value; }
        }
        public EmailAddress To
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

        public string TextContent
        {
            get { return _textContent; }
            set { _textContent = value; }
        }

        public string HtmlContent
        {
            get { return _htmlContent; }
            set { _htmlContent = value; }
        }

        public List<EmailAttachment> InlinedAttachments
        {
            get { return _attachments; }
            set { _attachments = value; }
        }
        public EmailMessage() {
            _subject = string.Empty;
            _textContent = string.Empty;
            _htmlContent = string.Empty;
            _cc = new List<EmailAddress>();
            _bcc = new List<EmailAddress>();
            _attachments = new List<EmailAttachment>();
        }
        public EmailMessage(EmailAddress from, EmailAddress to)
        {
            _subject = string.Empty;
            _textContent = string.Empty;
            _htmlContent = string.Empty;
            _from = from;
            _to = to;
            _cc = new List<EmailAddress>();
            _bcc = new List<EmailAddress>();
            _attachments = new List<EmailAttachment>();
        }
        public EmailMessage(EmailAddress from, EmailAddress to, List<EmailAddress> cc, List<EmailAddress> bcc)
        {
            _subject = string.Empty;
            _textContent = string.Empty;
            _htmlContent = string.Empty;
            _from = from;
            _to = to;
            _cc = cc;
            _bcc = bcc;
            _attachments = new List<EmailAttachment>();
        }
        public EmailMessage(EmailAddress from, EmailAddress to, List<EmailAddress> cc, List<EmailAddress> bcc, List<EmailAttachment> attachments)
        {
            _subject = string.Empty;
            _textContent = string.Empty;
            _htmlContent = string.Empty;
            _from = from;
            _to = to;
            _cc = cc;
            _bcc = bcc;
            _attachments = attachments;
        }
    }
}
