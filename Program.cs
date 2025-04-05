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
            string StartMessage = "Welcome!";
            string AppName = "-*-MultiplicationMadness-*-";
            string[] Incorrect = ["Unlucky, you can do the next one!", "Don't be too down, you got this!", "Worry not, practice makes perfect!", "Incorrect, don't worry though, you can get the next one!"];
            string[] Correct = ["Great Job!", "Keep up the good work!", "Spectacular Work!", "Amazing work , keep it up!"];
            string InvalidInput = "Please enter a valid number between 1 and 100";
            
            // Random Number Generator for Array messages
            Random randomNumberOne = new Random();
            

            Console.WriteLine(AppName);

            // Game Boolean
            bool ApplicationRunning = true;

            while (ApplicationRunning)
            {
                Console.WriteLine("Do you want to start the game? (Y/N)");
                string UserDecision = Console.ReadLine();
                
                if (UserDecision.ToUpper() == "Y")
                {
                    // Start Message with basic instruction
                    Console.WriteLine(StartMessage);
                    Thread.Sleep(300);

                    // Incremental Number Variable
                    int i = 0;
                    int Score = 0;

                    while (i < 10)
                    {
                        // Rnd Number variable
                        int NumOne = randomNumberOne.Next(1, 11);
                        int NumTwo = randomNumberOne.Next(1, 11);

                        int rndString = randomNumberOne.Next(0, 4);

                        // Answer definition
                        int Answer = NumOne * NumTwo;

                        Thread.Sleep(10);
                        Console.Clear();

                        // Score Keeper
                        Console.WriteLine($"Current score: {Score}");
                        // Question definition
                        string Question = $"What is {NumOne} x {NumTwo}?";

                        // Printing to console
                        Console.WriteLine(Question);

                        // User Input

                        int UserAnswer;

                        while (true)
                        {
                            try
                            {
                                UserAnswer = Convert.ToInt32(Console.ReadLine());
                                if (UserAnswer < 0 || UserAnswer > 100)
                                {
                                    Console.WriteLine(InvalidInput);
                                }
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine(InvalidInput);
                            }
                        }

                        if (UserAnswer != Answer)
                        {
                            Console.WriteLine(Incorrect[rndString]);
                        }
                        else if (UserAnswer == Answer)
                        {
                            Console.WriteLine(Correct[rndString]);
                            Score++;
                        }
                        i++;
                        Thread.Sleep(1000);
                        Console.Clear();
                    }
                    Console.WriteLine($"Well Done! You got {Score}/{i} correct!");

                }
                else if(UserDecision.ToUpper() == "N")
                {
                    Console.Clear();
                    ApplicationRunning = false;
                } else
                {
                    Console.WriteLine("Incorrect data entry, please enter Y or N.");
                }
                ApplicationRunning = false;
            }
            
            Thread.Sleep(3500);
            Console.Clear();
            Environment.Exit(0);
        }
    }
}
