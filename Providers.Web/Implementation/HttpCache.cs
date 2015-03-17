using Providers.Web.Providers;
using HttpContextMvc = System.Web.HttpContext;


namespace Providers.Web.Implementation {

	/// <summary>
	/// Http cache.
	/// </summary>
	public class HttpCache : IHttpCache {

		private HttpContextMvc m_HttpContext = HttpContextMvc.Current;

		/// <summary>
		/// Get value.
		/// </summary>
		/// <param name="name">Name value.</param>
		/// <returns>Value.</returns>
		public string GetValue ( string name ) {
			return m_HttpContext.Cache[name].ToString ();
		}

		/// <summary>
		/// Set value.
		/// </summary>
		/// <param name="name">Name value.</param>
		/// <param name="value">Value.</param>
		public void SetValue ( string name , string value ) {
			m_HttpContext.Cache[name] = value;
		}

	}

}
