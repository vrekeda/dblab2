using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dblab2
{
    class RandomFilling
    {
        private Dictionary<string, List<string>> randData;
        private List<string> fileWithRand;
        private List<int> IdTA;
        private List<int> IdTour;
        private List<int> IdClients;
        dblab2Context db;
        Random random;
        public RandomFilling(dblab2Context db)
        {
            this.db = db;
            InitiateRandData();
        }

        public Client GetRandClient()
        {
            Client client = new Client()
            {
                Firstname = randData["name"][random.Next(randData["name"].Count)],
                Lastname = randData["surname"][random.Next(randData["surname"].Count)],
                Birthdate = DateTime.Parse(GetRandomDate(1900, 118)),
                Gender = GetRandomGender()
            };
            //client.ClientToTour.Add(new ClientToTour { TourId = IdTour[random.Next(IdTour.Count)] });
            return client;
        }

        public TravelAgency GetRandTravelAgency()
        {
            TravelAgency travelAgency = new TravelAgency()
            {
                Name = randData["compname"][random.Next(randData["compname"].Count)],
                Adress = randData["address"][random.Next(randData["address"].Count)],
            };
            return travelAgency;
        }

        public Tour GetRandTour()
        {
            Tour tour = new Tour()
            {
                City = randData["city"][random.Next(randData["city"].Count)],
                Tourdate = DateTime.Parse(GetRandomDate(2020, 5)),
                Price = GetRandomPrice(),
                IdTA = IdTA[random.Next(IdTA.Count)],
                Description = randData["description"][random.Next(randData["description"].Count)],
            };
            return tour;
        }

        public int GetRandomTourId()
        {

            return IdTour[random.Next(IdTour.Count)];

        }
        public int GetRandomTAId()
        {

            return IdTA[random.Next(IdTA.Count)];

        }
        public int GetRandomClientId()
        {

            return IdClients[random.Next(IdClients.Count)];

        }
        private int GetRandomPrice()
        {
            return random.Next(500, 5000);
        }
        private string GetRandomDate(int begYear, int range)
        {
            return random.Next(begYear, begYear + range).ToString() + "-"
                + random.Next(1, 12).ToString() + "-"
                + random.Next(1, 31).ToString();
        }
        public bool GetRandomGender()
        {
            if (random.Next(0, 2) == 0)
                return false;
            else
                return true;
        }
        private void InitiateRandData()
        {
            IdTA = new List<int>();
            IdTour = new List<int>();
            IdClients = new List<int>();
            foreach (Client client in db.Clients.ToList())
            {
                IdClients.Add(client.Id);
            }
            foreach (Tour tour in db.Tours)
            {
                IdTour.Add(tour.Id);
            }
            foreach (TravelAgency travelAgency in db.TravelAgencies)
            {
                IdTA.Add(travelAgency.Id);
            }
            random = new Random();
            randData = new Dictionary<string, List<string>>
            {
                {"address", new List<string>() },
                {"name", new List<string>() },
                {"city", new List<string>() },
                {"surname", new List<string>() },
                {"compname", new List<string>() },
                {"description", new List<string>()  }
            };
            fileWithRand = new List<string>
            {
                "address",
                "name",
                "city",
                "surname",
                "compname",
                "description"
            };
            string tmp;
            foreach (string file in fileWithRand)
            {
                StreamReader reader;
                try
                {
                    reader = new StreamReader("../../Random/random_" + file + ".csv");
                }
                catch (Exception ex)
                {
                    Console.Write($"File not found\n{ex.Message}");
                    return;
                }
                while ((tmp = reader.ReadLine()) != null)
                {
                    randData[file].Add(tmp);
                }
                reader.Close();
            }
        }
    }
}
