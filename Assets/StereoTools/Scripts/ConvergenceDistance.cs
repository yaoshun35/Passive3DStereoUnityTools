using UnityEngine;
using UnityEngine.UI;

public class ConvergenceDistance : MonoBehaviour
{
    // ��ȡ�������
    public Camera leftCamera;
    public Camera rightCamera;

    // ��ǰ��۾���
    private float currentDistance = 5.0f;

    // ��۾�����ڷ���
    private float adjustStep = 1.0f;

    // ����۾���
    private float maxDistance = 100.0f;

    // ��С��۾���
    private float minDistance = 1.0f;

    // ������ʾ��۾�����ı����
    public Text distanceText;

    // ��ʱ��
    private float timer = 0f;

    // ���֮��ľ��� (ͫ��)
    private float interpupillaryDistance = 0.06f;

    void Update()
    {
        // ���� I ����С��۾���
        if (Input.GetKeyDown(KeyCode.I))
        {
            currentDistance = Mathf.Clamp(currentDistance - adjustStep, minDistance, maxDistance);
            UpdateCameraRotations();
            ShowDistance();
        }

        // ���� O �����ӻ�۾���
        if (Input.GetKeyDown(KeyCode.O))
        {
            currentDistance = Mathf.Clamp(currentDistance + adjustStep, minDistance, maxDistance);
            UpdateCameraRotations();
            ShowDistance();
        }

        // ��ʱ��
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                distanceText.text = "";
            }
        }
    }

    // ���������ת
    void UpdateCameraRotations()
    {
        // �����۽Ƕ�
        float convergenceAngle = Mathf.Atan(interpupillaryDistance / (2.0f * currentDistance)) * Mathf.Rad2Deg;

        // ��ת���
        leftCamera.transform.localRotation = Quaternion.Euler(0, -convergenceAngle, 0);
        rightCamera.transform.localRotation = Quaternion.Euler(0, convergenceAngle, 0);
    }

    // ��ʾ��۾���
    void ShowDistance()
    {
        distanceText.text = "��۾���: " + currentDistance.ToString("F1") + "m";
        timer = 2f;
    }
}