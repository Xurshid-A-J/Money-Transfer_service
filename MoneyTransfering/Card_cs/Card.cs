using System;
namespace Card
{
	public class Card
	{
		public delegate void TransferNotification(Card card, int amount);
		public event TransferNotification OnTransferNote;
		public int Id;
		public string Owner;
		public int Balance { get; set; } = 0;
		public CardType Type;
		public Currency currency;

		public Card(CardType type,string owner,int id)
		{ 
			Type = type;
            currency = type == CardType.UZCARD | type == CardType.HUMO? Currency.Sum: Currency.Dollar;
			Owner = owner;
			Id = id;
		}


		List<(int, string, int)> Transactions = new();
		public void TransferMoney(Card card,int amount)
		{ 
			try
			{ 
				if (!((card.Type == CardType.UZCARD | card.Type == CardType.HUMO) &&
								(Type == CardType.UZCARD || Type == CardType.HUMO)))
				{ throw (new Exception(" Card types dont match !")); }
				if (amount > Balance) throw (new Exception(" Not enough money on your balance to send !"));
				Balance -= amount;
				OnTransferNote.Invoke(this, amount);
                Console.WriteLine(" Transfer successful");
            }
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
           

        }
		public void ReceiveMoney(Card card,int amount)
		{
			Transactions.Add((card.Id, card.Owner, amount));
			card.Balance += amount;
		}

		public void TransactionHistory()
		{
			foreach (var item in Transactions)
			{
				Console.WriteLine(item);
			}
		}

		public void MyCardInfo()
		{
			Console.WriteLine( ToString()+$", Balance :{Balance}");
			
		}
        public override string ToString()
        {
			return $"Owner :{Owner} , ID : {Id} , Type : {Type} , " +
				$"Currency: {currency} ";
        }

		public void TopUp(int amount)
		{
			this.Balance += amount;
			Console.WriteLine($" + {amount} to the Balance !\n Current balance : { this.Balance} {currency} ");
		}
       
    }
}

