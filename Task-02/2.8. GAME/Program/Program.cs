using System;
using System.Collections.Generic;

namespace _2._8._GAME
{
    class Program
    {
        static void Main(string[] args)
        {
            Field gameField = new Field(Console.WindowHeight,Console.WindowWidth); //игровое поле
            GameConfig gameConfig = new GameConfig(); //настройки игры, ну типо того)

            Player player = new Player(0,0, health: 100, atackPower: 40); //игрок в начале координат

            List<Creature> enemy = new List<Creature>(5);
            List<Bonus> bonus = new List<Bonus>(4);
            List<Objects> hindrance = new List<Objects>(4);

            Random random = new Random();

            foreach (var item in enemy)
            {
                enemy.Add(new Wolf(random.Next(gameField.Width - 1), random.Next(gameField.Height - 1)));
                enemy.Add(new Wolf(random.Next(gameField.Width - 1), random.Next(gameField.Height - 1)));
                enemy.Add(new Bear(random.Next(gameField.Width - 1), random.Next(gameField.Height - 1)));
                enemy.Add(new Spider(random.Next(gameField.Width - 1), random.Next(gameField.Height - 1)));
                enemy.Add(new Spider(random.Next(gameField.Width - 1), random.Next(gameField.Height - 1)));
            }

            foreach (var item in bonus)
            {
                bonus.Add(new Apple(random.Next(gameField.Width - 1), random.Next(gameField.Height - 1)));
                bonus.Add(new Apple(random.Next(gameField.Width - 1), random.Next(gameField.Height - 1)));
                bonus.Add(new Cherry(random.Next(gameField.Width - 1), random.Next(gameField.Height - 1)));
                bonus.Add(new Cherry(random.Next(gameField.Width - 1), random.Next(gameField.Height - 1)));
            }

            foreach (var item in bonus)
            {
                hindrance.Add(new Tree(random.Next(gameField.Width - 1), random.Next(gameField.Height - 1)));
                hindrance.Add(new Stone(random.Next(gameField.Width - 1), random.Next(gameField.Height - 1)));
                hindrance.Add(new Tree(random.Next(gameField.Width - 1), random.Next(gameField.Height - 1)));
                hindrance.Add(new Tree(random.Next(gameField.Width - 1), random.Next(gameField.Height - 1)));
            }
        }
    }
}
