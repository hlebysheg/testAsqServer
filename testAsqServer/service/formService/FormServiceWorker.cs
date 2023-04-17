using System;
using System.Security.Cryptography;
using testAsqServer.model.DTO;
using testAsqServer.model.Entity;
using static System.Net.Mime.MediaTypeNames;

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

        public async Task<bool> SaveFormAsync(FormDTO dto)
        {
            PayForm payForm = new PayForm
            {
                BankName = dto.PayInfo.BankName,
                Bik = dto.PayInfo.Bik,
                CheckingAccount = dto.PayInfo.CheckingAccount,
                CorrespondentAccount = dto.PayInfo.CorrespondentAccount,
            };
            await _ctx.PayForm.AddAsync(payForm);

            DateTime date;
            StandartIPForm standartIPForm = new StandartIPForm
            {
                Inn = dto.IpInfo.Inn,
                InnFile = await SaveFileAsync(dto.IpInfo.InnFile),
                Ogrip = dto.IpInfo.Ogrip,
                OgripFile = await SaveFileAsync(dto.IpInfo.OgripFile),
                RegisterDate = DateTime.TryParse(dto.IpInfo.RegisterDate, out date) ? date : (DateTime?)null,
                EgripFile = await SaveFileAsync(dto.IpInfo.EgripFile),
                RentFile = dto.IpInfo.RentFile != null? await SaveFileAsync(dto.IpInfo.RentFile): null,
                PayForm = payForm,
            };
            await _ctx.StandartIPForm.AddAsync(standartIPForm);

            OOOForm oooForm;
            if (dto.Organisation?.OrganisationFullName != null && dto.Organisation.OrganisationFullName != "")
            {
                oooForm = new OOOForm
                {
                    OrganisationFullName = dto.Organisation.OrganisationFullName,
                    OrganisationShortName = dto.Organisation.OrganisationShortName,
                    Date = dto.Organisation.Date,
                    StandartIPForm = standartIPForm,
                };
                await _ctx.OOOForm.AddAsync(oooForm);
            }

            try
            {
                await _ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        private async Task<model.Entity.FileInfo> SaveFileAsync(IFormFile formFile)
        {
            //todo вынести в отдельный сервис
            if (formFile.Length == 0)
            {
                return null;
            }

            var filePath = Path.Combine(_conf["FilePath"],
                Guid.NewGuid().ToString() + formFile.FileName);

            string hash;

            using (var md5 = MD5.Create())
            {
                using (var stream = System.IO.File.Create(filePath))
                {
                    await formFile.CopyToAsync(stream);
                    hash = string.Concat(md5.ComputeHash(stream).Select(x => x.ToString("X2")));
                }
            }

            model.Entity.FileInfo result = new model.Entity.FileInfo
            {
                Name = formFile.FileName,
                Path = filePath,
                hash = hash,
            };

            try
            {
                await _ctx.FileInfo.AddAsync(result);
            }
            catch
            {
                return null;
            }
            return result;

        }
    }
}

