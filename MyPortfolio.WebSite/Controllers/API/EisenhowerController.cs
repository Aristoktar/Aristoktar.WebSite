using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyPortfolio.Logic.Data.Interfaces;
using MyPortfolio.Logic.Entities;
using Providers.Security.Providers;

namespace MyPortfolio.WebSite.Controllers.API
{
    public class EisenhowerController : ApiController
    {
		private IEisenhowerContext m_EisenhowerContex;
		private ISiteAuthorization m_SiteAuthorisation;
		private IUserProvider m_UserProvider;

		public EisenhowerController ( IEisenhowerContext eisenhowerContext , ISiteAuthorization siteAuth , IUserProvider userProvider ) {
			m_EisenhowerContex = eisenhowerContext;
			m_SiteAuthorisation = siteAuth;
			m_UserProvider = userProvider;
		}
		
		

		public List<EisenhowerTask> GetTasks () {
			var user = m_SiteAuthorisation.GetAuthorizedSiteUser ();
			return m_EisenhowerContex.EisenhowerTaskQuery.ToList ();
		}
		[HttpPost]
		public EisenhowerTask AddTask (EisenhowerTask task) {
			task.Created = DateTime.Now;
			m_EisenhowerContex.AddTask ( task );
			m_EisenhowerContex.SaveAllChanges ();
			return task;
		}

		[HttpGet]
		public int DelTask ( int Id ) {
			m_EisenhowerContex.DeleteTask (Id);
			m_EisenhowerContex.SaveAllChanges ();
			return Id;
		}
    }
}
