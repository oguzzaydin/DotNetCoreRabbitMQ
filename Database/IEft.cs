using System;
using System.Collections.Generic;
using System.Text;
using Database.Models;

namespace Database
{
    public interface IEft
    {
        void Send(SendingEftModel model);
        Customer GetCustomer(int userId);
    }
}
