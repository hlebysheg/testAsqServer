using System;
using testAsqServer.model.DTO;

namespace testAsqServer.service.formService
{
	public interface IFormService
	{
		public Task<bool> SaveFormAsync(FormDTO dto);
	}
}

