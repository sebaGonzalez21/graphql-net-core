using AutoMapper.QueryableExtensions;
using ProjectGraphql.DBContext;
using ProjectGraphql.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGraphql.Repository
{
    public class ReservationRepository
    {
        private readonly HotelDbContext _hotelDbContext;

        public ReservationRepository(HotelDbContext hotelDbContext)
        {
            _hotelDbContext = hotelDbContext;
        }

        public async Task<IEnumerable<Reservation>> GetAll()
        {
            return await _hotelDbContext
                .Reservations
                .Include(x => x.Room)
                .Include(x => x.Guest)
                .ToListAsync();
        }

        public Reservation Get(int id)
        {
            return GetQuery().Single(x => x.Id == id);
        }

        public IIncludableQueryable<Reservation, Guest> GetQuery()
        {
            return _hotelDbContext
                 .Reservations
                 .Include(x => x.Room)
                 .Include(x => x.Guest);
        }
    }
}
