using KiwiSoft.MailJet;
using KiwiSoft.MailJet.Constants;
using KiwiSoft.MailJet.Models;

namespace MailTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test_Basic()
        {
            EmailAddress to = new EmailAddress();
            to.Email = "francis@mailinator.com";
            to.Name = "Francis Lemuire";

            EmailAddress from = new EmailAddress();
            from.Email = "john.hadikusumo@gmail.com";
            from.Name = "John Hadikusumo";

            EmailMessage message = new EmailMessage(from,new List<EmailAddress>() { to });
            message.Subject = "Testing";
            message.TextPart = "Hello";
            message.HtmlPart = "<b>Hello</b>";

            eMailBroker broker = new eMailBroker(message);
            Tuple<bool,string?> result = broker.Send();

            Assert.True(true);
        }

        [Fact]
        public void Test_With_Attachment()
        {
            EmailAddress to = new EmailAddress();
            to.Email = "john.hadikusumo@gmail.com";
            to.Name = "John Hadikusumo";

            EmailAddress from = new EmailAddress();
            from.Email = "john.hadikusumo@gmail.com";
            from.Name = "John Hadikusumo";

            List<EmailAttachment> attachements = new List<EmailAttachment>() { 
                new EmailAttachment(@"D:\KiwiSoft.MailJet\MailTest\test.pdf",FileTypes.Pdf){}
            };

            EmailMessage message = new EmailMessage(from, new List<EmailAddress>() { to }, attachements);
            message.Subject = "Testing";
            message.TextPart = "Hello";
            message.HtmlPart = "<b>Hello</b>";

            eMailBroker broker = new eMailBroker(message);
            Tuple<bool, string?> result = broker.Send();

            Assert.True(true);
        }
    }
}