using Hospital.Models;
using System;

namespace Hospital
{
	internal class Patient : IObserver
	{
		private string _lastName;
		private int _age;
		private DateTime _dateOfReceipt;
		private Diagnosis _diagnosis;
		private string _hospitalDepartment;

		public string LastName
		{
			get { return _lastName; }
			set { _lastName = value; }
		}
		public Diagnosis DiagnosisPatient
		{
			get => _diagnosis; set => _diagnosis = value;
		}
		public int Age
		{
			get { return _age; }
			set { _age = value; }
		}
		public string HospitalDepartment
		{
			get => _hospitalDepartment;
			set => _hospitalDepartment = value;
		}
		public DateTime DateOfReceipt
		{
			get => _dateOfReceipt; set => _dateOfReceipt = value;
		}
		public DateTime ArrivalTime => Convert.ToDateTime(_dateOfReceipt - _diagnosis.TreatmentTime);

		public override string ToString() => $"{_lastName};{_age};{_dateOfReceipt};{_diagnosis.Title}";

		public Patient(string lastName, int age, DateTime dateOfReceipt, string titleOfDiagnosis, CollectionDiagnosis collection)
		{
			_lastName = lastName;
			_age = age;
			_dateOfReceipt = dateOfReceipt;
			_diagnosis = collection.diagnosisList.Find(d => d.Title == titleOfDiagnosis);
			_diagnosis.Attach(this);
			_hospitalDepartment = _diagnosis.HospitalDepartment;
		}

		public void Update(ISubject subject)
		{
			_hospitalDepartment = _diagnosis.HospitalDepartment;
		}
	}
}
