namespace CityPopulationMVC.Models
{
    public class CityModel
    {
        public string City { get; set; }
        public string State { get; set; }
        public int Population { get; set; }

        public List<Itemlist> StateList { get; set; }

        public class Itemlist
        {
            public string Text { get; set; }
            public string Value { get; set; }
        }

        public CityModel()
        {
            StateList = States.Select(x => new Itemlist { Value = x, Text = x }).ToList();
        }

        private string[] States => new[]
            {
"Alabama",
"Alaska",
"Arizona",
"Arkansas",
"California",
"Colorado",
"Connecticut",
"District of Columbia",
"Florida",
"Georgia",
"Hawaii",
"Idaho",
"Illinois",
"Indiana",
"Iowa",
"Kansas",
"Kentucky",
"Louisiana",
"Maryland",
"Massachusetts",
"Michigan",
"Minnesota",
"Mississippi",
"Missouri",
"Montana",
"Nebraska",
"Nevada",
"New Hampshire",
"New Jersey",
"New Mexico",
"New York",
"North Carolina",
"North Dakota",
"Ohio",
"Oklahoma",
"Oregon",
"Pennsylvania",
"Rhode Island",
"South Carolina",
"South Dakota",
"Tennessee",
"Texas",
"Utah",
"Virginia",
"Washington",
"Wisconsin"
            };
    }
}
