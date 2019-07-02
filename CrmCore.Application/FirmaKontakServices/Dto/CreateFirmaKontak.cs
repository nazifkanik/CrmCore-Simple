using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CrmCore.Application.FirmaKontakServices.Dto
{
    public class CreateFirmaKontak
    {
        [Required]
        [Display(Name = "Adı Soyadı")]
        public string AdiSoyadi { get; set; }

        public string Telefon { get; set; }

        public string EPosta { get; set; }

        public virtual int FirmaId { get; set; }

        [Required]
        [Display(Name = "Oluşturan Kullanıcı")]
        public string CreatorUserId { get; set; }
    }
}
