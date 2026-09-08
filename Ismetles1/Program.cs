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

Console.WriteLine("3----------------------------------------------");
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


Console.WriteLine("4----------------------------------------------");
// 2/4. feladat
// Készíts függvényt, amely paraméterként kap egy repülőgéptípust.
// Add vissza azoknak a repülőgépeknek a neveit, amelyek az adott típushoz tartoznak.
List<Plane> searchedPlanes = new List<Plane>();
searchedPlanes = PlaneType.SearchFromTypeName(Planes, PlaneTypes, "Commercial Airliner");
foreach (Plane plane in searchedPlanes)
{
    Console.WriteLine(plane.PlaneName);
}


Console.WriteLine("5----------------------------------------------");
// 2/5. feladat
// Készíts függvényt, amely paraméterként kap egy évszámot.
// Add vissza azoknak a repülőgépeknek a neveit, amelyek a paraméterként megkapott évben már léteztek.
List<Plane> searchedPlanes2 = new List<Plane>();
searchedPlanes2 = Plane.SearchFromPlaneDate(Planes, 2000);
foreach (Plane plane in searchedPlanes2)
{
    Console.WriteLine(plane.PlaneName);
}

Console.WriteLine("6----------------------------------------------");
// 6. feladat
// Készíts statisztikát, amely megmondja, hogy típusonként hány repülőgép tartozik az adott típushoz.
// Add vissza egy szótárban a típus nevét és a hozzá tartozó darabszámot.
var stats = PlaneType.CountPlanesByType(Planes, PlaneTypes);
foreach (var keyValue in stats)
{
    Console.WriteLine($"{keyValue.Key} -> {keyValue.Value}");
}

Console.WriteLine("7----------------------------------------------");
// 7. feladat
// Készíts függvényt, amely megmondja,hogy az egyes típusokhoz tartozó repülőgépek közül mekkora a legnagyobb maximális sebesség.
// Add vissza egy szótárban a típus nevét és a hozzá tartozó sebességértéket.
var stats2 = PlaneType.MaxSpeedByType(Planes, PlaneTypes);
foreach (var keyValue in stats2)
{
    Console.WriteLine($"{keyValue.Key} -> {keyValue.Value}");
}

Console.WriteLine("8----------------------------------------------");
// 8. feladat
// Készíts függvényt, amely visszaadja azoknak a repülőgépeknek a neveit ABC-sorrendben, amelyek neve legalább 3 szóból áll.
List<Plane> searchedPlanes3 = Plane.PlaneNamesWithMoreThan3WordsInABC(Planes);
foreach (Plane plane in searchedPlanes3)
    {
    Console.WriteLine(plane.PlaneName);
}

Console.WriteLine("9----------------------------------------------");
// 9. feladat
// Készíts függvényt, amely megmondja, hogy típusonként mennyi az átlagos sebesség.
// Add vissza egy szótárban a típus nevét és a hozzá tartozó lebegőpontos értéket.
var stats3 = PlaneType.AverageSpeedByType(Planes, PlaneTypes);
foreach(var keyValue in stats3)
{
    Console.WriteLine($"{keyValue.Key} -> {keyValue.Value}");
}

Console.WriteLine("10----------------------------------------------");
// 10. feladat
// Készíts függvényt, amely paraméterként kap egy minimum kapacitást.
// Add vissza azoknak a repülőgépeknek a neveit, amelyek kapacitása legalább akkora, mint a paraméterként kapott érték.
// Az eredményt rendezd kapacitás szerint növekvő sorrendbe.
List<string> searchedPlanes4 = Plane.SearchFromCapacity(Planes, 200);
foreach(string plane in searchedPlanes4)
{
    Console.WriteLine(plane);
}

Console.WriteLine("11----------------------------------------------");
// 11. feladat
// Készíts függvényt, amely paraméterként kap egy darabszámot.
// Add vissza a megadott darabszámú leggyorsabb repülőgép nevét.
// A repülőgépeket MaxSpeed alapján rendezd csökkenő sorrendbe.
//
// Például:
// ha a paraméter értéke 5,
// akkor az 5 leggyorsabb repülőgép nevét add vissza.
List<Plane> searchedPlanes5 = Plane.SortBySpeedAndParameter(Planes, 5);
foreach(Plane plane in searchedPlanes5)
{
    Console.WriteLine(plane);
}

Console.WriteLine("12----------------------------------------------");
// 12. feladat
// Készíts függvényt, amely paraméterként kap egy minimum és egy maximum kapacitást.
// Add vissza azoknak a repülőgépeknek a neveit, amelyek kapacitása a két megadott érték közé esik.
// Az eredményt rendezd ABC-sorrendbe.
List<Plane> searchedPlanes6 = Plane.CapacityBetweenTwoParameters(Planes, 100, 200);
foreach(Plane plane in searchedPlanes6)
{
    Console.WriteLine(plane);
}

