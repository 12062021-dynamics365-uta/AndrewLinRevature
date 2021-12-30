using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("9_ClassesChallenge.Tests")]
namespace _9_ClassesChallenge
{
    internal class Human2
    {
        private string lastName { get; set; }
        private string firstName { get; set; }

        private string eyeColor { get; set; }
        private int Age { get; set; }
        private int weight;
        public int Weight { get {return weight; } set { if (value < 0 || value > 400) weight = 0; else weight = value; } }
        
        public Human2()
        {
            lastName = "Smyth";
            firstName = "Pat";
            eyeColor = "null";
            Age = 0;
        }

        public Human2(string first, string last, string eye, int age)
        {
            firstName = first;
            lastName = last;
            eyeColor = eye;
            Age = age;
            AboutMe2();
        }
        public Human2(string first, string last, int age)
        {
            firstName = first;
            lastName = last;
            Age = age;
            eyeColor = "null";
            AboutMe2();
        }

        public Human2(string first, string last, string eye)
        {
            firstName = first;
            lastName = last;
            eyeColor = eye;
            Age = 0;
            AboutMe2();
           
        }
        public string AboutMe2()
        {
            if (eyeColor == "null")
            {
                return $"My name is {firstName} {lastName}. My age is {Age}.";
            }
            else if (Age == 0)
            {
                return $"My name is {firstName} {lastName}. My eye color is {eyeColor}.";
            }
            else if (eyeColor == "null" && Age == 0)
            {
                return $"My name is {firstName} {lastName}.";
            }
            else
            {
                return $"My name is {firstName} {lastName}. My age is {Age}. My eye color is {eyeColor}.";

            }
        }
        public string AboutMe()
        {
            return $"My name is {firstName} {lastName}.";
        }

    }   
}