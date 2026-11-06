using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Referências")]
    [SerializeField] private GameObject obstaclePrefab; // O molde que vamos clonar

    [Header("Configurações de Geração")]
    [SerializeField] private float spawnRate = 2f; // Tempo em segundos entre cada tubo
    [SerializeField] private float minY = -2f; // Altura mínima (tubo mais para baixo)
    [SerializeField] private float maxY = 3f;  // Altura máxima (tubo mais para cima)

    private float timer = 0f;

    private void Update()
    {
        // Adicionamos o tempo que passou desde o último frame ao nosso cronómetro
        timer += Time.deltaTime;

        // Quando o cronómetro atinge ou ultrapassa o tempo definido, criamos um tubo
        if (timer >= spawnRate)
        {
            SpawnObstacle();
            timer = 0f; // Reinicia o cronómetro
        }
    }

    private void SpawnObstacle()
    {
        // Escolhe uma altura aleatória entre o mínimo e o máximo
        float randomY = Random.Range(minY, maxY);
        
        // Define a posição final: o X é o mesmo do Spawner, o Y é o valor aleatório
        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, 0f);

        // A função Instantiate clona o prefab na posição escolhida. 
        // Quaternion.identity significa "sem rotação" (rotação padrão).
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }
}