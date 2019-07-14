using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Models
{
    public  class SendingEftModel
    {
        public int FromId { get; set; }
        public int ToId { get; set; }
        public double Money { get; set; }
    }
}
