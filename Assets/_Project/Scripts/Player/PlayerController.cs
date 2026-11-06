using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Configurações de Voo")]
    [SerializeField] private float jumpForce = 6.5f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        bool spacePressed = Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame;
        bool mousePressed = Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame;

        if (spacePressed || mousePressed)
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector2(0f, jumpForce);
    }

    // NOVO: Método que a Unity chama automaticamente quando há um impacto físico
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se o objeto com o qual batemos tem a etiqueta "Obstacle"
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("O pássaro bateu! GAME OVER!");
            
            // Congela o tempo do jogo para parar tudo
            Time.timeScale = 0f; 
        }
    }
}