using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Configuración de Control")]
    public float sensibilidadRotacion = 150f;

    void Update()
    {
        // Detectamos si el usuario mantiene presionado el clic izquierdo o toca la pantalla
        if (Input.GetMouseButton(0))
        {
            // Obtenemos cuánto se movió el mouse en el eje X (horizontal)
            float mouseX = Input.GetAxis("Mouse X");

            // Aplicamos la rotación a la torre en su eje Y
            // Multiplicamos por -1 para que la torre gire hacia donde arrastras el dedo
            transform.Rotate(0, -mouseX * sensibilidadRotacion * Time.deltaTime, 0);
        }
    }
}