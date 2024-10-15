using System.Collections;
using UnityEngine;
using UnityEngine.UI; // ��� ������ � UI ����������

public class LifeAmount : MonoBehaviour
{

    public Image[] heartIcons; // ������ ��� �������� ������

    

    private void Start()
    {
        UpdateLivesDisplay(); // ��������� ����������� ������ ��� ������
        StartCoroutine(CheckCondition()); // ��������� �������� ��� ��������
    }

    IEnumerator CheckCondition()
    {
        // �������� ���� ����� �� ����
        while (GlobalValuesManager.Instance.playerLives != 0)
        {
            // � �������� ���� ����� ����� �������� �� ������ �����
            // ���� ���������� ������ ����������, ��������� �����������
            UpdateLivesDisplay();

            // ��� �� ���������� ����� ����� ��������� ���������
            yield return null;
        }

        Debug.Log("Player is dead. Stopped checking condition.");
    }

    // ������� ��� ���������� ����������� ���������� ������
    void UpdateLivesDisplay()
    {
        // ���������� �� ���� ������� � �������� ��� ���������� ��
        for (int i = 0; i < heartIcons.Length; i++)
        {
            if (i < GlobalValuesManager.Instance.playerLives)
            {
                heartIcons[i].enabled = true; // ���������� ������
            }
            else
            {
                heartIcons[i].enabled = false; // �������� ������
            }
        }
    }
}
