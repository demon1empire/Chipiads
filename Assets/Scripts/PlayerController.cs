using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float bounceForce = 5f;

    private void OnCollisionEnter(Collision collision)
    {
        // Reiniciamos la velocidad vertical para un rebote consistente
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, bounceForce, rb.linearVelocity.z);
        
        
    }
}