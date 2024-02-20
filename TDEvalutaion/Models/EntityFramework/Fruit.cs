using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TDEvalutaion.Models.EntityFramework
{
    [Table("fruit")]
    public class Fruit
    
    {
        [Key]
        [Column("idfruit")]
        public int IdFruit{ get; set; }

        [Column("nomfruit")]
        [StringLength(100)]
        public string NomFruit { get; set; }


        [Column("poidsfruit" )]
        public int PoidsFruit { get; set; }

        [InverseProperty("FruitDuPanier")]
        public virtual ICollection<Panier> PanierDuFruit { get; set; } = new List<Panier>();

    }
}
