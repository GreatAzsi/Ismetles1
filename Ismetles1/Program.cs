namespace Ismetles1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Bevezetés

            Console.WriteLine("Adj meg tetszőleges mennyiségű egész számokat egyetlen sorban, vesszővel elválasztva.");
            List<int> szamok = Console.ReadLine().Split(',').Select(int.Parse).ToList();
            foreach (int i in szamok)
            {
                Console.WriteLine(i);
            }

            // 1. feladat
            // Adja vissza a listában lévő legnagyobb számot
            int max = szamok.Max();
            Console.WriteLine("A legnagyobb szám: " + max);

        }
    }
}
