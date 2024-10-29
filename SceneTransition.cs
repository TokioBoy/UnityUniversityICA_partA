using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public Text levelText; // Ссылка на Text компонент
    public float fadeDuration = 1.5f; // Продолжительность анимации затухания
    public float displayDuration = 0.5f; // Время показа перед началом затухания

    private void Start()
    {
        // Устанавливаем начальную непрозрачность текста
        levelText.canvasRenderer.SetAlpha(1.0f);
        // Запускаем корутину
        StartCoroutine(FadeOutAndLoad());
    }

    private IEnumerator FadeOutAndLoad()
    {
        // Ждем заданное время показа
        yield return new WaitForSeconds(displayDuration);

        // Анимация затухания
        levelText.CrossFadeAlpha(0, fadeDuration, false);

        // Ждем завершения затухания
        yield return new WaitForSeconds(fadeDuration);

        // Убираем текст с экрана
        levelText.gameObject.SetActive(false);
    }
}
