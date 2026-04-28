using UnityEngine;
using TMPro; // Necesario para controlar el texto del Canvas

public class GameManager : MonoBehaviour
{
    public static GameManager instancia; // Para acceder desde otros scripts

    [Header("UI de Puntaje")]
    public TextMeshProUGUI textoPuntaje;
    public TextMeshProUGUI textoRecord;

    [Header("Lógica de Puntos")]
    public int puntajeActual = 0;
    public int recordPuntaje = 0;

    void Awake() {
        // Esto permite que otros scripts llamen al GameManager fácilmente
        instancia = this;
    }

    void Start() {
        // 1. Cargamos el récord guardado al iniciar el juego
        recordPuntaje = PlayerPrefs.GetInt("Highscore", 0);
        ActualizarInterfaz();
    }

    public void GanarPunto() {
        puntajeActual++;
        
        // 2. Si superamos el récord, lo actualizamos
        if (puntajeActual > recordPuntaje) {
            recordPuntaje = puntajeActual;
            // 3. GUARDADO DE DATOS: Guardamos el nuevo récord físicamente
            PlayerPrefs.SetInt("Highscore", recordPuntaje);
        }

        ActualizarInterfaz();
    }

    void ActualizarInterfaz() {
        textoPuntaje.text = "Puntaje: " + puntajeActual.ToString("000");
        // Si tienes un texto para el récord, lo actualizas aquí también
        if(textoRecord != null) 
            textoRecord.text = "Record: " + recordPuntaje.ToString("000");
    }
}