Console.WriteLine("13----------------------------------------------");
// 13. feladat
// Készíts függvényt, amely paraméterként kap egy évszámot és egy minimum maximális sebességet.
// Add vissza azoknak a repülőgépeknek a neveit, amelyek a paraméterként kapott év után készültek, és maximális sebességük legalább akkora, mint a paraméterként kapott sebesség.
// Az eredményt MaxSpeed szerint csökkenő sorrendbe rendezd.
List<Plane> searchedPlanes7 = Plane.DateAndMinSpeed(Planes, 2000, 800);
foreach(Plane plane in searchedPlanes7)
{
    Console.WriteLine(plane);
}

Console.WriteLine("14----------------------------------------------");
// 14. feladat
// Készíts függvényt, amely paraméterként kap egy minimum kapacitást.
// A legalább ekkora kapacitású repülőgépek közül keresd meg a legnagyobb kapacitásút.
// Add vissza a repülőgép nevét.
Plane largestCapacityPlane = Plane.LargestCapacityAboveLimit(Planes, 200);
Console.WriteLine(largestCapacityPlane);

Console.WriteLine("15----------------------------------------------");
// 15. feladat
// Készíts függvényt, amely paraméterként kap egy repülőgéptípust.
// Az adott típushoz tartozó repülőgépek közül keresd meg a legrégebben gyártott repülőgépet.
// Add vissza a repülőgép nevét.
string OldestPlaneInSpecificType = PlaneType.OldestPlaneInSpecificType(Planes, PlaneTypes, "Commercial Airliner");
Console.WriteLine(OldestPlaneInSpecificType);

Console.WriteLine("16----------------------------------------------");
// 16. feladat
// Készíts függvényt, amely paraméterként kap egy évszámot.
// Számítsd ki azoknak a repülőgépeknek az átlagos kapacitását, amelyek a paraméterként kapott évben vagy azután készültek.
double averageCapacity = Plane.AverageCapacityInGivenYear(Planes, 2013);
Console.WriteLine(averageCapacity);

Console.WriteLine("17----------------------------------------------");
// 17. feladat
// Készíts függvényt, amely paraméterként kap egy szövegrészletet.
// Add vissza azoknak a repülőgépeknek a neveit, amelyek nevében szerepel a paraméterként kapott szöveg.
// A keresés során ne számítson,hogy kis- vagy nagybetűkkel adták meg a keresett kifejezést.
// Az eredményt ABC-sorrendben add vissza.
List<string> searchedPlanes8 = Plane.PlaneNamesWhichAreContainText(Planes, "Air");
foreach(string plane in searchedPlanes8)
{
    Console.WriteLine(plane);
}

Console.WriteLine("18----------------------------------------------");
// 18. feladat
// Készíts függvényt, amely paraméterként kap két szöveget.
// A két szöveg egy-egy repülőgépnév kezdete legyen.
// Add vissza azokat a repülőgépeket, amelyek neve az egyik vagy a másik paraméterként kapott szöveggel kezdődik.
// Például:
// "Airbus"
// "Boeing"
//
//Rendezd őket gyártási év szerint csökkenő sorrendbe.
List<string> searchedPlanes9 = Plane.PlaneNamesWhichStartWithText(Planes, "Airbus", "Boeing");
foreach (string plane in searchedPlanes9)
{
    Console.WriteLine(plane);
}

Console.WriteLine("19----------------------------------------------");
// 19. feladat
// Készíts függvényt, amely paraméterként kap egy repülőgéptípust és egy minimum sebességet.
// Add vissza az adott típushoz tartozó olyan repülőgépek neveit, amelyek maximális sebessége nagyobb, mint a paraméterként kapott minimum sebesség.
// Az eredményt MaxSpeed szerint csökkenő sorrendbe rendezd.
List<string> searchedPlanes10 = PlaneType.PlaneNamesWithTypeAndMinSpeed(Planes, PlaneTypes, "Commercial Airliner", 800);
foreach (string plane in searchedPlanes10)
{
    Console.WriteLine(plane);
}

Console.WriteLine("20----------------------------------------------");
// 20. feladat
// Készíts függvényt, amely típusonként kiszámítja az összes férőhely számát.
// Add vissza egy szótárban:
// TypeName -> összes Capacity
// Például:
// "Személyszállító" -> 1250
var stats4 = PlaneType.CountSeatsByType(Planes, PlaneTypes);
foreach (var keyValue in stats4)
{
    Console.WriteLine($"{keyValue.Key} -> {keyValue.Value}");
}

Console.WriteLine("21----------------------------------------------");
// 21. feladat
// Készíts függvényt, amely típusonként megkeresi a legnagyobb kapacitású repülőgépet.
// Add vissza minden típushoz a legnagyobb kapacitású repülőgép nevét.
//
// A feladat megoldásánál használj GroupBy-t,
var stats5 = PlaneType.LargestCapacityByType(Planes, PlaneTypes);
foreach (var keyValue in stats5)
{
    Console.WriteLine($"{keyValue.Key} -> {keyValue.Value}");
}

Console.WriteLine("22----------------------------------------------");
// 22. feladat
// Készíts függvényt, amely visszaadja a 3 legújabb olyan repülőgépet, amely legalább 150 fő befogadására képes.
List<Plane> newestPlanes = Plane.PlanesWithAbove150People(Planes);
foreach (var plane in newestPlanes) {  Console.WriteLine(plane); }
