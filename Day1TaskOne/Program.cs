var lines = File.ReadLines("input.txt");

var sum = lines.Sum(
    line =>
        Convert.ToInt32(
            line.First(char.IsNumber).ToString() + line.Reverse().First(char.IsNumber))
        );

Console.WriteLine(sum);
Console.ReadKey();