using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Line_notify1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var request = (HttpWebRequest)WebRequest.Create("https://notify-api.line.me/api/notify");
            var postData = string.Format("message={0}&stickerPackageId={1}&stickerId={2}", "Text text", "4", "624");
            string url = "https://scontent.fbkk1-1.fna.fbcdn.net/v/t1.0-9/26111938_2049569015313552_4269829488480010286_n.jpg?_nc_fx=fbkk1-1&oh=005d2598946f2205b60c56027ad4d686&oe=5AB3ACF5";
            var postPicture = string.Format("message={0}&imageThumbnail={1}&imageFullsize={2}", "Text text", url, url);
            var data = Encoding.UTF8.GetBytes(postPicture);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            //string aem = "0WImx6DWZeJBetgLyNNID09dEDNOtarrNVzOzTVAbSI";
            string test = "lKKM4maKGZkMg0de7McFaadYmZHAr9l9tQ5kbqIXuW0";
            request.Headers.Add("Authorization", "Bearer " + test);

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }


            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();


            return View();
        }

    
    }
}