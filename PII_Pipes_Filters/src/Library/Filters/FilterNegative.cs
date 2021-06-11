using System;
using System.Collections.Generic;
using System.Text;
using CompAndDel;
using System.Drawing;
using System.Diagnostics;

namespace CompAndDel.Filters
{
    public class FilterNegative : IFilter
    {
        /// <summary>
        /// Recibe una imagen y la retorna con un filtro del tipo negativo aplicado
        /// </summary>
        /// <param name="image">Imagen a la cual se le va a plicar el filtro.</param>
        /// <returns>Imagen con el filtro aplicado</returns>
        public IPicture Filter(IPicture image)
        {
            Debug.Assert(image != null);
            IPicture negativo = image.Clone();
            for (int x = 0; x < negativo.Width; x++)
            {
                for (int y = 0; y < negativo.Height; y++)
                {
                    Color colorOriginal = negativo.GetColor(x,y);

                    byte rOriginal = colorOriginal.R;
                    byte gOriginal = colorOriginal.G;
                    byte bOriginal = colorOriginal.B;
                   
                    byte rNeg = Convert.ToByte(Math.Abs(rOriginal - byte.MaxValue));
                    byte gNeg = Convert.ToByte(Math.Abs(gOriginal - byte.MaxValue));
                    byte bNeg = Convert.ToByte(Math.Abs(bOriginal - byte.MaxValue));

                    Color colorNegativo;
                    colorNegativo = Color.FromArgb(rNeg, gNeg, bNeg);

                    negativo.SetColor(x, y, colorNegativo);
                }
            } 
            return negativo;
        }
    }
}
