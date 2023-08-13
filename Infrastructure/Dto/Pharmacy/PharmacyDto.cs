using Dal.Model.Base;

namespace Infrastructure.Dto.Pharmacy
{
    public class PharmacyDto : DtoBase
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Zip { get; set; } = string.Empty;
        public int FilledPrescriptions { get; set; }
    }
}
