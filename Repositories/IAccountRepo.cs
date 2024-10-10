using ContactApp.DTOs;
using ContactApp.Models;
using static ContactApp.Responses.CustomResponses;

namespace ContactApp.Repositories
{
	public interface IAccountRepo
	{
		Task<List<AddContactDTO>> GetAllContactsAsync();
		Task<Contact?> GetContactAsync(string email);
		Task<BaseResponse> AddContactAsync(AddContactDTO model);
		Task<BaseResponse> DeleteContactAsync(DeleteContactDTO model);
		Task<BaseResponse> UpdateContactAsync(string email, AddContactDTO model);
	}
}
