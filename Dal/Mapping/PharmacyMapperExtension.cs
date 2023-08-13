using Dal.Model.Pharmacy;
using Infrastructure.Dto.Pharmacy;

namespace Dal.Mapping
{
    public static class PharmacyMapperExtension
    {
        public static PharmacyDto ToDto(this Pharmacy source, PharmacyDto destination = null)
        {
            if (source == null)
                return null;

            destination ??= new PharmacyDto();

            destination.Id = source.Id;
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.City = source.City;
            destination.State = source.State;
            destination.Zip = source.Zip;
            destination.FilledPrescriptions = source.FilledPrescriptions;

            return destination;
        }

        public static Pharmacy ToEntity(this PharmacyDto source, Pharmacy destination = null)
        {
            if (source == null)
                return null;

            destination ??= new Pharmacy();

            destination.Id = source.Id;
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.City = source.City;
            destination.State = source.State;
            destination.Zip = source.Zip;
            destination.FilledPrescriptions = source.FilledPrescriptions;

            return destination;
        }
    }
}
