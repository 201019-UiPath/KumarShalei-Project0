using System;
using System.Collections.Generic;

namespace TeaLib
{
    public class Order
    {
        int orderId;
        int customerId;
        int locationId;
        List<string> items = new List<string>();
        string subtotal;
        DateTime date;
        bool completed;
    }
}