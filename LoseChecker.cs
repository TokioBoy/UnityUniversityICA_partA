using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseChecker : MonoBehaviour
{
    private void Start()
    {
        {
            // «апускаем корутину, котора€ будет следить за выполнением услови€
            StartCoroutine(CheckCondition());
        }
    }

    IEnumerator CheckCondition()
    {
        // ∆дЄм, пока условие не выполнитс€
        while (!GlobalValuesManager.Instance.lose)
        {
            // «десь может быть проверка вашего услови€, например:
            if (GlobalValuesManager.Instance.playerLives == 0)
            {
                //  ак только условие выполнено, выполн€ем действи€
                GlobalValuesManager.Instance.lose = true;
                SceneManager.LoadScene("TheStart");

            }

            // ∆дЄм до следующего кадра перед повторной проверкой
            yield return null;
        }

        // Ёта часть выполнитс€ один раз, когда условие будет выполнено
        Debug.Log("Stopped checking condition.");
    }
}
