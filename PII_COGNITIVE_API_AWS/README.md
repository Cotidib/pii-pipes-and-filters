# Universidad Católica del Uruguay
# Facultad de Ingeniería y Tecnologías
# Programación II
## Libreria de Reconocimiento Facial

Esta libreria utiliza el servico de Face detection de Rekognition de Amazon Web Services (AWS) (https://aws.amazon.com/es/rekognition/) para encontrar caras en las fotos.
Para ello, se utiliza la clase ```CognitiveFace```, la cual recibe por parametro una imagen (path donde se ubica en disco) y la envia a traves de una llamada REST a la API para detectar si la misma contiene o no una cara (Mediante las bibliotecas de clase de AWS, ver dependencias). 
En caso de encotrar un rostro, la propiedad ```FaceFound``` de la clase anterior indicará el resultado.
Adicionalmente, si se detecta una sonrisa en la cara encontrada, esto se indicará marcando la propiedad ```SmileFound``` como ```true```

### Ejemplo de uso:
```c#
static void Main(string[] args)
{
    CognitiveFace cognitiveFace = new CognitiveFace("<AWS_ACCESS_KEY>", "<AWS_SECRET_ACCESS_KEY>");

    Console.WriteLine("\nProcess The Rock Image");
    cognitiveFace.ProcessImage("../../Assets/the_rock.jpeg");
            
    Console.WriteLine("Face: {0}", cognitiveFace.FaceFound);
    Console.WriteLine("Smile: {0}", cognitiveFace.SmileFound);
}
```