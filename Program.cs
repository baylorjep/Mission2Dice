using System;

public class DiceSimulator
{
    private const int NumSides = 6;

    public int[] SimulateRolls(int numRolls)
    {
        Random random = new Random();
        int[] results = new int[11]; // Index 0 is not used, as dice combination starts from 2.

        for (int i = 0; i < numRolls; i++)
        {
            int dice1 = random.Next(1, NumSides + 1);
            int dice2 = random.Next(1, NumSides + 1);
            int sum = dice1 + dice2;

            results[sum - 2]++;
        }

        return results;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the dice throwing simulator!");
        Console.Write("How many dice rolls would you like to simulate? ");
        int numRolls = Convert.ToInt32(Console.ReadLine());

        DiceSimulator diceSimulator = new DiceSimulator();
        int[] results = diceSimulator.SimulateRolls(numRolls);

        Console.WriteLine("\nDICE ROLLING SIMULATION RESULTS");
        Console.WriteLine("Each \"*\" represents 1% of the total number of rolls.");

        int totalRolls = results.Sum();
        Console.WriteLine($"Total number of rolls = {totalRolls}.");

        for (int i = 2; i <= 12; i++)
        {
            int percentage = results[i - 2] * 100 / totalRolls;
            string asterisks = new string('*', percentage);
            Console.WriteLine($"{i}: {asterisks}");
        }

        Console.WriteLine("\nThank you for using the dice throwing simulator. Goodbye!");
    }
}
