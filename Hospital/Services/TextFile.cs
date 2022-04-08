using Hospital.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Hospital.Services
{
	internal class TextFile
	{
		private string _fileNamePatients;
		private string _fileNameDiagnosis;

		public TextFile()
		{
			_fileNamePatients = "Patients.txt";
			_fileNameDiagnosis = "Diagnosis.txt";
		}

		public async Task<CollectionDiagnosis> ReadAsync()
		{
			var collection = new CollectionDiagnosis();

			using (StreamReader reader = new StreamReader(_fileNameDiagnosis))
			{
				string? line;
				while ((line = await reader.ReadLineAsync()) != null)
				{
					string[] word = line.Split(';');

					collection.diagnosisList.Add(new Diagnosis(word[0], TimeSpan.Parse(word[1]), word[2]));
				}
			}

			return collection;
		}
		public async Task<CollectionPatiens> ReadAsync(CollectionDiagnosis collection)
		{
			var collectionPatients = new CollectionPatiens();

			using (StreamReader reader = new StreamReader(_fileNamePatients))
			{
				string? line;
				while ((line = await reader.ReadLineAsync()) != null)
				{
					string[] word = line.Split(';');

					collectionPatients.PatientsList.Add(new Patient(word[0], Convert.ToDateTime(word[1]), word[2], collection));
				}
			}

			return collectionPatients;
		}
		public void Write(CollectionDiagnosis diagnosis)
		{
			using (StreamWriter writer = new StreamWriter(_fileNameDiagnosis, false))
			{
				foreach (Diagnosis item in diagnosis.diagnosisList)
				{
					WriteAsync(item, writer);
				}
			}
		}
		public void Write(CollectionPatiens patiens)
		{
			using (StreamWriter writer = new StreamWriter(_fileNamePatients, false))
			{
				foreach (Patient item in patiens.PatientsList)
				{
					WriteAsync(item, writer);
				}
			}
		}

		private async Task WriteAsync(object obj, StreamWriter writer)
		{
			await writer.WriteLineAsync(obj.ToString());
		}
	}
}
