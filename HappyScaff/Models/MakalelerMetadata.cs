using System;
using System.ComponentModel.DataAnnotations;

namespace HappyScaff.Models
{
    [MetadataType(typeof(MakalelerMetadata))]
    public partial class Makaleler
    {
    }

    public partial class MakalelerMetadata
    {
        [Required(ErrorMessage = "Please enter : MakaleId")]
        [Display(Name = "MakaleId")]
        public int MakaleId { get; set; }

        [Display(Name = "MakaleBaslik")]
        [MaxLength(50)]
        public string MakaleBaslik { get; set; }

        [Display(Name = "MakaleIcerik")]
        [MaxLength(50)]
        public string MakaleIcerik { get; set; }

        [Display(Name = "KategoriId")]
        public int KategoriId { get; set; }

        [Display(Name = "Kategoriler")]
        public Kategoriler Kategoriler { get; set; }

    }
}
