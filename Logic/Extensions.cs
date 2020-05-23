using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public static class Extensions
    {
        public static ArraySegment<byte> GetArraySegment(this string message)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            return new ArraySegment<byte>(buffer);
        }
    }
}
