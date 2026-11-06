using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    // NOVO: Variável pública que os outros scripts podem ler para saber se o jogo está a decorrer
    public bool IsPlaying { get; private set; } = false;

    [Header("Interface")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private GameObject readyText; // NOVO: Referência ao texto inicial

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

    // NOVO: Função para iniciar a partida
    public void StartGame()
    {
        IsPlaying = true;
        readyText.SetActive(false); // Esconde a mensagem "Clique para começar"
    }

    public void GameOver()
    {
        // Garante que o jogo deixa de estar no estado "Playing"
        IsPlaying = false; 

        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;

        int currentScore = ScoreManager.Instance.GetScore();
        HighScoreService.TrySaveHighScore(currentScore);
        highScoreText.text = "RECORDE: " + HighScoreService.GetHighScore();
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}