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
            FilterTwitterPost twitterPost = new FilterTwitterPost();

            PipeNull pipeNull = new PipeNull();

            PipeSerial pipeSerialTwitterPostNegative = new PipeSerial(twitterPost,pipeNull);

            PipeSerial pipeSave1 = new PipeSerial(save,pipeSerialTwitterPostNegative);

            PipeSerial pipeSerialNegative = new PipeSerial(negative,pipeSave1);

            PipeSerial pipeSerialTwitterPostGrayscale = new PipeSerial(twitterPost,pipeSerialNegative);

            PipeSerial pipeSave0 = new PipeSerial(save,pipeSerialTwitterPostGrayscale);

            PipeSerial pipeSerialGrayscale = new PipeSerial(grayscale,pipeSave0);

            pipeSerialGrayscale.Send(pic); 
        }
    }
}
