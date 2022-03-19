using System;
using System.Collections.Generic;

namespace Hospital
{
	internal class Diagnosis : ISubject
	{
		private TimeSpan _treatmentTime;
		private string _hospitaldepartment;
		private List<IObserver> _observers = new List<IObserver>();

		public string HospitalDepartment
		{
			get => _hospitaldepartment;
			set
			{
				_hospitaldepartment = value;
				Notify();
			}
		}
		public string Title { get; set; }
		public TimeSpan TreatmentTime
		{
			get => _treatmentTime;
			set
			{
				_treatmentTime = value;
				Handler?.Invoke(this, _treatmentTime);
			}
		}
		public event EventHandler<TimeSpan> Handler;
		public Diagnosis(string title, TimeSpan treatmentTime, string hospitalDepartment)
		{
			Title = title;
			TreatmentTime = treatmentTime;
			HospitalDepartment = hospitalDepartment;
		}

		public override string ToString() => $"{Title};{TreatmentTime};{HospitalDepartment}";

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
