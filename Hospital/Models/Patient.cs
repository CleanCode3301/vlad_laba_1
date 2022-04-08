using Hospital.Models;
using System;

namespace Hospital
{
	internal class Patient : IObserver
	{
		private string _lastName;
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

		public override string ToString() => $"{_lastName};{_dateOfReceipt};{_diagnosis.Title}";

		public Patient(string lastName, DateTime dateOfReceipt, string titleOfDiagnosis, CollectionDiagnosis collection)
		{
			_lastName = lastName;
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
