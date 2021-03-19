using System;
using System.Collections.Generic;
using System.Text;
using BootcampExtensions.Model;
using System.Linq;

namespace BootcampExtensions.TypedExtension
{
    public static class LateFeeExtension
    { //Burada geç verilen kitaba LateFee ücretini yansıt işlemi yapıyoruz. En uzun süre geç verilene en çok ceza kesilecektir. Bu şekilde totalFee olarak döndüreceğiz
        public static void ApplyLateFee(this List<Library> TotalLateFee)
        {
            //buradaki business LateDateCount değerini alacağız ve LateFee ile çarpıp döndüreceğiz TotalLateFee olarak döndürmek
            var MaxLateFee = TotalLateFee.OrderByDescending(p => p.LateDateCount).FirstOrDefault();
            MaxLateFee.TotalFee = (MaxLateFee.LateDateCount * MaxLateFee.LateFee);


        }
       
        
    }
}
