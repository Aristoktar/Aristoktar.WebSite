using System;
using System.Linq;
using Providers.Web.Providers;
using HttpContextMvc = System.Web.HttpContext;
using HttpCookieMvc = System.Web.HttpCookie;


namespace Providers.Web.Implementation {

	/// <summary>
	/// Http session.
	/// </summary>
	public class HttpCookie : IHttpCookie {

		private HttpContextMvc m_HttpContext = HttpContextMvc.Current;

		/// <summary>
		/// Get value.
		/// </summary>
		/// <param name="name">Name value.</param>
		/// <returns>Value.</returns>
		public string GetValue ( string name ) {
			var cookie = m_HttpContext.Request.Cookies.Get ( name );
			if ( cookie == null ) return null;
			var value = m_HttpContext.Request.Cookies[name].Value;
			if ( value == null ) return null;

			return value.ToString ();
		}

		/// <summary>
		/// Set value.
		/// </summary>
		/// <param name="name">Name value.</param>
		/// <param name="value">Value.</param>
		public void SetValue ( string name , string value ) {
			HttpCookieMvc setCookie = new HttpCookieMvc ( name , value );
			setCookie.Expires = DateTime.Now.AddDays ( 7 );
			setCookie.HttpOnly = true;
			m_HttpContext.Response.Cookies.Add ( setCookie );
		}

		/// <summary>
		/// Remove value.
		/// </summary>
		/// <param name="name"></param>
		public void RemoveValue ( string name ) {
			HttpCookieMvc myCookie = new HttpCookieMvc ( name );
			myCookie.Expires = DateTime.Now.AddDays ( -1d );
			m_HttpContext.Response.Cookies.Add ( myCookie );


			//m_HttpContext.Response.Cookies.Remove ( name );
			
		}

	}

}
