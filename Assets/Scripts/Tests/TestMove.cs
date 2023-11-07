using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotSpeed = 10f;
    public Transform towerTransform;

    // Update is called once per frame
    void Update()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveH, 0, moveV);
        Vector3 newPosition = transform.position + movement * moveSpeed * Time.deltaTime;
        transform.position=newPosition;

        if (movement != Vector3.zero)
        {
            Quaternion targetRot = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, rotSpeed*Time.deltaTime);
        }

        if (Input.GetMouseButton(0)) 
        {
            Vector3 mousePosition = new Vector3(Mouse.current.position.ReadValue().x, Mouse.current.position.ReadValue().y,0);
            Ray ray=Camera.main.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                Vector3 targetDirection = hitInfo.point - towerTransform.position;
                Quaternion targetTower=Quaternion.LookRotation(targetDirection);
                towerTransform.rotation=Quaternion.Lerp(towerTransform.rotation,targetTower,rotSpeed*Time.deltaTime);
            }
        }
    }
}
