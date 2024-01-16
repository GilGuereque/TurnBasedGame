using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedGame
{
    internal class Unit
    {
        private int currentHp;
        private int maxHp;
        private int attackPower;
        private int healPower;
        private string unitName;
        private Random random;

        public int Hp { get { return currentHp; } }

        public string UnitName { get { return unitName; } }

        public bool IsDead { get { return currentHp <= 0; } }

        // Creating a Unit constructor to use for our enemy & player classes
        public Unit(int maxHp, int attackPower, int healPower, string unitName)
        {
            this.maxHp = maxHp;
            this.currentHp = maxHp;
            this.attackPower = attackPower;
            this.healPower = healPower;
            this.unitName = unitName;
            this.random = new Random();
        }

        // Build out the Attack method 
        public void Attack(Unit unitToAttack)
        {
            double rng = random.NextDouble();
            rng = rng / 2 + 0.75f; // Change the dmg range betweent 0.75% to 1.25%
            int randDamage = (int)(attackPower * rng);
            unitToAttack.TakeDamage(randDamage);
            Console.WriteLine(unitName + " attacks " + unitToAttack.unitName + " and deals " + randDamage + " damage! Ouch.");
        }

        // TakeDamage method with lowers the Units HP & checks if they are dead yet
        public void TakeDamage(int damage)
        {
            currentHp -= damage;

            if(IsDead)
            {
                Console.WriteLine(UnitName + " has been defeated! Victory!");
            }
        }

        // Heal method the player or enemy can use to heal themselves
        public void Heal()
        {
            double rng = random.NextDouble();
            rng = rng / 2 + 0.75f;
            int heal = (int)(rng * healPower);
            currentHp = heal + currentHp > maxHp ? maxHp : currentHp + heal;
            Console.WriteLine(UnitName + " heals by " + heal + " points. Nice!");
        }
    }

}
