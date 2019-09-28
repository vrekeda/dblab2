using System;
using System.Collections.Generic;

namespace dblab2
{
    public partial class Client
    {
        public Client()
        {
            ClientToTour = new HashSet<ClientToTour>();
            TravelAgencyToClient = new HashSet<TravelAgencyToClient>();
        }

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime? Birthdate { get; set; }
        public bool Gender { get; set; }

        public ICollection<ClientToTour> ClientToTour { get; set; }
        public ICollection<TravelAgencyToClient> TravelAgencyToClient { get; set; }
    }
}
