using System;
using System.ComponentModel.DataAnnotations;

namespace testAsqServer.model.Entity
{
	public class PayForm
	{
        [Key]
        public string Bik { get; set; }

        public string BankName { get; set; }

        public string CheckingAccount { get; set; }

        public string CorrespondentAccount { get; set; }
    }
}

