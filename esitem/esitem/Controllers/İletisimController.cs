using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using esitem.Models;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Configuration;



namespace esitem.Controllers
{
    public class İletisimController : Controller
    {
        // GET: İletisim
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Email model, HttpPostedFileBase resim)

        {
            MailMessage mm = new MailMessage();
            mm.SubjectEncoding = Encoding.Default;
            mm.Subject = "İleşim Formundan Mesajınız Var";
            mm.BodyEncoding = Encoding.Default;
            mm.Body = "Sayın  ," + model.Ad + model.Soyad + " Kişisinden gelen mesajın içeriği aşağıdaki gibidir. <br> " + model.Mesaj;
            mm.IsBodyHtml = true;
            mm.From = new MailAddress(ConfigurationManager.AppSettings["emailAccount"]);
            mm.To.Add("hkmusicmarket@gmail.com");

            if (resim != null)
            {
                mm.Attachments.Add(new Attachment(resim.InputStream, resim.FileName));
            }

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = ConfigurationManager.AppSettings["emailHost"];
            smtpClient.Port = int.Parse(ConfigurationManager.AppSettings["emailPort"]);
            smtpClient.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["emailAccount"], ConfigurationManager.AppSettings["emailPassword"]);
            smtpClient.EnableSsl = bool.Parse(ConfigurationManager.AppSettings["emailSLLEnable"]);
            smtpClient.Send(mm);





            TempData["Basarili"] = "Bildiriminiz için teşekkürler en kısa zamanda tarafaniza dönüş yapılacaktir iyi günler dileriz.";




            return RedirectToAction("Index");
        }
    }
}