using System.Collections;
using UnityEngine;

public class LogsSpawnerFunctionality : MonoBehaviour
{
    public GameObject logPrefab; // Префаб бревна
    public Transform spawnPoint; // Точка спавна бревен
    public float spawnInterval = 5f; // Интервал между спавнами (5 секунд)
    public float forwardForce = 10f; // Сила толкания бревна вперед

    // Start is called before the first frame update
    void Start()
    {
        // Начинаем цикл спавна бревен
        StartCoroutine(SpawnLogs());
    }

    // Функция для спавна бревен
    IEnumerator SpawnLogs()
    {
        while (true) // Цикл бесконечного спавна
        {
            SpawnLog();
            yield return new WaitForSeconds(spawnInterval); // Ожидание перед следующим спавном
        }
    }

    // Спавн одного бревна
    void SpawnLog()
    {
        // Спавним бревно с поворотом на 90 градусов по X
        GameObject log = Instantiate(logPrefab, spawnPoint.position, Quaternion.Euler(0, 0, 0));

        Rigidbody rb = log.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Применяем силу вдоль оси Z, чтобы бревно катилось прямо
            rb.AddForce(Vector3.forward * forwardForce, ForceMode.Impulse);
        }
    }
}
