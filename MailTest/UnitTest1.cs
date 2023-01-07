using KiwiSoft.MailJet;
using KiwiSoft.MailJet.Models;

namespace MailTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
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

            eMailBroker broker = new eMailBroker();
            broker.Send(message);

            Assert.True(true);
        }
    }
}