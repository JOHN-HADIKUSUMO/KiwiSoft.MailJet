# KiwiSoft.MailJet
#### This nuget package is meant to be used as an alternative class library to send an email via MailJet rest api. Please visit https://www.mailjet.com to register and get the credentials.

#### Once you have a MailJet subscription, you will given the API KEY and SECRET KEY. Those two information must be provided inside **appsettings.json**.

##### appsettings.json
```JSON
{
  "KiwiSoft.MailJet": {
    "API_KEY": "82acf8666b21d53940ebca50483e471d",
    "SECRET_KEY": "83a0047210a026c5a1160cf969cca"
  }
}
```
# Example 1.
#### Sending an email to one recepient with no file attachment.

```C#
    EmailAddress to = new EmailAddress();
    to.Email = "james.wan@conjuring.com";
    to.Name = "James Wan";

    EmailAddress from = new EmailAddress();
    from.Email = "taylor.caraberon@gmail.com";
    from.Name = "Taylor Caraberon";

    EmailMessage message = new EmailMessage(from,new List<EmailAddress>() { to });
    message.Subject = "Your Subscription";
    message.TextPart = "Dear James, i really enjoy your recent movie. You were doing good job!";
    message.HtmlPart = "<p>Dear James,<br/><br/> i really enjoy your recent movie. You were doing good job!"</p>;

    eMailBroker broker = new eMailBroker(message);
    Tuple<bool,string?> result = broker.Send();
```

# Example 2.
#### Sending an email to one recepient with file attachment. 

```C#
    EmailAddress to = new EmailAddress();
    to.Email = "james.wan@conjuring.com";
    to.Name = "James Wan";

    EmailAddress from = new EmailAddress();
    from.Email = "taylor.caraberon@gmail.com";
    from.Name = "Taylor Caraberon";

    List<EmailAttachment> attachements = new List<EmailAttachment>() { 
    new EmailAttachment(@"D:\KiwiSoft.MailJet\MailTest\test.pdf",FileTypes.Pdf){}
    };

    EmailMessage message = new EmailMessage(from,new List<EmailAddress>() { to }, attachements);
    message.Subject = "Your Subscription";
    message.TextPart = "Dear James, i really enjoy your recent movie. You were doing good job!";
    message.HtmlPart = "<p>Dear James,<br/><br/> i really enjoy your recent movie. You were doing good job!"</p>;

    eMailBroker broker = new eMailBroker(message);
    Tuple<bool,string?> result = broker.Send();
```
# Example 3.
#### Sending an email to one recepient with carbon copy but no file attachment.

```C#
    EmailAddress to = new EmailAddress();
    to.Email = "james.wan@conjuring.com";
    to.Name = "James Wan";

    EmailAddress cc = new EmailAddress();
    cc.Email = "jenna.ortega@adamsfamily.com";
    cc.Name = "Jenna Ortega";
    
    EmailAddress from = new EmailAddress();
    from.Email = "taylor.caraberon@gmail.com";
    from.Name = "Taylor Caraberon";

    EmailMessage message = new EmailMessage(from,new List<EmailAddress>() { to },new List<EmailAddress>() { cc });
    message.Subject = "Your Subscription";
    message.TextPart = "Dear James, i really enjoy your recent movie. You were doing good job!";
    message.HtmlPart = "<p>Dear James,<br/><br/> i really enjoy your recent movie. You were doing good job!"</p>;

    eMailBroker broker = new eMailBroker(message);
    Tuple<bool,string?> result = broker.Send();
```
# Example 4.
#### Sending an email to one recepient with carbon copy and file attachment. 

```C#
    EmailAddress to = new EmailAddress();
    to.Email = "james.wan@conjuring.com";
    to.Name = "James Wan";

    EmailAddress cc = new EmailAddress();
    cc.Email = "jenna.ortega@adamsfamily.com";
    cc.Name = "Jenna Ortega";
    
    EmailAddress from = new EmailAddress();
    from.Email = "taylor.caraberon@gmail.com";
    from.Name = "Taylor Caraberon";

    List<EmailAttachment> attachements = new List<EmailAttachment>() { 
    new EmailAttachment(@"D:\KiwiSoft.MailJet\MailTest\test.pdf",FileTypes.Pdf){}
    };

    EmailMessage message = new EmailMessage(from,new List<EmailAddress>() { to },new List<EmailAddress>() { cc }, attachements);
    message.Subject = "Your Subscription";
    message.TextPart = "Dear James, i really enjoy your recent movie. You were doing good job!";
    message.HtmlPart = "<p>Dear James,<br/><br/> i really enjoy your recent movie. You were doing good job!"</p>;

    eMailBroker broker = new eMailBroker(message);
    Tuple<bool,string?> result = broker.Send();
```
# Example 5.
#### Sending an email to multiple recepients with no file attachment.

```C#
    List<EmailAddress> tos = new List<EmailAddress>(){
        new EmailAddress(){
            Email = "james.wan@conjuring.com",
            Name = "James Wan"
        },
        new EmailAddress(){
            Email = "mell.gibson@apocalypso.com",
            Name = "Mell Gibson"
        }
    }
    EmailAddress from = new EmailAddress();
    from.Email = "taylor.caraberon@gmail.com";
    from.Name = "Taylor Caraberon";

    EmailMessage message = new EmailMessage(from,tos);
    message.Subject = "Your Subscription";
    message.TextPart = "Dear Movie Directors, i really enjoy you guys recent movies. You all were doing good job!";
    message.HtmlPart = "<p>Dear Movie Directors,<br/><br/> i really enjoy you guys recent movies. You all were doing good job!"</p>;

    eMailBroker broker = new eMailBroker(message);
    Tuple<bool,string?> result = broker.Send();
```
# Example 6.
#### Sending an email to multiple recepients with file attachment.

```C#
    List<EmailAddress> tos = new List<EmailAddress>(){
        new EmailAddress(){
            Email = "james.wan@conjuring.com",
            Name = "James Wan"
        },
        new EmailAddress(){
            Email = "mell.gibson@apocalypso.com",
            Name = "Mell Gibson"
        }
    }
    EmailAddress from = new EmailAddress();
    from.Email = "taylor.caraberon@gmail.com";
    from.Name = "Taylor Caraberon";

    List<EmailAttachment> attachements = new List<EmailAttachment>() { 
    new EmailAttachment(@"D:\KiwiSoft.MailJet\MailTest\test.pdf",FileTypes.Pdf){}
    };
    
    EmailMessage message = new EmailMessage(from,tos,attachements);
    message.Subject = "Your Subscription";
    message.TextPart = "Dear Movie Directors, i really enjoy you guys recent movies. You all were doing good job!";
    message.HtmlPart = "<p>Dear Movie Directors,<br/><br/> i really enjoy you guys recent movies. You all were doing good job!"</p>;

    eMailBroker broker = new eMailBroker(message);
    Tuple<bool,string?> result = broker.Send();
```
