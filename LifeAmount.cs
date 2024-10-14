using System.Collections;
using UnityEngine;
using UnityEngine.UI; // Для работы с UI элементами

public class LifeAmount : MonoBehaviour
{
    // Статическая переменная для хранения единственного экземпляра
    public static LifeAmount Instance;

    public Image[] heartIcons; // Массив для хранения иконок

    public void Awake()
    {
        // Если экземпляра еще нет, делаем этот экземпляром и не уничтожаем при загрузке новой сцены
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Объект будет существовать между сценами
        }
        else
        {
            // Если уже существует экземпляр, уничтожаем новый объект
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateLivesDisplay(); // Обновляем отображение жизней при старте
        StartCoroutine(CheckCondition()); // Запускаем корутину для проверки
    }

    IEnumerator CheckCondition()
    {
        // Проверка пока игрок не умер
        while (GlobalValuesManager.Instance.lose == false)
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
