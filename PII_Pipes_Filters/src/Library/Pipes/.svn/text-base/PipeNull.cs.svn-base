using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PicfilLib;


namespace PicEditor.Filtros.Pipes
{
    class PipeNull : NamedObject, IPipe
    {
        IPicture image;
        public PipeNull(string name) : base(name)
        {}
        /// <summary>
        /// Recibe una imagen, la guarda en una variable image y la retorna.
        /// </summary>
        /// <param name="picture">Imagen a recibir</param>
        /// <returns>La misma imagen</returns>
        public IPicture Send(IPicture picture)
        {
            this.image = picture;
            return this.image;
        }

    }
}
