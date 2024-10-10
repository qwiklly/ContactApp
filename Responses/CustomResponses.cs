namespace ContactApp.Responses
{
	public class CustomResponses
	{
		public record BaseResponse(bool Flag = true, string Message = null! );
	}
}
