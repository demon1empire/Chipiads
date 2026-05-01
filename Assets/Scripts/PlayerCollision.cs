using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Detecta si choca contra la pieza roja
        if (collision.gameObject.CompareTag("Death"))
        {
            // Llama a la función GameOver del GameManager
            Object.FindFirstObjectByType<GameManager>().GameOver();
        }
    }
}