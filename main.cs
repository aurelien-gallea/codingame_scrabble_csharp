using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        // initialize dictionary to count points
        var dict = new Dictionary<char, int>();
        dict['e'] = 1; dict['a'] = 1; dict['i'] = 1; dict['o'] = 1; dict['n'] = 1;
        dict['r'] = 1; dict['t'] = 1; dict['l'] = 1; dict['s'] = 1; dict['u'] = 1;
        dict['d'] = 2; dict['g'] = 2;
        dict['b'] = 3; dict['c'] = 3; dict['m'] = 3; dict['p'] = 3;
        dict['f'] = 4; dict['h'] = 4; dict['v'] = 4; dict['w'] = 4; dict['y'] = 4;
        dict['k'] = 5;
        dict['j'] = 8; dict['x'] = 8;
        dict['q'] = 10; dict['z'] = 10;

        // can't modify this part (codingame) -----------------------------
        int N = int.Parse(Console.ReadLine());
        // stock words in array
        var wordsArray = new string[N];

        for (int i = 0; i < N; i++)
        {
            string W = Console.ReadLine();
            wordsArray[i] = W;
        }
        string LETTERS = Console.ReadLine();
        // ----------------------------------------------------------------
        // my stock of letters
        string myStock = LETTERS;
        // initialize variables to take best solution
        string bestWord = "";
        int bestWordLength = 0;
        int bestPoints = 0;

        // loop inside words array
        for (int i = 0; i < wordsArray.Length; i++)
        {
            // variables to compare current word with my letters
            int lettersUsed = 0;
            string word = wordsArray[i];

            // loop inside my stock of letters 
            for (int j = myStock.Length-1; j >= 0; j--)
            {
                // increment if match and remove letter used
                if (word.Contains(myStock[j])) {
                    lettersUsed++;
                    myStock = myStock.Remove(j);   
                }
                // if we made a word
                if (lettersUsed == word.Length)
                {
                    //initialize current point value of this word
                    int currPoints = 0;

                    //loop inside this word to count value
                    foreach (char item in word) if (dict.ContainsKey(item)) currPoints += dict[item];         
                        
                    // if the value or the value and length is better than previous we keep this new word
                    if (currPoints > bestPoints || (currPoints == bestPoints && word.Length < bestWordLength))
                    {
                        bestPoints = currPoints;
                        bestWord = word;
                        bestWordLength = word.Length;  
                    }
                    //reset to compare again
                    lettersUsed = 0;
                    break;
                } 
            }
            // reset my stock for the next word
            myStock = LETTERS;
        }
        Console.Write(bestWord);
    }
}
