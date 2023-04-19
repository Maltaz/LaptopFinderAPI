namespace LaptopFinder.Core.Entities
{
    public class Case
    {
        public int Id { get; set; }
        public int LaptopId { get; set; }
        public int GraphicsQuality { get; set; }
        public int AudioQuality { get; set; }
        public int Small { get; set; }
        public int Light { get; set; }
        public int Efficiency { get; set; }
        public int DiskSize { get; set; }
        public int KeyboardLight { get; set; }
        public int BatteryTime { get; set; }

        public double GetDistance(Case otherCase)
        {
            var sum = 
                GetSquaredDifference(GraphicsQuality, otherCase.GraphicsQuality) +
                GetSquaredDifference(AudioQuality, otherCase.AudioQuality) +
                GetSquaredDifference(Small, otherCase.Small) +
                GetSquaredDifference(Light, otherCase.Light) +
                GetSquaredDifference(Efficiency , otherCase.Efficiency) +
                GetSquaredDifference(DiskSize, otherCase.DiskSize) +
                GetSquaredDifference(KeyboardLight, otherCase.KeyboardLight) +
                GetSquaredDifference(BatteryTime, otherCase.BatteryTime);

            return Math.Sqrt(sum);
        }

        private static double GetSquaredDifference(int var1, int var2)
        {
            return Math.Pow(var1 - var2, 2);
        }
    }
}
