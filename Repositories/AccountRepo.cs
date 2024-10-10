using ContactApp.Data;
using ContactApp.DTOs;
using ContactApp.Models;
using Microsoft.EntityFrameworkCore;
using static ContactApp.Responses.CustomResponses;


namespace ContactApp.Repositories
{
	public class AccountRepo(appDbContext _appDbContext) : IAccountRepo
	{

		public async Task<BaseResponse> AddContactAsync(AddContactDTO model)
		{
			try
			{
				var findContact = await GetContactAsync(model.Email);
				if (findContact != null) return new BaseResponse(false, "Contact already exist");

				_appDbContext.Contacts.Add(
					 new Contact()
					 {
						 Email = model.Email,
						 Name = model.Name,
						 Phone = model.Phone,
					 });

				await _appDbContext.SaveChangesAsync();
				return new BaseResponse(true, "Contact added successfully");
			}
			catch
			{
				return new BaseResponse(false, "Error while adding successfully");
			}
		}

		public async Task<BaseResponse> DeleteContactAsync(DeleteContactDTO model)
		{
			try
			{
				var findContact = await GetContactAsync(model.Email);
				if (findContact != null)
				{
					_appDbContext.Contacts.Remove(findContact);
					await _appDbContext.SaveChangesAsync();
					return new BaseResponse(true, "User Successfully deleted");
				}
				else
				{
					return new BaseResponse(false, "Contact not found");
				}
			}
			catch
			{
				return new BaseResponse(false, "Error while deleting user");
			}
		}

		public async Task<List<AddContactDTO>> GetAllContactsAsync()
		{
			try
			{
				var contacts = await _appDbContext.Contacts
				.Select(x => new AddContactDTO
				{
					Email = x.Email,
					Name = x.Name,
					Phone = x.Phone
				})
				.ToListAsync();

				return contacts;
			}
			catch
			{
				throw new InvalidOperationException("Error while finding users ");
			}
		}

		public async Task<BaseResponse> UpdateContactAsync(string email, AddContactDTO model)
		{
			try
			{
				var contact = await GetContactAsync(email);

				if (contact == null)
				{
					return new BaseResponse(false, $"Contact with email '{email}' not found.");
				}
				
				contact.Name = model.Name ?? contact.Name;
				contact.Phone = model.Phone ?? contact.Phone;

				await _appDbContext.SaveChangesAsync();

				return new BaseResponse(true, "Contact updated successfully.");
			}
			catch
			{
				return new BaseResponse(false, "Error while updating contacts's data ");
			}
		}

		public async Task<Contact?> GetContactAsync(string email)
			=> await _appDbContext.Contacts.FirstOrDefaultAsync(e => e.Email == email);

	}
}
