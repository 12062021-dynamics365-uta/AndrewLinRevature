using System;

namespace Rock_Paper_Scissors_Demo1
{
	class RockPaperScissors
	{
		static void Main(string[] args)
		{
			//Welcome message
			Console.WriteLine("Hello. Welcome to Rock-Paper-Scissors Game!");
			// initialize win/tie counts
			int userWin = 0;
			int compWin = 0;
			int tie = 0;
			// best of 3 for loop
			for (int i = 0; i < 3; i++)
			{
				int convertedNumber = -1;
				bool conversionBool = false;
				//if the computer or user has won twice in a row, break out of the loop
				if (userWin == 2 || compWin == 2)
				{
					break;
				}

				do
				{
					//validate the use input as a 1, 2, or 3
					Console.WriteLine($"You have won {userWin} time(s), the computer has won {compWin} time(s), and tied {tie} time(s)!");
					Console.WriteLine("Please enter enter 1 for ROCK, 2 for PAPER, 3 for SCISSORS");
					string userInput = Console.ReadLine();

					//this version of TryParse() takes a string and the second argument is an out variable that is instantiated in that moment.
					conversionBool = Int32.TryParse(userInput, out convertedNumber);
					if (!conversionBool || convertedNumber < 1 || convertedNumber > 3)
					{
						Console.WriteLine("Hey, buddy... that wasn't a 1 or 2 or 3!");
					}

				} while (!(convertedNumber > 0 && convertedNumber < 4));
				//Console.WriteLine($"The int converted value inputted is {convertedNumber}");
				if (convertedNumber == 1)
				{
					Console.WriteLine("You have chosen Rock");
				}
				else if (convertedNumber == 2)
				{
					Console.WriteLine("You have chosen Paper");
				}
				else if (convertedNumber == 3)
				{
					Console.WriteLine("You have chosen Scissors");
				}
				//random number to simulate computer choosing rock, paper, or scissors
				Random randNum = new Random();
				int compNum = randNum.Next(1, 4);
				Console.WriteLine(compNum);// inclusive of the first (lower) value and exclusive of hte second(upper) value. 

				//checking all possible results of the round
				if (compNum == 1)
				{
					Console.WriteLine("The Computer has chosen Rock");
					if (convertedNumber == 1)
					{
						Console.WriteLine("It is a tie!");
						tie++;
					}
					else if (convertedNumber == 2)
					{
						Console.WriteLine("You Win this Round!");
						userWin++;
					}
					else if (convertedNumber == 3)
					{
						Console.WriteLine("You Lost this Round!");
						compWin++;
					}
				}
				else if (compNum == 2)
				{
					Console.WriteLine("The Computer has chosen Paper");
					if (convertedNumber == 1)
					{
						Console.WriteLine("You Lost this Round!");
						compWin++;
					}
					else if (convertedNumber == 2)
					{
						Console.WriteLine("It is a tie!");
						tie++;
					}
					else if (convertedNumber == 3)
					{
						Console.WriteLine("You Won this Round!");
						userWin++;
					}
				}
				else if (compNum == 3)
				{
					Console.WriteLine("The Computer has chosen Scissors");
					if (convertedNumber == 1)
					{
						Console.WriteLine("You Won this Round!");
						userWin++;
					}
					else if (convertedNumber == 2)
					{
						Console.WriteLine("You Lost this Round!");
						compWin++;
					}
					else if (convertedNumber == 3)
					{
						Console.WriteLine("It is a tie!");
						tie++;
					}
				}
			}
			// checking and posting all possible results of the best of 3 match
			if (userWin == compWin)
			{
				Console.WriteLine($"The best of 3 Series is a tie! The final score is {userWin}-{compWin} with {tie} ties");
			}
			else if (userWin > compWin)
			{
				Console.WriteLine($"You win! The final score is {userWin}-{compWin} with {tie} ties");
			}
			else if (userWin < compWin)
			{
				Console.WriteLine($"You lost! The final score is {userWin}-{compWin} with {tie} ties");
			}
			/**homework - 
			 * 1. get a random number for the computer
			 * 2. compare who won the round
			 * 3. refactor the code to have a best of three game
			 * 4. print out the winner, and how many games were won by each (and ties)
			 * 5. and exit the program.
			 * 
			 * 
			 * 
			 * 
			**/




		}
	}
}
