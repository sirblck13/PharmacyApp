using Infrastructure.Dto.Pharmacy;
using WebApi.ViewModel;

namespace WebApi.Mapping
{
    public static class PharmacyMapperExtension
    {
        public static PharmacyVm ToPharmacyVm(this PharmacyDto source, PharmacyVm destination = null)
        {
            if (source == null)
                return null;

            destination ??= new PharmacyVm();

            destination.Id = source.Id;
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.City = source.City;
            destination.State = source.State;
            destination.Zip = source.Zip;
            destination.FilledPrescriptions = source.FilledPrescriptions;

            return destination;
        }

        public static PharmacyDto ToPharmacyDto(this PharmacyVm source, PharmacyDto destination = null)
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
    }
}
