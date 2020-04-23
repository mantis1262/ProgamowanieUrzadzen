using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Helpers
{
    public class IdGenerator
    {
        private const string ID_PREFIX = "ORDER_";
        private int _orderNum;

        public int OrderNum { get => _orderNum; }

        public IdGenerator()
        {
            _orderNum = 1;
        }

        public string GetNextId()
        {
            string id = ID_PREFIX + _orderNum.ToString();
            ++_orderNum;
            return id;
        }
    }
}
