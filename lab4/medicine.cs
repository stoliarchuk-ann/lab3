using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public abstract class Medicine
    {
        public string name;
        public string dosage;
        private double price;
        public double Price
        {
            get { return price; }
            set
            {
                if (value < 0) 
                    throw new ArgumentException("Ціна не може бути від'ємною.", nameof(value));
                price = value;
            }
        }
        public Medicine(string name, string dosage, double price)
        {
            this.name = name;
            this.dosage = dosage;
            this.Price = price;
        }
        public abstract string Apply();
        public abstract string GetSideEffects();
    }

    public class Tablet : Medicine, IApplicable, IHasSideEffects
    {
        public int pillsInPackage;
        public Tablet(string name, string dosage, double price, int pillsInPackage)
            : base(name, dosage, price)
        {
            this.pillsInPackage = pillsInPackage;
        }
        public int CalculateTreatmentCourse(int pillsPerDay)
        {
            return pillsInPackage / pillsPerDay;
        }
        public override string Apply()
        {
            return $"Прийняти таблетку {name} (дозування: {dosage}).";
        }
        public override string GetSideEffects()
        {
            return $"Побічні ефекти від {name}: можливий головний біль або нудота.";
        }
    }

    public class Syrup : Medicine, IApplicable, IExpirationCheckable, IHasSideEffects
    {
        public double volume;
        public Syrup(string name, string dosage, double price, double volume) 
            : base(name, dosage, price)
        {
            this.volume = volume;
        }
        public bool CheckExpirationDate(int monthsPassed)
        {
            if (monthsPassed > 12)
                return false;
            else
                return true;
        }
        public override string Apply()
        {
            return $"Прийняти сироп {name} (дозування: {dosage}).";
        }
        public override string GetSideEffects()
        {
            return $"Побічні ефекти від {name}: можливий головний біль та запаморочення.";
        }
    }
}
