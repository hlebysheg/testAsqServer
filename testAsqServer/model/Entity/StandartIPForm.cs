using System;
using System.ComponentModel.DataAnnotations;

namespace testAsqServer.model.Entity
{
	public class StandartIPForm
	{
        [Key]
        public string Inn { get; set; }

        public FileInfo InnFile { get; set; }

        public string Ogrip { get; set; }

        public FileInfo OgripFile { get; set; }

        public DateTime? RegisterDate { get; set; }

        public FileInfo EgripFile { get; set; }

        public FileInfo? RentFile { get; set; }

        //key
        public int PayFormId { get; set; }
        public PayForm PayForm { get; set; }
    }
}

