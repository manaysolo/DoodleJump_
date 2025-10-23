using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public float JumpForce = 10f;

    private Camera mainCamera;
    private float offsetBelow = 5f; // Distance sous la caméra avant suppression

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (mainCamera != null)
        {
            float cameraBottomY = mainCamera.transform.position.y - mainCamera.orthographicSize;

            // Supprimer la plateforme si elle est bien en dessous de la caméra
            if (transform.position.y < cameraBottomY - offsetBelow)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.linearVelocity;
                velocity.y = JumpForce;
                rb.linearVelocity = velocity;
            }
        }
    }
}
