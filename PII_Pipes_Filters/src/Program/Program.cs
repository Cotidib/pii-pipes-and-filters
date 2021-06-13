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

            FilterSave save = new FilterSave();
            FilterBlurConvolution blur = new FilterBlurConvolution();
            EdgeDetection1Filter edge1 = new EdgeDetection1Filter();
            EdgeDetection2Filter edge2 = new EdgeDetection2Filter();
            EdgeDetection3Filter edge3 = new EdgeDetection3Filter();
            SharpenFilter sharpen = new SharpenFilter();
            GaussianBlurFilter gaussianBlur = new GaussianBlurFilter();


            PipeNull pipeNull = new PipeNull();
            PipeSerial pipeSave = new PipeSerial(save, pipeNull);

            PipeSerial pipeSerialSharpen = new PipeSerial(sharpen, pipeSave);

            PipeSerial pipeSerialConv = new PipeSerial(edge2, pipeSerialSharpen);

            pipeSerialConv.Send(pic); 
        }
    }
}
