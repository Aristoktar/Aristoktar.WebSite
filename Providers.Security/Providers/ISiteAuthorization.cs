using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPortfolio.Logic.Entities;


namespace Providers.Security.Providers {
	public interface ISiteAuthorization {
		string AuthorizeUser ( string login , string password );
		/// <summary>
		/// Authorize Vk use.
		/// </summary>
		/// <param name="expire"></param>
		/// <param name="mid">VKUserId</param>
		/// <param name="secret"></param>
		/// <param name="sid"></param>
		/// <param name="sig">hash</param>
		/// <returns></returns>
		string AuthorizeUserVK (string UserId, string TokenVK);
		string GetByteHashConvertToString ( byte[] hash );
		string AuthorizeUserAfterVerification ( string login , string password );
		string AuthorizeAdmin ( string login , string password );
		void LogOutUser ();
		string GetUserCookie ();
		User GetAuthorizedSiteUser ();
		User GetAuthorizedAdmin ();

	}
}
