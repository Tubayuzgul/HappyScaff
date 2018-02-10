using System;
using System.ComponentModel.DataAnnotations;

namespace HappyScaff.Models
{
    [MetadataType(typeof(KategorilerMetadata))]
    public partial class Kategoriler
    {
    }

    public partial class KategorilerMetadata
    {
        [Required(ErrorMessage = "Please enter : KategoriId")]
        [Display(Name = "KategoriId")]
        public int KategoriId { get; set; }

        [Display(Name = "KategoriBaslik")]
        [MaxLength(50)]
        public string KategoriBaslik { get; set; }

        [Display(Name = "KategoriIcerik")]
        [MaxLength(50)]
        public string KategoriIcerik { get; set; }

        [Display(Name = "Makaleler")]
        public Makaleler Makaleler { get; set; }

    }
}
