using System.Collections;
using UnityEngine;
using UnityEngine.UI; // Для работы с UI элементами

public class LifeAmount : MonoBehaviour
{

    public Image[] heartIcons; // Массив для хранения иконок

    

    private void Start()
    {
        UpdateLivesDisplay(); // Обновляем отображение жизней при старте
        StartCoroutine(CheckCondition()); // Запускаем корутину для проверки
    }

    IEnumerator CheckCondition()
    {
        // Проверка пока игрок не умер
        while (GlobalValuesManager.Instance.playerLives != 0)
        {
            // В реальной игре здесь будет проверка на потерю жизни
            // Если количество жизней изменилось, обновляем отображение
            UpdateLivesDisplay();

            // Ждём до следующего кадра перед повторной проверкой
            yield return null;
        }

        Debug.Log("Player is dead. Stopped checking condition.");
    }

    // Функция для обновления отображения количества жизней
    void UpdateLivesDisplay()
    {
        // Проходимся по всем иконкам и скрываем или показываем их
        for (int i = 0; i < heartIcons.Length; i++)
        {
            if (i < GlobalValuesManager.Instance.playerLives)
            {
                heartIcons[i].enabled = true; // Показываем иконку
            }
            else
            {
                heartIcons[i].enabled = false; // Скрываем иконку
            }
        }
    }
}
