using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using v2.Models;

namespace v2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Welcome to our website";
            return View();         
        }

        public IActionResult About()
        {
            ViewData["Title"] = "About us";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Title"] = "Our contact details";
            return View();
        }

        public IActionResult Products()
        {
            ViewData["Title"] = "Our products page";
            return View();
        }

        public IActionResult Resources()
        {
            ViewData["Title"] = "Free resources for you";
            return View();
        }

        public IActionResult Sitemap()
        {
            ViewData["Title"] = "Sitemap";
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SendEmail(v2.Models.EmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                var message = new MimeMessage();                                
                message.Date = DateTime.Now;
                message.Subject = "From the website";
                message.From.Add(new MailboxAddress(model.Name, model.Email));
                message.To.Add(new MailboxAddress("Paul", "info@pburger.com"));
                message.Body = new TextPart(TextFormat.Html){Text = model.Message};

                using (var client = new SmtpClient())
                {
                    try
                    {
                        client.LocalDomain = "www.pburger.com";
                        client.Connect("mail.pburger.com", 25, SecureSocketOptions.None);
                        client.Authenticate("info@pburger.com", "Shotgun_56");
                        client.Send(message);
                        client.Disconnect(true);
                    }
                    catch (Exception ex) { string m = ex.Message; }
                }
            }

            return RedirectToAction("Contact", new { message = "Message Sent" });
        }
    }
}
