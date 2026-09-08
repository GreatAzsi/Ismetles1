using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ismetles1
{
    public class FileManager
    {
        public static (List<Plane>, List<PlaneType>) Readfile(string path)
        {
            try
            {
                List<Plane> All = new();
                List<PlaneType> All2 = new();
                List<PlaneType> All2Distinct = new();

                foreach (string line in File.ReadAllLines(path).Skip(1))
                {

                    string[] temp = line.Split(";");

                    if (temp.Length == 7)
                    {
                        All.Add(new Plane(int.Parse(temp[0]), temp[1], int.Parse(temp[2]), int.Parse(temp[3]), int.Parse(temp[4]), int.Parse(temp[5])));

                        All2.Add(new PlaneType(int.Parse(temp[5]), temp[6]));
                    }
                }
                All2Distinct = All2.GroupBy(PlaneType => PlaneType.TypeId).Select(group => group.First()).ToList();
                return (All, All2Distinct);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                List<Plane> All = new();
                List<PlaneType> All2Distinct = new();
                return (All, All2Distinct);
            }
        }
    }
}
