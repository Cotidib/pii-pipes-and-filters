using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using CompAndDel;
using System.Diagnostics;

namespace CompAndDel.Filters
{
    public class FilterGreyscale : IFilter
    {
        /// <summary>
        /// Recibe una imagen y la retorna con un filtro de escala de grises aplicado.
        /// </summary>
        /// <param name="image">Imagen a la que se le va a aplicar el filtro.</param>
        /// <returns>Imagen con el filtro aplicado.</returns>
        public IPicture Filter(IPicture image)
        {
            Debug.Assert(image != null);
            IPicture greyScale = image.Clone();
            for (int x = 0; x < greyScale.Width; x++)
            {
                for (int y = 0; y < greyScale.Height; y++)
                {
                    Color colorOriginal = greyScale.GetColor(x, y);

                    byte rOriginal = colorOriginal.R;
                    byte gOriginal = colorOriginal.G;
                    byte bOriginal = colorOriginal.B;
                    int luma = (int)((rOriginal * 0.3) + (gOriginal * 0.59) + (bOriginal * 0.11));
                    Color colorGris;
                    colorGris = Color.FromArgb(luma, luma, luma);
                    greyScale.SetColor(x, y, colorGris);
                }
            }
            return greyScale;
        }
    }
}
