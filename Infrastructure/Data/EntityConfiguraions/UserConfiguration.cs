using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.EntityConfiguraions
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            Ignore(x => x.FullName);

            Property(x=> x.FirstName)
                .HasMaxLength(50);

            Property(x=> x.LastName)
                .HasMaxLength(250);

            Property(x=> x.PhoneNumber)
               .HasMaxLength(20);


        }
    }
}
