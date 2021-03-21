namespace P02.BattlePoints
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Enemy
    {
        public int BattlePoints { get; set; }

        public int EnergyToDefead { get; set; }
    }

    public class Program
    {
        private static List<Enemy> enemies;
        private static int personalEnergy;
        private static int[,] battlePointsInfo;
        public static void Main()
        {
            ReadInput();
            FindMaximumBattlePoint();
            PrintResult();
        }

        private static void PrintResult()
        {
            Console.WriteLine(battlePointsInfo[enemies.Count, personalEnergy]);
            var enemiesDefeaded = ReconstructPath();
            Console.WriteLine(string.Join(", ", enemiesDefeaded));
        }

        private static Stack<int> ReconstructPath()
        {
            var output = new Stack<int>();

            var currRow = enemies.Count;
            var currCol = personalEnergy;

            while (currRow > 0 && currCol > 0)
            {
                if (battlePointsInfo[currRow, currCol] != battlePointsInfo[currRow - 1, currCol])
                {
                    output.Push(currRow - 1);
                    currCol -= enemies[currRow - 1].EnergyToDefead;
                }

                currRow--;
            }

            return output;
        }

        private static void FindMaximumBattlePoint()
        {
            var rows = enemies.Count + 1;
            var cols = personalEnergy + 1;

            battlePointsInfo = new int[rows, cols];

            for (int enemyIndx = 0; enemyIndx < battlePointsInfo.GetLength(0) - 1; enemyIndx++)
            {
                var currEnemy = enemies[enemyIndx];

                for (int currEnergy = 1; currEnergy < battlePointsInfo.GetLength(1); currEnergy++)
                {
                    var excludingValue = battlePointsInfo[enemyIndx, currEnergy];

                    if (currEnemy.EnergyToDefead > currEnergy)
                    {
                        battlePointsInfo[enemyIndx + 1, currEnergy] = excludingValue;
                        continue;
                    }

                    var includingValue = currEnemy.BattlePoints + battlePointsInfo[enemyIndx, currEnergy - currEnemy.EnergyToDefead];

                    battlePointsInfo[enemyIndx + 1, currEnergy] = Math.Max(excludingValue, includingValue);
                }
            }
        }

        private static void ReadInput()
        {
            var energyRequiredInfo = ReadArray();
            var battlePointsGivenInfo = ReadArray();

            enemies = CreateEnemies(energyRequiredInfo, battlePointsGivenInfo);

            personalEnergy = int.Parse(Console.ReadLine());
        }

        private static List<Enemy> CreateEnemies(int[] energyRequiredInfo, int[] battlePointsGivenInfo)
        {
            var output = new List<Enemy>();

            for (int i = 0; i < energyRequiredInfo.Length; i++)
            {
                var newEnemy = new Enemy
                {
                    EnergyToDefead = energyRequiredInfo[i],
                    BattlePoints = battlePointsGivenInfo[i]
                };

                output.Add(newEnemy);
            }

            return output;
        }

        private static int[] ReadArray()
        {
            return Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
        }
    }
}
