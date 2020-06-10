﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ClientData.Communication
{
    internal static class Extensions
    {
        internal static ArraySegment<byte> GetArraySegment(this string message)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            return new ArraySegment<byte>(buffer);
        }
    }
}
