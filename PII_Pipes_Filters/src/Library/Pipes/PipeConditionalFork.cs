using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompAndDel.Filters;
using Program; 


namespace CompAndDel.Pipes
{
     public class PipeConditionalFork : IPipe
     {
          IPipe next2Pipe;
          IPipe nextPipe;
          FaceRecognitionFilter ConditionalFilter {get;}

        /// <summary>
        /// La cañería recibe una imagen y, según un condicional, se envía por una cañería o la otra
        /// </summary>
        /// <param name="truePipe">Cañeria si filtro igual a true</param>
        /// <param name="falsePipe">Cañeria si filtro igual a false</param>
        /// <param name="conditional">Condición a cumplir para que se utilice un filtro u otro</param>
          public PipeConditionalFork(IPipe truePipe, IPipe falsePipe, FaceRecognitionFilter conditionalFilter) 
          {
            this.next2Pipe = truePipe;
            this.nextPipe = falsePipe; 
            this.ConditionalFilter = conditionalFilter;        
          }


          public IPicture Send(IPicture picture)
          {
               picture = this.ConditionalFilter.Filter(picture);

               if(ConditionalFilter.ItHasFace == true)
               {
                    return this.next2Pipe.Send(picture);
               }
               else
               {
                    return this.nextPipe.Send(picture);
               }
          }
     }
}