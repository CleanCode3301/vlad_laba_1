using System;

namespace Hospital
{
	internal class Patient : IObserver
	{
		private string _lastName;
		private string _age;
		private DateTime _dateOfReceipt;
		private Diagnosis _diagnosis;
		private string _hospitalDepartment;

		public DateTime ArrivalTime => Convert.ToDateTime(_dateOfReceipt - _diagnosis._treatmentTime);

		public override string ToString() => $"{_lastName};{_age};{_dateOfReceipt};{_hospitalDepartment}";

		public void Observer()
		{

		}

		public void Update(ISubject subject)
		{
			throw new NotImplementedException();
		}
	}
}
