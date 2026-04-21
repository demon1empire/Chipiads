using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    [Header("Ajustes de Movimiento")]
    [Tooltip("Velocidad de desplazamiento del personaje")]
    public float velocidad = 7.0f;

    void Update()
    {
        // Detectamos la entrada del teclado (WASD o Flechas)
        // GetAxis devuelve un valor entre -1 y 1
        float movHorizontal = Input.GetAxis("Horizontal");
        float movVertical = Input.GetAxis("Vertical");

        // Creamos un vector de movimiento:
        // X = Movimiento lateral (Derecha/Izquierda)
        // Y = 0 (No queremos que flote solo con las flechas)
        // Z = Movimiento frontal (Adelante/Atrás)
        Vector3 direccion = new Vector3(movHorizontal, 0, movVertical);

        // Aplicamos el movimiento al Transform
        // Time.deltaTime asegura que la velocidad sea constante sin importar los FPS
        transform.Translate(direccion * velocidad * Time.deltaTime);
    }
}