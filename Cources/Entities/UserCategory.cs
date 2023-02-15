using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cources.Areas.Admin.Models;

namespace Cources.Entities
{
    public class UserCategory
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        
        public int CategoryId { get; set; }
        public virtual List<UserModel> Users { get; set; }
        public virtual Category Categories { get; set; }
    }
}
