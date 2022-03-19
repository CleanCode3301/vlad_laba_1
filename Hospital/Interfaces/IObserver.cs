using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital
{
	internal interface IObserver
	{

		// Получает обновление от издателя
		public void Update(ISubject subject);
	}
}
