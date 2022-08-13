
namespace Repositorio.Common.Classes.Response
{
    public class ResponseHandler<T> where T : new()
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
	public class ResponseDTO<T>
	{
		public HeaderResponseDTO Header { get; set; }
		public T Data { get; set; }

		public ResponseDTO()
		{
			Header = new HeaderResponseDTO();
			Header.StatusCode = HttpCodes.Ok;
		}
	}
	public class HeaderResponseDTO
	{
		public HttpCodes StatusCode { get; set; }
		public string Message { get; set; }
	}

	public enum HttpCodes
	{
		Ok = 200,
		BadRequest = 400,
		NotFound = 404,
		ValidationError = 421,
		InternalServerError = 500
	}
}
