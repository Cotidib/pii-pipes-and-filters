using System;
using System.Drawing;
using CompAndDel;

namespace CompAndDel.Filters
{
    public class SharpenFilter : FilterConvolution
    {
        public SharpenFilter()
        {
          this.MatrizParametros = new int[3, 3];
          this.Complemento = 0;
          this.Divisor = 1;
          MatrizParametros[0, 1] = -1;
          MatrizParametros[1, 0] = -1;
          MatrizParametros[1, 2] = -1;
          MatrizParametros[2, 1] = -1;
          MatrizParametros[1,1] = 5;

        }
    }
}