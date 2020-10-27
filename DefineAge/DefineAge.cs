using System;

namespace DefineAge
{
	public class DefineAge
	{
        public DateTime birthday { get; set; }
        private int age { get; set; }

        public DefineAge(DateTime birthday)
		{
			this.birthday = birthday;
			setAge(birthday);
		}

		public int getAge() => age;

		public void setAge(DateTime birthday)
        {
			double daysOfYear = 365.2425;

			if (DateTime.Today.Date >= birthday)
				age = 0;

			double totalDays = DateTime.Today.Subtract(birthday).TotalDays;
			double result = totalDays / daysOfYear;

			age = (int)Math.Truncate(result);
        }
	}
}

