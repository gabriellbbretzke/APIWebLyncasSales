using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendasLyncas.Domain.Entities;

namespace VendasLyncas.Infra.Context.Configurations
{
    //public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    //{
    //    public void Configure(EntityTypeBuilder<Cliente> builder)
    //    {
    //        builder.HasKey(p => p.Id);

    //        builder.Property(p => p.Nome)
    //            .HasMaxLength(200)
    //            .IsRequired();

    //        builder.Property(p => p.Email)
    //            .HasMaxLength(300)
    //            .IsRequired();

    //        builder.Property(p => p.Telefone)
    //            .HasMaxLength(20)
    //            .IsRequired();

    //        builder.Property(p => p.Cpf)
    //            .HasMaxLength(14)
    //            .IsRequired();

    //        builder.Property(p => p.FlagAtivo)
    //            .IsRequired();

    //        builder.ToTable("Cliente");
    //    }
    //}
}
