using System;
using System.Collections.Generic;

namespace dblab2
{
    public partial class TravelAgencyToClient
    {
        public int TravelAgencyId { get; set; }
        public int ClientId { get; set; }

        public Client Client { get; set; }
        public TravelAgency TravelAgency { get; set; }
    }
}
