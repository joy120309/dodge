using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rigidbody;

    private float speed = 8f;

    void Start()
    {
        if (FindAnyObjectByType<GameManager>() == null)
        {
            GameObject go = new GameObject("GameManager");
            go.AddComponent<GameManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        float speedX = inputX * speed;
        float speedZ = inputZ * speed;

        Vector3 newVelocity = new Vector3(speedX, 0f, speedZ);
        rigidbody.linearVelocity = newVelocity;
    }

    public void Die()
    {
        GameManager gameManager = FindAnyObjectByType<GameManager>();
        if (gameManager != null)
        {
            gameManager.EndGame();
        }

        gameObject.SetActive(false);
    }
}
