using UnityEngine;

public class generadorobstaculos : MonoBehaviour
{
    [Header("CONFIGURACION DE PREFAB")]
    [SerializeField] private GameObject obstaculoPrefab;

    [Header("PARAMETROS DE TIEMPO")]
    [SerializeField] private float spawnRate = 2f;
    private float timer = 0f;

    [Header("VARIACION DE ALTURA")]
    [SerializeField] private float heightOffset = 2.5f;

    private void Update()
    {
        // SI EL JUEGO TERMINO NO GENERAR MAS OBSTACULOS
        if (GameManager.Instance != null && GameManager.Instance.IsGameOver) return;

        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    private void SpawnObstacle()
    {
        // CALCULAR ALTURA ALEATORIA EN EL EJE Y
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        float randomY = Random.Range(lowestPoint, highestPoint);

        // INSTANCIAR EL PREFAB EN LA POSICION DEL GENERADOR CON LA ALTURA VARIADA
        Instantiate(obstaculoPrefab, new Vector3(transform.position.x, randomY, 0), Quaternion.identity);
    }
}