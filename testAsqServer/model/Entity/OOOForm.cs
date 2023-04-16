using System;
namespace testAsqServer.model.Entity
{
	public class OOOForm
	{
        public int Id { get; set; }

        public string? OrganisationFullName { get; set; }

        public string? OrganisationShortName { get; set; }

        public string? Date { get; set; }


        //key
        public int StandartIPFormId { get; set; }

        public StandartIPForm StandartIPForm { get; set; }
    }
}

