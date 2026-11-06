using UnityEngine;
using UnityEngine.InputSystem; // Adiciona o suporte ao novo sistema de entrada

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
        // Verifica se a barra de espaço ou o botão esquerdo do mouse foi pressionado neste frame
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
}