var lines = File.ReadLines("input.txt");

var games = lines.Select(CreateGame);

Console.WriteLine(games.Where(g => g.Valid).Sum(g => g.GameNumber));

Console.ReadKey();
return;

Game CreateGame(string line)
{
    var doo = line.Split(": ");

    var rounds = CreateRounds(doo.Last());

    return new Game(int.Parse(doo.First().Split(" ").Last()), rounds.All(c => c.Valid));
}

List<Round> CreateRounds(string game)
{
    var splitGame = game.Split("; ");

    return splitGame.Select(CreateStones).Select(stones => new Round(ValidateRound(stones))).ToList();
}

bool ValidateRound(List<Stones> stones)
=> stones.Select(IsValid).All(c => c);


bool IsValid(Stones stone) => stone.Color switch
{
    Color.Blue => stone.Number <= 14,
    Color.Red => stone.Number <= 12,
    Color.Green => stone.Number <= 13
};

List<Stones> CreateStones(string line)
{
    var stones = line.Split(", ");

    return stones.Select(CreateStone).ToList();
}

Stones CreateStone(string input)
{
    var stones = input.Split(" ");

    return new Stones(ParseEnum<Color>(stones.Last()), Convert.ToInt32(stones.First()));
}

static T ParseEnum<T>(string value)
{
    return (T) Enum.Parse(typeof(T), value, true);
}

internal enum Color
{
    Blue,
    Red,
    Green
}

internal record Game(int GameNumber, bool Valid);

internal record Round(bool Valid);

internal record Stones(Color Color, int Number);