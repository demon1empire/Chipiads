using UnityEngine;
using UnityEngine.UI; // ¡Muy importante incluir esto para trabajar con UI!

public class BarraProgreso : MonoBehaviour
{
    [Header("Referencias")]
    public Transform jugador;     // Arrastra a tu objeto Player aquí
    public Transform metaBase;    // Arrastra el objeto que representa el final del nivel
    public Slider sliderProgreso; // Arrastra tu Slider de UI aquí

    private float posYInicial;
    private float distanciaTotal;

    void Start()
    {
        // Al inicio, guardamos desde dónde empieza a caer el jugador
        if (jugador != null && metaBase != null)
        {
            posYInicial = jugador.position.y;
            
            // La distancia total es la resta entre la posición más alta (inicio) y la más baja (meta)
            distanciaTotal = posYInicial - metaBase.position.y;
        }
    }

    void Update()
    {
        // Solo calculamos si tenemos todas las referencias
        if (jugador != null && metaBase != null && sliderProgreso != null)
        {
            // ¿Cuánto ha bajado el jugador desde su punto inicial?
            float distanciaRecorrida = posYInicial - jugador.position.y;

            // Calculamos el porcentaje dividiendo lo recorrido entre el total (esto da un valor entre 0 y 1)
            float progreso = distanciaRecorrida / distanciaTotal;

            // Mathf.Clamp01 asegura que el valor nunca sea menor a 0 ni mayor a 1
            sliderProgreso.value = Mathf.Clamp01(progreso); 
        }
    }
}