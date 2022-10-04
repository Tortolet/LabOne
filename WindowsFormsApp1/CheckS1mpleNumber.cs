using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class CheckS1mpleNumber
    {
        public bool checkSimpleNumber(int numb)
        {
            int i;
            for (i = 2; i <= Math.Sqrt(numb); i++)
            {
                if (numb % i == 0)
                    return false;
            }
            return true;
        }

        public int[] checkSimpleNumberInterval(int numbA, int numbB)
        {
            if (numbA == 1)
                throw new ArgumentException("Начинайте диапозон от 2.");
            if (numbA > numbB)
                throw new ArgumentException("Вы ввели неправильные значения.");
            if (numbA == numbB)
                throw new ArgumentException("Значения должны отличаться.");

            int[] arrayX = new int[numbB];
            int q = 0;
            for (int i = numbA; i <= numbB; i++)
            {
                if (checkSimpleNumber(i))
                {
                    arrayX[q] = i;
                    q++;
                }
            }
            Array.Resize(ref arrayX, q);
            return arrayX;
        }
    }
}
