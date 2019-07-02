using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CrmCore.Core.Firma
{
    public class Firma
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        [Display(Name = "Firma Adı")]
        public string Adi { get; set; }

        public string WebSitesi { get; set; }

        public string EPosta { get; set; }

        public string Telefon { get; set; }

        public string Adres { get; set; }

        public string FaturaAdresi { get; set; }

        [Required]
        [Display(Name = "Oluşturan Kullanıcı")]
        public string CreatorUserId { get; set; }

        [Display(Name = "Oluşturma Tarihi")]
        public DateTime CreatedDate { get; set; }

        public static Firma Create(string adi, string webSitesi, string ePosta, string telefon, string adres, string faturaAdresi, string creatorUserId)
        {
            return new Firma
            {
                Adi = adi,
                WebSitesi=webSitesi,
                EPosta= ePosta,
                Telefon= telefon,
                Adres = adres,
                FaturaAdresi= faturaAdresi,
                CreatorUserId = creatorUserId,
                CreatedDate = DateTime.Now
            };
        }
    }
}

/*
    public class BazaarList
    {
        [MaxLength(160)]
        [Display(Name ="Açıklama")]
        public string Description { get; set; }
        [Required]
        [Display(Name ="Oluşturan Kullanıcı")]
        public string CreatorUserId { get; set; }
        [Display(Name ="Oluşturma Tarihi")]
        public DateTime CreatedDate { get; set; }
        public virtual ICollection<BazaarListItem> BazaarListItems { get; set; }
        // Single Responsiblity ve DRY
        public static BazaarList Create(string title, string description, string creatorUserId)
        {
            return new BazaarList
            {
                Title = title,
                Description = description,
                CreatorUserId = creatorUserId,
                CreatedDate = DateTime.Now
            };
            // PascalCase : sinif isimleri, sinif properties, metod isimleri
            // camelCase: degiskenler, parametreler
            // kebap-case: html, css, js dosya isimleri. CSS'de id ve class isimleri
        }
    }
     */
