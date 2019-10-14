using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
/**
 * Sebastian Gonzalez
 * seba.gonzalezp17@gmail.com
 * */
namespace ProjectGraphql.Model
{
    public class Room
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Number { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        public RoomStatus Status { get; set; }

        public bool AllowedSmoking { get; set; }

        public Room()
        {

        }
        public Room(int number, string name, RoomStatus status, bool allowedSmoking)
        {
            Number = number;
            Name = name;
            Status = status;
            AllowedSmoking = allowedSmoking;
        }
    }
}
