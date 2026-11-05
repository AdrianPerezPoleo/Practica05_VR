# Práctica 05. VR. Google Cardboard
- **Autor:** Adrián Pérez Poleo
- **Correo:** alu0101635224@ull.edu.es

## Índice
- [Ejercicio 01](#ejercicio-01)
- [Ejercicio 02](#ejercicio-02) 
- [Ejercicio 03](#ejercicio-03)

## Introducción
En esta práctica se ha introducido el uso de Google Cardboard para el desarrollo de aplicaciones de Realidad Virtual (VR) en Unity. Además de configurar el entorno para la compilación en Android, se han implementado mecánicas de interacción basadas en la mirada y el movimiento guiado por la inclinación de la cabeza. Para conectar la interfaz del visor de Realidad Virtual con los elementos interactivos de la escena, se ha vuelto a hacer uso de delegados y eventos.

## Ejercicio 01
Este ejercicio no tiene ficheros de código.

### Descripción
Este primer ejercicio pide la configuración inicial del proyecto para integrar el entorno de Google Cardboard, así como la generación de un archivo ejecutable (APK) para ser probado en dispositivos Android.

### Implementación
La implementación de esta fase consistió en ajustar los *Build Settings* de Unity para la plataforma Android. Se importó el paquete de *Google Cardboard XR Plugin* y se configuraron las opciones de resolución, presentación y los ajustes de *Player* requeridos por el visor VR. Finalmente, se compiló el proyecto para generar el archivo APK.

### Ejecución
> En esta práctica he tenido que incrustar vídeos en vez de GIFs debido a su elevado tamaño.


https://github.com/user-attachments/assets/4e0c6e9e-3aff-44fb-b686-0ec0d49f0146


## Ejercicio 02
Los ficheros de código se encuentran en: 

[Assets/Scripts/Player_Movement.cs](Assets/Scripts/Player_Movement.cs)

[Assets/Scripts/Battery.cs](Assets/Scripts/Battery.cs)

### Descripción
Se pide crear una escena de Realidad Virtual que incluya un terreno y *assets* de la Asset Store. El jugador debe poder desplazarse por la escena (mediante mando o utilizando la vista) y recolectar objetos interactivos simplemente enfocándolos con la retícula central.

### Implementación
Para el entorno, se construyó una escena utilizando elementos importados (simulando una base espacial). El desplazamiento del jugador se implementó a través de la vista mediante el script `Player_Movement.cs`. Este componente evalúa la inclinación de la cámara a través de `localEulerAngles.x`. Si el jugador mira hacia abajo (entre 25 y 90 grados), la variable `isMoving` se activa y el `Rigidbody` desplaza al jugador hacia adelante.

Para la recolección, se configuraron una serie de baterías como objetos interactivos con el script `Battery.cs`. Haciendo uso del sistema de puntero de Cardboard, los métodos `OnPointerEnter` y `OnPointerExit` alteran el color de la luz de la batería a rojo cuando el jugador la está mirando. Si se acciona el trigger mientras se mira (`OnPointerClick`), el objeto se desactiva de la escena, simulando su recolección.

### Ejecución

https://github.com/user-attachments/assets/ea1c2653-46ce-4114-bdc4-7188bd9411de


## Ejercicio 03
Los ficheros de código se encuentran en: 

[Assets/Scripts/Antenna_Notifier.cs](Assets/Scripts/Antenna_Notifier.cs)

[Assets/Scripts/BatteryAntennaListener.cs](Assets/Scripts/BatteryAntennaListener.cs)

### Descripción
En este ejercicio se elige un objeto específico de la escena (en este caso, una antena) que atraiga el resto de coleccionables. Cuando el jugador selecciona este objeto con la vista, las baterías deben comenzar a dirigirse automáticamente hacia la posición del jugador.

### Implementación
Para lograr esta mecánica, se aplicó un patrón observador similar al de prácticas pasadas. La antena tiene asignado el script `Antenna_Notifier.cs`, el cual detecta la mirada del jugador con `OnPointerEnter` y dispara el evento `OnFollowPlayer` (lanzando `OnStopFollowingPlayer` al apartar la vista mediante `OnPointerExit`).

Por su parte, el script `BatteryAntennaListener.cs` se encuentra en las baterías. Este script recupera la referencia de la antena y se suscribe a sus eventos. Al ser notificado de que la antena está siendo observada, activa una bandera de seguimiento y, en el `FixedUpdate`, calcula el vector de dirección hacia el jugador para desplazarse mediante `rb.MovePosition` y orientarse con `rb.MoveRotation`.

### Ejecución

https://github.com/user-attachments/assets/575b1e7b-da5a-492f-8f3b-ff6ac5def90d
