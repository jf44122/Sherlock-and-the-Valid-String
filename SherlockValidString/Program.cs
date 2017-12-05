using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{

    static string isValid(string s)
    {
        // make an arrary representing each letter in an array where the letter indicates the placement a=0, b=1, etc
        // convert the array into byte and subtract a from each value
        // foreach letter, add one to the approprite array box
 
        int[] count = new int[26];
        byte sToByte = 0;
        for (int ccc = 0; ccc < s.Length; ccc++)
        {
            sToByte = (byte)(Convert.ToByte(s[ccc]) - 'a');
            ++count[sToByte];
        }
        count = count.OrderByDescending(c => c).ToArray();
        int numberOfElements = count.Distinct().Count();
        int[] uniques = new int[numberOfElements];
        uniques = count.Distinct().ToArray();
        

        // remove either too many or not enough uninque values to be a problem
        if (numberOfElements <= 2)
            return "YES";
        else if (((numberOfElements > 4) && (uniques.Contains(0))) || numberOfElements > 3)
            return "NO";
        // uniques[3] is either 0 or not existing
        else
        {
            int[] first = Array.FindAll(count, delegate (int i) { return i == uniques[0]; });
            int[] second = Array.FindAll(count, delegate (int i) { return i == uniques[1]; });
            int longest = first.Length > second.Length ? first[0] : second[0];
            int shortest = first.Length > second.Length ? second[0] : first[0];
            if ((first.Length > 1) && (second.Length > 1))
                return "NO";
            else if ((first[0] ==1) || (second[0] ==1))
                return "YES";
            else if (shortest-longest == 1)
                return "YES";
            return "NO";
        }
    
    }
    static void Main(String[] args)
    {
        string s = Console.ReadLine();
        string result = isValid(s);
        Console.WriteLine(result);
        Console.Read();
    }
}
