using System;
namespace testAsqServer.model.DTO
{
	public class StandartIPFormDTO
	{
        public string Inn { get; set; }
        public IFormFile InnFile { get; set; }
        public string Ogrip { get; set; }
        public IFormFile OgripFile { get; set; }
        public string? RegisterDate { get; set; }
        public IFormFile EgripFile { get; set; }
        public IFormFile? RentFile { get; set; }
	}
}

