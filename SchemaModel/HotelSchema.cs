using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGraphql.SchemaModel
{
    public class HotelSchema : Schema
    {
        public HotelSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<ReservationQuery>();
        }
    }
}
