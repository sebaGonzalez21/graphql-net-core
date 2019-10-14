﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
/**
 * Sebastian Gonzalez
 * seba.gonzalezp17@gmail.com
 * */
namespace ProjectGraphql.Model
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("RoomId")]
        public Room Room { get; set; }
        public int RoomId { get; set; }

        [ForeignKey("GuestId")]
        public Guest Guest { get; set; }
        public int GuestId { get; set; }

        [Required]
        public DateTime CheckinDate { get; set; }

        public DateTime CheckoutDate { get; set; }

        public Reservation()
        {

        }

        public Reservation(DateTime checkinDate, DateTime checkoutDate, int roomId, int guestId)
        {
            CheckinDate = checkinDate;
            CheckoutDate = checkoutDate;
            RoomId = roomId;
            GuestId = guestId;
        }
    }
}
