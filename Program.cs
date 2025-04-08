using System;
using System.Security.Cryptography.X509Certificates;

namespace MultiplicationApplication;

public class MainProgram
{
    public class MultiplicationApplication()
    {
        public static void Main(string[] args)
        {
            // Variable definitions
            string StartMessage = "Lets begin the Multiplication MADNESS!!";
            string AppName = "-*-MultiplicationMadness-*-";
            string[] Incorrect = ["Unlucky, you can do the next one!", "Don't be too down, you got this!", "Worry not, practice makes perfect!", "Incorrect, don't worry though, you can get the next one!"];
            string[] Correct = ["Great Job!", "Keep up the good work!", "Spectacular Work!", "Amazing work , keep it up!"];
            string InvalidInput = "Please enter a valid number between 1 and 100";
            
            // Random Number Generator for Array messages
            Random randomNumberOne = new Random();
            
            // Application Name output
            Console.WriteLine(AppName);

            // Game Boolean
            bool ApplicationRunning = true;

            while (ApplicationRunning)
            {
                Console.WriteLine("Do you want to start the game? (Y/N)"); // User instruction
                // User input Y or N
                string UserDecision = Console.ReadLine();
                // Trims any white space between characters ~ before and after the string
                UserDecision = UserDecision.Trim();
                
                // Checks User decision statement
                if (UserDecision.ToUpper() == "Y")
                {
                    // Start Message with basic instruction
                    Console.WriteLine(StartMessage);
                    Thread.Sleep(1500); // Console sleeps for 1.5 seconds

                    // Incremental Number Variable
                    int i = 0;
                    int Score = 0;

                    // Game while loop
                    while (i < 10)
                    {
                        // Rnd Number variable
                        int NumOne = randomNumberOne.Next(1, 11);
                        int NumTwo = randomNumberOne.Next(1, 11);

                        // Random string variable
                        int rndString = randomNumberOne.Next(0, 4);

                        // Answer definition
                        int Answer = NumOne * NumTwo;

                        Thread.Sleep(10); // Console stops for .01 seconds
                        Console.Clear(); // Clears previous outputs

                        // Score Keeper
                        Console.WriteLine($"Current score: {Score}");
                        // Question definition
                        string Question = $"What is {NumOne} x {NumTwo}?";

                        // Printing to console
                        Console.WriteLine(Question);

                        // User Input
                        int UserAnswer;

                        // checks user input for invalid information ~ non numeric data or out of range
                        while (true)
                        {
                            try // checks if the user information is in the correct format, will loop until its correct
                            {
                                UserAnswer = Convert.ToInt32(Console.ReadLine()); // Data required to be integer
                                if (UserAnswer < 0 || UserAnswer > 100) // Data criteria
                                {
                                    Console.WriteLine(InvalidInput);
                                }
                                break;
                            }
                            catch (FormatException) // If data is not in the same format
                            {
                                Console.WriteLine(InvalidInput); // Outputs incorrect information entered
                            }
                        }
                        // Answer Check
                        if (UserAnswer != Answer) // if not the same as answer
                        {
                            Console.WriteLine(Incorrect[rndString]); // Selects random string from array
                        }
                        else if (UserAnswer == Answer) // if correct
                        {
                            Console.WriteLine(Correct[rndString]); // Selects random string from array
                            Score++; // increments score by 1
                        }
                        i++; // increments question count by 1
                        Thread.Sleep(1000); // console pauses for 1 second
                        Console.Clear(); // clears previous outputs to console
                    }
                    // Outputs Final score after all questions have been answer
                    Console.WriteLine($"Well Done! You got {Score}/{i} correct!");

                }
                else if(UserDecision.ToUpper() == "N") // User decision will close the application if N is chosen at the beginning
                {
                    Console.Clear();
                    ApplicationRunning = false;
                } 
                else //any input that isnt Y or N will output this prompt
                {
                    Console.WriteLine("Please enter Y or N as your decision.");
                }
                ApplicationRunning = false; // Closes the loop
            }
            // Provides 2.5 seconds before closing the console.
            Thread.Sleep(2500);
            Console.Clear();
            Environment.Exit(0);
        }
    }
}
