using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia; 

    [Header("UI de Puntaje")]
    public TextMeshProUGUI textoPuntaje;
    public TextMeshProUGUI textoRecord;

    [Header("Lógica de Puntos")]
    public int puntajeActual = 0;
    public int recordPuntaje = 0;

    void Awake() {
        instancia = this;
    }

    void Start() {
        recordPuntaje = PlayerPrefs.GetInt("Highscore", 0);
        ActualizarInterfaz();
    }

    public void GanarPunto() {
        puntajeActual++;
        if (puntajeActual > recordPuntaje) {
            recordPuntaje = puntajeActual;
            PlayerPrefs.SetInt("Highscore", recordPuntaje);
        }
        ActualizarInterfaz();
    }

    void ActualizarInterfaz() {
        if(textoPuntaje != null) textoPuntaje.text = "Puntaje: " + puntajeActual.ToString("000");
        if(textoRecord != null) textoRecord.text = "Record: " + recordPuntaje.ToString("000");
    }

   
    public void GameOver() {
        Debug.Log("Reiniciando nivel...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}