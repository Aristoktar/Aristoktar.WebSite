using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Providers.Security.Providers;
using Providers.Web.Providers;
using MyPortfolio.Logic.Data.Interfaces;
using MyPortfolio.Logic.Enums;
using MyPortfolio.Logic.Entities;
using MyPortfolio.Logic.Exceptions;


namespace Providers.Security.Implementation {
	public class SiteAuthorization : ISiteAuthorization {

		public const string CookieValueName = "UserCookie";
		public const string CookieVKValueName = "UserCookieVK";

		private IUserProvider m_UserProvider;
		private IHashProvider m_HashProvider;
		private IRandomizeProvider m_RandomizeProvider;
		private IHttpContext m_HttpContext;
		public SiteAuthorization ( IUserProvider userProvider,
									IHashProvider hashProvider ,
									IRandomizeProvider RandomizeProvider,
									IHttpContext httpConext) {
			m_HashProvider = hashProvider;
			m_UserProvider = userProvider;
			m_RandomizeProvider = RandomizeProvider;
			m_HttpContext = httpConext;
			
		}
		public string AuthorizeUser ( string login , string password ) {
			var passwordHash = m_HashProvider.ComputeHash ( password );
			var user = m_UserProvider.UserQuery
				.Where (
					a =>
						a.Email == login &&
						( a.Password == passwordHash ) &&
						( a.Role == UserRole.siteUser )

				)
				.FirstOrDefault ();

			user.UniqueString = m_RandomizeProvider.GetRandomString ();
			m_UserProvider.SaveAllChanges ();

			m_HttpContext.Cookie.SetValue ( CookieValueName , user.UniqueString );
			return user.UniqueString;
		}
		public string AuthorizeUserAfterVerification ( string login , string password ) {
			//var user = m_UserProvider.UserQuery
			//	.Where (
			//		a =>
			//			a.Email == login &&
			//			( a.Password == password ) &&
			//			a.Verified == true &&
			//			( a.Role == UserRoleType.SiteUser ||
			//			a.Role == UserRoleType.Teacher )

			//	)
			//	.FirstOrDefault ();
			//if ( user == null ) throw new AlefApplicationException ( ErrorType.AuthenticationError );

			//user.UniqueString = m_RandomizeProvider.GetRandomString ();
			//m_UserProvider.SaveAllChanges ();

			//m_HttpContext.Cookie.SetValue ( CookieValueName , user.UniqueString );
			//return user.UniqueString;
			return "";
		}

		public string AuthorizeAdmin ( string login , string password ) {
			//var passwordHash = m_HashProvider.ComputeHash ( password );
			//var user = m_UserProvider.UserQuery
			//	.Where (
			//		a =>
			//			a.Email == login &&
			//			( a.Password == passwordHash ) &&
			//			a.Verified == true &&
			//			(a.Role == UserRoleType.Administrator)
			//	)
			//	.FirstOrDefault ();
			//if ( user == null ) throw new AlefApplicationException ( ErrorType.AuthenticationAdminError );

			//user.UniqueString = m_RandomizeProvider.GetRandomString ();
			//m_UserProvider.SaveAllChanges ();

			//m_HttpContext.Cookie.SetValue ( CookieValueName , user.UniqueString );
			//return user.UniqueString;
			return "";
		}

		/// <summary>
		/// Logout user.
		/// </summary>
		/// <param name="session">Cookie.</param>
		public void LogOutUser () {
			m_HttpContext.Cookie.RemoveValue ( CookieValueName );
			
		}

		/// <summary>
		/// Get user cookie.
		/// </summary>
		/// <returns>Unique string.</returns>
		public string GetUserCookie () {
			var value = m_HttpContext.Cookie.GetValue ( CookieValueName );
			return value;
		}

		/// <summary>
		/// Get user cookie VK.
		/// </summary>
		/// <returns>Unique string.</returns>
		public string GetUserCookieVK () {
			var value = m_HttpContext.Cookie.GetValue ( CookieVKValueName );
			return value;
		}

		/// <summary>
		/// Get authorized site user.
		/// </summary>
		/// <returns>Site user.</returns>
		public User GetAuthorizedSiteUser () {
			var cookie = GetUserCookie ();
			if ( cookie == null ) return null;
			User user = m_UserProvider.UserQuery
				.FirstOrDefault ( a => a.UniqueString == cookie
					&& (a.Role == UserRole.siteUser || a.Role == UserRole.Admin));
			return user;
		}


		public User GetAuthorizedAdmin () {
			var cookie = GetUserCookie ();
			if ( cookie == null ) throw new MyPortfolioException ();
			User user = m_UserProvider.UserQuery.FirstOrDefault ( a => a.UniqueString == cookie && a.Role == UserRole.Admin);
			if ( user != null ) return user;
			else throw new MyPortfolioException ( );
		}
		public User GetAuthorizedAdminHeader () {
			var cookie = GetUserCookie ();
			if ( cookie == null ) throw new MyPortfolioException ();
			User user = m_UserProvider.UserQuery.FirstOrDefault ( a => a.UniqueString == cookie && a.Role == UserRole.Admin);
			return user;
		}


		public string AuthorizeUserVK ( string UserId , string TokenVK ) {

			if ( string.IsNullOrWhiteSpace ( TokenVK ) ) return "";
			var user = m_UserProvider.UserQuery
				.Where (a =>a.VKUserId == UserId)
				.FirstOrDefault ();
			user.UniqueString = m_RandomizeProvider.GetRandomString ();
			
			m_UserProvider.SaveAllChanges ();

			m_HttpContext.Cookie.SetValue ( CookieValueName , user.UniqueString );
			return user.UniqueString;
			
				
			
		}

		public string GetByteHashConvertToString ( byte[] hash ) {
			string hashString = string.Empty;
			foreach ( byte x in hash ) {
				hashString += String.Format ( "{0:x2}" , x );
			}
			return hashString;
		}


		
	}
}
