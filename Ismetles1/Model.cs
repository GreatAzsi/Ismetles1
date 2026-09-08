using System;
using System.Collections.Generic;
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
    }

}
