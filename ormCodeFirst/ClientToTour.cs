using System;
using System.Collections.Generic;

namespace dblab2
{
    public partial class ClientToTour
    {
        public int ClientId { get; set; }
        public int TourId { get; set; }

        public Client Client { get; set; }
        public Tour Tour { get; set; }
    }
}
