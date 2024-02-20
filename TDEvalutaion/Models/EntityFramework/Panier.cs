using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TDEvalutaion.Models.EntityFramework
{
    [Table("panier")]
    public class Panier
    {
        [Key]
        [Column("idpanier")]
        public int IdPanier { get; set; }

        [Key]
        [Column("idfruit")]
        public int IdFruit { get; set; }

        [Column("quantitepanier")]
        public int Quantitepanier { get; set; }


        [ForeignKey("IdFruit")]
        [InverseProperty("PanierDuFruit")]
        public virtual Fruit? FruitDuPanier { get; set; }

    }
}
