using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebApplication4.Controllers
{
    public class SpeakersController : Controller
    {
        SpeakerRepository service;
        public SpeakersController()
        {
            service = new SpeakerRepository();
        }

        // GET: Speakers
        public ActionResult Index()
        {
            return View(service.FindAll());
        }

        public ActionResult Details(string SpeakerId)
        {
            Speaker speaker = service.FindSpeaker(SpeakerId);
            return Json(speaker, JsonRequestBehavior.AllowGet);
        }
    }

    public class Speaker
    {
        public string SpeakerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        string FullName_;
        public string FullName
        {
            get
            {
                return FullName_;
            }
            set
            {
                FullName_ += " " + FirstName;
                FullName_ += " " + LastName;
            }
        }

        public string PicUrl { get; set; }

        public string MyProperty { get; set; }
    }

    public class SpeakerRepository
    {
        public SpeakerRepository()
        {
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString("https://randomuser.me/api/?result=10");
                resultsRandom data = Newtonsoft.Json.JsonConvert.DeserializeObject<resultsRandom>(json);

                foreach (results item in data.results)
                {
                    Speaker sp = new Speaker();
                    sp.FirstName = item.name.first;
                    sp.LastName = item.name.last;
                    sp.PicUrl = item.picture.medium;
                    sp.SpeakerId = item.login.uuid;

                    Speakers.Add(sp);
                }
            }

        }

        static List<Speaker> Speakers = new List<Speaker>();

        public Speaker FindSpeaker(string SpeakerId)
        {
            return Speakers.FirstOrDefault(f => f.SpeakerId == SpeakerId);
        }

        public List<Speaker> FindAll()
        {
            return Speakers;
        }
    }

    public class resultsRandom
    {
        public List<results> results = new List<Controllers.results>();
    }

    public class results
    {
        public name name { get; set; }
        public picture picture { get; set; }
        public login login { get; set; }
    }

    public class name
    {
        public string first { get; set; }
        public string last { get; set; }
    }
    public class picture
    {
        public string medium { get; set; }
    }
    public class login
    {
        public string uuid { get; set; }
    }
}