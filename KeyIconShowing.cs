using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Для работы с UI элементами

public class KeyIconShowing : MonoBehaviour
{

    public Image[] keyIcons; // Массив для хранения иконок



    private void Start()
    {
        UpdateKeyDisplay(); // Обновляем отображение жизней при старте
        StartCoroutine(CheckCondition()); // Запускаем корутину для проверки
    }

    IEnumerator CheckCondition()
    {
        // Проверка пока игрок не умер
        while (GlobalValuesManager.Instance.playerLives != 0)
        {
            // В реальной игре здесь будет проверка на потерю жизни
            // Если количество жизней изменилось, обновляем отображение
            UpdateKeyDisplay();

            // Ждём до следующего кадра перед повторной проверкой
            yield return null;
        }
    }

    // Функция для обновления отображения количества жизней
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