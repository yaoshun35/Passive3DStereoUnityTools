using UnityEngine;
using UnityEngine.UI;

public class PupillaryDistance : MonoBehaviour
{
    // ��ȡ�������
    public Camera leftCamera;
    public Camera rightCamera;

    // ��ǰͫ��
    private float currentDistance = 0.06f;

    // ͫ����ڷ���
    private float adjustStep = 0.0004f;

    // ���ͫ��
    private float maxDistance = 0.3f;

    // ��Сͫ��
    private float minDistance = 0f;

    // ������ʾͫ����ı����
    public Text distanceText;

    // ��ʱ��
    private float timer = 0f;

    void Update()
    {
        // ����J����Сͫ��
        if (Input.GetKey(KeyCode.J))
        {
            currentDistance = Mathf.Clamp(currentDistance - adjustStep, minDistance, maxDistance);
            UpdateCameraPositions();
            ShowDistance();
        }

        // ����K������ͫ��
        if (Input.GetKey(KeyCode.K))
        {
            currentDistance = Mathf.Clamp(currentDistance + adjustStep, minDistance, maxDistance);
            UpdateCameraPositions();
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

    // �������λ��
    void UpdateCameraPositions()
    {
        leftCamera.transform.localPosition = new Vector3(-currentDistance / 2, 0, 0);
        rightCamera.transform.localPosition = new Vector3(currentDistance / 2, 0, 0);
    }

    // ��ʾͫ��
    void ShowDistance()
    {
        distanceText.text = "ͫ��: " + currentDistance.ToString("F3");
        timer = 2f;
    }
}