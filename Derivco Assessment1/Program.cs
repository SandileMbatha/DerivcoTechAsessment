using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace Derivco_Assessment1
{
    class Program
    {
		public static void Main()
		{

			//Clear the ouput.text file for new outputs
			File.Create(@"C:\Users\USER\Desktop\Derivco Assessment1\output.txt").Close();

			/*Reads the two set of files:
			 * one containing the males
			 * and one containing the females
			*/
			var readerF = new StreamReader(@"C:\Users\USER\Desktop\Derivco Assessment1\Females.csv");
			var readerM = new StreamReader(@"C:\Users\USER\Desktop\Derivco Assessment1\Males.csv");



			List<string[]> list1 = new List<string[]>();
			List<string[]> list2 = new List<string[]>();

			while (!readerF.EndOfStream && !readerM.EndOfStream)
			{

				var line1 = readerF.ReadLine().ToLower();
				var line2 = readerM.ReadLine().ToLower();

				string[] temp1 = line1.Split(",");
				string[] temp2 = line2.Split(",");

				//generate a line that is used for computation
				var LineE = temp1[0] + " matches " + temp2[0];
				var lineR = temp2[0] + " matches " + temp1[0];

				//A line is then paired with a default 0%
				string[] arrNew = { LineE, "0" };
				string[] arr = { lineR, "0" };
				list1.Add(arr);
				list2.Add(arrNew);
			
			}

		
			foreach (string[] element in list1)
            {
				//counts and remove white spaces
				int countSpaces = element[0].Count(Char.IsWhiteSpace);
				String string2 = TennisGame.ReplaceWhitespace(element[0], "");

				string perc = "";
				if (string2.All(Char.IsLetter) && countSpaces == 2)
				{
					String string3 = TennisGame.RemoveDuplicates(string2);
					String string4 = TennisGame.findMatches(string2, string3);
					String string5 = TennisGame.AddDigits(string4);
					perc = string5;

					element[1] = perc;
				}
				else
				{
					element[1] = perc;
					Console.WriteLine("Invalid Input");
				}
				
			}


			foreach (string[] element in list2)
			{
				//counts and remove white spaces
				int countSpaces = element[0].Count(Char.IsWhiteSpace);
				String string2 = TennisGame.ReplaceWhitespace(element[0], "");

				string perc = "";
				if (string2.All(Char.IsLetter) && countSpaces == 2)
				{
					String string3 = TennisGame.RemoveDuplicates(string2);
					String string4 = TennisGame.findMatches(string2, string3);
					String string5 = TennisGame.AddDigits(string4);
					perc = string5;

					element[1] = perc;
				}
				else
				{
					element[1] = perc;
					Console.WriteLine("Invalid Input");
				}

			}

			Dictionary<string, int> My_dict1 = new Dictionary<string, int>();
			foreach(string[] item in list1)
            {
				string key = item[0];
				int value = int.Parse(item[1]);
				My_dict1.Add(key, value);  
			}

			Dictionary<string, int> My_dict2 = new Dictionary<string, int>();
			foreach (string[] item in list2)
			{
				string key = item[0];
				int value = int.Parse(item[1]);
				My_dict2.Add(key, value);
			}
			//sorting the list in descending order
			var MyList1 = My_dict1.ToList();
			var MyList2 = My_dict2.ToList();

			double average = 0;

			Dictionary<string, double> averages = new Dictionary<string, double>();
			for(int j = 0; j < My_dict1.Count; j++)
            {
				average = (MyList2[j].Value + MyList1[j].Value) / 2;
				averages.Add(MyList2[j].Key, average);
			}
				
			My_dict2 = My_dict2.OrderByDescending(key => key.Value).ToDictionary(key => key.Key, key => key.Value);
			My_dict1 = My_dict1.OrderByDescending(key => key.Value).ToDictionary(key => key.Key, key => key.Value);
			averages = averages.OrderByDescending(key => key.Value).ToDictionary(key => key.Key, key => key.Value);

			var MyList3 = averages.ToList();
			MyList1 = My_dict1.ToList();
			MyList2 = My_dict2.ToList();

			//append each result to an ouput.txt file
			foreach (var value in MyList1)
			{
				if (value.Value >= 80)
				{
					var towrite = value.Key + " " + value.Value + "%" + "," + " Good Match";
					using (StreamWriter writer = new StreamWriter(@"C:\Users\USER\Desktop\Derivco Assessment1\output.txt", true))
					{
						writer.WriteLine(towrite);
					}
				}
				else
				{
					var towrite1 = value.Key + " " + value.Value + "%";

					using (StreamWriter writer = new StreamWriter(@"C:\Users\USER\Desktop\Derivco Assessment1\output.txt", true))
					{
						writer.WriteLine(towrite1);
					}

				}
			}



			var text = "===================================REVERSE ORDER============================================";
			using (StreamWriter writer = new StreamWriter(@"C:\Users\USER\Desktop\Derivco Assessment1\output.txt", true))
			{
				writer.WriteLine(text);
			}
			//append each result to an ouput.txt file
			

 			for(int i = 0; i < MyList2.Count; i++) {

				if (MyList2[i].Value >= 80)
				{
					var towrite = MyList2[i].Key + " " + MyList2[i].Value + "%" + "," + " Good Match";
					using (StreamWriter writer = new StreamWriter(@"C:\Users\USER\Desktop\Derivco Assessment1\output.txt", true))
					{
						writer.WriteLine(towrite);
					}
				}
				else
				{
					var towrite1 = MyList2[i].Key + " " + MyList2[i].Value + "%";

					using (StreamWriter writer = new StreamWriter(@"C:\Users\USER\Desktop\Derivco Assessment1\output.txt", true))
					{
						writer.WriteLine(towrite1);
					}

				}
			}

			var text1 = "======================================AVERAGE=================================================";
			using (StreamWriter writer = new StreamWriter(@"C:\Users\USER\Desktop\Derivco Assessment1\output.txt", true))
			{
				writer.WriteLine(text1);
			}

			foreach (var value in MyList3)

			{
				string[] arr = value.Key.Split(" ");
				if (value.Value >= 80)
				{
					var line = arr[0] + " and " + arr[2] + ", " + " Average = " + value.Value + " Good Match";
					using (StreamWriter writer = new StreamWriter(@"C:\Users\USER\Desktop\Derivco Assessment1\output.txt", true))
					{
						writer.WriteLine(line);
					}
				}
				else
				{
					var line = arr[0] + " and " + arr[2] + ", " + " Average = " + value.Value;
					using (StreamWriter writer = new StreamWriter(@"C:\Users\USER\Desktop\Derivco Assessment1\output.txt", true))
					{
						writer.WriteLine(line);

					}
				}

			}

		}
	}
}
