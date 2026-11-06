using UnityEngine;
using UnityEngine.SceneManagement; // Necessário para recarregar a cena

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Interface")]
    [SerializeField] private GameObject gameOverPanel; // Referência ao painel que criámos

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Função chamada quando o pássaro bate
    public void GameOver()
    {
        gameOverPanel.SetActive(true); // Liga o ecrã de Game Over
        Time.timeScale = 0f; // Congela o jogo
    }

    // Função que o botão vai chamar
    public void RestartGame()
    {
        Time.timeScale = 1f; // IMPORTANTE: Descongela o tempo antes de reiniciar
        // Recarrega a cena atual (que se chama Gameplay)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}