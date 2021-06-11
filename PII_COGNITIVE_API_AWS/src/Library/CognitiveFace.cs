using System;
using System.IO;
using Amazon;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;

namespace Program
{
    public class CognitiveFace
    {

        private AmazonRekognitionClient rekognitionClient;

        /// <summary>
        /// Indica si la ultima llamada encontró o no una cara en la imagen
        /// </summary>
        /// <value></value>
        public bool FaceFound { get; private set; }

        /// <summary>
        /// Indica si la ultima llamada encontró una sonrisa o no
        /// </summary>
        /// <value></value>
        public bool SmileFound { get; private set; }

        public CognitiveFace(string awsAccessKeyId, string awsSecretAccessKey)
        {
            this.rekognitionClient = new AmazonRekognitionClient("AKIASL52INKSZSNJOYHG", "97MDIw0z79T9GUH/WMnmjfObKmuuK8iqyAUomNR9", RegionEndpoint.USEast1);
        }

        private Image GetImage(string imagePath)
        {

            Image image = new Image();
            try
            {
                using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    byte[] data = null;
                    data = new byte[fs.Length];
                    fs.Read(data, 0, (int)fs.Length);
                    image.Bytes = new MemoryStream(data);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load file " + imagePath);
            }
            return image;
        }

        public void ProcessImage(string imagePath)
        {

            if (imagePath == null)
            {
                Console.WriteLine("File path cannot be null");
                return;
            }

            Image image = this.GetImage(imagePath);
            DetectFacesRequest detectFacesRequest = new DetectFacesRequest()
            {
                Attributes = { "ALL" },
                Image = image
            };

            try
            {
                DetectFacesResponse result = rekognitionClient.DetectFacesAsync(detectFacesRequest).Result;
                Console.WriteLine("Processing ... " + imagePath);

                if (result == null)
                {
                    return;
                }

                foreach (FaceDetail faceDetail in result.FaceDetails)
                {
                    this.SmileFound = faceDetail.Smile.Value;
                    this.FaceFound = true;
                }

            }
            catch
            {
                Console.WriteLine("Image cannot be processed !");
            }
        }

    }
}