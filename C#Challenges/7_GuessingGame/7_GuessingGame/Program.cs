﻿using System;
using System.Collections.Generic;

namespace _7_GuessingGameChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
           
        }

        /// <summary>
        /// This method returns a randomly chosen number between 1 and 100, inclusive.
        /// </summary>
        /// <returns></returns>
        public static int GetRandomNumber()
        {
            Random rand = new Random();
            int randNum = rand.Next(1, 101);
            return randNum;
        }

        /// <summary>
        /// This method gets input from the user, 
        /// verifies that the input is valid and 
        /// returns an int.
        /// </summary>
        /// <returns></returns>
        public static int GetUsersGuess()
        {
            bool isValid = false;
            int userInput = -1;
            do
            {
                Console.WriteLine("What is your guess? 1-100");
                userInput = Convert.ToInt32(Console.ReadLine());
                if(userInput >= 1 && userInput <= 100)
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Give a valid guess");
                }
            } while (isValid == false);
            return userInput;
        }

        /// <summary>
        /// This method will has two int parameters.
        /// It will:
        /// 1) compare the first number to the second number
        /// 2) return -1 if the first number is less than the second number
        /// 3) return 0 if the numbers are equal
        /// 4) return 1 if the first number is greater than the second number
        /// </summary>
        /// <param name="randomNum"></param>
        /// <param name="guess"></param>
        /// <returns></returns>
        public static int CompareNums(int randomNum, int guess)
        {
            if (randomNum < guess)
            {
                return -1;

            }
            else if(randomNum == guess)
            {
                return 0;
            }
            else if(randomNum > guess)
            {
                return 1;
            }
            else
            {
                return -2;
            }
        }

        /// <summary>
        /// This method offers the user the chance to play again. 
        /// It returns true if they want to play again and false if they do not.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static bool PlayGameAgain()
        {
            bool ifPlay = false;
            Console.WriteLine("Do you want to play again? Enter yes or no)");
            string yesOrNo = Console.ReadLine();
            if (yesOrNo == "yes" || yesOrNo == "Yes")
            {
                ifPlay = true;
            }
            return ifPlay;
        }
    }
}
