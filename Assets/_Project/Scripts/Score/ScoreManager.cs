using UnityEngine;
using TMPro; // Necessário para controlar o TextMeshPro da interface

public class ScoreManager : MonoBehaviour
{
    // O padrão "Singleton" permite que qualquer script encontre o ScoreManager facilmente
    public static ScoreManager Instance { get; private set; }

    [Header("Interface")]
    [SerializeField] private TextMeshProUGUI scoreText; // Referência ao texto no ecrã

    private int score = 0; // Começamos com 0 pontos

    private void Awake()
    {
        // Garante que só existe um ScoreManager no jogo
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Função pública para que o Pássaro possa dizer: "Ei, soma um ponto!"
    public void AddPoint()
    {
        score++; // Soma 1
        scoreText.text = score.ToString(); // Converte o número para texto e atualiza o ecrã
    }

    public int GetScore()
    {
        return score;
    }
}