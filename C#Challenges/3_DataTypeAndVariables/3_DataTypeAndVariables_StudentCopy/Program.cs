using System;

namespace _3_DataTypeAndVariablesChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //
            //
            // Insert code here.
            //
            //
        }
        /// <summary>
        /// This method has an 'object' type parameter. 
        /// 1. Create a switch statement that evaluates for the data type of the parameter
        /// 2. You will need to get the data type of the parameter in the 'case' part of the switch statement
        /// 3. For each data type, return a string of exactly format, "Data type => <type>" 
        /// 4. For example, an 'int' data type will return ,"Data type => int",
        /// 5. A 'ulong' data type will return "Data type => ulong",
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string PrintValues(object obj)
        {
            TypeCode typeCode = Type.GetTypeCode(obj.GetType());

            switch (typeCode)
            {
                case TypeCode.Byte:
                    return "Data type => byte";
                case TypeCode.SByte:
                    return "Data type => sbyte";
                case TypeCode.Int32:
                    return "Data type => int";
                case TypeCode.UInt32:
                    return "Data type => uint";
                case TypeCode.Int16:
                    return "Data type => short";
                case TypeCode.UInt16:
                    return "Data type => ushort";
                case TypeCode.Single:
                    return "Data type => float";
                case TypeCode.Double:
                    return "Data type => double";
                case TypeCode.Char:
                    return "Data type => char";
                case TypeCode.String:
                    return "Data type => string";
                case TypeCode.Decimal:
                    return "Data type => decimal";
                case TypeCode.Int64:
                    return "Data type => long";
                case TypeCode.UInt64:
                    return "Data type => ulong";
                default:
                    return null;
            }


        }

        /// <summary>
        /// THis method has a string parameter.
        /// 1. Use the .TryParse() method of the Int32 class (Int32.TryParse()) to convert the string parameter to an integer. 
        /// 2. You'll need to investigate how .TryParse() and 'out' parameters work to implement the body of StringToInt().
        /// 3. If the string cannot be converted to a integer, return 'null'. 
        /// 4. Investigate how to use '?' to make non-nullable types nullable.
        /// </summary>
        /// <param name="numString"></param>
        /// <returns></returns>
        public static int? StringToInt(string numString)
        {
            int numInt;
            if (int.TryParse(numString, out numInt))
            {
                return numInt;
            }
            else if (string.IsNullOrEmpty(numString))
            {
                return null;
            }
            return null;
        }
    }// end of class
}// End of Namespace
