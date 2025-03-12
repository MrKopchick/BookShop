using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BookShop.DataAccess.Entities;
using BookShop.Core.Models;

namespace BookShop.DataAccess.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<BookEntity> 
    {
        public void Configure(EntityTypeBuilder<BookEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.Title).HasMaxLength(Book.MAX_TITLE_LENGTH).IsRequired();

            builder.Property(b => b.Description).IsRequired();

            builder.Property(b => b.Price).IsRequired();
        }
    }
}
