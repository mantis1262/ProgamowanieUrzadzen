using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Logic.Services;
using Data.Model;
using Logic.Dto;
using Logic.Events;
using System.Reactive.Linq;

namespace LogicTest
{
    [TestClass]
    public class CyclicDiscountTests
    {
        //[TestMethod]
        //public void TimerTest()
        //{
        //    using (CyclicDiscountService _timer = new CyclicDiscountService(10, TimeSpan.FromSeconds(1)))
        //    {
        //        int counter = 0;
        //        IObservable<System.Reactive.EventPattern<DiscountEvent>> _tickObservable = Observable.FromEventPattern<DiscountEvent>(_timer, "Handler");

        //        Assert.AreEqual(0, counter);

        //        using (IDisposable _observer = _tickObservable.Subscribe(x => counter++))
        //        {
        //            _timer.Start();
        //            System.Threading.Thread.Sleep(2000);
        //        }

        //        Assert.AreNotEqual(0, counter);
        //    }
        //}
    }
}
