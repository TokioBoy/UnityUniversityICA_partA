using System.Collections;
using UnityEngine;

public class LogsSpawnerFunctionality : MonoBehaviour
{
    public GameObject logPrefab; // ������ ������
    public Transform spawnPoint; // ����� ������ ������
    public float spawnInterval = 5f; // �������� ����� �������� (5 ������)
    public float forwardForce = 10f; // ���� �������� ������ ������

    // Start is called before the first frame update
    void Start()
    {
        // �������� ���� ������ ������
        StartCoroutine(SpawnLogs());
    }

    // ������� ��� ������ ������
    IEnumerator SpawnLogs()
    {
        while (true) // ���� ������������ ������
        {
            SpawnLog();
            yield return new WaitForSeconds(spawnInterval); // �������� ����� ��������� �������
        }
    }

    // ����� ������ ������
    void SpawnLog()
    {
        // ������� ������ � ��������� �� 90 �������� �� X
        GameObject log = Instantiate(logPrefab, spawnPoint.position, Quaternion.Euler(0, 0, 0));

        Rigidbody rb = log.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // ��������� ���� ����� ��� Z, ����� ������ �������� �����
            rb.AddForce(Vector3.forward * forwardForce, ForceMode.Impulse);
        }
    }
}
