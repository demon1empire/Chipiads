using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    [Header("Ajustes de Salto")]
    public float fuerzaSalto = 5.0f; // La fuerza hacia arriba al rebotar
    
    [Header("Configuración de Súper Velocidad")]
    public int perfectPasses = 0; // Cuenta los espacios vacíos atravesados
    public int passesToSuperSpeed = 3; // Cuántos pases para activar el modo invencible
    public bool isSuperSpeed = false; // Estado del poder

    [Header("Efectos Visuales")]
    public TrailRenderer superSpeedTrail; // Arrastra aquí el Trail Renderer desde el Inspector

    private Rigidbody rb;

    void Start()
    {
        // Obtenemos la referencia al Rigidbody al iniciar
        rb = GetComponent<Rigidbody>();

        // Nos aseguramos de que el efecto visual esté apagado al inicio del nivel
        if (superSpeedTrail != null)
        {
            superSpeedTrail.enabled = false;
        }
    }

    // --- 1. DETECCIÓN DE AROS ATRAVESADOS (El Contador) ---
    private void OnTriggerEnter(Collider other)
    {
        // Si atravesamos el sensor de en medio sin chocar
        if (other.CompareTag("SensorPuntaje"))
        {
            perfectPasses++; // Aumentamos la racha

            // Si llegamos a la meta de pases limpios (ej. 3), activamos el poder
            if (perfectPasses >= passesToSuperSpeed)
            {
                ActivarSuperVelocidad();
            }
        }
    }

    private void ActivarSuperVelocidad()
    {
        isSuperSpeed = true;
        
        // Encendemos la estela visual
        if (superSpeedTrail != null) 
        {
            superSpeedTrail.enabled = true;
        }
    }

    private void ResetearSuperVelocidad()
    {
        isSuperSpeed = false;
        perfectPasses = 0; // La racha vuelve a cero
        
        // Apagamos la estela visual
        if (superSpeedTrail != null) 
        {
            superSpeedTrail.enabled = false;
        }
    }

    // --- 2. LÓGICA DE COLISIÓN (Impacto y Destrucción) ---
    private void OnCollisionEnter(Collision collision)
    {
        // Solo evaluamos colisiones si la bola va cayendo
        if (rb.linearVelocity.y <= 0.1f)
        {
            // Identificamos qué acabamos de tocar
            bool tocoPlataforma = collision.gameObject.CompareTag("Plataforma");
            bool tocoPeligro = collision.gameObject.CompareTag("Peligro"); // La zona de "daño"

            if (isSuperSpeed)
            {
                // Si el poder está activo, destruimos la plataforma, ya sea buena o mala
                if (tocoPlataforma || tocoPeligro)
                {
                    // collision.transform.parent.gameObject destruye todo el disco completo.
                    // Si solo quieres destruir el trozo que tocó, usa solo collision.gameObject
                    Destroy(collision.transform.parent.gameObject);

                    // Reseteamos el contador para que deba hacer otros 3 pases limpios
                    ResetearSuperVelocidad();
                    
                    // Seguimos rebotando después de destruir
                    RealizarSalto(); 
                }
            }
            else
            {
                // COMPORTAMIENTO NORMAL (Sin poder)
                if (tocoPeligro)
                {
                    // Aquí va tu lógica de perder el nivel
                    Debug.Log("¡Has tocado una zona de peligro!");
                    // GameManager.GameOver();
                }
                else // Si choca con una plataforma normal u otra cosa
                {
                    // Como tocó una plataforma, pierde la racha de pases perfectos
                    ResetearSuperVelocidad();
                    
                    // Aplicamos el rebote limpio original
                    RealizarSalto();
                }
            }
        }
    }

    // Función auxiliar para aplicar el salto de manera limpia
    private void RealizarSalto()
    {
        rb.linearVelocity = new Vector3(0, fuerzaSalto, 0);
    }
}