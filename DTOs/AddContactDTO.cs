using System.ComponentModel.DataAnnotations;

namespace ContactApp.DTOs
{
	public class AddContactDTO
	{
		[Required]
		public string Name { get; set; } = string.Empty;

		[Required, DataType(DataType.EmailAddress), EmailAddress]
		public string Email { get; set; } = string.Empty;

		[Required]
		public string Phone {  get; set; } = string.Empty;
	}
}
