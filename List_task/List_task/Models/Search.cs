using System;
using System.Collections.Generic;
using System.Text;

namespace List_task
{
    class Search
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public Search(int id, string location,DateTime checkIn, DateTime checkOut)
        {
            Id = id;
            Location = location;
            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        public string Time
        {
            get
            {

                string s = String.Format("{0} - {1}",CheckIn.ToString("d"), CheckOut.ToString("d"));
                return s;
            }
        }

    }
}
