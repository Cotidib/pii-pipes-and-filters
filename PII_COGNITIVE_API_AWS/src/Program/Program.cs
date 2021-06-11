using System;
using System.Collections.Generic;
using System.IO;

namespace Program
{
    class Program

    {
        public static void Main(string[] args)
        {
            CognitiveFace cognitiveFace = new CognitiveFace("<AWS_ACCESS_KEY>", "<AWS_SECRET_ACCESS_KEY>");

            Console.WriteLine("\nProcess The Rock Image");
            cognitiveFace.ProcessImage("../../Assets/the_rock.jpeg");
            
            Console.WriteLine("Face: {0}", cognitiveFace.FaceFound);
            Console.WriteLine("Smile: {0}", cognitiveFace.SmileFound);

        }
    }

}

