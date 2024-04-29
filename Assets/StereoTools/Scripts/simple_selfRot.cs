using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class simple_selfRot : MonoBehaviour
{

    public Vector3 RotSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Rotate(new Vector3(RotSpeed.x,RotSpeed.y,RotSpeed.z)*Time.deltaTime, Space.Self);
    }
}
