using System;
using System.ComponentModel.DataAnnotations;
/**
 * Sebastian Gonzalez
 * seba.gonzalezp17@gmail.com
 * */
namespace ProjectGraphql.Model
{
    public class Guest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        public string Name { get; set; }

        public DateTime RegisterDate { get; set; }

        public Guest()
        {

        }

        public Guest(string name, DateTime registerDate)
        {
            Name = name;
            RegisterDate = registerDate;
        }
    }
}
