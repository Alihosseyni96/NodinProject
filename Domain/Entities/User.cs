using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get => $"{this.FirstName} {this.LastName}"; }
        
        /// <summary>
        /// محصولاتی که کاربر ایجاد کرده است
        /// </summary>
        public ICollection<Product> Products { get; set; }


    }
}
