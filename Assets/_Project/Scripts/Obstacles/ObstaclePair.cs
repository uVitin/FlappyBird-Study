using UnityEngine;

public class ObstaclePair : MonoBehaviour
{
    [Header("Configurações de Movimento")]
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float destroyXPosition = -10f; // Posição onde o tubo já não é visível

    private void Update()
    {
        // Vector3.left representa a direção (-1, 0, 0)
        // Time.deltaTime garante que a velocidade é constante, independentemente dos FPS do jogo
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        // Se o tubo passar do limite esquerdo do ecrã, ele destrói-se para poupar memória
        if (transform.position.x < destroyXPosition)
        {
            Destroy(gameObject);
        }
    }
}