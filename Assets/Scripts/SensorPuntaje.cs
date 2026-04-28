using UnityEngine;

public class SensorPuntaje : MonoBehaviour
{
    // Este método se activa cuando algo entra en el cubo invisible
    private void OnTriggerEnter(Collider other)
    {
        // Revisamos si lo que entró tiene la etiqueta "Player"
        if (other.CompareTag("Player"))
        {
            // Llamamos al GameManager para sumar el punto
            GameManager.instancia.GanarPunto();
            
            // Opcional: Destruimos el sensor para que no sume puntos dobles
            Destroy(gameObject); 
        }
    }
}