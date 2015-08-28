using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPortfolio.Logic.Data.Interfaces;
using MyPortfolio.Logic.Entities;

namespace MyPortfolio.Logic.Data.Implementation {
	public class EisenhowerContext : IEisenhowerContext {

		private IDataContext m_DataContext;

		public EisenhowerContext ( IDataContext dataContext ) {
			m_DataContext = dataContext;
		}
		public IQueryable<EisenhowerTask> EisenhowerTaskQuery {
			get {
				return m_DataContext.EisenhowerTaskQuery;
			}
		}

		public void AddTask ( EisenhowerTask task ) {
			m_DataContext.AddEisenhowerTask ( task );
		}

		public void DeleteTask ( int taskId ) {
			m_DataContext.DeleteEisenhowerTask ( taskId );
		}


		public void SaveAllChanges () {
			m_DataContext.SaveAllChanges ();
		}
	}
}
