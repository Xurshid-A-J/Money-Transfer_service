﻿using System;
namespace Card
{
	public class TryCatch
	{
		public static void MeasureLength()
		{
			Console.WriteLine(" Enter the text  :");
			try
			{ 
                string? str = Console.ReadLine();
				if (str == null)
					throw (new ArgumentException("  Input cannot be empty !!!"));

            }
			catch (ArgumentException ms)
			{
				Console.WriteLine(ms.Message);
			}
			


		}
	}
}

