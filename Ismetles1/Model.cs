using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;

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
    }

}
    


