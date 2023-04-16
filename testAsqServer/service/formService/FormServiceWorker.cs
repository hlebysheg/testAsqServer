using System;
using testAsqServer.model.DTO;
using testAsqServer.model.Entity;

namespace testAsqServer.service.formService
{
	public class FormServiceWorker: IFormService
	{
        private readonly IConfiguration _conf;
        private readonly FormDbContext _ctx;
        public FormServiceWorker(IConfiguration conf, FormDbContext ctx)
		{
            _conf = conf;
            _ctx = ctx;
		}

        public Task<bool> SaveFormAsync(FormDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}

