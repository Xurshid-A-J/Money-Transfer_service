using System;


namespace Projects.CRUD_JSON
{
	public class ReadJSON
	{
		public static void ReadJson()
		{
			List<Account> accounts = new();

			accounts = Methods.GetAccounts();

			Console.WriteLine("Reading all items from Json file ... ");
			Console.WriteLine(" \v\t\t All data :");
			accounts.ForEach(x => Console.WriteLine(x));

		}
	}
}

