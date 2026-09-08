using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ismetles1;
using System.Diagnostics.CodeAnalysis;

// Bevezetés

Console.WriteLine("Adj meg tetszőleges mennyiségű egész számokat egyetlen sorban, vesszővel elválasztva.");
List<int> szamok = Console.ReadLine().Split(',').Select(int.Parse).ToList();
foreach (int i in szamok)
{
    Console.WriteLine(i);
}

Console.WriteLine("----------------------------------------------");
// 1. feladat
// Adja vissza a listában lévő legnagyobb számot
int max = szamok.Max();
Console.WriteLine("A legnagyobb szám: " + max);

Console.WriteLine("----------------------------------------------");
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

Console.WriteLine("----------------------------------------------");
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

Console.WriteLine("----------------------------------------------");
// 4.feladat
// Adja vissza egy új listában az összes negatív számot.
List<int> negativSzamok = new List<int>();
foreach (int i in szamok)
{
    if (i < 0)
    {
        negativSzamok.Add(i);
    }
}
Console.WriteLine("A negatív számok: " + string.Join(", ", negativSzamok));

Console.WriteLine("----------------------------------------------");
// 5.feladat
// Add vissza a listában lévő számok közül a három legnagyobbat (Linq-t már ajánlott használni)
// Ha a listában háromnál kevesebb szám található,akkor az összes rendelkezésre álló számot adja vissza.
List<int> haromLegnagyobb = szamok.OrderByDescending(x => x).Take(3).ToList();
Console.WriteLine("A három legnagyobb szám: " + string.Join(", ", haromLegnagyobb));

Console.WriteLine("----------------------------------------------");
// 2/3. feladat
// Készíts konstruktort, amelyben meghívod a filebeolvasásra szolgáló függvényt.
var result = FileManager.Readfile("planes.txt");
List<Plane> Planes = result.Item1;
List<PlaneType> PlaneTypes = result.Item2;

foreach (Plane plane in Planes)
{
    Console.WriteLine(plane.PlaneName);
}
foreach (PlaneType planetype in PlaneTypes)
{
    Console.WriteLine(planetype.TypeName);
}


Console.WriteLine("----------------------------------------------");
// 2/4. feladat
// Készíts függvényt, amely paraméterként kap egy repülőgéptípust.
// Add vissza azoknak a repülőgépeknek a neveit, amelyek az adott típushoz tartoznak.
List<Plane> searchedPlanes = new List<Plane>();
searchedPlanes = PlaneType.SearchFromTypeName(Planes, PlaneTypes, "Commercial Airliner");
foreach (Plane plane in searchedPlanes)
{
    Console.WriteLine(plane.PlaneName);
}


Console.WriteLine("----------------------------------------------");
// 2/5. feladat
// Készíts függvényt, amely paraméterként kap egy évszámot.
// Add vissza azoknak a repülőgépeknek a neveit, amelyek a paraméterként megkapott évben már léteztek.
List<Plane> searchedPlanes2 = new List<Plane>();
searchedPlanes2 = Plane.SearchFromPlaneDate(Planes, 2000);
foreach (Plane plane in searchedPlanes2)
{
    Console.WriteLine(plane.PlaneName);
}

Console.WriteLine("----------------------------------------------");
// 6. feladat
// Készíts statisztikát, amely megmondja, hogy típusonként hány repülőgép tartozik az adott típushoz.
// Add vissza egy szótárban a típus nevét és a hozzá tartozó darabszámot.
var stats = PlaneType.CountPlanesByType(Planes, PlaneTypes);
foreach (var keyValue in stats)
{
    Console.WriteLine($"{keyValue.Key} -> {keyValue.Value}");
}

Console.WriteLine("----------------------------------------------");
// 7. feladat
// Készíts függvényt, amely megmondja,hogy az egyes típusokhoz tartozó repülőgépek közül mekkora a legnagyobb maximális sebesség.
// Add vissza egy szótárban a típus nevét és a hozzá tartozó sebességértéket.
var stats2 = PlaneType.MaxSpeedByType(Planes, PlaneTypes);
foreach (var keyValue in stats2)
{
    Console.WriteLine($"{keyValue.Key} -> {keyValue.Value}");
}

Console.WriteLine("----------------------------------------------");
// 8. feladat
// Készíts függvényt, amely visszaadja azoknak a repülőgépeknek a neveit ABC-sorrendben, amelyek neve legalább 3 szóból áll.
List<Plane> searchedPlanes3 = Plane.PlaneNamesWithMoreThan3WordsInABC(Planes);
foreach (Plane plane in searchedPlanes3)
    {
    Console.WriteLine(plane.PlaneName);
}