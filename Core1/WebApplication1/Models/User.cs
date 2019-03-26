using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    [Table("dbtest")]
    public class User
    {
        [Required, MinLength(5), Key]
        public string Id { get; set; }

        [EmailAddress, Required]
        public string Name { get; set; }

        [CheckAda("asdfasfd",Nama = "asdfasdfasdf"), Column("pwd")]
        public string Password { get; set; }

        public override string ToString()
        {
            return base.ToString();
            //return $"Id:{Id}; Name:{Name}; Password:{Password}";
        }
    }

    public class CheckAdaAttribute : RequiredAttribute
    {
        public CheckAdaAttribute(string id)
        {

        }

        public string Nama { get; set; }
    }
}
