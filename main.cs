using System;

class Program {
  public static void Main (string[] args) {
    double[] temperatures = new double[5];
    bool isGettingWarmer = true, isGettingCooler = true;

    for (int i = 0; i < temperatures.Length; i++) {
      temperatures[i] = GetValidTemperature(i + 1);
      if (i > 0) {
        if (temperatures[i] <= temperatures[i - 1]) {
          isGettingWarmer = false;
        }
        if (temperatures[i] >= temperatures[i - 1]) {
          isGettingCooler = false;
        }
      }
    }

    DisplayTemperatures(temperatures);
    AnalyzeAndDisplayTemperatureTrend(isGettingWarmer, isGettingCooler);
    DisplayAverageTemperature(temperatures);
  }

  private static double GetValidTemperature(int day) {
    double temperature;
    Console.Write($"Enter temperature for day {day}: ");
    while (!double.TryParse(Console.ReadLine(), out temperature) || temperature < -30 || temperature > 130) {
      Console.WriteLine("Invalid temperature. Please enter a temperature between -30 and 130.");
      Console.Write($"Re-enter temperature for day {day}: ");
    }
    return temperature;
  }

  private static void DisplayTemperatures(double[] temperatures) {
    Console.Write("5-day Temperatures: [");
    for (int i = 0; i < temperatures.Length; i++) {
      Console.Write(temperatures[i] + (i < temperatures.Length - 1 ? ", " : ""));
    }
    Console.WriteLine("]");
  }

  private static void AnalyzeAndDisplayTemperatureTrend(bool isGettingWarmer, bool isGettingCooler) {
    if (isGettingWarmer) {
      Console.WriteLine("Getting warmer");
    } else if (isGettingCooler) {
      Console.WriteLine("Getting cooler");
    } else {
      Console.WriteLine("It's a mixed bag");
    }
  }

  private static void DisplayAverageTemperature(double[] temperatures) {
    double average = 0;
    foreach (double temp in temperatures) {
      average += temp;
    }
    average /= temperatures.Length;
    Console.WriteLine($"Average Temperature is {average:F1} degrees");
  }
}
