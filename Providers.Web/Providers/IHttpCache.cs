using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providers.Web.Providers {

	/// <summary>
	/// Http cache.
	/// </summary>
	public interface IHttpCache {

		/// <summary>
		/// Get value.
		/// </summary>
		/// <param name="name">Name value.</param>
		/// <returns>Value.</returns>
		string GetValue ( string name );

		/// <summary>
		/// Set value.
		/// </summary>
		/// <param name="name">Name value.</param>
		/// <param name="value">Value.</param>
		void SetValue ( string name , string value );

	}

}
