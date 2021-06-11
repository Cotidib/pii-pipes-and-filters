using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PicfilLib;

namespace PicEditor.Filtros.Pipes
{
    class PipeSerial : NamedObject, IPipe
    {
        protected IFilter filtro;
        protected IPipe nextPipe;
        /// <summary>
        /// La cañería recibe una imagen, le aplica un filtro y la envía a la siguiente cañería
        /// </summary>
        /// <param name="tipoFiltro">Tipo de filtro que se debe aplicar sobre la imagen. Se crea un nuevo filtro con los parametros por defecto</param>
        /// <param name="nextPipe">Siguiente cañería</param>
        public PipeSerial(string name, StaticMembers.TipoFiltro tipoFiltro, IPipe nextPipe) : base(name)
        {
            this.nextPipe = nextPipe;
            this.filtro = StaticMembers.GenerarFiltro(tipoFiltro);
        }
        /// <summary>
        /// La cañería recibe una imagen, le aplica un filtro y la envía a la siguiente cañería
        /// </summary>
        /// <param name="filtro">Filtro que se debe aplicar sobre la imagen</param>
        /// <param name="nextPipe">Siguiente cañería</param>
        public PipeSerial(string name, IFilter filtro, IPipe nextPipe) : base(name)
        {
            this.nextPipe = nextPipe;
            this.filtro = filtro;
        }
        /// <summary>
        /// Devuelve el proximo IPipe
        /// </summary>
        public IPipe Next
        {
            get { return this.nextPipe; }
        }
        /// <summary>
        /// Devuelve el IFilter que aplica este pipe
        /// </summary>
        public IFilter Filter
        {
            get { return this.filtro; }
        }
        /// <summary>
        /// Recibe una imagen, le aplica un filtro y la envía al siguiente Pipe
        /// </summary>
        /// <param name="picture">Imagen a la cual se debe aplicar el filtro</param>
        public IPicture Send(IPicture picture)
        {
            picture = this.filtro.Filter(picture);
            return this.nextPipe.Send(picture);
        }
    }
}
