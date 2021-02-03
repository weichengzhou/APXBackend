using System;


namespace APX.Models
{
    public class Token
    {
        public int SEQ { get; set; }
        
        public string Body { get; set; }
        
        public string CreatedUser { get; set; }

        public DateTime CreatedDate { get; set; }

        public string UpdatedUser { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}