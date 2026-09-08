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
    public class FileManager
    {
        public static (List<Plane> ,List<PlaneType>) Readfile(string path)
        {
            try
            {
                List<Plane> All = new();
                List<PlaneType> All2 = new();

                foreach (string line in File.ReadAllLines(path).Skip(1))
                {

                    string[] temp = line.Split(";");

                    if (temp.Length == 7)
                    {
                        All.Add(new Plane(int.Parse(temp[0]), temp[1], int.Parse(temp[2]), int.Parse(temp[3]), int.Parse(temp[4]), int.Parse(temp[5]), int.Parse(temp[6])));

                        All2.Add(new PlaneType(int.Parse(temp[6]), temp[7]));

                        List<PlaneType> All2Distinct = All2.GroupBy(PlaneType => PlaneType.TypeId).Select(group => group.first()).ToList();
                    }
                }
                return (All,All2Distinct);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
    
}
