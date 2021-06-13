using System;
using System.Drawing;
using CompAndDel;

namespace CompAndDel.Filters
{
    public class GaussianBlurFilter : FilterConvolution
    {
        public GaussianBlurFilter()
        {
          this.MatrizParametros = new int[3, 3];
          this.Complemento = 0;
          this.Divisor = 16;
          MatrizParametros[0, 1] = 2;
          MatrizParametros[1, 0] = 2;
          MatrizParametros[1, 2] = 2;
          MatrizParametros[2, 1] = 2;
          MatrizParametros[0, 0] = 1;
          MatrizParametros[0, 2] = 1;
          MatrizParametros[2, 0] = 1;
          MatrizParametros[2, 2] = 1;
          MatrizParametros[1,1] = 4;

        }
    }
}