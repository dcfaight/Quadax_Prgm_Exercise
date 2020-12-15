//Author: David Faight
//Description: 4 digits between 1 and 6 are randomly generated. Player picks 4 digits between 1 and
//6 attempting to match the randomly generated digits. Player has 10 attempts. 
//+ indicates a complete match both in digit and location.
//- indicates a digit match only, not location.
//Summary of plus sign and minus sign digits provided at end of each attempt.
//Match all 4 digits, receive congratulatory message.
//Exhaust all 10 attempts, receive Game Over notification.

using System;

namespace Quadax_Programming_Exercise_001__David_Faight_
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] playerStrArray = { "", "", "", "", "" };
            int[] playerIntArray = { 0, 0, 0, 0 };
            bool parseOk = false;
            int dsplyDgt = 1;
            int[] rndDgt = { 0, 0, 0, 0 };
            bool match = false;
            int totalMatch = 0;
            int[] locMatch = { 0,0,0,0}; //digit and location match
            int[] digMatch = { 0, 0, 0, 0 };  //digit match only

            //Random 4 digit generation***********************************************
            Random rnd = new Random();
            for (int r = 0; r < 4; r++)
            {
                rndDgt[r] = rnd.Next(1,7);
                
                for(int s=3; s >= 0; s--) //eliminates duplicate digits
                {
                    if (rndDgt[r] == rndDgt[s] && r!=s) 
                    {
                        rndDgt[r] = rnd.Next(1, 7);
                        s=3; //s=3 last number sometimes gets duplicated
                    }
                }//end s for loop
            }//end r for loop
            //Random 4 digit generation***********************************************

        for(int a = 10; a >= 0; a--)//a for attempts 
        {
            //Player's attempts*******************************************************
            if (a == 10) { 
                Console.WriteLine($"Greetings, Please enter 4 digits between 1 and 6.\n");
            }
            else
            {
                    if (totalMatch == 4)
                    {
                        Console.WriteLine($"You are the Digit Matching Champion!!!");
                        break;
                    }
                    if (a == 0)
                    {
                        Console.WriteLine($"You have exhausted all attempts, You Lose, Game Over!!!");
                        break;
                    }
                    totalMatch = 0;
                Console.WriteLine($"\nTry Again, you have {a} attempts remaining.");
            }
                for (int i = 0; i < 4; i++) 
                {
                //read in digit
                Console.Write($"Enter Digit {dsplyDgt}: ");
                playerStrArray[i] = Console.ReadLine();
                
                //validate input
                parseOk = int.TryParse(playerStrArray[i], out playerIntArray[i]);
                if (!parseOk)
                {
                    Console.WriteLine($"Invalid input, must be digit between 1 and 6. Try Again.\n");
                    i--;
                    continue;
                }
                else
                {
                    //range validation
                    if (playerIntArray[i] > 6 || playerIntArray[i] < 1)
                    {
                        Console.WriteLine("Invalid input, must be digit between 1 and 6. Try Again.\n");
                        i--;
                        continue;
                    }//if all clear, enter digit prompt increased
                    else { dsplyDgt++;  }
                    
                }
                
            }//end i for loop****************************************************
            //Player's attempts*******************************************************            
        for(int m = 0; m < 4; m++)
            {
                match = false;
                if (playerIntArray[m] == rndDgt[m])//check complete match
                {
                    Console.Write($"+");
                        totalMatch++;
                    match = true;
                        locMatch[m]=playerIntArray[m];
                    continue;
                }
                else
                {
                    for(int n = 3; n >= 0; n--)//check for digit match only
                    {
                        if (playerIntArray[m] == rndDgt[n])
                        {
                            Console.Write($"-" );
                            match = true;
                            digMatch[m] = playerIntArray[m];
                            continue;
                        }
                    }
                     }//if no match, print blank space
                if (match == false) {
                  //Console.Write($"{playerIntArray[m]}"); initially had non matched digit displayed
                        Console.Write($" ");//prints space in non matched position
                    }

                }
        //Summaries
        //Complete Matches *****************************************************************
                Console.WriteLine($"\nComplete Match (Digit & Location) indicated by + sign:");
                for(int p = 0; p < 4; p++)
                {
                    if (locMatch[p] == 0) 
                    {
                        Console.Write($"");
                    }
                    else
                    {
                        Console.Write($"{locMatch[p]}");
                    }
                }
                Console.WriteLine();
        //Matched digit, NOT location**************************************************************
                Console.WriteLine($"\nMatched Digit, NOT Location indicated by - sign:");
                for (int q = 0; q < 4; q++)
                {
                    if (digMatch[q] == 0)
                    {
                        Console.Write($"");
                    }
                    else
                    {
                        Console.Write($"{digMatch[q]}");
                    }
                }
                Console.WriteLine();
                dsplyDgt = 1;
                //clear out summaries
                Array.Clear(locMatch, 0, locMatch.Length);
                Array.Clear(digMatch, 0, digMatch.Length);
            }// end attempts loop
        }//end MAIN
    }
}
