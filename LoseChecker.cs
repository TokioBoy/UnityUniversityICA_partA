using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseChecker : MonoBehaviour
{
    private void Start()
    {
        {
            // ��������� ��������, ������� ����� ������� �� ����������� �������
            StartCoroutine(CheckCondition());
        }
    }

    IEnumerator CheckCondition()
    {
        // ���, ���� ������� �� ����������
        while (!GlobalValuesManager.Instance.lose)
        {
            // ����� ����� ���� �������� ������ �������, ��������:
            if (GlobalValuesManager.Instance.playerLives == 0)
            {
                // ��� ������ ������� ���������, ��������� ��������
                GlobalValuesManager.Instance.lose = true;
                SceneManager.LoadScene("TheStart");

            }

            // ��� �� ���������� ����� ����� ��������� ���������
            yield return null;
        }

        // ��� ����� ���������� ���� ���, ����� ������� ����� ���������
        Debug.Log("Stopped checking condition.");
    }
}
