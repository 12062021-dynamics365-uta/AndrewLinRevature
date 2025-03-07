﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _11_ArraysAndListsChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {

        }//EoM

        /// <summary>
        /// This method takes an array of integers and returns a double, the average 
        /// value of all the integers in the array
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static double AverageOfValues(int[] array)
        {
            return array.Average();
        }

        /// <summary>
        /// This method increases each array element by 2 and 
        /// returns an array with the altered values.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int[] SunIsShining(int[] x)
        {
            
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = x[i] + 2;
            }
            return x;
        }

        /// <summary>
        /// This method takes an ArrayList containing types of double, int, and string 
        /// and returns the average of the ints and doubles only, as a decimal.
        /// It ignores the string values and rounds the result to 3 decimal places toward the nearest even number.
        /// </summary>
        /// <param name="myArrayList"></param>
        /// <returns></returns>
        public static decimal ArrayListAvg(ArrayList myArrayList)
        {
            decimal avg = 0;
            int counter = 0;
            
         
            TypeCode typecode;
            for (int i = 0; i < myArrayList.Count; i++)
            {
                typecode = Type.GetTypeCode(myArrayList[i].GetType());
                if(typecode == TypeCode.Int32 || typecode == TypeCode.Double)
                {
                    avg = avg + Convert.ToDecimal(myArrayList[i]);
                    counter++;

                }
              
            }

            return decimal.Round(avg / counter, 3);
        }

        /// <summary>
        /// This method returns the rank (starting with 1st place) of a new 
        /// score entered into a list of randomly ordered scores.
        /// </summary>
        /// <param name="myArray1"></param>
        public static int ListAscendingOrder(List<int> scores, int yourScore)
        {
            scores.Add(yourScore);
            scores.Sort();
            return scores.IndexOf(yourScore) + 1;
        }

        /// <summary>
        /// This method has with two parameters takes a List<string> and a string.
        /// The method returns true if the string parameter is found in the List, otherwise false.
        /// </summary>
        /// <param name="myArray2"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public static bool FindStringInList(List<string> myArray2, string word)
        {
            bool isinList = myArray2.Contains(word);
            return isinList;
        }
    }//EoP
}// EoN