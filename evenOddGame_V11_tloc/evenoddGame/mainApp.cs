using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evenoddGame
{
	class mainApp : Helper
	{
		// all variables, arrays, lists //
		private int[] luckyNums = new int[20];
		private List<int> oddList = new List<int>();
		private List<int> evenList = new List<int>();
		private List<string> listOfResults = new List<string>();
		private Random randNum = new Random();
		private string gameName = "EvenOdd Game";
		private string userName = string.Empty;
		private string userEOChoice1 = string.Empty;
		private int userAge = 0;
		private int userMoneyBetChoice2 = 0;
		private int userNumOfDsChoice3 = 0;
		private int tBet = 0;
		private int minNum = 1;
		private int maxNum = 80;
		private int totalOdds = 0;
		private int totalEvens = 0;
		private int numberOfDraws = 0;
		private int resultEven = 0;
		private int resultOdd = 0;
		private int resultDraw = 0;
		private int totalEarnings = 0;
		private int earningsMinusTotalBet = 0;

		public mainApp()
		{

		} // 1st constuctor end //

		public void playGame()
		{
			// start evenOddGame // 
			welcomeMenu(gameName);
			gameDescription(gameName);

			// setPlayer //
			Player player = new Player();
			player.setPlayer();
			userName = player.playerName;
			userAge = player.playerAge;
			userMoneyBetChoice2 = player.moneyBet;
			userNumOfDsChoice3 = player.numberofDraws;
			tBet = player.totalBet;

			// set and display draws //
			userEOChoice1 = playerEvenOddChoice();
			displayNumOfDraws(userNumOfDsChoice3, luckyNums, randNum, minNum, maxNum, oddList, evenList, totalOdds, totalEvens, numberOfDraws, listOfResults);

			// calculate total earnings //
			resultEven = calcResEven(listOfResults, resultEven);
			resultOdd = calcResOdd(listOfResults, resultOdd);
			resultDraw = calcResDraw(listOfResults, resultDraw);
			totalEarnings = calcEarning(userEOChoice1, totalEarnings, listOfResults, userMoneyBetChoice2, resultEven, resultOdd, resultDraw);
			earningsMinusTotalBet = totalEarnings - tBet;

			// final display and end //
			displayIndexOfData(userName, userAge, userMoneyBetChoice2, tBet, userNumOfDsChoice3, resultEven, resultOdd, resultDraw, userEOChoice1);
			displayEarnings(totalEarnings, tBet, earningsMinusTotalBet);
			theEnd();

		} // public void playGame() end //

		private int calcEarning(string userEOChoice1, int totalEarnings, List<string> listOfResults, int userMoneyBetChoice2, int resultEven, int resultOdd, int resultDraw)
		{
			if ((userEOChoice1 == "E") || (userEOChoice1 == "e"))
			{
				totalEarnings = calcEvenEarnings(listOfResults, userMoneyBetChoice2, resultEven);
			}
			else if ((userEOChoice1 == "O") || (userEOChoice1 == "o"))
			{
				totalEarnings = calcOddEarnings(listOfResults, userMoneyBetChoice2, resultOdd);
			}
			else if ((userEOChoice1 == "D") || (userEOChoice1 == "d"))
			{
				totalEarnings = calcDrawEarnings(listOfResults, userMoneyBetChoice2, resultDraw);
			}

			return totalEarnings;

		} // private int calcEarning(string userEOChoice1, int totalEarnings, List<string> listOfResults, int userMoneyBetChoice2, int resultEven, int resultOdd, int resultDraw) end //

		private int calcResDraw(List<string> listOfResults, int resultDraw)
		{
			foreach (string result in listOfResults)
			{
				if (result == "DRAW")
				{
					resultDraw++;
				}
			}

			return resultDraw;

		} // private int calcResDraw(List<string> listOfResults, int resultDraw) end //

		private int calcResOdd(List<string> listOfResults, int resultOdd)
		{
			foreach (string result in listOfResults)
			{
				if (result == "ODD")
				{
					resultOdd++;
				}
			}

			return resultOdd;

		} // private int calcResOdd(List<string> listOfResults, int resultOdd) end //

		private int calcResEven(List<string> listOfResults, int resultEven) 
		{
			foreach (string result in listOfResults)
			{
				if (result == "EVEN")
				{
					resultEven++;
				}
			}

			return resultEven;

		} // private int calcResEven(List<string> listOfResults, int resultEven) end //

		private void displayIndexOfData(string userName, int userAge, int userMoneyBetChoice2, int tBet, int userNumOfDsChoice3, int resultEven, int resultOdd, int resultDraw, string userEOChoice1)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("\n\n - - - - - - - - - - > Index < - - - - - - - - - - \n\n");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine(" Player Data: \n");
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine(" Player Name: {0}     Player Age: {1} ", userName, userAge, userMoneyBetChoice2);
			Console.WriteLine(" Bet: {0} (Euros)     Total Bet: {1} (Euros) ", userMoneyBetChoice2, tBet);
			Console.WriteLine(" Number of draws: {0} ", userNumOfDsChoice3);
			if ((userEOChoice1 == "E") || (userEOChoice1 == "e"))
			{
				Console.WriteLine(" Betted outcome: EVEN ");
			}
			else if ((userEOChoice1 == "O") || (userEOChoice1 == "o"))
			{
				Console.WriteLine(" Betted outcome: ODD ");
			}
			else if ((userEOChoice1 == "D") || (userEOChoice1 == "d"))
			{
				Console.WriteLine(" Betted outcome: DRAW ");
			}
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("\n Lottery Results: \n");
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("     - Times EVEN won ---> {0} ", resultEven);
			Console.WriteLine("     - Times ODD won ---> {0} ", resultOdd);
			Console.WriteLine("     - Times DRAW won ---> {0} \n", resultDraw);
			Console.ForegroundColor = ConsoleColor.White;

		} // private void displayIndexOfData(string userName, int userAge, int userMoneyBetChoice2, int tBet, int userNumOfDsChoice3, int resultEven, int resultOdd, int resultDraw, string userEOChoice1) end // 

		private void displayEarnings(int totalEarnings, int tBet, int earningsMinusTotalBet) 
		{
			if (totalEarnings < tBet)
			{
				Console.WriteLine("\n Lottery result earnings ---> {0} (Lottery Earnings) - {1} (Total Bet) = {2} (Total Amount Earned or Lost) ", totalEarnings, tBet, earningsMinusTotalBet);
				earningsMinusTotalBet = earningsMinusTotalBet * (-1);
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("\n You lost {0} Euros! \n", earningsMinusTotalBet);
				Console.ForegroundColor = ConsoleColor.White;
			}
			else if (totalEarnings > tBet)
			{
				Console.WriteLine("\n Lottery result earnings ---> {0} (Lottery Earnings) - {1} (Total Bet) = {2} (Total Amount Earned or Lost) ", totalEarnings, tBet, earningsMinusTotalBet);
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("\n You won {0} Euros! \n", earningsMinusTotalBet);
				Console.ForegroundColor = ConsoleColor.White;
			}
			else
			{
				Console.WriteLine("\n Lottery result earnings ---> {0} (Lottery Earnings) - {1} (Total Bet) = {2} (Total Amount Earned or Lost) ", totalEarnings, tBet, earningsMinusTotalBet);
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.WriteLine("\n You didn't win or lose any money! You just got your bet back which was {0} Euros! \n", earningsMinusTotalBet);
				Console.ForegroundColor = ConsoleColor.White;
			}

			pressAnyKey();

		} // private void displayEarnings(int totalEarnings, int tBet, int earningsMinusTotalBet) end //

		private int calcEvenEarnings(List<string> listOfResults, int userMoneyBetChoice2, int resultEven)
		{
			int earningsORnot = 0;
			foreach (var result in listOfResults)
			{
				if (result == "EVEN") 
				{
					earningsORnot = (userMoneyBetChoice2 * 2) * resultEven;
				}	
			}

			return earningsORnot;

		} // private int calcEvenEarnings(List<string> listOfResults, int userMoneyBetChoice2, int resultEven, int tBet) end //

		private int calcOddEarnings(List<string> listOfResults, int userMoneyBetChoice2, int resultOdd)
		{
			int earningsORnot = 0;
			foreach (var result in listOfResults)
			{
				if (result == "ODD") 
				{
					earningsORnot = (userMoneyBetChoice2 * 2) * resultOdd;
				}	
			}

			return earningsORnot;

		} // private int calcOddEarnings(List<string> listOfResults, int userMoneyBetChoice2, int resultOdd, int tBet) end //

		private int calcDrawEarnings(List<string> listOfResults, int userMoneyBetChoice2, int resultDraw)
		{
			int earningsORnot = 0;
			foreach (var result in listOfResults)
			{
				if (result == "DRAW") 
				{
					earningsORnot = (userMoneyBetChoice2 * 4) * resultDraw;
				}	
			}

			return earningsORnot;

		} // private int calcDrawEarnings(List<string> listOfResults, int userMoneyBetChoice2, int resultDraw, int tBet) end //

		private string playerEvenOddChoice()
		{
			bool plChoice = false;
			string plEvenOddDrawChoice = string.Empty;

			while (!plChoice)
			{
				choicesMenu();
				plEvenOddDrawChoice = Console.ReadLine();

				if ((plEvenOddDrawChoice == "E") || (plEvenOddDrawChoice == "e"))
				{
					plChoice = true;
				}
				else if ((plEvenOddDrawChoice == "O") || (plEvenOddDrawChoice == "o"))
				{
					plChoice = true;
				}
				else if ((plEvenOddDrawChoice == "D") || (plEvenOddDrawChoice == "d"))
				{
					plChoice = true;
				}
				else if ((plEvenOddDrawChoice == "000") || (plEvenOddDrawChoice == "000"))
				{
					plChoice = true;
					ExitApp();
				}
				else
				{
					plChoice = false;
					wrongInpHint();
				}
			}
			return plEvenOddDrawChoice;

		} // private string playerEvenOddChoice() end //

		private void displayNumOfDraws(int userNumOfDsChoice3, int[] luckyNums, Random randNum, int minNum, int maxNum, List<int> oddList, List<int> evenList, int totalOdds, int totalEvens, int numberOfDraws, List<string> listOfResults)
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("\n\n - - - - - - - - - - - - - - - - - - - - >   Lottery Results   < - - - - - - - - - - - - - - - - - - - - \n\n");
			Console.ForegroundColor = ConsoleColor.White;

			if (userNumOfDsChoice3 == 2)
			{
				for (int d = 1; d <= 2; d++)
				{
					numberOfDraws = numberOfDraws + 1;
					drawRunAddShow(luckyNums, randNum, minNum, maxNum, oddList, evenList, totalOdds, totalEvens, numberOfDraws, listOfResults);
				}
			}
			else if (userNumOfDsChoice3 == 3)
			{
				for (int d = 1; d <= 3; d++)
				{
					numberOfDraws = numberOfDraws + 1;
					drawRunAddShow(luckyNums, randNum, minNum, maxNum, oddList, evenList, totalOdds, totalEvens, numberOfDraws, listOfResults);
				}
			}
			else if (userNumOfDsChoice3 == 4)
			{
				for (int d = 1; d <= 4; d++)
				{
					numberOfDraws = numberOfDraws + 1;
					drawRunAddShow(luckyNums, randNum, minNum, maxNum, oddList, evenList, totalOdds, totalEvens, numberOfDraws, listOfResults);
				}
			}
			else if (userNumOfDsChoice3 == 5)
			{
				for (int d = 1; d <= 5; d++)
				{
					numberOfDraws = numberOfDraws + 1;
					drawRunAddShow(luckyNums, randNum, minNum, maxNum, oddList, evenList, totalOdds, totalEvens, numberOfDraws, listOfResults);
				}
			}
			else if (userNumOfDsChoice3 == 6)
			{
				for (int d = 1; d <= 6; d++)
				{
					numberOfDraws = numberOfDraws + 1;
					drawRunAddShow(luckyNums, randNum, minNum, maxNum, oddList, evenList, totalOdds, totalEvens, numberOfDraws, listOfResults);
				}
			}
			else if (userNumOfDsChoice3 == 10)
			{
				for (int d = 1; d <= 10; d++)
				{
					numberOfDraws = numberOfDraws + 1;
					drawRunAddShow(luckyNums, randNum, minNum, maxNum, oddList, evenList, totalOdds, totalEvens, numberOfDraws, listOfResults);
				}
			}
			else if (userNumOfDsChoice3 == 20)
			{
				for (int d = 1; d <= 20; d++)
				{
					numberOfDraws = numberOfDraws + 1;
					drawRunAddShow(luckyNums, randNum, minNum, maxNum, oddList, evenList, totalOdds, totalEvens, numberOfDraws, listOfResults);
				}
			}
			else if (userNumOfDsChoice3 == 50)
			{
				for (int d = 1; d <= 50; d++)
				{
					numberOfDraws = numberOfDraws + 1;
					drawRunAddShow(luckyNums, randNum, minNum, maxNum, oddList, evenList, totalOdds, totalEvens, numberOfDraws, listOfResults);
				}
			}
			else if (userNumOfDsChoice3 == 100)
			{
				for (int d = 1; d <= 100; d++)
				{
					numberOfDraws = numberOfDraws + 1;
					drawRunAddShow(luckyNums, randNum, minNum, maxNum, oddList, evenList, totalOdds, totalEvens, numberOfDraws, listOfResults);
				}
			}
			else if (userNumOfDsChoice3 == 200)
			{
				for (int d = 1; d <= 200; d++)
				{
					numberOfDraws = numberOfDraws + 1;
					drawRunAddShow(luckyNums, randNum, minNum, maxNum, oddList, evenList, totalOdds, totalEvens, numberOfDraws, listOfResults);
				}
			}
			else
			{
				numberOfDraws = numberOfDraws + 1;
				drawRunAddShow(luckyNums, randNum, minNum, maxNum, oddList, evenList, totalOdds, totalEvens, numberOfDraws, listOfResults);
			}

			Console.WriteLine();
			pressAnyKey();

		} // private void displayNumOfDraws(int userNumOfDsChoice3, int[] luckyNums, Random randNum, int minNum, int maxNum, List<int> oddList, List<int> evenList, int totalOdds, int totalEvens, int numberOfDraws) end //

		private void drawRunAddShow(int[] luckyNums, Random randNum, int minNum, int maxNum, List<int> oddList, List<int> evenList, int totalOdds, int totalEvens, int numberOfDraws, List<string> listOfResults)
		{
			runDraw(luckyNums, randNum, minNum, maxNum);
			addLuckyNumsToLists(luckyNums, oddList, evenList);
			totalOdds = oddList.Count;
			totalEvens = evenList.Count;
			ShowDrawNumbers(numberOfDraws, evenList, oddList, totalEvens, totalOdds, listOfResults);

		} // private void drawRunAddShow(int [] luckyNums, Random randNum, int minNum, int maxNum, int numberOfDraws, List<int> oddList, List<int> evenList, int totalOdds, int totalEvens) end //

		private void resultPerDraw(List<int> evenList, List<int> oddList, List<string> listOfResults)
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
			if (evenList.Count > oddList.Count)
			{
				Console.WriteLine("\n Result is ---> EVEN numbers are more than ODD numbers! ");
				listOfResults.Add("EVEN");
			}
			else if (oddList.Count > evenList.Count)
			{
				Console.WriteLine("\n Result is ---> ODD numbers are more than EVEN numbers! ");
				listOfResults.Add("ODD");
			}
			else
			{
				Console.WriteLine("\n Result is ---> DRAW! ");
				listOfResults.Add("DRAW");
			}
			Console.ForegroundColor = ConsoleColor.White;

		} // private void resultPerDraw(List<int> evenList, List<int> oddList) end //

		private void ShowDrawNumbers(int numberOfDraws, List<int> evenList, List<int> oddList, int totalEvens, int totalOdds, List<string> listOfResults)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine(" Draw number {0}: ", numberOfDraws);
			Console.ForegroundColor = ConsoleColor.White;

			Console.Write("\n Even numbers are:");
			foreach (var even in evenList)
			{
				Console.Write("   " + even);
			}
			Console.WriteLine("\n\n Total numbers: {0} ", totalEvens);

			Console.Write("\n Odd numbers are:");
			foreach (var odd in oddList)
			{
				Console.Write("   " + odd);
			}
			Console.WriteLine("\n\n Total numbers: {0} ", totalOdds);

			resultPerDraw(evenList, oddList, listOfResults);
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("\n - - - - - - - - - - - - - - - - - - - - - - - - - \n");
			Console.ForegroundColor = ConsoleColor.White;

			evenList.Clear();
			oddList.Clear();

		} // private void ShowDrawNumbers(int numberOfDraws, List<int> evenList, List<int> oddList, int totalEvens, int totalOdds) end //

		private void addLuckyNumsToLists(int[] luckyNums, List<int> oddList, List<int> evenList)
		{
			foreach (var lnum in luckyNums)
			{
				if (lnum % 2 == 0)
				{
					oddList.Add(lnum);
				}
				else if (lnum % 2 != 0)
				{
					evenList.Add(lnum);
				}
			}

		} // private void addLuckyNumsToLists(int [] luckyNums, List <int> oddList, List<int> evenList) end //

		private void runDraw(int[] luckyNums, Random randNum, int minNum, int maxNum)
		{
			for (int i = 0; i < luckyNums.Length; i++)
			{
				luckyNums[i] = randNum.Next(minNum, maxNum);
			}

		} // private void runDraw(int[] luckyNums, Random randNum, int minNum, int maxNum) end //

		private void wrongInpHint()
		{
			Console.Clear();
			Console.WriteLine("\n Wrong input! Remember: \n");
			Console.WriteLine("      - Select 'E' or 'e' for EVEN ");
			Console.WriteLine("      - Select 'O' or 'o' for ODD ");
			Console.WriteLine("      - Select 'D' or 'd' for DRAW ");
			Console.WriteLine("      ...or write '000' to exit \n");
			pressAnyKey();

		} //private void wrongInpHint() end //

		private void choicesMenu()
		{
			Console.WriteLine("\n Let's play the game now, shall we? What's your guess? ");
			Console.WriteLine("\n      - Select 'E' or 'e' for EVEN ");
			Console.WriteLine("\n      - Select 'O' or 'o' for ODD ");
			Console.WriteLine("\n      - Select 'D' or 'd' for DRAW ");
			Console.WriteLine("\n      ...or write '000' to exit");
			Console.WriteLine("\n (selet one of the above and press 'Enter' to see the lottery results or to exit the game) \n");

		} // private void choicesMenu() end //

		private void ExitApp()
		{
			Console.Clear();
			Console.WriteLine("\n Thank you and goodbye :( Press any key to exit... ");
			Console.ReadKey();
			Environment.Exit(0);

		} // private void ExitApp() end //

		private void welcomeMenu(string gameName)
		{
			Console.WriteLine("\n Hello and welcome to {0}!!! \n", gameName);
			pressAnyKey();

		} // private void welcomeMenu(string gameName) end //

		private void gameDescription(string gameName)
		{
			Console.WriteLine("\n In {0}, 20 numbers (between 1 - 80) are chosen randomly. You can bet on whether the majority of these numbers will be EVEN or ODD. Also, you can bet on DRAW! \n", gameName);
			Console.WriteLine(" If you guess correctly and the majority is either EVEN or ODD you win your bet multiplied by 2! ");
			Console.WriteLine(" If you guess correctly and the result is DRAW you win your bet multiplied by 4! ");
			Console.WriteLine(" Otherwise, you lose!!! ");
			Console.WriteLine("\n Press any key to continue... ");
			Console.ReadKey();
			Console.Clear();

		} // private void gameDescription(string gameName) end //

		private void theEnd()
		{
			Console.Clear();
			Console.WriteLine("\n - - - - - - - - - - > The End < - - - - - - - - - - \n");
			pressAnyKey();

		} // private void theEnd() end //

	} // class mainApp end //

} // namespace end //
