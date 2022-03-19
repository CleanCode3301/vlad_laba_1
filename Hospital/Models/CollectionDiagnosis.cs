using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Models
{
	internal class CollectionDiagnosis
	{
		public List<Diagnosis> diagnosisList { get; set; }

		public CollectionDiagnosis()
		{
			diagnosisList = new List<Diagnosis>();
		}
	}
}
