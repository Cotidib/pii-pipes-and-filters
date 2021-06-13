using System;
using System.Collections.Generic;

namespace CompAndDel.Filters
{
    public class FilterSave : IFilter
    {
        public IPicture Filter(IPicture image)
        {   
            Random r = new Random ();
            PictureProvider p = new PictureProvider();
            p.SavePicture(image,"../../Assets/"+ r.Next (10,101)+".jpg");
            p.SavePicture(image,"../../Assets/FinalNewImage.jpg");
            Console.WriteLine("Se ha guardado el archivo como FinalNewImage.jpg");
            return image;
        }
    }
}
