using System;
using System.Threading;
using System.Collections.Generic;

namespace MindfullnessApp
{
    class ReflectionActivity : Activity
    {
        private string GetRandomPrompt()
        {
            List<string> experienceQuestions = new List<string>
            {
                "Think of a time when you stood up for someone else.",
                "Think of a time when you did something really difficult.",
                "Think of a time when you helped someone in need.",
                "Think of a time when you did something truly selfless."
            };

            Random rand = new Random();

            int randomExperienceIndex = rand.Next(experienceQuestions.Count);
            string randomExperienceQuestion = experienceQuestions[randomExperienceIndex];
            return randomExperienceQuestion;

        }

        private List<string> GetRandomQuestions()
        {
            List<string> significanceQuestions = new List<string>
            {
                "Why was this experience meaningful to you?",
                "Have you ever done anything like this before?",
                "How did you get started?",
                "How did you feel when it was complete?",
                "What made this time different than other times when you were not as successful?",
                "What is your favorite thing about this experience?",
                "What could you learn from this experience that applies to other situations?",
                "What did you learn about yourself through this experience?",
                "How can you keep this experience in mind in the future?"
            };

            Random rand = new Random();

            List<string> randomSignificanceQuestions = new List<string>();
            while (randomSignificanceQuestions.Count < 3)
            {
                int randomSignificanceIndex = rand.Next(significanceQuestions.Count);
                string randomSignificanceQuestion = significanceQuestions[randomSignificanceIndex];
                if (!randomSignificanceQuestions.Contains(randomSignificanceQuestion))
                {
                    randomSignificanceQuestions.Add(randomSignificanceQuestion);
                }
            }
            return randomSignificanceQuestions;
        }

        public void ReflectionExercise()
        {
            Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life. After you continue, you will have 30 seconds to answer each question.");
            Console.WriteLine("Here is your prompt: ");
            Console.WriteLine($"\n{GetRandomPrompt()}");
            Console.WriteLine("Press backspace to continue...");
            Console.ReadKey();

            List<string> randomSignificanceQuestions = GetRandomQuestions();
            foreach (string question in randomSignificanceQuestions)
            {
                Console.WriteLine(question);
                RunTimer(30, true);

            }
            GoodbyeMessage("Reflection");

        }

    }
}
