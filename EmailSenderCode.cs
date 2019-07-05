using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using EASendMail;


namespace Aiuto
{
    class Program
    {
        static void Main(string[] args)
        {

            SmtpMail oMail = new SmtpMail("TryIt");
            SmtpClient oSmtp = new SmtpClient();

            // Your email address

            oMail.From = args[0];            
            
            // Set recipient email address
            oMail.To = "test123@gmail.com";

            // Set email subject
            oMail.Subject = "help";

            // Set email body
            oMail.TextBody = "this is a test email sent from c# project.";
            // Hotmail SMTP server address
            SmtpServer oServer = new SmtpServer("smtp.gmail.com");

            int pos = oMail.From.ToString().IndexOf("@");
            string user = oMail.From.ToString().Substring(1, pos-1);
            
            // Hotmail user authentication should use your
            // email address as the user name.
            oServer.User = user;
            oServer.Password = args[1];

            // Set 587 port, if you want to use 25 port, please change 587 to 25
            oServer.Port = 587;

            // detect SSL/TLS connection automatically
            oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

            try
            {
                Console.WriteLine("start to send email over SSL...");
                oSmtp.SendMail(oServer, oMail);
                Console.WriteLine("email was sent successfully!");
            }
            catch (Exception ep)
            {
                Console.WriteLine("failed to send email with the following error:");
                Console.WriteLine(ep.Message);
            }
        }
    }
}
