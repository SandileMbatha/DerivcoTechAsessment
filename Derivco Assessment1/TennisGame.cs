using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;


public class TennisGame
{
	//removes white spaces in a sentence
	private static readonly Regex sWhitespace = new Regex(@"\s+");
	public static string ReplaceWhitespace(string input, string replacement)
	{
		return sWhitespace.Replace(input, replacement);
	}

	//method to remove duplicate characters in a sentence
	public static string RemoveDuplicates(string input)
	{
		return new string(input.ToCharArray().Distinct().ToArray());
	}

	//find and count matching characters
	public static string findMatches(string input1, string input2)
	{
		string resultednumber = string.Empty;
		foreach (char i in input2)
		{
			int count = 0;
			foreach (char j in input1)
			{
				if (i == j)
				{
					count += 1;
				}
			}
			resultednumber += count.ToString();
		}
		return resultednumber;
	}

	//Add the right mos and left most digits of a number
	public static string AddDigits(string input)
	{

		// test if number has number of digits > 2 or no
		var result = input.Length > 2 ? "" : input;
		while (input.Length > 2)
		{
			var lengthOfNumber = input.Length;
			result = "";
			for (var i = 0; i < lengthOfNumber / 2; i++)
			{
				//add the both start left and end right digits
				result += (input[i] + input[lengthOfNumber - 1 - i] - 2 * '0').ToString();
			}
			//check if number of digit is odd or even
			if (lengthOfNumber % 2 != 0)
				result += input[lengthOfNumber / 2];

			input = result;
		}
		return result;
	}

	
}