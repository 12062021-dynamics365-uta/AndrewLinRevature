using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{


    static void minimaxSum(int[] arr)
    {
        Array.Sort(arr);
        long min = arr.Take(4).Sum(item => (long)item);
        long max = arr.Skip(1).Sum(item => (long)item);

        Console.WriteLine($"{min} {max}");
    }

    static void Main(String[] args)
    {
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
        minimaxSum(arr);
    }
}