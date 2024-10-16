using System.Collections;
using UnityEngine;

public class SwordKillerFunctionality : MonoBehaviour
{
    public Transform pointA;  // Точка А
    public Transform pointB;  // Точка Б
    public float speed = 5f;  // Скорость движения меча
    public float rotationSpeed = 180f;  // Скорость поворота (градусы в секунду)
    private bool movingToB = true;  // Направление движения
    private bool isWaiting = false; // Флаг для отслеживания паузы
    private Quaternion targetRotation;  // Целевая ориентация меча

    void Start()
    {
        // Инициализация целевой ориентации как текущей
        targetRotation = transform.rotation;
    }

    // Update вызывается на каждом кадре
    void Update()
    {
        if (!isWaiting)
        {
            // Определение текущей цели
            Transform target = movingToB ? pointB : pointA;

            // Движение меча к цели
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            // Проверка, достиг ли меч точки назначения
            if (Vector3.Distance(transform.position, target.position) < 0.1f)
            {
                // Начинаем корутину для поворота, паузы и смены направления
                StartCoroutine(RotateAndWaitBeforeMove());
            }
        }
    }

    // Корутин для поворота, ожидания и продолжения движения
    IEnumerator RotateAndWaitBeforeMove()
    {
        isWaiting = true;  // Устанавливаем флаг ожидания

        // Рассчитываем новую целевую ориентацию с поворотом на 180 градусов
        targetRotation = transform.rotation * Quaternion.Euler(0, 0, 180);

        // Плавный поворот меча, пока он не достигнет целевой ориентации
        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.1f)
        {
            // Плавное вращение меча к целевой ориентации
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            yield return null; // Ждем один кадр перед продолжением цикла
        }

        // Ждем 3 секунды после завершения поворота
        yield return new WaitForSeconds(3f);

        // Изменение направления движения
        movingToB = !movingToB;

        isWaiting = false;  // Сбрасываем флаг ожидания
    }
}
