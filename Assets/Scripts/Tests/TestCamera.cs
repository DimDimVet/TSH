using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TestCamera : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _gameObject;
    private Vector3 prevPos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButton(0))
        //{
        //    Vector2 pos = Input.mousePosition;
        //    timer -= Time.deltaTime;
        //    if (timer <= 0)
        //    {
        //        print(pos);
        //        transform.RotateAround(_gameObject.position, Vector3.up, pos.x*Time.deltaTime);
        //    }

        //}
        //else
        //{
        //    timer = 0.5f;
        //}

        Vector2 pos = Input.mousePosition;
        //if (Input.GetMouseButtonDown(0))
        //    //{
        //    //    prevPos = _camera.ScreenToViewportPoint(pos);
        //    //}
            if (Input.GetMouseButton(0))
            {
                Vector3 dir = prevPos - _camera.ScreenToViewportPoint(pos);
                transform.position = _gameObject.position;

                //_camera.transform.Rotate(new Vector3(0,0,1) ,dir.y*180);
                transform.Rotate(new Vector3(0, 1, 0), dir.x * 180, Space.World);
                transform.Translate(new Vector3(0, 0, -10));
                prevPos = _camera.ScreenToViewportPoint(pos);
            }



    }
}
