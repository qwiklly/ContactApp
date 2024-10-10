using ContactApp.DTOs;
using ContactApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using static ContactApp.Responses.CustomResponses;

namespace ContactApp.Controllers
{

	[Route("api/application")]
	[ApiController]
	public class ApplicationController(IAccountRepo _accountrepo) : ControllerBase
	{
		/// <summary>
		/// Получает контакт по email.
		/// </summary>
		/// <param name="email">Email контакта.</param>
		/// <returns>Контакт или ошибка</returns>
		[HttpGet("getContact/{email}")]
		public async Task<ActionResult<BaseResponse>> GetContact(string email)
		{
			var result = await _accountrepo.GetContactAsync(email);
			return Ok(result);
		}

		/// <summary>
		/// Получает список всех контактов.
		/// </summary>
		/// <returns>Список контактов или ошибка</returns>
		[HttpGet("getAllContacts")]
		public async Task<ActionResult<BaseResponse>> GetAllContactsAsync()
		{
			var result = await _accountrepo.GetAllContactsAsync();
			return Ok(result);
		}

		/// <summary>
		/// Добавляет новый контакт.
		/// </summary>
		/// <param name="model">Модель данных нового контакта.</param>
		/// <returns>Добавляет контакт или ошибка.</returns>
		[HttpPost("addContact")]
		public async Task<ActionResult<BaseResponse>> AddContactAsync(AddContactDTO model)
		{
			var result = await _accountrepo.AddContactAsync(model);
			return Ok(result);
		}

		/// <summary>
		/// Удаляет контакт.
		/// </summary>
		/// <param name="model">Модель данных для удаления контакта.</param>
		/// <returns>Удаляет контакт или ошибка</returns>
		[HttpDelete("deleteContact")]
		public async Task<ActionResult<BaseResponse>> DeleteContactAsync(DeleteContactDTO model)
		{
			var result = await _accountrepo.DeleteContactAsync(model);
			return Ok(result);
		}

		/// <summary>
		/// Обновляет информацию о контакте.
		/// </summary>
		/// <param name="email">Email контакта для обновления.</param>
		/// <param name="model">Новая модель данных для обновления контакта.</param>
		/// <returns>Обновляет информацию или ошибка.</returns>
		[HttpPut("updateContact/{email}")]
		public async Task<ActionResult<BaseResponse>> UpdateUserAsync(string email, AddContactDTO model)
		{
			var result = await _accountrepo.UpdateContactAsync(email, model);
			return Ok(result);
		}

	}
}
