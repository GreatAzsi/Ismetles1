using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;
using System.Threading.Channels;

namespace Ismetles1
{
    internal class Model
    {

    }
    public class Plane
    {
        public int Planeid { get; set; }
        public string PlaneName { get; set; }
        public int Capacity { get; set; }
        public int MaxSpeed { get; set; }
        public int BuildYear { get; set; }
        public int TypeId { get; set; }
        public Plane(int planeId, string planeName, int capacity, int maxSpeed, int buildYear, int typeId)
        {
            Planeid = planeId;
            PlaneName = planeName;
            Capacity = capacity;
            MaxSpeed = maxSpeed;
            BuildYear = buildYear;
            TypeId = typeId;
        }
        public override string ToString()
        {
            return $"PlaneId: {Planeid}, PlaneName: {PlaneName}, Capacity: {Capacity}, MaxSpeed: {MaxSpeed}, BuildYear: {BuildYear}, TypeId: {TypeId}";
        }
        public static List<Plane> SearchFromPlaneDate(List<Plane> Planes, int BuildYear)
        {
            List<Plane> SearchedPlanes = new();
            foreach (Plane Plane in Planes)
            {
                if (Plane.BuildYear <= BuildYear)
                {
                    SearchedPlanes.Add(Plane);
                }
            }
            return SearchedPlanes;
        }
        public static List<Plane> PlaneNamesWithMoreThan3WordsInABC(List<Plane> Planes)
        {
            List<Plane> SearchedPlanes = new();
            foreach (Plane Plane in Planes)
            {
                if (Plane.PlaneName.Split(' ').Length >= 3)
                {
                    SearchedPlanes.Add(Plane);
                }
            }
            SearchedPlanes.Sort((x, y) => x.PlaneName.CompareTo(y.PlaneName));
            return SearchedPlanes;
        }
        public static List<String> SearchFromCapacity(List<Plane> Planes, int parameter)
        {
            List<String> SearchedPlanes = new();
            foreach (Plane Plane in Planes)
            {
                if (Plane.Capacity >= parameter)
                {
                    SearchedPlanes.Add(Plane.PlaneName);
                }
            }
            SearchedPlanes.Sort();
            return SearchedPlanes;
        }
        public static List<Plane> SortBySpeedAndParameter(List<Plane> Planes, int parameter)
        {
            List<Plane> SearchedPlanes = new List<Plane>();
            SearchedPlanes = Planes.OrderByDescending(p => p.MaxSpeed).Take(parameter).ToList();
            return SearchedPlanes;
        }
        public static List<Plane> CapacityBetweenTwoParameters(List<Plane> Planes, int minCapacity, int maxCapacity)
        {
            List<Plane> SearchedPlanes = new List<Plane>();
            foreach (Plane Plane in Planes)
            {
                if (Plane.Capacity >= minCapacity && Plane.Capacity <= maxCapacity)
                {
                    SearchedPlanes.Add(Plane);
                }
            }
            SearchedPlanes.Sort((x, y) => x.PlaneName.CompareTo(y.PlaneName));
            return SearchedPlanes;
        }
        public static List<Plane> DateAndMinSpeed(List<Plane> Planes, int BuildYear, int MinSpeed)
        {
            List<Plane> SearchedPlanes = new List<Plane>();
            foreach (Plane Plane in Planes)
            {
                if (Plane.BuildYear > BuildYear && Plane.MaxSpeed >= MinSpeed)
                {
                    SearchedPlanes.Add(Plane);
                }
            }
            List<Plane> SearchedPlanesOrdered = SearchedPlanes.OrderByDescending(p => p.MaxSpeed).ToList();
            return SearchedPlanesOrdered;
        }
        public static Plane LargestCapacityAboveLimit(List<Plane> Planes, int Limit)
        {
            List<Plane> SearchedPlanes = new();
            foreach (Plane Plane in Planes)
            {
                if (Plane.Capacity > Limit)
                {
                    SearchedPlanes.Add(Plane);
                }
            }
            Plane LargestCapacity = SearchedPlanes[0];
            foreach (Plane Plane in SearchedPlanes)
            {
                if (Plane.Capacity > LargestCapacity.Capacity)
                {
                    LargestCapacity = Plane;
                }
            }
            return LargestCapacity;
        }
        public static double AverageCapacityInGivenYear(List<Plane> Planes, int BuildYear)
        {
            List<Plane> SearchedPlanes = new();
            foreach (Plane Plane in Planes)
            {
                if (Plane.BuildYear == BuildYear)
                {
                    SearchedPlanes.Add(Plane);
                }
            }
            double sumCapacity = 0;
            foreach (Plane Plane in SearchedPlanes)
            {
                sumCapacity += Plane.Capacity;
            }
            double averageCapacity = sumCapacity / SearchedPlanes.Count;
            return averageCapacity;
        }
        public static List<string> PlaneNamesWhichAreContainText(List<Plane> Planes, string searchText)
        {
            List<string> SearchedPlaneNames = new List<string>();
            foreach (Plane Plane in Planes)
            {
                if (Plane.PlaneName.Contains(searchText))
                {
                    SearchedPlaneNames.Add(Plane.PlaneName);
                }
            }
            SearchedPlaneNames.Sort();
            return SearchedPlaneNames;
        }
        public static List<string> PlaneNamesWhichStartWithText(List<Plane> Planes, string searchText1, string searchText2)
        {
            List<Plane> SearchedPlanes = new List<Plane>();
            foreach (Plane Plane in Planes)
            {
                if (Plane.PlaneName.StartsWith(searchText1) || Plane.PlaneName.StartsWith(searchText2))
                {
                    SearchedPlanes.Add(Plane);
                }
            }
            SearchedPlanes = SearchedPlanes.OrderByDescending(x => x.BuildYear).ToList();
            List<string> PlaneNames = new List<string>();
            foreach (Plane Plane in SearchedPlanes)
            {
                PlaneNames.Add(Plane.PlaneName);
            }
            return PlaneNames;
        }
        public static List<Plane> PlanesWithAbove150People(List<Plane> Planes)
        {
            List<Plane> SearchedPlanes = new List<Plane>();
            foreach (Plane Plane in Planes)
            {
                if (Plane.Capacity > 150)
                {
                    SearchedPlanes.Add(Plane);
                }
            }
            SearchedPlanes = SearchedPlanes.OrderByDescending(x => x.BuildYear).Take(3).ToList();
            return SearchedPlanes;
        }
    }
    public class PlaneType
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public PlaneType(int typeId, string typeName)
        {
            TypeId = typeId;
            TypeName = typeName;
        }
        public override string ToString()
        {
            return $"TypeId: {TypeId}, TypeName: {TypeName}";
        }
        public static List<Plane> SearchFromTypeName(List<Plane> Planes, List<PlaneType> PlaneTypes, string typeName)
        {
            List<Plane> SearchedPlanes = new();
            int TypeId = 0;
            foreach (PlaneType Type in PlaneTypes)
            {
                if (Type.TypeName == typeName)
                {
                    TypeId = Type.TypeId;
                }
            }
            foreach (Plane Plane in Planes)
            {
                if (Plane.TypeId == TypeId)
                {
                    SearchedPlanes.Add(Plane);
                }
            }
            return SearchedPlanes;
        }
        public static Dictionary<string, int> CountPlanesByType(List<Plane> Planes, List<PlaneType> PlaneTypes)
        {
            var result = new Dictionary<string, int>();
            foreach (PlaneType type in PlaneTypes)
            {
                int count = 0;
                foreach (Plane plane in Planes)
                {
                    if (plane.TypeId == type.TypeId)
                    {
                        count++;
                    }
                }
                result[type.TypeName] = count;
            }
            return result;
        }
        public static Dictionary<string, int> MaxSpeedByType(List<Plane> Planes, List<PlaneType> PlaneTypes)
        {
            var result = new Dictionary<string, int>();
            foreach (PlaneType type in PlaneTypes)
            {
                int maxSpeed = 0;
                foreach (Plane plane in Planes)
                {
                    if (plane.TypeId == type.TypeId && plane.MaxSpeed > maxSpeed)
                    {
                        maxSpeed = plane.MaxSpeed;
                    }
                }
                result[type.TypeName] = maxSpeed;
            }
            return result;
        }
        public static Dictionary<string, double> AverageSpeedByType(List<Plane> Planes, List<PlaneType> PlaneTypes)
        {
            var result = new Dictionary<string, double>();
            foreach (PlaneType type in PlaneTypes)
            {
                double sumSpeed = 0;
                double averageSpeed = 0;
                int count = 0;
                foreach (Plane plane in Planes)
                {
                    if (plane.TypeId == type.TypeId)
                    {
                        sumSpeed += plane.MaxSpeed;
                        count++;
                    }
                }
                averageSpeed = count > 0 ? sumSpeed / count : sumSpeed;
                result[type.TypeName] = averageSpeed;
            }
            return result;
        }
        public static String OldestPlaneInSpecificType(List<Plane> Planes, List<PlaneType> PlaneTypes, string typeName)
        {
            List<Plane> SearchedPlanes = new();
            int TypeId = 0;
            foreach (PlaneType Type in PlaneTypes)
            {
                if (Type.TypeName == typeName)
                {
                    TypeId = Type.TypeId;
                }
            }
            foreach (Plane Plane in Planes)
            {
                if (Plane.TypeId == TypeId)
                {
                    SearchedPlanes.Add(Plane);
                }
            }
            Plane OldestPlane = SearchedPlanes[0];
            foreach (Plane Plane in SearchedPlanes)
            {
                if (Plane.BuildYear < OldestPlane.BuildYear)
                {
                    OldestPlane = Plane;
                }
            }
            return OldestPlane.PlaneName;
        }
        public static List<string> PlaneNamesWithTypeAndMinSpeed(List<Plane> Planes, List<PlaneType> PlaneTypes, string typeName, int minSpeed)
        {
            List<Plane> SearchedPlanes = new();
            int TypeId = 0;
            foreach (PlaneType Type in PlaneTypes)
            {
                if (Type.TypeName == typeName)
                {
                    TypeId = Type.TypeId;
                }
            }
            foreach (Plane Plane in Planes)
            {
                if (Plane.TypeId == TypeId && Plane.MaxSpeed >= minSpeed)
                {
                    SearchedPlanes.Add(Plane);
                }
            }
            List<Plane> OrderedSearchedPlanes = SearchedPlanes.OrderByDescending(p => p.MaxSpeed).ToList();
            List<string> PlaneNames = new();

            foreach (Plane Plane in OrderedSearchedPlanes)
            {
                PlaneNames.Add(Plane.PlaneName);
            }
            return PlaneNames;
        }
        public static Dictionary<string, int> CountSeatsByType(List<Plane> Planes, List<PlaneType> PlaneTypes)
        {
            var result = new Dictionary<string, int>();
            foreach (PlaneType type in PlaneTypes)
            {
                int SeatsCount = 0;
                foreach (Plane plane in Planes)
                {
                    if (plane.TypeId == type.TypeId)
                    {
                        SeatsCount += plane.Capacity;
                    }
                }
                result[type.TypeName] = SeatsCount;
            }
            return result;

        }
        public static Dictionary<string, Plane> LargestCapacityByType(List<Plane> Planes, List<PlaneType> PlaneTypes)
        {
            var result = new Dictionary<string, Plane>();
            foreach (PlaneType type in PlaneTypes)
            {
                Plane LargestCapacity = Planes[0];
                foreach (Plane plane in Planes)
                {
                    if (plane.TypeId == type.TypeId)
                    {
                        if (plane.Capacity > LargestCapacity.Capacity)
                        {
                            LargestCapacity = plane;
                        }
                    }
                }
                result[type.TypeName] = LargestCapacity;
            }
            return result;
        }
    }
}


