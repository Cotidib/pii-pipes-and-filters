using System;
using System.Drawing;
using CompAndDel;

namespace CompAndDel.Filters
{
    public abstract class FilterConvolution : IFilter
    {
        public int[,] MatrizParametros{get; protected set;}
        public int Complemento{get; protected set;} 
        public int Divisor{get; protected set;}
        
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
                    redFinal += matrizVecinos[x, y].R * this.MatrizParametros[x, y]; 
                    greenFinal += matrizVecinos[x, y].G * this.MatrizParametros[x, y]; 
                    blueFinal += matrizVecinos[x, y].B * this.MatrizParametros[x, y];        
                }
            }
            redFinal = Math.Abs((redFinal/this.Divisor) + this.Complemento);
            redFinal = Math.Min(255, redFinal);
            
            greenFinal = Math.Abs((greenFinal / this.Divisor) + this.Complemento);
            greenFinal = Math.Min(255, greenFinal);
            
            blueFinal = Math.Abs((blueFinal / this.Divisor) + this.Complemento);
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