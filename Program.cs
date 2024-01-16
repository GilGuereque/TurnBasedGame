using TurnBasedGame;

Unit player = new Unit(100, 25, 13, "Player1");
Unit enemy = new Unit(80, 11, 8, "Lich King");

Console.WriteLine("It is the player turn! What will you choose to do?");
string playerChoice = Console.ReadLine();

if (playerChoice == "attack")
{
    player.Attack(enemy);
}
