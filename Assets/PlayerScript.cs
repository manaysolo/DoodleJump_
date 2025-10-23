using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerScript : MonoBehaviour
{
    public float movementSpeed = 10f;
    private Rigidbody2D rb;
    private float movement = 0f;
    private Camera mainCamera;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }

    private void Update()
    {
        movement = Input.GetAxis("Horizontal") * movementSpeed;

        float cameraBottomY = mainCamera.transform.position.y - mainCamera.orthographicSize;

        if (transform.position.y < cameraBottomY - 1f)
        {
            DieFromFall();
        }
    }

    private void FixedUpdate()
    {
        Vector2 velocity = rb.linearVelocity;
        velocity.x = movement;
        rb.linearVelocity = velocity;
    }

    public void DieFromFall()
    {
        Debug.Log("Game Over — sortie de l'écran");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void DieFromEnemy()
    {
        Debug.Log("Touché par un ennemi — redémarrage du jeu");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
