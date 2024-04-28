using UnityEngine;
using UnityEngine.UI;

public class PupillaryDistance : MonoBehaviour
{
    // 获取两个相机
    public Camera leftCamera;
    public Camera rightCamera;

    // 当前瞳距
    private float currentDistance = 0.06f;

    // 瞳距调节幅度
    private float adjustStep = 0.0004f;

    // 最大瞳距
    private float maxDistance = 0.3f;

    // 最小瞳距
    private float minDistance = 0f;

    // 用于显示瞳距的文本组件
    public Text distanceText;

    // 计时器
    private float timer = 0f;

    void Update()
    {
        // 按下J键减小瞳距
        if (Input.GetKey(KeyCode.J))
        {
            currentDistance = Mathf.Clamp(currentDistance - adjustStep, minDistance, maxDistance);
            UpdateCameraPositions();
            ShowDistance();
        }

        // 按下K键增加瞳距
        if (Input.GetKey(KeyCode.K))
        {
            currentDistance = Mathf.Clamp(currentDistance + adjustStep, minDistance, maxDistance);
            UpdateCameraPositions();
            ShowDistance();
        }

        // 计时器
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                distanceText.text = "";
            }
        }
    }

    // 更新相机位置
    void UpdateCameraPositions()
    {
        leftCamera.transform.localPosition = new Vector3(-currentDistance / 2, 0, 0);
        rightCamera.transform.localPosition = new Vector3(currentDistance / 2, 0, 0);
    }

    // 显示瞳距
    void ShowDistance()
    {
        distanceText.text = "瞳距: " + currentDistance.ToString("F3");
        timer = 2f;
    }
}