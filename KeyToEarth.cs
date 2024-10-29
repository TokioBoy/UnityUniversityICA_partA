using System.Collections;
using UnityEngine;

public class KeyToEarth : MonoBehaviour
{
    private bool hasBeenCollected = false; // ���� ��� ��������, ��� �� ������ ��� ������

    public void OnTriggerEnter(Collider other)
    {
        // ���������, ��� ������, ������� ����������� �������, � ����� � ������ �� ��� ������ �����
        if (other.CompareTag("Player") && !hasBeenCollected)
        {
            hasBeenCollected = true; // ������������� ����, ����� ������������� ��������� �������������

            // ������������� ���� hasKey � ExitHellScript � �������� true
            ExitHellScript.hasKey = true;
            GlobalValuesManager.Instance.playerLives++;

            // ��������� ��������, ����� ������ ������ ����� 1 �������
            StartCoroutine(HideObjectAfterDelay());
        }
    }

    private IEnumerator HideObjectAfterDelay()
    {
        // ���� 0.6 ������
        yield return new WaitForSeconds(0.6f);

        // �������� ��� ������������ ������� ������ (���� ����)
        gameObject.SetActive(false);
    }
}
