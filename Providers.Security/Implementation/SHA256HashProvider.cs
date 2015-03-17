using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Providers.Security.Providers;

namespace Providers.Security.Implementation {
	public class SHA256HashProvider : IHashProvider {

		/// <summary>
		/// Вычислить хэш сумму.
		/// </summary>
		/// <param name="source">Источник.</param>
		/// <returns>Хэш сумма.</returns>
		public string ComputeHash ( string source ) {
			var hashComputed = SHA256Managed.Create ();
			var hash = hashComputed.ComputeHash ( Encoding.UTF8.GetBytes ( source ) );
			return GetByteHashConvertToString ( hash );
		}

		/// <summary>
		/// Сконвертить массив байт хэша в строку.
		/// </summary>
		/// <param name="hash">Хэш сумма.</param>
		/// <returns>хэш сумма в виде строки.</returns>
		public string GetByteHashConvertToString ( byte[] hash ) {
			string hashString = string.Empty;
			foreach ( byte x in hash ) {
				hashString += String.Format ( "{0:x2}" , x );
			}
			return hashString;
		}
	}
}
