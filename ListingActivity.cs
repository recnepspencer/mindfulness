using System;
using System.Threading;

namespace MindfullnessApp
{
    class ListingActivity : Activity
    {
        private int GetContemplationCount()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("How long would you have to contemplate each prompt? (in seconds, up to 120)");
                    int roundCount = int.Parse(Console.ReadLine());
                    if (roundCount >= 1 && roundCount <= 120)
                        return roundCount;

                    Console.WriteLine("Please enter a valid number between 1 and 120.");
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        private int GetListTimer()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("How much time do you want to make your list? (in seconds, up to 120)");
                    int breathIn = int.Parse(Console.ReadLine());
                    if (breathIn >= 1 && breathIn <= 120)
                        return breathIn;

                    Console.WriteLine("Please enter a valid number between 1 and 120.");
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        private string GetRandomPrompt()
        {
            List<string> experienceQuestions = new List<string>
            {
                "Who are people that you appreciate?",
                "What are personal strengths of yours?",
                "Who are people that you have helped this week?",
                "When have you felt the Holy Ghost this month?",
                "Who are some of your personal heroes?"
            };

            Random rand = new Random();

            int randomExperienceIndex = rand.Next(experienceQuestions.Count);
            string randomExperienceQuestion = experienceQuestions[randomExperienceIndex];
            return randomExperienceQuestion;

        }

        protected void RunTimerWithInput(int seconds)
        {
            List<string> userInputs = new List<string>();
            DateTime startTime = DateTime.Now;

            while ((DateTime.Now - startTime).TotalSeconds < seconds)
            {
                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    userInputs.Add(input);
                }
            }

            // Do something with userInputs
            foreach (var input in userInputs)
            {
                Console.WriteLine($"You typed: {input}");
            }
        }

        public void ListingExercise()
        {
            Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
            int contTimer = GetContemplationCount();
            int listTimer = GetListTimer();
            Console.WriteLine($"Here is your prompt: {GetRandomPrompt()}");
            RunTimer(contTimer, true);
            Console.WriteLine("Now, make a list of as many things as you can think of that fit the prompt.");
            RunTimerWithInput(listTimer);

            GoodbyeMessage("Listing");


        }
    }
}
