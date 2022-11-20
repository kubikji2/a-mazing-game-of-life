using System.Collections.Generic;

namespace AMGOLCore
{
    public class EnumrableUtils
    {
        // convert array to comma-separated string
        public static string ToString<T>(T[] array)
        {
            string s = "";
            for (int i = 0; i < array.Length; i++)
            {
                s += array[i].ToString();
                s += i < array.Length-1 ? ", " : ""; 
            }
            return s;
        }
        
        // convert list to comma-separated string
        public static string ToString<T>(List<T> array)
        {
            string s = "";
            for (int i = 0; i < array.Count; i++)
            {
                s += array[i].ToString();
                s += i < array.Count-1 ? ", " : ""; 
            }
            return s;
        }

    }

}