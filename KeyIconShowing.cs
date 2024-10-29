using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // ��� ������ � UI ����������

public class KeyIconShowing : MonoBehaviour
{

    public Image[] keyIcons; // ������ ��� �������� ������



    private void Start()
    {
        UpdateKeyDisplay(); // ��������� ����������� ������ ��� ������
        StartCoroutine(CheckCondition()); // ��������� �������� ��� ��������
    }

    IEnumerator CheckCondition()
    {
        // �������� ���� ����� �� ����
        while (GlobalValuesManager.Instance.playerLives != 0)
        {
            // � �������� ���� ����� ����� �������� �� ������ �����
            // ���� ���������� ������ ����������, ��������� �����������
            UpdateKeyDisplay();

            // ��� �� ���������� ����� ����� ��������� ���������
            yield return null;
        }
    }

    // ������� ��� ���������� ����������� ���������� ������
    void UpdateKeyDisplay()
    {
        if(ExitHellScript.hasKey == true)
        {
            keyIcons[0].enabled = true;
        }else if(ExitHellScript.hasKey == false)
        {
            keyIcons[0].enabled = false;
        }
        if (ExitEarthScript.hasKey == true)
        {
            keyIcons[1].enabled = true;
        }
        else if (ExitEarthScript.hasKey == false)
        {
            keyIcons[1].enabled = false;
        }
        if (ExitHeavenScript.hasKey == true)
        {
            keyIcons[2].enabled = true;
        }
        else if (ExitHeavenScript.hasKey == false)
        {
            keyIcons[2].enabled = false;
        }
    }
}