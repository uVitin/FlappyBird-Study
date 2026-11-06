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

        // NOVO: Desliga a simulação física temporariamente
        rb.simulated = false;
    }

    private void Update()
    {
        bool spacePressed = Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame;
        bool mousePressed = Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame;

        if (spacePressed || mousePressed)
        {
            // NOVO: Verifica se é o primeiro clique para começar o jogo
            if (!GameManager.Instance.IsPlaying)
            {
                GameManager.Instance.StartGame(); // Avisa o GameManager
                rb.simulated = true; // Acorda a gravidade e as colisões
            }
            
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
            // Em vez do Debug.Log, chamamos o GameManager
            GameManager.Instance.GameOver();
            
            // Congela o tempo do jogo para parar tudo
            Time.timeScale = 0f; 
        }
    }

    // NOVO: Método que a Unity chama quando o objeto atravessa um Trigger (colisor fantasma)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se a zona atravessada tem a etiqueta "ScoreZone"
        if (collision.CompareTag("ScoreZone"))
        {
            // Substituímos o Debug.Log por isso:
            ScoreManager.Instance.AddPoint();
        }
    }
}