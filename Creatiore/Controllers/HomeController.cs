using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web.Mvc;

namespace Creatiore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
            var mailBody = new StringBuilder();
            mailBody.AppendFormat("Name : {0} </br>", formCollection["inputName"]);
            mailBody.AppendFormat("Email : {0} </br>", formCollection["inputName"]);
            mailBody.AppendFormat("Message : {0} </br>", formCollection["message"]);
            var mailMessage = new MailMessage();
            mailMessage.Body = mailBody.ToString();
            mailMessage.Subject = formCollection["inputSubject"];
            mailMessage.From = new MailAddress("info@creatiore.com");
            mailMessage.To.Add(new MailAddress("info@creatiore.com"));
            mailMessage.IsBodyHtml = true;
            var smtp = new SmtpClient()
            {
                Host = "mail.creatiore.com",
                Port = 587,
                Credentials = new NetworkCredential(mailMessage.From.Address, "gy333123"),
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
            smtp.Send(mailMessage);

            ViewBag.Message = "Thank you for contacting us. We will return you quickly.";

            return View();
        }
    }
}
