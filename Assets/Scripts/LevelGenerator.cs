using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject anilloPrefab;
    public int cantidadAnillos = 15;
    public float distanciaVertical = 5f;

    void Start()
    {
        for (int i = 0; i < cantidadAnillos; i++)
        {
            // Crea el anillo hacia abajo
            Vector3 posicion = new Vector3(0, -i * distanciaVertical, 0);
            GameObject nuevoAnillo = Instantiate(anilloPrefab, posicion, Quaternion.identity, transform);
            
            // Rotación aleatoria para que el hueco cambie de lugar
            nuevoAnillo.transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);

            // CURVA DE DIFICULTAD (Punto 2 de tu tarea):
            // Si el anillo es mayor al número 5, hacemos que rote un poco
            if (i > 5)
            {
                // Aquí podrías añadirle un script de rotación o achicar el hueco
                nuevoAnillo.transform.localScale *= 0.9f; 
                // Dentro del bucle for del LevelGenerator
if (i > 5) {
    // Hace que el anillo sea un 10% más pequeño (hueco más difícil)
    nuevoAnillo.transform.localScale *= 0.9f; 
    
    // Opcional: Podrías añadir un script de rotación automática aquí
    // para que el jugador tenga que calcular el tiempo del salto.
}
            }
        }
    }
    
}