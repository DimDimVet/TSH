using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2Camera : MonoBehaviour
{
    public float rotateSpeed = 10f;
    public float moveSpeed = 10f;
    public GameObject GO;

    private void Update()
    {
        transform.position=GO.transform.position;
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        print(v);
        transform.Translate(new Vector3(h,0,v)*Time.deltaTime*moveSpeed,Space.Self);
        //
        float keyRotation = 0;
        if (Input.GetKey(KeyCode.Q))
        {
            keyRotation = -1f;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            keyRotation = 1f;
        }
        transform.Rotate(Vector3.up*rotateSpeed* Time.deltaTime * keyRotation, Space.World);
    }
}
