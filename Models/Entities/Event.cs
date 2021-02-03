using System;


namespace APX.Models
{
    public class Event
    {
        public int SEQ { get; set; }

        public string APISystem { get; set; }

        public string APIName { get; set; }

        public string APIVersion { get; set; }

        public string Source { get; set; }

        public string Name { get; set; }
        
        public DateTime Time { get; set; }

        public string Flow { get; set; }

        public string IPAddress { get; set; }

        public string Status { get; set; }

        public string Desc { get; set; }

        public string CreatedUser { get; set; }

        public DateTime CreatedDate { get; set; }

        public string UpdatedUser { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}