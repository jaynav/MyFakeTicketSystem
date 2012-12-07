using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace new_ticket_master
{
    static class validateAgainst
    {
        internal static bool letters(string value)
        {
            bool typeOfLetter = true;
       
            for (int i = 0; i< value.Length; i++)
            {
                if (Char.IsLetter(value, i) == true)
                {
                    typeOfLetter = false;
                    break;
                }
            }
           
           return typeOfLetter;
        }

        internal static bool numbers(string value)
       {
           foreach (char c in value)
           {
               if (char.IsNumber(c))
               {
                   return false;
                   
               }
           }
           return true;
       }
        

        /*internal static bool numbers(string value)
        {
          
          
            //alphanumeric with underscore
            //Regex.IsMatch(value, "^[a-zA-Z0-9_]$");
            //letters numbers  underscores along with international charates
            //@"^[\w]$"
            //letters numbers
            //@"^[\p{L}\p{N}]$"
            //letters
            //@"^[\p{L}]$"
            return Regex.IsMatch(value, @"^[0-9]$");
           
           
            
          
        }*/

       

        
    }
}
