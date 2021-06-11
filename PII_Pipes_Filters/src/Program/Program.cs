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
            FilterSave save = new FilterSave();

            PipeNull pipeNull = new PipeNull();

            PipeSerial pipeSave1 = new PipeSerial(save,pipeNull);

            PipeSerial pipeSerialNegative = new PipeSerial(negative,pipeSave1);

            PipeSerial pipeSave0 = new PipeSerial(save,pipeSerialNegative);

            PipeSerial pipeSerialGrayscale = new PipeSerial(grayscale,pipeSave0);

            pipeSerialGrayscale.Send(pic); 
        }
    }
}
