using System;
namespace Providers.Web.Providers {

	/// <summary>
	/// Http request.
	/// </summary>
	public interface IHttpRequest {

		/// <summary>
		/// Content type.
		/// </summary>
		string ContentType {
			get;
		}

		/// <summary>
		/// Is ajax request.
		/// </summary>
		bool IsAjaxRequest {
			get;
		}

		/// <summary>
		/// Ajax required.
		/// </summary>
		void AjaxRequired ();

		/// <summary>
		/// Url.
		/// </summary>
		Uri Url {
			get;
		}

		/// <summary>
		/// User host address.
		/// </summary>
		string UserHostAddress {
			get;
		}

	}

}
