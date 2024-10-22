using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwordKillerFunctionality : MonoBehaviour
{
    public Transform pointA;  // ����� �
    public Transform pointB;  // ����� �
    public float speed = 5f;  // �������� �������� ����
    public float rotationSpeed = 180f;  // �������� �������� (������� � �������)
    private bool movingToB = true;  // ����������� ��������
    private bool isWaiting = false; // ���� ��� ������������ �����
    private Quaternion targetRotation;  // ������� ���������� ����
    [SerializeField] private Transform respawnPoint;
    public Transform player;

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

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object the skull collides with is the player
        if (other.CompareTag("Player"))
        {
            HandleSwordTouch();
        }
    }

    // A method that defines what happens when the skull touches the player
    void HandleSwordTouch()
    {
        Debug.Log("Spear has touched the player!");

        GlobalValuesManager.Instance.playerLives--;
        player.transform.position = respawnPoint.transform.position;

        // If the player has no lives left, restart the game
        if (GlobalValuesManager.Instance.playerLives == 0)
        {
            ExitHellScript.hasKey = false;
            SceneManager.LoadScene("TheStart");
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
        yield return new WaitForSeconds(1f);

        // ��������� ����������� ��������
        movingToB = !movingToB;

        isWaiting = false;  // ���������� ���� ��������
    }
}
