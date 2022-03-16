using System;
using System.Collections.Generic;

namespace Hospital
{
	internal class Diagnosis : ISubject
	{
		private string _title;
		public DateTime _treatmentTime;
		private string _hospitalDepartment;

		private List<IObserver> _observers = new List<IObserver>();

		public void Attach(IObserver observer)
		{
			_observers.Add(observer);
		}

		public void Detach(IObserver observer)
		{
			_observers.Remove(observer);
		}

		public void Notify()
		{
			foreach (var observer in _observers)
			{
				observer.Update(this);
			}
		}
	}
}
