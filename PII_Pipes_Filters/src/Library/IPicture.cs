using System;
using System.Drawing;

namespace CompAndDel
{
    /// <summary>
    /// Una imagen.
    /// </summary>
    /// <remarks>
    /// Las imagenes son una matriz de colores. Adicionalmente, se proveen operaciones para
    /// obtener las dimensiones de la imagen, modificar el tamanio de la imagen, y copiar la imagen
    /// a una nueva imagen.
    /// </remarks>
    public interface IPicture
    {
        /// <summary>
        /// Retorna el ancho de la imagen.
        /// </summary>
        Int32 Width { get; }

        /// <summary>
        /// Retorna el alto de la imagen.
        /// </summary>
        Int32 Height { get; }

        /// <summary>
        /// Retorna el color del punto localizado en la posicion (x, y) de la imagen. La esquina superior
        /// izquiera de la matriz corresponde al punto (0,0) y el inferior derecho al (Width - 1, Height -1).
        /// </summary>
        /// <param name="x">la coordenada x del punto</param>
        /// <param name="y">la coordenada y del punto</param>
        /// <returns>el color del punto</returns>
        Color GetColor(Int32 x, Int32 y);

        /// <summary>
        /// Establece el color del punto localizado en la posicion (x, y) de la imagen. La esquina superior
        /// izquiera de la matriz corresponde al punto (0,0) y el inferior derecho al (Width - 1, Height -1).
        /// </summary>
        /// <param name="x">la coordenada x del punto</param>
        /// <param name="y">la coordenada y del punto</param>        
        /// <param name="color">el color a usar para el punto</param>
        void SetColor(Int32 x, Int32 y, Color color);
        
        /// <summary>
        /// Modifica el tamanio de la imagen.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Los colores de la imagen deben preservarse.
        /// </para>
        /// <para>
        /// Si la imagen tiene nuevos puntos, estos comienzan en color negro.
        /// </para>
        /// </remarks>
        /// <param name="width">el nuevo ancho de la imagen</param>
        /// <param name="height">el nuevo largo de la imagen</param>
        void Resize(Int32 width, Int32 height);

        /// <summary>
        /// Copia la imagen en una nueva imagen.
        /// </summary>
        /// <returns></returns>
        IPicture Clone();
    }
}