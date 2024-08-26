using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendasLyncas.Domain.Entities;

namespace VendasLyncas.Infra.Context.Configurations
{
    //public class VendaConfiguration : IEntityTypeConfiguration<Venda>
    //{
    //    public void Configure(EntityTypeBuilder<Venda> builder)
    //    {
    //        builder.HasKey(p => p.Id);

    //        builder.Property(p => p.QuantidadeItens)
    //            .IsRequired();

    //        builder.Property(p => p.DataVenda)
    //            .IsRequired();

    //        builder.Property(p => p.DataFaturamento)
    //            .IsRequired();

    //        builder.Property(p => p.ValorTotal)
    //            .IsRequired();

    //        builder.ToTable("Venda");

    //        builder.HasMany(p => p.Itens)
    //            .WithOne(p => p.Venda)
    //            .HasForeignKey(p => p.VendaId)
    //    }
    //}
}
