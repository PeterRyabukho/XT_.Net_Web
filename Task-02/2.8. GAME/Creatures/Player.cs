using System;
using System.Collections.Generic;
using System.Text;

namespace _2._8._GAME
{
    class Player: Creature
    {
        public Player(int x, int y):base(x, y, health: 0, atackPower: 0)
        {

        }
        public Player() :this(x:0,y:0,health: 100, atackPower: 40)
        {

        }
        public Player(int x, int y, int health, int atackPower):base(x,y,health,atackPower)
        {

        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0)
                Health = 0;
        }

        public int Healing(int heal)
        {
            Health += heal;
            if(Health>=100)
            {
                heal = Health - 100;
                Health = 100;
            }
            return heal;
        }
    }
}
