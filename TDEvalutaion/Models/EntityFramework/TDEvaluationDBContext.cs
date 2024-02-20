using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace TDEvalutaion.Models.EntityFramework
{
  
        public partial class TDEvaluationDBContext : DbContext
        {
            public TDEvaluationDBContext()
            {
            }

            public TDEvaluationDBContext(DbContextOptions<TDEvaluationDBContext> options)
                : base(options)
            {
            }

            public virtual DbSet<Fruit> Fruits { get; set; } = null!;
            public virtual DbSet<Panier> Paniers { get; set; } = null!;//mettre les deux noms des models au pluriel
         



           // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            //{
                //            if (!optionsBuilder.IsConfigured)
                //            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //                optionsBuilder.UseNpgsql("Server=localhost;port=5432;Database=TP4; uid=postgres; \npassword=postgres;");
                //            }
           // }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {

            modelBuilder.Entity<Panier>(entity => entity.HasOne(d => d.FruitDuPanier).WithMany(p => p.PanierDuFruit)
       .HasForeignKey(d => d.IdFruit).OnDelete(DeleteBehavior.Restrict).HasConstraintName("fk_pan_frt"));//montrer la clef etrangere

            modelBuilder.Entity<Panier>().HasKey(d => d.IdPanier).HasName("pk_panier");//bien montrer qui est la vraie clef primaire quand le model a deux [key]

        }

            partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        }
    }


