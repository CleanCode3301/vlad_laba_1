using System.Collections.Generic;

namespace Hospital.Models
{
	internal class CollectionPatiens
	{
		public List<Patient> PatientsList { get; set; }

		public CollectionPatiens()
		{
			PatientsList = new List<Patient>();
		}
	}
}
