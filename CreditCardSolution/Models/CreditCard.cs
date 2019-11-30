using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.UI.WebControls;

namespace CreditCardSolution.Models
{
    public class CreditCard
    {
        [Required]
        [Display(Name = "Credit card digits")]
        public string Digits { get; set; }
        
        public bool IsValid()
        {
            return Digits.All(char.IsDigit) && Digits.Reverse()
                       .Select(c => c - 48)
                       .Select((thisNum, i) => i % 2 == 0
                           ? thisNum
                           :((thisNum *= 2) > 9 ? thisNum - 9 : thisNum)
                       ).Sum() % 10 == 0;
        }

        public string getType()
        {
            switch (Digits[0])
            {
                case '3':
                    if (Digits[1] == '4' || Digits[1] == '7')
                    {
                        return "AMEX";
                    }
                    goto default;
                case '4':
                    return "VISA";
                case '5':
                    int s = Digits[1];
                    if (s >= 1 && s <= 5)
                    {
                        return "MasterCard";
                    }
                    goto default;
                case '6':
                    if (Digits.Substring(1, 3) == "011")
                    {
                        return "Discover";
                    }
                    goto default;
                default:
                    return "Desconhecido";
              
            }
            
        }
    }
}