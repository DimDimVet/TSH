using System;
using UnityEngine;
using static EventManager;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private GameObject cameraPoint;
    [SerializeField] private CameraSettings cameraSettings;
    private bool NotActionClass = false;
    private Vector3 setVector;
    private float rezultPositionZ, rezultPositionX;
    private float limitZ, limitX, tempLimitZ, tempLimitX, setZ, setX;
    private float speedMove;
    private Construction player;
    private bool isControlDistance;
    private bool isRun = false;

    void Start()
    {
        if (cameraSettings == null) { print($"Не установлен Settings в CameraMove"); NotActionClass = true; }
        if (NotActionClass) { return; }//Проверка разрешнения
        GetSetting();
        //Cursor.lockState = CursorLockMode.Locked;
    }

    private void GetSetting()
    {
        cameraSettings.IsUpDate = false;
        setVector =new Vector3(cameraSettings.AxesX, cameraSettings.AxesY, cameraSettings.AxesZ);
        cameraPoint.transform.position = setVector;
        limitZ= cameraSettings.LimitZ;
        limitX = cameraSettings.LimitX;
        speedMove = cameraSettings.SpeedMove;
        isControlDistance=cameraSettings.IsControlDistance;
    }
    private void GetIsRun()//получаем ращрешение по результату данных из листа
    {
        if (!isRun)//если общее разрешение на запуск false
        {
            player = GetPlayer();//получаем данные из листа
            if (player.MovePlayer != null) { isRun = true; }
            else { isRun = false; print($"Камера не получила Player"); }
        }
    }
    private void MoveActiv()
    {
        if (isRun)
        {
            //rezultPositionZ = player.Transform.position.z - cameraPoint.transform.position.z+ setVector.z;
            //rezultPositionX = player.Transform.position.x - cameraPoint.transform.position.x + setVector.x;
            //if (isControlDistance)
            //{
            //    if (rezultPositionZ > 0) { setZ = 1; } else if (rezultPositionZ < 0) { setZ = -1; }
            //    if (Math.Abs(rezultPositionZ) > tempLimitZ)
            //    {
            //        tempLimitZ = 1f;
            //        cameraPoint.transform.Translate(new Vector3(0, 0, setZ) * Time.deltaTime * speedMove, Space.World);
            //    }
            //    else { tempLimitZ = limitZ; }
            //    //
            //    if (rezultPositionX > 0) { setX = 1; } else if (rezultPositionX < 0) { setX = -1; }
            //    if (Math.Abs(rezultPositionX) > tempLimitX)
            //    {
            //        tempLimitX = 1f;
            //        cameraPoint.transform.Translate(new Vector3(setX, 0, 0) * Time.deltaTime * speedMove, Space.World);
            //    }
            //    else { tempLimitX = limitX; }
            //}
            //else
            //{
            //    cameraPoint.transform.Translate(new Vector3(rezultPositionX, 0, rezultPositionZ) * Time.deltaTime * speedMove, Space.World);
            //}
        }
    }

    [SerializeField] private Vector3 _distanceFromObject; // Camera's distance from the object

    private void LateUpdate() //Works after all update functions called
    {
        //Vector3 positionToGo = player.Transform.position + _distanceFromObject; //Target position of the camera
        //Quaternion rotToGo = player.Transform.rotation;
        //Vector3 smoothPosition = Vector3.Lerp(a: transform.position, b: positionToGo, t: 0.125F); //Smooth position of the camera
        ////cameraPoint.transform.position = smoothPosition;
        //cameraPoint.transform.position = positionToGo;
        //cameraPoint.transform.rotation = rotToGo;
        ////cameraPoint.transform.rotation = positionToGo.rotation;
        //cameraPoint.transform.LookAt(player.Transform.position); //Camera will look(returns) to the object
    }
    private void Update()
    {
        if (NotActionClass) { return; }//Проверка разрешнения

        if (cameraSettings.IsUpDate)
        {
            GetSetting();
        }

        if (!isRun)//если нет разрешения, пытаемся подключать лист
        {
            GetIsRun();
        }
        else
        {
            MoveActiv();
        }
    }
}
