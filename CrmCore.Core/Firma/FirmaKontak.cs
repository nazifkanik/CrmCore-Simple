using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CrmCore.Core.Firma
{
    public class FirmaKontak
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Adı Soyadı")]
        public string AdiSoyadi { get; set; }

        public string Telefon { get; set; }

        public string EPosta { get; set; }

        [Display(Name = "Firma Adı")]
        [ForeignKey("FirmaId")]
        public virtual Firma Firma { get; set; }

        public virtual int FirmaId { get; set; }

        [Required]
        [Display(Name = "Oluşturan Kullanıcı")]
        public string CreatorUserId { get; set; }

        [Display(Name = "Oluşturma Tarihi")]
        public DateTime CreatedDate { get; set; }

        public static FirmaKontak Create(string adiSoyadi, string telefon, string ePosta, int firmaId, string creatorUserId)
        {
            return new FirmaKontak
            {
                AdiSoyadi = adiSoyadi,
                Telefon = telefon,
                EPosta = ePosta,
                FirmaId = firmaId,
                CreatorUserId = creatorUserId,
                CreatedDate = DateTime.Now
            };
        }
    }
}