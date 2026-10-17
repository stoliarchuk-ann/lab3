using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class Drops : Medicine, IApplicable, IExpirationCheckable, IHasSideEffects
    {
        public Drops(string name, string dosage, double price) : base(name, dosage, price)
        {
        }

        public override string Apply()
        {
            return $"Закапати краплі {name} (дозування: {dosage}).";
        }

        public override string GetSideEffects()
        {
            return $"Побічні ефекти від {name}: можлива алергічна реакція.";
        }

        public bool CheckExpirationDate(int monthsPassed)
        {
            if (monthsPassed > 12)
                return false;
            else
                return true;
        }
    }
}
