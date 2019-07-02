using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CrmCore.Application
{
    public class CreateFirma
    {
        [Required]
        [MaxLength(200)]
        [Display(Name = "Firma Adı")]
        public string Adi { get; set; }

        public string WebSitesi { get; set; }

        public string EPosta { get; set; }

        public string Telefon { get; set; }

        public string Adres { get; set; }

        public string FaturaAdresi { get; set; }

        [Display(Name = "Oluşturan Kullanıcı")]
        public string CreatorUserId { get; set; }
    }
}