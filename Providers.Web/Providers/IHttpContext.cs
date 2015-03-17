using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providers.Web.Providers {

	/// <summary>
	/// Http context.
	/// </summary>
	public interface IHttpContext {

		/// <summary>
		/// Request.
		/// </summary>
		IHttpRequest Request {
			get;
		}

		/// <summary>
		/// Cache.
		/// </summary>
		IHttpCache Cache {
			get;
		}

		/// <summary>
		/// Session.
		/// </summary>
		IHttpCookie Cookie {
			get;
		}

	}

}
