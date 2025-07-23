using AdminPanel.DAL.Configuration.DataType;
using AdminPanel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdminPanel.DAL.Configuration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public const string Table_name = "account";

        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable(Table_name);

            builder.HasKey(e => new { e.Id });
            builder.HasIndex(e => e.Email);

            builder.Property(e => e.Id)
                   .HasColumnType(EntityDataTypes.Guid)
                   .HasColumnName("pk_account_id");

            builder.Property(e => e.Name)
                   .HasColumnType(EntityDataTypes.Character_varying)
                   .HasColumnName("name");

            builder.Property(e => e.Email)
                   .HasColumnType(EntityDataTypes.Character_varying)
                   .HasColumnName("email");

            builder.Property(e => e.Password)
                   .HasColumnType(EntityDataTypes.Character_varying)
                   .IsRequired()
                   .HasColumnName("password");

            builder.Property(e => e.Salt)
                   .HasColumnType(EntityDataTypes.Character_varying)
                   .HasColumnName("salt");

            builder.Property(e => e.Status)
                   .HasColumnType(EntityDataTypes.Smallint)
                   .HasColumnName("status");
        }
    }
}
