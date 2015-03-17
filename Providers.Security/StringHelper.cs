using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Providers.Security {
	public class StringHelper {
			/// <summary>
			/// Get random string.
			/// </summary>
			/// <returns>Random String.</returns>
			public static string GetRandomString () {
				Guid g = Guid.NewGuid ();
				return
					Convert.ToBase64String ( g.ToByteArray () )
						.Replace ( "=" , "" )
						.Replace ( "+" , "" )
						.Replace ("/","");
			}

	}
}