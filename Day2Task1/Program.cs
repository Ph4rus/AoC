﻿var lines = File.ReadLines("input.txt");

var games = lines.Select(CreateGame).ToList();

Console.WriteLine(games.Where(g => g.Valid).ToList().Sum(g => g.GameNumber));

Console.ReadKey();
return;

Game CreateGame(string line)
{
    var doo = line.Split(":");

    var rounds = CreateRounds(doo.Last());

    return new Game(Convert.ToInt32(doo.First().Split(" ").Last()), rounds.All(c => c.Valid));
}

IEnumerable<Round> CreateRounds(string game)
{
    var doo = game.Split(";");

    return doo.Select(CreateStones).Select(stones => new Round(ValidateRound(stones))).ToList();
}

bool ValidateRound(IEnumerable<Stones> stones)
{
    var valid = stones.Select(IsValid).ToList();

    return valid.All(c => c);
}

bool IsValid(Stones stone) => stone.Color switch
{
    Color.Blue => stone.Number <= 14,
    Color.Red => stone.Number <= 12,
    Color.Green => stone.Number <= 13
};

List<Stones> CreateStones(string line)
{

    var doo = line.Split(",");

    return doo.Select(CreateStone).ToList();
}

Stones CreateStone(string stones)
{
    var doo = stones.Trim().Split(" ");

    return new Stones(ParseEnum<Color>(doo.Last()), Convert.ToInt32(doo.First()));
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