using AvaJobs.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace AvaJobs.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string code, string state)
        {
            if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(state))
            {
                return View();
            }
            else
            {
                try
                {
                    //Get Accedd Token
                    var client = new RestClient("https://www.linkedin.com/oauth/v2/accessToken");
                    var request = new RestRequest(Method.POST);
                    request.AddParameter("grant_type", "authorization_code");
                    request.AddParameter("code", code);
                    request.AddParameter("redirect_uri", "http://avajobs.azurewebsites.net/");
                    request.AddParameter("client_id", "77mx9721mlv2q9");
                    request.AddParameter("client_secret", "IxkBrczENK46dRB1");
                    IRestResponse response = client.Execute(request);
                    var content = response.Content;

                    //Fetch AccessToken
                    JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                    LinkedINVM linkedINVM = jsonSerializer.Deserialize<LinkedINVM>(content);
                    if(linkedINVM != null)
                    {
                        //Get Profile Details
                        client = new RestClient("https://api.linkedin.com/v1/people/~?oauth2_access_token=" + linkedINVM.access_token + "&format=json");
                        request = new RestRequest(Method.GET);
                        response = client.Execute(request);
                        content = response.Content;

                        jsonSerializer = new JavaScriptSerializer();
                        LinkedINResVM linkedINResVM = jsonSerializer.Deserialize<LinkedINResVM>(content);
                    return View(linkedINResVM);
                    }
                    else
                    {
                        return View();
                    }



                }
                catch
                {
                    throw;
                }
            }

        }
       
    }
}