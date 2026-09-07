using System.Diagnostics.CodeAnalysis;

namespace Ismetles1;

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

        // 2. feladat
        // Számítsa ki és adja vissza a listában található számok átlagát.
        // Figyelj arra, hogy az eredmény lebegőpontos szám legyen.
        int sum = 0;
        foreach (int i in szamok)
        {
            sum += i;
        }
        double atlag = (double)sum / szamok.Count;
        Console.WriteLine("A számok átlaga: " + atlag);

        // 3. feladat
        // Számolja meg és adja vissza,hogy hány darab 30-nál nagyobb szám található a listában.
        int count = 0;
        foreach (int i in szamok)
        {
            if (i > 30)
            {
                count++;
            }
        }
        Console.WriteLine("A 30-nál nagyobb számok száma: " + count);
    }
}
