using System;
using System.Collections.Generic;

namespace dblab2
{
    public partial class TravelAgency
    {
        public TravelAgency()
        {
            Tour = new HashSet<Tour>();
            TravelAgencyToClient = new HashSet<TravelAgencyToClient>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }

        public virtual ICollection<Tour> Tour { get; set; }
        public virtual ICollection<TravelAgencyToClient> TravelAgencyToClient { get; set; }
    }
}
