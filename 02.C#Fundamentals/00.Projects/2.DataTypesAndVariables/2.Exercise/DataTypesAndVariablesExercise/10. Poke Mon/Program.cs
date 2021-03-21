using System;

namespace _10._Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            int pokePowerN = int.Parse(Console.ReadLine());
            int pokePowerNCopy = pokePowerN;
            int distanceM = int.Parse(Console.ReadLine());
            int exhaustionFactorY = int.Parse(Console.ReadLine());

            int target = 0;
            while (pokePowerN >= distanceM)
            {
                pokePowerN -= distanceM;
                target++;
                if (pokePowerN == pokePowerNCopy * 0.5)
                {
                    if (exhaustionFactorY != 0)
                    {
                        pokePowerN /= exhaustionFactorY;
                    }
                }
            }

            Console.WriteLine(pokePowerN);
            Console.WriteLine(target);
        }
    }
}
