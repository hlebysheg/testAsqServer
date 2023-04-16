using System;
namespace testAsqServer.model.DTO
{
	public class FormDTO
	{
        public OOOFormDTO? Organisation { get; set; }
        public PayFormDTO? PayInfo { get; set; }
        public StandartIPFormDTO IpInfo { get; set; }
    }
}

