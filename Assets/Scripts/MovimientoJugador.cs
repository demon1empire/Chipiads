using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    [Header("Ajustes de Salto")]
    public float fuerzaSalto = 5.0f; // La fuerza hacia arriba al rebotar
    
    private Rigidbody rb;

    void Start()
    {
        // Obtenemos la referencia al Rigidbody al iniciar
        rb = GetComponent<Rigidbody>();
    }

    // Usamos OnCollisionEnter para detectar cuando toca el suelo/plataforma
    private void OnCollisionEnter(Collision collision)
    {
        // 1. Verificamos que el impacto sea contra una plataforma (opcionalmente por Tag)
        // 2. Solo saltamos si el personaje está cayendo (velocidad Y negativa o casi cero)
        if (rb.linearVelocity.y <= 0.1f)
        {
            // Aplicamos una velocidad directa hacia arriba para un rebote limpio
            rb.linearVelocity = new Vector3(0, fuerzaSalto, 0);
        }
    }
}