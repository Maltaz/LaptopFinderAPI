using FluentValidation;
using LaptopFinderAPI.Dtos;

namespace LaptopFinderAPI.Validation
{
    public class CaseDataDtoValidator : AbstractValidator<CaseDataDto>
    {
        public CaseDataDtoValidator()
        {
            RuleFor(x => x.GraphicsQuality).NotNull();
            RuleFor(x => x.AudioQuality).NotNull();
            RuleFor(x => x.Small).NotNull();
            RuleFor(x => x.Light).NotNull();
            RuleFor(x => x.Efficiency).NotNull();
            RuleFor(x => x.KeyboardLight).NotNull();
            RuleFor(x => x.BatteryTime).NotNull();
        }
    }
}
