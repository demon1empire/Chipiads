using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Referencias de Paneles")]
    public GameObject mainMenuPanel;
    public GameObject gamePanel;
    public GameObject gameOverPanel;
    public GameObject victoryPanel;

    void Start()
    {
        // Al iniciar el juego, aseguramos que solo se vea el menú
        ShowPanel(mainMenuPanel);
    }

    // Método para el botón "Jugar"
    public void StartGame()
    {
        ShowPanel(gamePanel);
        // Aquí podrías reanudar el tiempo si estaba pausado
        Time.timeScale = 1; 
    }

    // Método para el botón "Reintentar"
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Método para el botón "Siguiente Nivel"
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Función auxiliar para apagar todos los paneles y prender solo uno
    private void ShowPanel(GameObject panelToShow)
    {
        mainMenuPanel.SetActive(panelToShow == mainMenuPanel);
        gamePanel.SetActive(panelToShow == gamePanel);
        gameOverPanel.SetActive(panelToShow == gameOverPanel);
        victoryPanel.SetActive(panelToShow == victoryPanel);
    }
}