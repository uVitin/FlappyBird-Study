using UnityEngine;

// Uma classe "static" não herda de MonoBehaviour e não é arrastada para a cena.
// Fica disponível globalmente no código.
public static class HighScoreService
{
    private const string HighScoreKey = "HighScore_Flappy";

    public static int GetHighScore()
    {
        // Pede à Unity o valor guardado. Se não existir nada, devolve 0.
        return PlayerPrefs.GetInt(HighScoreKey, 0);
    }

    public static void TrySaveHighScore(int currentScore)
    {
        // Só guarda se a pontuação atual for maior que o recorde antigo
        if (currentScore > GetHighScore())
        {
            PlayerPrefs.SetInt(HighScoreKey, currentScore);
            PlayerPrefs.Save(); // Força a gravação no disco
        }
    }
}