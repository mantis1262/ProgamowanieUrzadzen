using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Events
{
    public class CyclicEvent : EventArgs
    {
        public CyclicEvent(long counter)
        {
            Counter = counter;
        }

        public long Counter { get; private set; }
    }
}
