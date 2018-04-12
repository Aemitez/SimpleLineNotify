using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Mvc;

namespace SimpleLineNotify.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SentMessage(string message,string stkId,string stkPkId)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create("https://notify-api.line.me/api/notify");
                string postData;
                #region Custom data
                if (message != null & stkId == null & stkId == null)
                {
                    postData = string.Format("message={0}", message);
                }
                else
                {
                    postData = string.Format("message={0}&stickerPackageId={1}&stickerId={2}", message, stkPkId, stkId);
                }

                // postPicture
                //var postPicture = string.Format("message={0}&imageThumbnail={1}&imageFullsize={2}", "Text text", url, url);
                #endregion
                var data = Encoding.UTF8.GetBytes(postData);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                #region Token
                //Add Token
                string lineNotifyToken = "?????????????????????";
                #endregion
                request.Headers.Add("Authorization", "Bearer " + lineNotifyToken);

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }


                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                TempData["alert"] = "success";
            }
            catch (Exception ex)
            {
                throw new Exception("Send message is not working." + ex.Message);
            }
           

            return RedirectToAction("Index");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
