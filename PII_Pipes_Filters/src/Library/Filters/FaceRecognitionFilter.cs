using System;
using System.Collections.Generic;
using System.IO;
using Amazon;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Program;

namespace CompAndDel.Filters
{
     public class FaceRecognitionFilter: IFilter
     {
          public bool ItHasFace { get; protected set;}

          public IPicture Filter(IPicture image)
          {
               CognitiveFace cognitiveFace = new CognitiveFace("", "");

               Console.WriteLine("\n Processing Image");
               cognitiveFace.ProcessImage(image.ImagePath);
                         
               Console.WriteLine("Face: {0}", cognitiveFace.FaceFound);
               Console.WriteLine("Smile: {0}", cognitiveFace.SmileFound);

               if(cognitiveFace.FaceFound)
               {
                    ItHasFace = true;
               }
               else if (cognitiveFace.FaceFound == false)
               {
                    ItHasFace = false;
               }

               return image;
          }
     }
}