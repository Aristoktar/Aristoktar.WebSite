using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Providers.Security.Providers;

namespace Providers.Security.Implementation {
	public class DefaultRandomizeProvider : IRandomizeProvider {
		/// <summary>
		/// Get random string.
		/// </summary>
		/// <returns>Random string.</returns>
		public string GetRandomString () {
			return StringHelper.GetRandomString ();
		}
	}
}