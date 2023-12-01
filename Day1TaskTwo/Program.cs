var lines = File.ReadLines("input.txt");

int sum = 0;


var numbers = Enum.GetValues(typeof(Numbers)).Cast<Numbers>().Select(e => e.ToString()).ToList();

numbers.AddRange(Enumerable.Range(1, 9).Select(n => n.ToString()).ToList());


foreach (var line in lines)
{
    var first = new List<Tuple<int, string>>();
    foreach (var num in numbers)
    {
        first.Add(new Tuple<int, string>(line.IndexOf(num), num));
    }
    
    first = first.OrderBy(c => c.Item1).ToList();
    
    var last = new List<Tuple<int, string>>();
    foreach (var num in numbers)
    {
        last.Add(new Tuple<int, string>(line.LastIndexOf(num), num));
    }
    
    last = last.OrderBy(c => c.Item1).ToList();

    var num1 = first.First(i => i.Item1 != -1);
    var num2 = last.Last();

    sum += Convert.ToInt32(ToInt(num1.Item2).ToString() + ToInt(num2.Item2));
}

int ToInt(string input)
{
    if (input.Length > 2)
    {
        return Convert.ToInt32(ParseEnum<Numbers>(input)) + 1;
    }

    return Convert.ToInt32(input);
}

static T ParseEnum<T>(string value)
{
    return (T) Enum.Parse(typeof(T), value, true);
}



Console.WriteLine(sum);
Console.ReadKey();




enum Numbers{
    one,
    two,
    three,
    four,
    five,
    six,
    seven,
    eight,
    nine
}