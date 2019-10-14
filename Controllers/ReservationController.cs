using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectGraphql.Model;
using ProjectGraphql.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Graphql.Controllers
{
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private readonly ReservationRepository _reservationRepository;

        public ReservationsController(ReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Reservation>> List() {
            return await _reservationRepository.GetAll();
        }
    }
}
