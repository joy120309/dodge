using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 7f; // Slightly slower bullet speed as requested
    private Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        
        // Randomize bullet speed (between 4f and 12f) for varied falling speeds
        speed = Random.Range(4f, 12f);
        
        // Set initial velocity straight down (since it's spawned facing down)
        rigidbody.linearVelocity = transform.forward * speed;
        Destroy(gameObject, 5f); 
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController playerController = other.GetComponent<PlayerController>();

        if (playerController != null)
        {
            playerController.Die();
        }
    }
}
