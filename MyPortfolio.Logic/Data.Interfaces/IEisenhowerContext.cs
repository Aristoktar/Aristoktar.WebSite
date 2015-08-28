using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPortfolio.Logic.Entities;

namespace MyPortfolio.Logic.Data.Interfaces {
	public interface IEisenhowerContext {
		IQueryable<EisenhowerTask> EisenhowerTaskQuery {
			get;
		}

		void AddTask ( EisenhowerTask task );
		void DeleteTask ( int TaskId );

		void SaveAllChanges ();
	}
}
