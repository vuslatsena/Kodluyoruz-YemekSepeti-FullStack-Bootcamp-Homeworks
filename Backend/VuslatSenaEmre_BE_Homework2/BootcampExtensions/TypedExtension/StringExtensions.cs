using System;
using System.Collections.Generic;
using System.Text;

namespace BootcampExtensions.TypedExtension
{
    public static class StringExtensions
    {
        public static bool IsEmpty(this string p)
        {
            //gönderilen string parametresinin boş olup olmadığını kontrol ediyor.
            return string.IsNullOrWhiteSpace(p);
        }

        public static bool IsFilled(this string p)
        {
            //string ifadesi dolu mu?
            return !IsEmpty(p);
        }
    }
}
