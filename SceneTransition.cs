using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public Text levelText; // ������ �� Text ���������
    public float fadeDuration = 1.5f; // ����������������� �������� ���������
    public float displayDuration = 0.5f; // ����� ������ ����� ������� ���������

    private void Start()
    {
        // ������������� ��������� �������������� ������
        levelText.canvasRenderer.SetAlpha(1.0f);
        // ��������� ��������
        StartCoroutine(FadeOutAndLoad());
    }

    private IEnumerator FadeOutAndLoad()
    {
        // ���� �������� ����� ������
        yield return new WaitForSeconds(displayDuration);

        // �������� ���������
        levelText.CrossFadeAlpha(0, fadeDuration, false);

        // ���� ���������� ���������
        yield return new WaitForSeconds(fadeDuration);

        // ������� ����� � ������
        levelText.gameObject.SetActive(false);
    }
}
