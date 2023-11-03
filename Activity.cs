using System;
using System.Threading;

namespace MindfullnessApp
{
    class Activity
    {


        public void ShowMenu()
        {
            int choice = 0;
            bool continueProgram = true;

            while (continueProgram)
            {
                string menu = @"
Mindfulness App Menu:
1. Breathing Exercise
2. Reflection Exercise
3. Listing Exercise
4. Quit
                ";
                Console.WriteLine(menu);

                bool validInput = false;

                while (!validInput)
                {
                    try
                    {
                        Console.Write("Select an option: ");
                        choice = int.Parse(Console.ReadLine());

                        if (choice >= 1 && choice <= 4)
                        {
                            validInput = true;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid number between 1 and 4.");
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                    }
                }

                switch (choice)
                {
                    case 1:
                        BreathingActivity breathingActivity = new BreathingActivity();
                        breathingActivity.BreathingExercise();
                        break;
                    case 2:
                        ReflectionActivity reflectionActivity = new ReflectionActivity();
                        reflectionActivity.ReflectionExercise();
                        break;
                    case 3:
                        ListingActivity listingActivity = new ListingActivity();
                        listingActivity.ListingExercise();
                        break;
                    case 4:
                        Console.WriteLine("Exiting... Take care!");
                        continueProgram = false;
                        break;
                }
            }
        }


        protected void RunTimer(int seconds, bool showSpinner = false)
        {
            bool countDownIsRunning = true;
            Thread spinnerThread = null;

            if (showSpinner)
            {
                spinnerThread = new Thread(() =>
                {
                    char[] spinnerChars = new char[] { '/', '-', '\\', '|' };
                    int i = 0;
                    while (countDownIsRunning)
                    {
                        Console.Write("\r" + spinnerChars[i % 4]);
                        i++;
                        Thread.Sleep(100);
                    }
                });

                spinnerThread.Start();
            }

            // Run the timer on the main thread
            Thread.Sleep(seconds * 1000);

            // Stop the spinner
            countDownIsRunning = false;

            if (spinnerThread != null)
            {
                spinnerThread.Join();  // Wait for the spinner thread to complete
            }
        }

        protected void GoodbyeMessage(string activity)
        {
            Console.WriteLine($"You have finished the {activity} activity!");
        }


    }
}
