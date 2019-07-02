using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CrmCore.Application.GorusmeServices.Dto
{
    public class CreateGorusme
    {
        public string Konu { get; set; }

        public string Detay { get; set; }

        public virtual int FirmaId { get; set; }

        public virtual int FirmaKontakId { get; set; }

        [Required]
        [Display(Name = "Oluşturan Kullanıcı")]
        public string CreatorUserId { get; set; }
    }
}
