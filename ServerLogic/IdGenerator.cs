using System;
using System.Collections.Generic;
using System.Text;

namespace ServerLogic
{
    public static class IdGenerator
    {
        private const string CLIENT_ID_PREFIX = "CLIENT_";
        private const string ORDER_ID_PREFIX = "ORDER_";
        private static int _clientNum = 1;
        private static int _orderNum = 1;

        public static int ClientNum { get => _clientNum; set => _clientNum = value; }
        public static int OrderNum { get => _orderNum; set => _orderNum = value; }

       

        public static string GetNextCustomerId()
        {
            string id = CLIENT_ID_PREFIX + _clientNum.ToString();
            ++_clientNum;
            return id;
        }

        public static string GetNextOrderId()
        {
            string id = ORDER_ID_PREFIX + _orderNum.ToString();
            ++_orderNum;
            return id;
        }
    }
}
