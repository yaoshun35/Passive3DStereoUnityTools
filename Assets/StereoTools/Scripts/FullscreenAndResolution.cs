using UnityEngine;
using System.IO;

public class FullscreenAndResolution : MonoBehaviour
{
    // ָ��Ҫ��ʾ/���صĶ���
    public GameObject targetObject;

    void Start()
    {
        // ��ȡ�ֱ����ļ�
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
                Debug.LogError("�ֱ����ļ���ʽ����");
            }
        }
        else
        {
            Debug.LogError("�Ҳ����ֱ����ļ���");
        }
    }

    void Update()
    {
        // ���� H ����ʾ/���ض���
        if (Input.GetKeyDown(KeyCode.H))
        {
            targetObject.SetActive(!targetObject.activeSelf);
        }

        // ���� Esc ���˳�����
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}