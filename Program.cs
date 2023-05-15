using System;

class Program {
    static void Main(string[] args) {
        double Vmax, Vdrink, Vfill;
        int tdrink, tfill, tday;
        bool x;

        Console.WriteLine("Enter the capacity of the water tank (Vmax):");
        Vmax = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter the average volume of water that participants drink during each break (Vdrink):");
        Vdrink = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter the volume of water that can be added in each water-filling cycle (Vfill):");
        Vfill = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter the interval between rest periods (tdrink):");
        tdrink = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the interval between filling cycles (tfill):");
        tfill = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the total duration of the activity from start to finish of the day (tday):");
        tday = int.Parse(Console.ReadLine());

        int numWaterBreaks = tday / tdrink;
        int numWaterFills = (tday - tfill) / tfill;
        double remainingWater = Vmax;

        for (int i = 0; i <= numWaterBreaks; i++) {

            remainingWater -= Vdrink + 2;

            if (remainingWater >= Vdrink) {
                Console.WriteLine($"Enough water, {Math.Max(remainingWater - 1, 0)} left");
                
            } else {
                Console.WriteLine("Not Enough Water");
                }

            if (i * tdrink % tfill == 0) {
                remainingWater = Math.Min(Vmax, remainingWater + Vfill);
                Console.WriteLine("Overflow Water");
                return;
            }
            
        }      
    }
}