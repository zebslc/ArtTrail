namespace ArtTrail.DomainEntities.ModelMapping
{
    using System.Data.Entity.ModelConfiguration;

    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            this.Property(x => x.CategoryName).HasMaxLength(50).IsRequired();
            this.HasMany(m => m.ChildCategories).WithMany();
        }
    }
}
