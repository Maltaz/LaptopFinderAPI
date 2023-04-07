using MongoDB.Driver;
using System.Runtime.Intrinsics.Arm;

namespace LaptopFinderAPI.Dtos
{
    public class LaptopDto
    {
        public string Company { get; set; }
        public string Product { get; set; }
        public string TypeName { get; set; }
        public string Inches { get; set; }
        public string ScreenResolution { get; set; }
        public string CPU { get; set; }
        public string Ram { get; set; }
        public string Memory { get; set; }
        public string GPU { get; set; }
        public string OpSys { get; set; }
        public string Weight { get; set; }
        public string Price { get; set; }
    }
}
