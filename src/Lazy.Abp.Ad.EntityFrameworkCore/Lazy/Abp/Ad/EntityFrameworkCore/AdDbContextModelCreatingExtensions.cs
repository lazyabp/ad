using System;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Lazy.Abp.Ad.EntityFrameworkCore
{
    public static class AdDbContextModelCreatingExtensions
    {
        public static void ConfigureAd(
            this ModelBuilder builder,
            Action<AdModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new AdModelBuilderConfigurationOptions(
                AdDbProperties.DbTablePrefix,
                AdDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            /* Configure all entities here. Example:

            builder.Entity<Question>(b =>
            {
                //Configure table & schema name
                b.ToTable(options.TablePrefix + "Questions", options.Schema);
            
                b.ConfigureByConvention();
            
                //Properties
                b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);
                
                //Relations
                b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

                //Indexes
                b.HasIndex(q => q.CreationTime);
            });
            */


            builder.Entity<Advertising>(b =>
            {
                b.ToTable(options.TablePrefix + "Advertisings", options.Schema);
                b.ConfigureByConvention();

                b.HasIndex(q => q.Name);
                b.HasMany(q => q.Items).WithOne().HasForeignKey(x => x.AdvertisingId);
                /* Configure more properties here */
            });

            builder.Entity<AdvertisingItem>(b =>
            {
                b.ToTable(options.TablePrefix + "AdvertisingItems", options.Schema);
                b.ConfigureByConvention(); 
                
                /* Configure more properties here */
            });


            builder.Entity<UserAdvertising>(b =>
            {
                b.ToTable(options.TablePrefix + "UserAdvertisings", options.Schema);
                b.ConfigureByConvention();

                b.HasIndex(q => q.AdvertisingItemId);
                //b.HasOne(m => m.AdvertisingItem).WithMany().OnDelete(DeleteBehavior.NoAction);

                /* Configure more properties here */
            });
        }
    }
}
