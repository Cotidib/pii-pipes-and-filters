using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider p = new PictureProvider();
            IPicture pic = p.GetPicture("../../Assets/gift.png");

            FilterGreyscale grayscale = new FilterGreyscale();
            FilterNegative negative = new FilterNegative();

            PipeNull pipeNull = new PipeNull();

            PipeSerial pipeSerialNegative = new PipeSerial(negative,pipeNull);
            PipeSerial pipeSerialGrayscale = new PipeSerial(grayscale,pipeSerialNegative);

            pipeSerialGrayscale.Send(pic); 
            pipeSerialNegative.Send(pic);

           
            
        }
    }
}
