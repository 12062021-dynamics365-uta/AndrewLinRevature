using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("9_ClassesChallenge.Tests")]
namespace _9_ClassesChallenge
{
    internal class Human
    {
        private string lastName { get; set; }
        private string firstName { get; set; }

        public Human()
        {
        lastName = "Smyth";
         firstName = "Pat";
           AboutMe();
        }

        public Human(string first, string last)
        {
            firstName = first;
            lastName = last;
            AboutMe();
        }
        public string AboutMe()
        {
            return $"My name is {firstName} {lastName}.";
        }
    }//end of class
}//end of namespace