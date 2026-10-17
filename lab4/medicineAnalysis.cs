using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class MedicineAnalysis
    {
        public static double GetTotalCost(List<Medicine> medicines)
        {
            double totalCost = 0;
            foreach (var med in medicines)
            {
                totalCost += med.Price;
            }

            return totalCost;
        }

        public static int GetValidMedicinesCount(List<IExpirationCheckable> medicines, int monthsPassed)
        {
            int validCount = 0;
            foreach (var med in medicines)
            {
                if (med.CheckExpirationDate(monthsPassed))
                    validCount++;
            }
            return validCount;
        }
    }
}
