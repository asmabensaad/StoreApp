using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class Stock
    {

        [Required]
        public int position { get; set; }
        public string Classe { get; set; }
        public int Type { get; set; }
        [Key]
        public string MSPEREF { get; set; }
        public string designation { get; set; }
        public string Constructeur { get; set; }
        public string fournisseur { get; set; }
        public string REFEXTERNE { get; set; }
        public string UNITE { get; set; }
        public float PRICE { get; set; }



    }
}
