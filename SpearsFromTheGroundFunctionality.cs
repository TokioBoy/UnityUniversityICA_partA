using System.Collections;
using UnityEngine;


public class SpearsFromTheGroundFunctionality : MonoBehaviour
{
    public Transform pointA;  // Точка внизу
    public Transform pointB;  // Точка наверху
    public float speedUp = 10f;  // Скорость подъема
    public float speedDown = 3f;  // Скорость спуска
    private bool movingUp = true;  // Направление движения вверх
    private bool isWaiting = false; // Флаг для отслеживания паузы
    

    // Update вызывается на каждом кадре
    void Update()
    {
        if (!isWaiting)
        {
            // Определение текущей цели
            Transform target = movingUp ? pointB : pointA;

            // Движение копья к цели с разной скоростью для подъема и спуска
            float speed = movingUp ? speedUp : speedDown;
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            // Проверка, достигло ли копьё цели
            if (Vector3.Distance(transform.position, target.position) < 0.1f)
            {
                // Начинаем корутину для паузы и смены направления
                StartCoroutine(WaitAndChangeDirection());
            }
        }
    }

    // Корутин для ожидания и смены направления
    IEnumerator WaitAndChangeDirection()
    {
        isWaiting = true;  // Устанавливаем флаг ожидания

        // Ждем 1 секунду
        yield return new WaitForSeconds(1f);

        // Изменение направления движения (вверх/вниз)
        movingUp = !movingUp;

        isWaiting = false;  // Сбрасываем флаг ожидания
    }
}
