using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class IdGenerator
    {
        private const string CLIENT_ID_PREFIX = "CLIENT_";
        private const string ORDER_ID_PREFIX = "ORDER_";
        private int _clientNum;
        private int _orderNum;

        public int ClientNum { get => _clientNum; }
        public int OrderNum { get => _orderNum; }

        public IdGenerator()
        {
            _clientNum = 1;
            _orderNum = 1;
        }

        public string GetNextCustomerId()
        {
            string id = CLIENT_ID_PREFIX + _clientNum.ToString();
            ++_clientNum;
            return id;
        }

        public string GetNextOrderId()
        {
            string id = ORDER_ID_PREFIX + _orderNum.ToString();
            ++_orderNum;
            return id;
        }
    }
}
