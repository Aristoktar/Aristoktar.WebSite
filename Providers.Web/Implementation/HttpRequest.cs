using System.Web.Mvc;
using HttpContextMvc = System.Web.HttpContext;
using System.Web;
using Providers.Web.Providers;


namespace Providers.Web.Implementation {

	/// <summary>
	/// Http request.
	/// </summary>
	public class HttpRequest : IHttpRequest {

		private HttpContextMvc m_HttpContext = HttpContextMvc.Current;

		/// <summary>
		/// Content type.
		/// </summary>
		public string ContentType {
			get {
				return m_HttpContext.Request.ContentType;
			}
		}

		/// <summary>
		/// Is Ajax request.
		/// </summary>
		public bool IsAjaxRequest {
			get {
				return new HttpRequestWrapper ( m_HttpContext.Request ).IsAjaxRequest ();
			}
		}

		/// <summary>
		/// Ajax required.
		/// </summary>
		public void AjaxRequired () {
			//if ( !IsAjaxRequest ) throw new CouriersApplicationException ( "Only ajax supported error." );
		}

		/// <summary>
		/// Url.
		/// </summary>
		public System.Uri Url {
			get {
				return m_HttpContext.Request.Url;
			}
		}

		/// <summary>
		/// User host address.
		/// </summary>
		public string UserHostAddress {
			get {
				return m_HttpContext.Request.UserHostAddress;
			}
		}

	}

}
