using UnityEngine;
    public class CameraMatrix : MonoBehaviour
{

    private void Start()
    {
        Camera _camera= this.GetComponent<Camera>();
        Matrix4x4 matrix = GetComponent<Camera>().projectionMatrix;
        //matrix[0, 0] *= 2.0f;
        matrix[1, 1] *= 2.0f;
        GetComponent<Camera>().projectionMatrix = matrix;






    }














}