using System.ComponentModel.DataAnnotations;

namespace ContactApp.DTOs
{
	public class DeleteContactDTO
	{
		[Required, DataType(DataType.EmailAddress), EmailAddress]
		public string Email { get; set; } = string.Empty;
	}
}
