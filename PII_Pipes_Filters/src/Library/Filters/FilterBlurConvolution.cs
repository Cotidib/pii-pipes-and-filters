using System;
using System.Drawing;
using CompAndDel;

namespace CompAndDel.Filters
{
    public class FilterBlurConvolution : IFilter
    {
        protected int[,] matrizParametros;
        protected int complemento, divisor;
        /// <summary>
        /// Filtro complejo que suaviza los bordes de una imagen.
        /// </summary>
        /// <param name="name">Nombre del objeto</param>
        public FilterBlurConvolution()
        {
            this.matrizParametros = new int[3, 3];
            this.complemento = 0;
            this.divisor = 9;
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    matrizParametros[x, y] = 1;
                }
            }
        }
        /// <summary>
        /// Recibe una imagen y la retorna con el filtro aplicado.
        /// </summary>
        /// <param name="image">Imagen a la cual se le va a plicar el filtro</param>
        /// <returns>Imagen con el filtro aplicado</returns>
        public IPicture Filter(IPicture image)
        {
            IPicture imagenFiltrada = image.Clone();
            Color[,] matrizVecinos;
            
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    matrizVecinos = CrearMatriz(image, x, y);
                    imagenFiltrada.SetColor(x, y, ObtenerColorFiltrado(matrizVecinos));
                }
            }
            return imagenFiltrada;
        }

        private Color ObtenerColorFiltrado(Color[,] matrizVecinos)
        {
            int redFinal = 0;
            int greenFinal = 0;
            int blueFinal = 0;

            for (int x = 0; x < matrizVecinos.GetLength(0); x++)
            {
                for (int y = 0; y < matrizVecinos.GetLength(1); y++)
                {
                    redFinal += matrizVecinos[x, y].R * this.matrizParametros[x, y]; 
                    greenFinal += matrizVecinos[x, y].G * this.matrizParametros[x, y]; 
                    blueFinal += matrizVecinos[x, y].B * this.matrizParametros[x, y];        
                }
            }
            redFinal = Math.Abs((redFinal/this.divisor) + this.complemento);
            redFinal = Math.Min(255, redFinal);
            
            greenFinal = Math.Abs((greenFinal / this.divisor) + this.complemento);
            greenFinal = Math.Min(255, greenFinal);
            
            blueFinal = Math.Abs((blueFinal / this.divisor) + this.complemento);
            blueFinal = Math.Min(255, blueFinal);
            return Color.FromArgb(redFinal, greenFinal, blueFinal);
        }

        private Color[,] CrearMatriz(IPicture image, int x, int y)
        {
            Color[,] matriz = new Color[3,3];
            
            matriz[0,0] = image.GetColor(Math.Max(x-1, 0), Math.Max(y-1,0));
            matriz[1,0] = image.GetColor(x, Math.Max(y-1,0));
            matriz[2,0] = image.GetColor(Math.Min(x+1, image.Width -1), Math.Max(y-1,0));
            matriz[0,1] = image.GetColor(Math.Max(x-1, 0), y);
            matriz[1,1] = image.GetColor(x, y);
            matriz[2,1] = image.GetColor(Math.Min(x+1, image.Width - 1),y);
            matriz[0,2] = image.GetColor(Math.Max(x-1, 0), Math.Min(y+1,image.Height - 1));
            matriz[1,2] = image.GetColor(x, Math.Min(y+1,image.Height - 1));
            matriz[2,2] = image.GetColor(Math.Min(x+1, image.Width - 1), Math.Min(y+1,image.Height - 1));
                    
            return matriz;
        }
    }
}