using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using CompAndDel;
using System.Diagnostics;

namespace CompAndDel.Filters
{
    public class FilterSave : IFilter
    {
        public IPicture Filter(IPicture image)
        {   
            Random r= new Random ();
            PictureProvider p = new PictureProvider();
            p.SavePicture(image,r.Next (10,101)+".jpg");

            return image;
        }
    }
}
