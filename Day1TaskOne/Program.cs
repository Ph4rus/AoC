var lines = File.ReadLines("input.txt");

int sum = 0;

foreach (var line in lines)
{
    sum += Convert.ToInt32(
        line.First(
            c => char.IsNumber(c)
            ).ToString() 
        + line.Reverse().
            First(
                c => char.IsNumber(c)
                )
        );
}

Console.WriteLine(sum);
Console.ReadKey();