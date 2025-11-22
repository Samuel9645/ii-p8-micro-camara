# P8 Micrófono y cámara

## Micrófono

### Colisión guerreros

Para esto, simplemente añadimos el `AudioClip` deseado en el componente `AudioSource` del guerrero y simplemente usamos `OnCollisionEnter` para reproducir el sonido al colisionar. [AudioOnColission](Scripts/AudioOnColission.cs).

[Vídeo original](Videos/slash.mp4)

https://github.com/user-attachments/assets/f578ebe3-e90c-42a7-827a-f03604331e3c

### ShowRecordText

Para notificar al usuario que la grabación está en curso, creamos una clase abstracta `ShowRecordText`, que será genérica tanto para el micrófono como para la cámara. Esta clase contiene métodos para mostrar y ocultar el texto de grabación en la UI. [ShowRecordText](Scripts/ShowRecordText.cs).

Cada implementación concreta de esta clase (por ejemplo, `MicrophoneShowRecordText` y `CameraShowRecordText`) simplemente tendrá que subscribirse a los eventos de inicio y fin de grabación, por lo que las clases quedan bastante compactas, además con el uso de lambdas podemos añadir parámetros a los métodos de suscripción. [MicrophoneShowRecordText](Scripts/MicrophoneShowRecordText.cs), [CameraShowRecordText](Scripts/CameraShowRecordText.cs).

### Grabación de audio

Usamos la clase `Microphone` de Unity y creamos una serie de eventos que se disparan al iniciar y detener la grabación, para actualizar el texto de la UI y pasar el audio grabado a un `AudioSource` para reproducirlo [AudioPlayer](Scripts/AudioPlayer.cs), [MicrophoneRecorder](Scripts/MicrophoneRecorder.cs).

[Vídeo](Videos/microphone.mp4)

https://github.com/user-attachments/assets/631f27d9-d33e-400e-8e12-d9cf81068605

## Cámara

### Grabación de vídeo

Para la grabación de vídeo usamos la clase `WebCamTexture` de Unity. Similar al caso del micrófono, creamos una serie de eventos para notificar el inicio y fin de la grabación, y actualizar el texto de la UI [TVCameraRecorder](Scripts/TVCameraRecorder.cs).

Además, para mostrar la grabación de la cámara, simplemente usamos el asset del monitor de la escena anterior y le ponemos un cubo fino delante con el mismo tamaño que la pantalla del monitor, aplicándole la textura de la cámara.

[Vídeo](Videos/camera.mp4)

https://github.com/user-attachments/assets/edcb5631-c723-4851-8b78-a62dc24074de
