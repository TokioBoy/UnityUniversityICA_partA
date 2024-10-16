using System.Collections;
using UnityEngine;

public class SwordKillerFunctionality : MonoBehaviour
{
    public Transform pointA;  // ����� �
    public Transform pointB;  // ����� �
    public float speed = 5f;  // �������� �������� ����
    public float rotationSpeed = 180f;  // �������� �������� (������� � �������)
    private bool movingToB = true;  // ����������� ��������
    private bool isWaiting = false; // ���� ��� ������������ �����
    private Quaternion targetRotation;  // ������� ���������� ����

    void Start()
    {
        // ������������� ������� ���������� ��� �������
        targetRotation = transform.rotation;
    }

    // Update ���������� �� ������ �����
    void Update()
    {
        if (!isWaiting)
        {
            // ����������� ������� ����
            Transform target = movingToB ? pointB : pointA;

            // �������� ���� � ����
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            // ��������, ������ �� ��� ����� ����������
            if (Vector3.Distance(transform.position, target.position) < 0.1f)
            {
                // �������� �������� ��� ��������, ����� � ����� �����������
                StartCoroutine(RotateAndWaitBeforeMove());
            }
        }
    }

    // ������� ��� ��������, �������� � ����������� ��������
    IEnumerator RotateAndWaitBeforeMove()
    {
        isWaiting = true;  // ������������� ���� ��������

        // ������������ ����� ������� ���������� � ��������� �� 180 ��������
        targetRotation = transform.rotation * Quaternion.Euler(0, 0, 180);

        // ������� ������� ����, ���� �� �� ��������� ������� ����������
        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.1f)
        {
            // ������� �������� ���� � ������� ����������
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            yield return null; // ���� ���� ���� ����� ������������ �����
        }

        // ���� 3 ������� ����� ���������� ��������
        yield return new WaitForSeconds(3f);

        // ��������� ����������� ��������
        movingToB = !movingToB;

        isWaiting = false;  // ���������� ���� ��������
    }
}
