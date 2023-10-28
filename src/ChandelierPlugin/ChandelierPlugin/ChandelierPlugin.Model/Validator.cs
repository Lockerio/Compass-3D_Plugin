using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChandelierPlugin.Model
{
    public class Validator
    {
        private bool IsNumberInRange(double value, double min, double max) 
        {
            if (min < value && value < max)
                return true;
            return false;
        }

        public void AssertNumberIsInRange(double value, double min, double max)
        {
            if (IsNumberInRange(value, min, max))
                return;
            throw new Exception("Ваше число не попадает в диапазон доступных чисел!");
        }
    }
}
