using System.Collections;
using UnityEngine;


public class SpearsFromTheGroundFunctionality : MonoBehaviour
{
    public Transform pointA;  // ����� �����
    public Transform pointB;  // ����� �������
    public float speedUp = 10f;  // �������� �������
    public float speedDown = 3f;  // �������� ������
    private bool movingUp = true;  // ����������� �������� �����
    private bool isWaiting = false; // ���� ��� ������������ �����
    

    // Update ���������� �� ������ �����
    void Update()
    {
        if (!isWaiting)
        {
            // ����������� ������� ����
            Transform target = movingUp ? pointB : pointA;

            // �������� ����� � ���� � ������ ��������� ��� ������� � ������
            float speed = movingUp ? speedUp : speedDown;
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            // ��������, �������� �� ����� ����
            if (Vector3.Distance(transform.position, target.position) < 0.1f)
            {
                // �������� �������� ��� ����� � ����� �����������
                StartCoroutine(WaitAndChangeDirection());
            }
        }
    }

    // ������� ��� �������� � ����� �����������
    IEnumerator WaitAndChangeDirection()
    {
        isWaiting = true;  // ������������� ���� ��������

        // ���� 1 �������
        yield return new WaitForSeconds(1f);

        // ��������� ����������� �������� (�����/����)
        movingUp = !movingUp;

        isWaiting = false;  // ���������� ���� ��������
    }
}
