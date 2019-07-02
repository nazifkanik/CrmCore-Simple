using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CrmCore.Core.Firma
{
    public class Gorusme
    {
        public int Id { get; set; }

        public string Konu { get; set; }

        public string Detay { get; set; }

        [Display(Name = "Firma Adı")]
        [ForeignKey("FirmaId")]
        public virtual Firma Firma { get; set; }

        public virtual int FirmaId { get; set; }

        [Display(Name = "Kontak Adı")]
        [ForeignKey("FirmaKontakId")]
        public virtual FirmaKontak FirmaKontak { get; set; }

        public virtual int FirmaKontakId { get; set; }

        [Required]
        [Display(Name = "Oluşturan Kullanıcı")]
        public string CreatorUserId { get; set; }

        [Display(Name = "Oluşturma Tarihi")]
        public DateTime CreatedDate { get; set; }

        public static Gorusme Create(string konu, string detay, int firmaId, int firmaKontakId, string creatorUserId)
        {
            return new Gorusme
            {
                Konu = konu,
                Detay = detay,
                FirmaId = firmaId,
                FirmaKontakId = firmaKontakId,
                CreatorUserId = creatorUserId,
                CreatedDate = DateTime.Now
            };
        }
    }
}
