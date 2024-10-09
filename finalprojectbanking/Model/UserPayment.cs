using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using finalprojectbanking.Model;


namespace finalprojectbanking.Model
{
   public class UserPayment
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Family { get; set; }
        public string IdCard { get; set; }
        public string Phone { get; set; }
        public string Fullname { get; set; }
        public int Nuneycetegory { get; set; }
        public string NumberLone { get; set; }
        public decimal LoneMoney { get; set; }
        public int MoneyFirst { get; set; }
        public int Interest { get; set; }
        public decimal UserPay { get; set; }
        public decimal TotalUserPay { get; set; }
    }
}
