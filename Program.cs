using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnBasedGame;

namespace TurnBasedGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Unit player = new Unit(100, 25, 13, "Player1");
            Unit enemy = new Unit(80, 11, 8, "Lich King");
            Random random = new Random();
            // while loop to keep game going if the player or enemy is not dead
            while(!player.IsDead && !enemy.IsDead)
            { 
                Console.WriteLine(player.UnitName + " HP = " + player.Hp + ". " + enemy.UnitName + " HP = " + enemy.Hp);
                Console.WriteLine("It is the player turn now! What will you choose to do? Enter in your choice: 'attack' or 'heal' ");
                string playerChoice = Console.ReadLine();

                if (playerChoice == "attack")
                {
                    player.Attack(enemy);
                }
                else
                {
                    player.Heal();
                }
                // if player or enemy is dead break out of the loop
                if (player.IsDead || enemy.IsDead) break;
                Console.WriteLine(player.UnitName + " HP = " + player.Hp + ". " + enemy.UnitName + " HP = " + enemy.Hp);

                Console.WriteLine("It is now the enemy turn!");
                // logic using Random to decide if 0 the enemy attacks, else it will heal
                int rand = random.Next(0, 2);

                if (rand == 0)
                {
                    enemy.Attack(player);
                }
                else
                {
                    enemy.Heal();
                }

            }
        }
    }
}