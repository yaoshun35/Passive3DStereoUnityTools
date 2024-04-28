using UnityEngine;
using UnityEngine.UI;

public class ConvergenceDistance : MonoBehaviour
{
    // 获取两个相机
    public Camera leftCamera;
    public Camera rightCamera;

    // 当前汇聚距离
    private float currentDistance = 5.0f;

    // 汇聚距离调节幅度
    private float adjustStep = 1.0f;

    // 最大汇聚距离
    private float maxDistance = 100.0f;

    // 最小汇聚距离
    private float minDistance = 1.0f;

    // 用于显示汇聚距离的文本组件
    public Text distanceText;

    // 计时器
    private float timer = 0f;

    // 相机之间的距离 (瞳距)
    private float interpupillaryDistance = 0.06f;

    void Update()
    {
        // 按下 I 键减小汇聚距离
        if (Input.GetKeyDown(KeyCode.I))
        {
            currentDistance = Mathf.Clamp(currentDistance - adjustStep, minDistance, maxDistance);
            UpdateCameraRotations();
            ShowDistance();
        }

        // 按下 O 键增加汇聚距离
        if (Input.GetKeyDown(KeyCode.O))
        {
            currentDistance = Mathf.Clamp(currentDistance + adjustStep, minDistance, maxDistance);
            UpdateCameraRotations();
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

    // 更新相机旋转
    void UpdateCameraRotations()
    {
        // 计算汇聚角度
        float convergenceAngle = Mathf.Atan(interpupillaryDistance / (2.0f * currentDistance)) * Mathf.Rad2Deg;

        // 旋转相机
        leftCamera.transform.localRotation = Quaternion.Euler(0, -convergenceAngle, 0);
        rightCamera.transform.localRotation = Quaternion.Euler(0, convergenceAngle, 0);
    }

    // 显示汇聚距离
    void ShowDistance()
    {
        distanceText.text = "汇聚距离: " + currentDistance.ToString("F1") + "m";
        timer = 2f;
    }
}