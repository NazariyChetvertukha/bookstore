﻿using System.IO;
using System.Text;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Store.Web.Models;

namespace Store.Web
{
    public static class SessionExtensions
    {
        private const string key = "Cart";

        public static void Set(this ISession session, Cart value)
        {
            if (value == null)
                return;
            using (var stream = new MemoryStream())
            using (var writter = new BinaryWriter(stream, Encoding.UTF8, true))
            {
                writter.Write(value.OrderId);
                writter.Write(value.TotalCount);
                writter.Write(value.TotalPrice);
                
                session.Set(key, stream.ToArray());
            }
        }

        public static bool TryGetCart(this ISession session, out Cart value)
        {
            if (session.TryGetValue(key, out byte[] buffer))
            {
                using (var stream = new MemoryStream(buffer))
                using (var reader = new BinaryReader(stream, Encoding.UTF8, true))
                {

                    var orderId = reader.ReadInt32();
                    var totalCount = reader.ReadInt32();
                    var totalPrice = reader.ReadDecimal();

                    value = new Cart(orderId)
                    {
                        TotalCount = totalCount,
                        TotalPrice = totalPrice,
                    };
                    
                    return true;
                }
            }

            value = null;
            return false;
        }
    }
}