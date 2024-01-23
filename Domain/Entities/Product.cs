using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string ManufactureEmail { get; set; }
        public string ManufacturePhone { get; set; }
        public DateTime ProduceDate { get; set; }
        /// <summary>
        /// کاربری که محصول را ایجاد کرده است
        /// </summary>
        public int UserId { get; set; }
        public User User { get; set; }

        public void ValidePersonGenerated(int loggedInUserId)
        {
            if(loggedInUserId != this.UserId)
            {
                throw new Exception("شما نمیتوانید این محصول را حذف کنید");
            }
        }
    }
}
