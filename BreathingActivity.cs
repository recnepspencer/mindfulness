using System;
using System.Threading;

namespace MindfullnessApp
{
    class BreathingActivity : Activity
    {
        private int GetRoundCount()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("How many rounds would you like to do for this session? (1-10)");
                    int roundCount = int.Parse(Console.ReadLine());
                    if (roundCount >= 1 && roundCount <= 10)
                        return roundCount;

                    Console.WriteLine("Please enter a valid number between 1 and 10.");
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        private int GetBreathIn()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("What interval would you like for your box breathing? (1-10)");
                    int breathIn = int.Parse(Console.ReadLine());
                    if (breathIn >= 1 && breathIn <= 10)
                        return breathIn;

                    Console.WriteLine("Please enter a valid number between 1 and 10.");
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        public void BreathingExercise()
        {
            Console.Clear();
            Console.WriteLine("This exercise will help you focus on your breathing...");

            int roundCount = GetRoundCount();
            int breathIn = GetBreathIn();

            for (int i = 0; i < roundCount; i++)
            {
                CountDown("Breathe in", breathIn);
                CountDown("Hold", breathIn);
                CountDown("Breathe out", breathIn);
                CountDown("Hold", breathIn);
            }
            GoodbyeMessage("Breathing");
        }
        private void CountDown(string action, int duration)
        {
            for (int i = duration; i > 0; i--)
            {
                Console.Clear();
                Console.WriteLine($"{action} {i}");
                Thread.Sleep(1000);
            }
        }
    }
}
