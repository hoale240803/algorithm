using System.Text.RegularExpressions;

namespace Algorithm.ArrayAndHashing;

public class ValidPalindromeArray{

    public bool IsPalindrome(string s) {
        
        // input: a palindrome is also case-insensitive and ignroes all non-alphanumeric

        // option 1: two pointers
        // left pointer: start from the beginning of the string
        // right pointer: start from the end of the string
        // if the character is not a letter or digit, move the pointer
        // if the character is a letter or digit, compare the characters
        // if the characters are not the same, return false
        // if the characters are the same, move the pointers
        // if the pointers meet, return true

        int left = 0;
        int right = s.Length - 1;
        
        while (left < right)
        {
            if (!char.IsLetterOrDigit(s[left]))
            {
                left++;
            }
            else if (!char.IsLetterOrDigit(s[right]))
            {
                right--;
            }
            else if (s[left].ToString().ToLower() != s[right].ToString().ToLower())
            {
                return false;
            }
            else
            {
                left++;
                right--;
            }   
        }   

        return true;
        


        // option 2: using two pointers
        // todo: remove all non-alphanumeric
        // todo: convert to lower case
        // todo: check if the string is a palindrome        
        // todo: return true if it is a palindrome, false otherwise

        // string cleanedString = Regex.Replace(s, "[^a-zA-Z0-9]", "").ToLower();
        // int left = 0;
        // int right = cleanedString.Length - 1;

        // while (left < right)
        // {
        //     if (cleanedString[left] != cleanedString[right])    
        //     {
        //         return false;
        //     }

        //     left++;
        //     right--;
        // }   

        // return true;
    }
}