using UnityEngine;
using System.IO;

public class FullscreenAndResolution : MonoBehaviour
{
    // 指定要显示/隐藏的对象
    public GameObject targetObject;

    void Start()
    {
        // 读取分辨率文件
        string filePath = Path.Combine(Application.streamingAssetsPath, "resolution.txt");
        if (File.Exists(filePath))
        {
            string[] resolutionValues = File.ReadAllText(filePath).Split(' ');
            if (resolutionValues.Length == 2)
            {
                int width = int.Parse(resolutionValues[0]);
                int height = int.Parse(resolutionValues[1]);
                Screen.SetResolution(width, height, true);
            }
            else
            {
                Debug.LogError("分辨率文件格式错误！");
            }
        }
        else
        {
            Debug.LogError("找不到分辨率文件！");
        }
    }

    void Update()
    {
        // 按下 H 键显示/隐藏对象
        if (Input.GetKeyDown(KeyCode.H))
        {
            targetObject.SetActive(!targetObject.activeSelf);
        }

        // 按下 Esc 键退出程序
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}