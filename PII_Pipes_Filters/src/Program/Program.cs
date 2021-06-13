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
            IPicture pic = p.GetPicture("../../Assets/Joker.jpeg");

            FilterGreyscale grayscale = new FilterGreyscale();
            FilterNegative negative = new FilterNegative();
            FilterSave save = new FilterSave();
            FilterTwitterPost twitterPost = new FilterTwitterPost();
            FaceRecognitionFilter conditionalFilter = new FaceRecognitionFilter();


            PipeNull pipeNull = new PipeNull();

            PipeSerial pipeSerialNegative = new PipeSerial(negative, pipeNull);

            PipeSerial pipeSerialTwitterPost = new PipeSerial(twitterPost, pipeNull);
            
            PipeConditionalFork pipeConditionalFork = new PipeConditionalFork(pipeSerialTwitterPost, pipeSerialNegative, conditionalFilter);

            PipeSerial pipeSerialGrayscale = new PipeSerial(grayscale, pipeConditionalFork);

            pipeSerialGrayscale.Send(pic); 
        }
    }
}
