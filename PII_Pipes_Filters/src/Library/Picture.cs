using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CompAndDel
{
    public class Picture : IPicture
    {
        private Color[,] matrizColores;
       
        public string ImagePath { get;}

        /// <summary>
        /// Constructor de imagen
        /// </summary>
        /// <param name="width">Ancho en pixels de la imagen</param>
        /// <param name="height">Altura en pixels de la imagen</param>
        /// <param name="imagePath">Path de la imágen original para el uso de filtros condicionales</param>

        public Picture(Int32 width, Int32 height, string imagePath)
        {
            this.matrizColores = new Color[width, height];
            this.matrizColores.Initialize();
            this.ImagePath = imagePath;
        }
        /// <summary>
        /// Devuelve el ancho en pixels de la imagen
        /// </summary>
        public Int32 Width 
        { 
            get {return this.matrizColores.GetLength(0); }
        }
        /// <summary>
        /// Devuelve la altura en pixels de la imagen
        /// </summary>
        public Int32 Height 
        {
            get { return this.matrizColores.GetLength(1); } 
        }
        /// <summary>
        /// Devuelve el color que compone la imagen en un pixel en particular en coordenadas cartesianas
        /// </summary>
        /// <param name="x">coordenada x del pixel a seleccionar</param>
        /// <param name="y">coordenada y del pixel a seleccionar</param>
        /// <returns>Color del pixel seleccionado</returns>
        public Color GetColor(Int32 x, Int32 y)
        {
            return this.matrizColores[x, y];
        }
        /// <summary>
        /// Setea el color que compone la imagen en un pixel en particular en coordenadas cartesianas
        /// </summary>
        /// <param name="x">coordenada x del pixel a seleccionar</param>
        /// <param name="y">coordenada y del pixel a seleccionar</param>
        /// <param name="color">Nuevo color del pixel seleccionado</param>
        public void SetColor(Int32 x, Int32 y, Color color)
        {
            this.matrizColores[x, y] = color;
        }
        /// <summary>
        /// Modifica el tamaño de la imagen. Si la nueva imagen es mas grande, los pixels nuevos se colorean en negro
        /// </summary>
        /// <param name="width">Nuevo ancho de la imagen en pixels</param>
        /// <param name="height">Nueva altura de la imagen en pixels</param>
        public void Resize(Int32 width, Int32 height)
        {
            Color[,] nuevaMatriz = new Color[width, height];
            nuevaMatriz.Initialize();
            
            int minX, minY;
            minX = Math.Min(width, this.Width);
            minY = Math.Min(height, this.Height);
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    nuevaMatriz[x, y] = Color.Black;
                }
            }

            for (int x = 0; x < minX; x++)
            {
                for (int y = 0; y < minY; y++)
                {
                    nuevaMatriz[x, y] = this.matrizColores[x, y];
                }
            }
            this.matrizColores = nuevaMatriz;
        }
        /// <summary>
        /// Devuelve un clon de la imagen
        /// </summary>
        /// <returns>Clon de la imagen</returns>
        public IPicture Clone()
        {
            Picture pictureClone = new Picture(this.Width, this.Height, this.ImagePath);
            for (int x = 0; x < pictureClone.Width; x++)
            {
                for (int y = 0; y < pictureClone.Height; y++)
                {
                    pictureClone.SetColor(x, y, this.matrizColores[x,y]);
                }
            }
            return pictureClone;
        }
    }
}
