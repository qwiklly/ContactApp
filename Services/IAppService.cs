using ContactApp.DTOs;
using static ContactApp.Responses.CustomResponses;

namespace ContactApp.Services
{
	public interface IAppService
	{
		Task<BaseResponse> GetAllContactsAsync();
		Task<BaseResponse> GetContactAsync(string email);
		Task<BaseResponse> AddContactAsync(AddContactDTO model);
		Task<BaseResponse> DeleteContactAsync(DeleteContactDTO model);
		Task<BaseResponse> UpdateContactAsync(string email, AddContactDTO model);
	}
}

