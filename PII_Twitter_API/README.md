![UCU](https://github.com/ucudal/PII_Conceptos_De_POO/raw/master/Assets/logo-ucu.png)

### FIT - Universidad Católica del Uruguay

# TwitterApiUCU
Api para publicar en twitter de la UCU y enviar mensajes directos

## Publicar en Twitter
Para poder publicar en Twitter, una vez agregada la libreria a su proyecto como referencia, 
podrá hacer uso del siguiente código de ejemplo:

```c#
var twitter = new TwitterImage(ConsumerKey, ConsumerKeySecret, AccessToken, AccessTokenSecret);
Console.WriteLine(twitter.PublishToTwitter("text",@"PathToImage.png"));
```
Esto publicará en el twitter de la cuenta @POOUCU la imagen y texto enviados e imprime por consola el resultado de la publicación. En caso de ser correcta, imprime "OK"

## Mensajes Privados
Twitter permite  los usuarios enviar mensajes privados entre ellos. Para esto, permitiremos enviar mensajes desde la cuenta de @POOUCU a un usuario cualquiera de Twitter
Para ello, el usuario que desee recibir mensajes, debe primero admitir mensajes desde cualquiera en https://twitter.com/settings/safety o de lo contrario seguir a la cuenta @POOUCU

Para enviar mensajes directos puedes utilizar el siguiente código:
```c#
var twitter = new TwitterMessage(consumerKey, consumerKeySecret, accessToken, accessTokenSecret);
twitter.SendMessage("Hola!", "<userId>");
```

El userId puede ser encontrado en el perfil del usuario. Para ello deberas:
* Loguearte a tu cuenta de twitter
* Ingresa al siguiente link: https://twitter.com/settings/your_twitter_data/account
* Ingresa nuevamente tu contraseña
* Copia el user id que aparece:
<img src="https://github.com/ucudal/PII_TwitterApi/blob/master/img/twitterUserId.png" width="600">

