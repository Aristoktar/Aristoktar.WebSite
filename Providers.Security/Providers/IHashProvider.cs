using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providers.Security.Providers {
	public interface IHashProvider {
		string ComputeHash ( string source );
		string GetByteHashConvertToString ( byte[] hash );
	}
}
