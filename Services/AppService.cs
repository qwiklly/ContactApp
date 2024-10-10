using ContactApp.DTOs;
using static ContactApp.Responses.CustomResponses;

namespace ContactApp.Services
{
	public class AppService : IAppService
	{
		private readonly HttpClient _httpClient;

		public AppService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		private static async Task<T> SendRequestAsync<T>(Func<Task<HttpResponseMessage>> httpRequest)
		{
			var response = await httpRequest();
			if (response.IsSuccessStatusCode)
			{
				return await response.Content.ReadFromJsonAsync<T>() ?? throw new HttpRequestException("Empty response received");
			}
			else
			{
				throw new HttpRequestException($"Request failed with status code {response.StatusCode} and reason {response.ReasonPhrase}.");
			}
		}

		public Task<BaseResponse> GetAllContactsAsync() =>
			SendRequestAsync<BaseResponse>(() => _httpClient.GetAsync("api/application/getAllContacts"));

		public Task<BaseResponse> GetContactAsync(string email) =>
			SendRequestAsync<BaseResponse>(() => _httpClient.GetAsync($"api/application/getContact/{email}"));

		public Task<BaseResponse> DeleteContactAsync(DeleteContactDTO model) =>
			SendRequestAsync<BaseResponse>(() => _httpClient.DeleteAsync($"api/application/deleteContact?email={model.Email}"));

		public Task<BaseResponse> UpdateContactAsync(string email, AddContactDTO model) =>
			SendRequestAsync<BaseResponse>(() => _httpClient.PutAsJsonAsync($"api/application/updateContact/{email}", model));

		public Task<BaseResponse> AddContactAsync(AddContactDTO model) =>
			SendRequestAsync<BaseResponse>(() => _httpClient.PostAsJsonAsync("api/application/addContact", model));
	}
}
