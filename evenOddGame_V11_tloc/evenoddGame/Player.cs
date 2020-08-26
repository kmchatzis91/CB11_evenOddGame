using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evenoddGame
{
	class Player : Helper
	{
		public string playerName { get; private set; }
		public int playerAge { get; private set; }
		public int moneyBet { get; private set; }
		public int totalBet { get; private set; }
		public int numberofDraws { get; private set; }
		private int totalEarnings { get; set; }
		private bool continueORnot { get; set; }
		private bool stopBetDraw { get; set; }

		public Player()
		{

		} // 1st constuctor end //

		public void setPlayer()
		{
			Console.WriteLine("\n Hello there player!!! \n");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine(" What's your name? \n");
			Console.ForegroundColor = ConsoleColor.White;
			playerName = Console.ReadLine();
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("\n How old are you? \n");
			Console.ForegroundColor = ConsoleColor.White;
			playerAge = validAge();
			Console.Clear();
			while (!stopBetDraw)
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("\n It's time to place your bets! Now pay attention to the following instructions: \n");
				Console.ForegroundColor = ConsoleColor.White;
				moneyBet = validMoneyBet();
				Console.Clear();
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("\n Now choose if you want to play in more than one draws: \n");
				Console.ForegroundColor = ConsoleColor.White;
				numberofDraws = validNumOfDraws();
				Console.Clear();
				totalBet = moneyBet * numberofDraws;
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("\n Based on your choices your total bet is: \n");
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.WriteLine(" Bet ({0} Euros) * Draws ({1} Euros) = Total Bet ({2} Euros) ", moneyBet, numberofDraws, totalBet);
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine("\n Is that ok with you? \n");
				continueORnot = ValidBool();
				Console.Clear();
				if (continueORnot == true)
				{
					stopBetDraw = true;
					Console.WriteLine("\n Your data is set! Are you ready to play the game? \n");
					pressAnyKey();
				}
				else
				{
					stopBetDraw = false;
					Console.WriteLine("\n Ok lets set again your Bet and your preferable number of Draws then! \n");
					pressAnyKey();
				}
			}

		} // public void setPalyer() //

	} // class Player end //

} // namespace end //
