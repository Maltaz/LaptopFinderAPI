using LaptopFinder.Core.Entities;

namespace LaptopFinder.Core.Repositories
{
    public interface ILaptopRepository
    {
        public Task<Laptop> GetLaptopData(int laptopId);
    }

    public class LaptopRepository : ILaptopRepository
    {
        //TODO
        public async Task<Laptop> GetLaptopData(int laptopId)
        {
            var laptop = new Laptop()
            {
                Id = 0,
                Ram = "12GB",
                Company = "Acer",
                CPU = "Intel Core i5 7200U 2.5GHz",
                ScreenResolution = "Full HD 1920x1080",
                GPU = "Nvidia GeForce GTX 950M",
                TypeName = "Notebook",
                Inches = "15.6",
                Memory = "128GB SSD +  1TB HDD",
                OpSys = "Windows 10",
                Price = "1369.90",
                Product = "Aspire F5-573G-510L",
                Weight = "2.6kg"
            };

            return laptop;
        }
    }
}
