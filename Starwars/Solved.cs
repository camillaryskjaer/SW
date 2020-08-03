using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starwars
{
    class Solved
    {
        public IEnumerable<Planet> Opgave1(List<Planet> planets)
        {
            var result = planets.Where(x => x.Name.StartsWith("M"));

            return result;
        }
        public IEnumerable<Planet> Opgave2(List<Planet> planets)
        {
            var result = planets.Where(x => x.Name.ToLower().Contains("y"));

            return result;
        }
        public IEnumerable<Planet> Opgave3(List<Planet> planets)
        {
            var result = planets.Where(x => x.Name.Length > 6 && 15 > x.Name.Length);

            return result;
        }
        public IEnumerable<Planet> Opgave4(List<Planet> planets)
        {
            var result = planets.Where(x => x.Name.IndexOf('a') == 1 && x.Name.EndsWith("e"));

            return result;
        }
        public IEnumerable<Planet> Opgave5(List<Planet> planets)
        {
            var result = planets.Where(x => x.RotationPeriod > 40).OrderBy(x => x.RotationPeriod);

            return result;
        }
        public IEnumerable<Planet> Opgave6(List<Planet> planets)
        {
            var result = planets.Where(x => x.RotationPeriod > 10 && x.RotationPeriod < 20).OrderBy(x => x.Name);

            return result;
        }
        public IEnumerable<Planet> Opgave7(List<Planet> planets)
        {

            var result = planets.Where(x => x.RotationPeriod > 30).OrderBy(x => x.Name).ThenBy(x => x.RotationPeriod);

            return result;
        }
        public IEnumerable<Planet> Opgave8(List<Planet> planets)
        {

            var result = planets.Where(x => x.RotationPeriod < 30 || x.SurfaceWater > 50).Where(x => x.Name.ToLower().Contains("ba"))
                .OrderBy(x => x.Name).ThenBy(x => x.SurfaceWater).ThenBy(x => x.RotationPeriod);

            return result;
        }
        public IEnumerable<Planet> Opgave9(List<Planet> planets)
        {

            var result = planets.Where(x => x.SurfaceWater > 0).OrderByDescending(x => x.SurfaceWater);

            return result;
        }
        public double CalculateSurfaceAreaByDiameter(double diameter)
        {
            double radius = diameter / 2;
            double surfaceArea = Math.PI * 4 * Math.Pow(radius, 2);
            return surfaceArea;
        }
        public IEnumerable<Planet> Opgave10(List<Planet> planets)
        {


            var result = planets.Where(x => x.Diameter > 0 && x.Population > 0).OrderBy(x => CalculateSurfaceAreaByDiameter(x.Diameter) / x.Population);

            return result;
        }
        public IEnumerable<Planet> Opgave11(List<Planet> planets)
        {

            var result = planets.Except(planets.Where(x => x.RotationPeriod > 0));

            return result;
        }
        public IEnumerable<Planet> Opgave12(List<Planet> planets)
        {

            var result = planets.Where(x => x.Name.ToLower().StartsWith("a") || x.Name.ToLower().EndsWith("s"));
            var result2 = planets.Where(x => x.Terrain != null).Where(x => x.Terrain.ToList().Contains("rainforests"));

            var finalresult = result.Union(result2);
            return finalresult;
        }
        public IEnumerable<Planet> Opgave13(List<Planet> planets)
        {

            var result = planets.Where(x => x.Terrain != null)
                 .SelectMany(x => x.Terrain, (plan, trr) => new { plan, trr })
                 .Where(x => x.trr.Contains("desert"))
                 .Select(x => x.plan);
            return result;
        }
        public IEnumerable<Planet> Opgave14(List<Planet> planets)
        {
            var result = planets.Where(x => x.Terrain != null)
                .SelectMany(x => x.Terrain, (plan, trr) => new { plan, trr })
                .Where(x => x.trr.Contains("swamp"))
                .Select(x => x.plan)
                .OrderBy(x => x.RotationPeriod)
                .ThenBy(x => x.Name);
            return result;
        }
        public bool StringArr(string str, string[] arr)
        {
            bool contains = false;
            for (int i = 0; i < arr.Length; i++)
            {
                if (str.Contains(arr[i]))
                {
                    contains = true;
                }
            }
            return contains;
        }
        public IEnumerable<Planet> Opgave15(List<Planet> planets)
        {
            string[] arr = new string[] { "aa", "ee", "ii", "oo", "uu", "yy" };
            var result = planets.Where(x => StringArr(x.Name, arr));
            return result;
        }
        public IEnumerable<Planet> Opgave16(List<Planet> planets)
        {
            string[] arr = new string[] { "kk", "ll", "rr", "nn" };
            var result = planets.Where(x => StringArr(x.Name, arr))
                .OrderByDescending(x => x.Name);
            return result;
        }

    }
}
