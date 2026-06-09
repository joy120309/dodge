using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 10f;
    Rigidbody rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.linearVelocity = transform.forward * speed;
        Destroy(gameObject, 3f);
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
