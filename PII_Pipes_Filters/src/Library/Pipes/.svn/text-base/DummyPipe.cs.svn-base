using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PicfilLib;

namespace PicEditor.Filtros.Pipes
{
    public class DummyPipe : NamedObject,IPipe
    {
        bool verificacion;
        IPicture imagen;
        /// <summary>
        /// Esta cañeria es utilizada con propostito de testeo. Recibe una imagen, la clona y la guarda en una variable.
        /// Luego coloca en true a la variable de verificacion.
        /// </summary>
        public DummyPipe(String name) : base (name)
        {
            verificacion = false;
        }
        public bool Verificacion
        {
            get { return verificacion; }
        }
        public IPicture Imagen
        {
            get { return imagen; }
        }

        public IPicture Send(IPicture picture)
        {
            this.imagen = picture;
            verificacion = true;
            return this.imagen;
        }
    }
}
