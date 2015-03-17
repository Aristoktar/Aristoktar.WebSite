using System;
using Providers.Web.Providers;


namespace Providers.Web.Implementation {

	/// <summary>
	/// Http context.
	/// </summary>
	public class HttpContext : IHttpContext {

		private IHttpRequest m_Request;

		private IHttpCache m_Cache;

		private IHttpCookie m_Session;

		/// <summary>
		/// Constructor injection.
		/// </summary>
		public HttpContext ( IHttpRequest request , IHttpCache cache , IHttpCookie session ) {
			m_Request = request;
			m_Cache = cache;
			m_Session = session;
		}

		/// <summary>
		/// Request.
		/// </summary>
		public IHttpRequest Request {
			get {
				return m_Request;
			}
		}

		/// <summary>
		/// Cache.
		/// </summary>
		public IHttpCache Cache {
			get {
				return m_Cache;
			}
		}

		/// <summary>
		/// Session.
		/// </summary>
		public IHttpCookie Cookie {
			get {
				return m_Session;
			}
		}

	}
}
