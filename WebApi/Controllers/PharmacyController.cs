using Infrastructure.Dto.Pharmacy;
using Infrastructure.Interfaces.Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Mapping;
using WebApi.Responses;
using WebApi.ViewModel;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PharmacyController : ControllerBase
    {

        #region Private Fields

        private readonly IPharmacyManager _pharmacyManager;

        #endregion

        #region Constructors

        public PharmacyController(IPharmacyManager pharmacyManager)
        {
            _pharmacyManager = pharmacyManager;
        }

        #endregion

        #region Public Methods

        [AllowAnonymous]
        [HttpGet]
        public async Task<ApiResponse<IEnumerable<PharmacyDto>>> GetAllPharmacies()
        {
            try
            {
                var pharmacyDto = await _pharmacyManager.GetAllAsync();

               
                return ApiResponse<IEnumerable<PharmacyDto>>.CreateOkResponse(pharmacyDto);
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return ApiResponse<IEnumerable<PharmacyDto>>.CreateBadRequestResponse(message); ;
            }
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ApiResponse<PharmacyVm>> GetPharmacyInfo(Guid id)
        {
            try
            {
                var pharmacyDto = await _pharmacyManager.GetByIdAsync(id);
                var result = pharmacyDto.ToPharmacyVm();

                var response = ApiResponse<PharmacyVm>.CreateOkResponse(result);
                return response;
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                var response = ApiResponse<PharmacyVm>.CreateBadRequestResponse(message);
                return response;
            }
        }

        [AllowAnonymous]
        [HttpPut]
        public async Task<ApiResponse<PharmacyVm>> Update([FromBody] PharmacyVm pharmacyVm)
        {
            try
            {
                var pharmacyDto = pharmacyVm.ToPharmacyDto();
                var resultDto = await _pharmacyManager.UpdateAsync(pharmacyDto);

                var result = resultDto.ToPharmacyVm();
                var response = ApiResponse<PharmacyVm>.CreateOkResponse(result);
                return response;

            }
            catch (Exception ex)
            {
                var message = ex.Message;
                var response = ApiResponse<PharmacyVm>.CreateBadRequestResponse(message);
                return response;
            }
        }

        #endregion

    }
}
