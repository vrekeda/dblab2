using System;
using System.Collections.Generic;

namespace dblab2
{
    public partial class Tour
    {
        public Tour()
        {
            ClientToTour = new HashSet<ClientToTour>();
        }

        public int Id { get; set; }
        public decimal Price { get; set; }
        public DateTime Tourdate { get; set; }
        public string City { get; set; }
        public int IdTA { get; set; }
        public string Description { get; set; }

        public TravelAgency IdTANavigation { get; set; }
        public ICollection<ClientToTour> ClientToTour { get; set; }
    }
}
