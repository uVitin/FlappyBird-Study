using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Adicionado para controlar o texto do recorde

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Interface")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI highScoreText; // Nova referência

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

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;

        // 1. Obtém a pontuação final desta partida
        int currentScore = ScoreManager.Instance.GetScore();
        
        // 2. Envia para o serviço verificar se é um novo recorde
        HighScoreService.TrySaveHighScore(currentScore);
        
        // 3. Atualiza o ecrã mostrando o recorde (antigo ou o novo que acabou de ser batido)
        highScoreText.text = "RECORDE: " + HighScoreService.GetHighScore();
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}