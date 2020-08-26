using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evenoddGame
{
	class Helper
	{
		protected Helper() 
		{

		} // 1st constuctor end //

		protected int validNumOfDraws() 
		{
			int validNoD = 0;
			bool IsValid = false;

			numOfDsMenu();
			while (!IsValid)
			{
				IsValid = Int32.TryParse(Console.ReadLine(), out validNoD);
				if (!IsValid)
				{
					Console.WriteLine("\n The number you gave was not valid!!! ");
					Console.WriteLine(" Please give a valid value (integer) ");
					Console.ForegroundColor = ConsoleColor.Blue;
					Console.WriteLine("\n Whenever you are ready choose if you want to play in more than one draws ---> ");
					Console.ForegroundColor = ConsoleColor.White;

					if ((IsValid) && (validNoD != 1 && validNoD != 2 && validNoD != 3 && validNoD != 4 && validNoD != 5 && validNoD != 6 && validNoD != 10 && validNoD != 20 && validNoD != 50 && validNoD != 100 && validNoD != 200))
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("\n Your input was not one of the previously mentioned numbers! Hence, you will automatically compete in only 1 draw! \n");
						Console.ForegroundColor = ConsoleColor.White;
						pressAnyKey();
						validNoD = 1;
					}
				}
				else
				{
					if (validNoD != 1 && validNoD != 2 && validNoD != 3 && validNoD != 4 && validNoD != 5 && validNoD != 6 && validNoD != 10 && validNoD != 20 && validNoD != 50 && validNoD != 100 && validNoD != 200)
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("\n Your input was not one of the previously mentioned numbers! Hence, you will automatically compete in only 1 draw! \n");
						Console.ForegroundColor = ConsoleColor.White;
						pressAnyKey();
						validNoD = 1;
					}
				}
			}
			return validNoD;

		} // protected void validNumOfDraws() end //

		protected void numOfDsMenu() 
		{
			Console.WriteLine("\n   - You can only use integer values! ");
			Console.WriteLine("\n   - You can can only compete in specific number of draws, as listed below: \n");
			Console.WriteLine("\n        - - - 1, 2, 3, 4, 5, 6, 10, 20, 50, 100, 200 - - - \n");
			Console.WriteLine("\n   - If your input is any other number and NOT one of the previously mentioned, you will automatically compete in only 1 draw! ");
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("\n Whenever you are ready select how many times you want to play ---> ");
			Console.ForegroundColor = ConsoleColor.White;

		} // protected void numOfDsMenu() end //

		protected int validAge()
		{
			int ValidInt = 0;
			bool IsValid = false;

			while (!IsValid)
			{
				IsValid = Int32.TryParse(Console.ReadLine(), out ValidInt);
				if (!IsValid)
				{
					Console.WriteLine("\n The number you gave was not valid!!! ");
					Console.WriteLine(" Please give a valid value (integer) ");
					Console.ForegroundColor = ConsoleColor.Blue;
					Console.WriteLine("\n Whenever you are ready give your age ---> ");
					Console.ForegroundColor = ConsoleColor.White;

					if ((IsValid) && (ValidInt < 0))
					{
						ValidInt = 18;
					}
					else if ((IsValid) && (ValidInt >= 0 && ValidInt < 18))
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine(" You are underaged! Normally, you wouldn't be able to play but since this is a fake game you may continue! \n");
						Console.ForegroundColor = ConsoleColor.White;
						pressAnyKey();
					}
					else if ((IsValid) && (ValidInt > 125))
					{
						ValidInt = 125;
					}
				}
				else
				{
					if (ValidInt < 0)
					{
						ValidInt = 18;
					}
					else if ((ValidInt >= 0 && ValidInt < 18))
					{
						Console.WriteLine("\n You are underaged! Normally, you wouldn't be able to play but since this is a fake game you may continue! \n");
						pressAnyKey();
					}
					else if (ValidInt > 125)
					{
						ValidInt = 125;
					}
				}
			}
			return ValidInt;

		} // protected int ValidInt() end //

		protected int validMoneyBet() 
		{
			int validBet = 0;
			bool IsValid = false;

			betMenu();
			while (!IsValid)
			{
				IsValid = Int32.TryParse(Console.ReadLine(), out validBet);
				if (!IsValid)
				{
					Console.WriteLine("\n The number you gave was not valid!!! ");
					Console.WriteLine(" Please give a valid value (integer) ");
					Console.ForegroundColor = ConsoleColor.Blue;
					Console.WriteLine("\n Whenever you are ready place your bet ---> ");
					Console.ForegroundColor = ConsoleColor.White;

					if ((IsValid) && (validBet <= 0))
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("\n Your bet was 0 or less than 0 Euros and thus, it will be converted to 1 Euro! \n");
						Console.ForegroundColor = ConsoleColor.White;
						pressAnyKey();
						validBet = 1;
					}
					else if ((IsValid) && (validBet > 100))
					{
						Console.ForegroundColor = ConsoleColor.Green;
						Console.WriteLine("\n Your bet was more than 100 Euros and thus, it will be converted to 100 Euros! \n");
						Console.ForegroundColor = ConsoleColor.White;
						pressAnyKey();
						validBet = 100;
					}
					else if ((IsValid) && (validBet < 10) && (validBet != 1 && validBet != 2 && validBet != 3 && validBet != 5 && validBet != 10))
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("\n Your bet was less than 10 and != 1, != 2, != 3, != 5 or != 10 Euros !!! ");
						Console.WriteLine(" Hence, it will be converted to 10 Euros! \n");
						Console.ForegroundColor = ConsoleColor.White;
						pressAnyKey();
						validBet = 10;
					}
					else if ((IsValid) && (validBet > 10) && (validBet != 15 && validBet != 20 && validBet != 30 && validBet != 50 && validBet != 100))
					{
						Console.ForegroundColor = ConsoleColor.Green;
						Console.WriteLine("\n Your bet was more than 10 and != 15, != 20, != 30, != 50 or != 100 Euros !!! ");
						Console.WriteLine(" Hence, it will be converted to 45 Euros! \n");
						Console.ForegroundColor = ConsoleColor.White;
						pressAnyKey();
						validBet = 45;
					}
				}
				else
				{
					if ((validBet <= 0))
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("\n Your bet was 0 or less than 0 Euros and thus, it will be converted to 1 Euro! \n");
						Console.ForegroundColor = ConsoleColor.White;
						pressAnyKey();
						validBet = 1;
					}
					else if ((validBet > 100))
					{
						Console.ForegroundColor = ConsoleColor.Green;
						Console.WriteLine("\n Your bet was more than 100 Euros and thus, it will be converted to 100 Euros! \n");
						Console.ForegroundColor = ConsoleColor.White;
						pressAnyKey();
						validBet = 100;
					}
					else if ((validBet < 10) && (validBet != 1 && validBet != 2 && validBet != 3 && validBet != 5 && validBet != 10))
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("\n Your bet was less than 10 and != 1, != 2, != 3, != 5 or != 10 Euros !!! ");
						Console.WriteLine(" Hence, it will be converted to 10 Euros! \n");
						Console.ForegroundColor = ConsoleColor.White;
						pressAnyKey();
						validBet = 10;
					}
					else if ((validBet > 10) && (validBet != 15 && validBet != 20 && validBet != 30 && validBet != 50 && validBet != 100))
					{
						Console.ForegroundColor = ConsoleColor.Green;
						Console.WriteLine("\n Your bet was more than 10 and != 15, != 20, != 30, != 50 or != 100 Euros !!! ");
						Console.WriteLine(" Hence, it will be converted to 45 Euros! \n");
						Console.ForegroundColor = ConsoleColor.White;
						pressAnyKey();
						validBet = 45;
					}
				}
			}
			return validBet;

		} // protected int validMoneyBet() //

		protected void betMenu()
		{
			Console.WriteLine("\n   - You can only bet with integer values (Euros), which are: \n");
			Console.WriteLine("\n        - - - 1, 2, 3, 5, 10, 15, 20, 30, 50, 100 - - - \n");
			Console.WriteLine("\n   - If your bet is 0 or less than 0 Euros, it will be converted to 1 Euro! ");
			Console.WriteLine("\n   - If your bet is more than 100 Euros, it will be converted to 100 Euros! ");
			Console.WriteLine("\n   - If your bet is less than 10 and != 1, != 2, != 3, != 5 or != 10 Euros, it will be converted to 10 Euros! ");
			Console.WriteLine("\n   - If your bet is more than 10 and != 15, != 20, != 30, != 50 or != 100 Euros, it will be converted to 45 Euros! ");
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("\n Whenever you are ready place your bet ---> ");
			Console.ForegroundColor = ConsoleColor.White;

		} // protected void betMenu() end //

		protected void pressAnyKey()
		{
			Console.WriteLine(" Press any key to continue... ");
			Console.ReadKey();
			Console.Clear();

		} // protected void pressAnyKey() end //
		protected bool ValidBool()
		{
			string userChoice = string.Empty;
			bool ValidAnswer = false;
			bool userAnswer = false;
			yesORno();

			while (!ValidAnswer)
			{
				userChoice = Console.ReadLine();

				if ((userChoice == "y") || (userChoice == "Y"))
				{
					ValidAnswer = true;
					userAnswer = true;
				}
				else if ((userChoice == "n") || (userChoice == "N"))
				{
					ValidAnswer = true;
					userAnswer = false;
				}
				else
				{
					Console.WriteLine("\n Wrong input! \n");
					yesORno();
					ValidAnswer = false;
				}
			} 

			return userAnswer;

		} // protected bool ValidBool() //

		protected void yesORno()
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine(" Write 'y' or 'Y' for YES... ");
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(" Write 'n' or 'N' for NO... ");
			Console.ForegroundColor = ConsoleColor.White;

		} // protected void yesORno() end //

	} // class Helper end //

} // namespace end //
