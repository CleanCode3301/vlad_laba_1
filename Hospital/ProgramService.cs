using Hospital.Models;
using Hospital.Services;
using les1;
using System.Linq;

namespace Hospital
{
	internal class ProgramService
	{
		public static void Test()
		{
			var textFile = new TextFile();

			CollectionDiagnosis collectionDiagnosis = textFile.ReadAsync().Result;
			CollectionPatiens collectionPatiens = textFile.ReadAsync(collectionDiagnosis).Result;


			var departments = (from dep in collectionPatiens.PatientsList select dep.HospitalDepartment).ToList().Distinct();

			foreach (var department in departments)
			{
				var table = new Table(
					department,
					new string[] { "Фамилия", "Диагноз", "Дата поступления", "Дата выписки" },
					new int[] { 15, 20, 23, 23 }
					);

				table.Hat();

				foreach (Patient patient in collectionPatiens.PatientsList)
				{
					table.Body(new object[] { patient.LastName, patient.DiagnosisPatient.Title, patient.DateOfReceipt, patient.ArrivalTime });
				}

				table.Bottom();
			}
		}
	}
}
