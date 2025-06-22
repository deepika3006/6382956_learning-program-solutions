using System;
using System.Collections.Generic;

class FinancialForecasting
{
    static void Main()
    {
        List<double> expenses = new List<double>();
        Console.WriteLine("Enter your monthly expenses for the last 6 months:");

        for (int i = 1; i <= 6; i++)
        {
            Console.Write("Month " + i + " expense (₹): ");
            string? input = Console.ReadLine();
            double value;

            if (double.TryParse(input, out value))
            {
                expenses.Add(value);
            }
            else
            {
                Console.WriteLine("Invalid input, try again.");
                i--; 
            }
        }

        Console.WriteLine("\nYour Entered Expenses:");
        for (int i = 0; i < expenses.Count; i++)
        {
            Console.WriteLine("Month " + (i + 1) + ": ₹" + expenses[i]);
        }

        if (expenses.Count >= 2)
        {
            double last = expenses[expenses.Count - 1];
            double secondLast = expenses[expenses.Count - 2];
            double change = last - secondLast;
            double trendForecast = last + change;
            Console.WriteLine("\n Trend-based Forecast for next month: ₹" + Math.Round(trendForecast, 2));
        }

        if (expenses.Count >= 3)
        {
            double sum = 0;
            for (int i = expenses.Count - 3; i < expenses.Count; i++)
            {
                sum += expenses[i];
            }
            double movingAvg = sum / 3;
            Console.WriteLine("3-Month Moving Average Forecast: ₹" + Math.Round(movingAvg, 2));
        }

        Console.WriteLine("\nThank you for using the forecast tool!");
    }
}
