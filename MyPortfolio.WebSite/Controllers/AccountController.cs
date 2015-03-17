using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPortfolio.WebSite.Models.Account;
using Providers.Security.Providers;
using MyPortfolio.Logic.Data.Interfaces;
using MyPortfolio.Logic.Entities;

namespace MyPortfolio.WebSite.Controllers
{
    public class AccountController : Controller
    {
		private ISiteAuthorization m_SiteAuthorisation;
		private IUserProvider m_UserProvider;

		public AccountController (ISiteAuthorization siteAuth, IUserProvider userProvider) {
			m_SiteAuthorisation = siteAuth;
			m_UserProvider = userProvider;
		}
        // GET: Profile
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult LogIn () {
			return View ();
		}

		[HttpPost]
		public ActionResult LogIn (LogInModel model) {
			model.StatusPost = true;
			m_SiteAuthorisation.AuthorizeUser(model.Email,model.Password);
			return View ( model );
		}

		[HttpPost]
		public ActionResult LogInVK ( LogInVKModel model ) {
			if ( m_UserProvider.UserQuery.FirstOrDefault ( a => a.VKUserId == model.UserId ) == null ) {
				m_UserProvider.AddUser ( new User {
					Name = model.UserId ,
					Password = "" ,
					Role = Logic.Enums.UserRole.siteUser ,
					VKUserId = model.UserId ,
					Email = model.Email
				} );
			}
			m_UserProvider.SaveAllChanges ();
			m_SiteAuthorisation.AuthorizeUserVK (model.UserId,model.Token);
			return View (model);
		}
		[HttpGet]
		public ActionResult LogInVK (string id ) {
			if ( !string.IsNullOrWhiteSpace ( id ) ) {

				string url = "https://oauth.vk.com/access_token?client_id=" + Providers.Security.Properties.Resources.VKAppId;
				url += "&client_secret=" + Providers.Security.Properties.Resources.VKSecureKey;
				url += "&redirect_uri=" + HttpContext.Request.Url.Host + ":" + HttpContext.Request.Url.Port + HttpContext.Request.Url.AbsolutePath;
				return View ();
				//url += "&code=" + code;
				return Redirect ( url );
			}
			else {
				string url = "https://oauth.vk.com/authorize?client_id=" + Providers.Security.Properties.Resources.VKAppId;
				url += "&scope=" + "4194304";
				url += "&redirect_uri=" + HttpContext.Request.Url.Host + ":" + HttpContext.Request.Url.Port + HttpContext.Request.Url.AbsolutePath+"/true";
				url += "&response_type=token";
				url += "&v=4.0";
				return Redirect ( url );
			}
		}
		

		private string GetByteHashConvertToString ( byte[] hash ) {
			string hashString = string.Empty;
			foreach ( byte x in hash ) {
				hashString += String.Format ( "{0:x2}" , x );
			}
			return hashString;
		}

		[HttpGet]
		public JsonResult LogOut(){
			m_SiteAuthorisation.LogOutUser ();
			return Json(true, JsonRequestBehavior.AllowGet);
		}
		[ChildActionOnly]
		public ActionResult LogInHeader () {
			var user = m_SiteAuthorisation.GetAuthorizedSiteUser ();
			if ( user != null ) return PartialView ( new UserModel {
				Id = user.Id ,
				Name = user.Name ,
				Role = user.Role
			} );
			return PartialView ();
		}

		[HttpGet]
		public ActionResult Registration () {
			return View ();
		}
    }
}