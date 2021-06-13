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
            IPicture pic = p.GetPicture("../../Assets/tree.jpeg");

            FilterSave save = new FilterSave();
            FilterBlurConvolution blur = new FilterBlurConvolution();

            PipeNull pipeNull = new PipeNull();
            PipeSerial pipeSave = new PipeSerial(save, pipeNull);

            PipeSerial pipeSerialConv = new PipeSerial(blur, pipeSave);

            pipeSerialConv.Send(pic); 
        }
    }
}
