using System.Collections;
using UnityEngine;

public class KeyToEarth : MonoBehaviour
{
    private bool hasBeenCollected = false; // Флаг для проверки, был ли объект уже собран

    public void OnTriggerEnter(Collider other)
    {
        // Проверяем, что объект, который активировал триггер, — игрок и объект не был собран ранее
        if (other.CompareTag("Player") && !hasBeenCollected)
        {
            hasBeenCollected = true; // Устанавливаем флаг, чтобы предотвратить повторное использование

            // Устанавливаем флаг hasKey в ExitHellScript в значение true
            ExitHellScript.hasKey = true;
            GlobalValuesManager.Instance.playerLives++;

            // Запускаем корутину, чтобы скрыть объект после 1 секунды
            StartCoroutine(HideObjectAfterDelay());
        }
    }

    private IEnumerator HideObjectAfterDelay()
    {
        // Ждем 0.6 секунд
        yield return new WaitForSeconds(0.6f);

        // Скрываем или деактивируем текущий объект (этот ключ)
        gameObject.SetActive(false);
    }
}
