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

    private bool isRun = false;

    void Start()
    {
        if (cameraSettings == null) { print($"�� ���������� Settings � CameraMove"); NotActionClass = true; }
        if (NotActionClass) { return; }//�������� �����������
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
    }
    private void GetIsRun()//�������� ���������� �� ���������� ������ �� �����
    {
        if (!isRun)//���� ����� ���������� �� ������ false
        {
            player = GetPlayer();//�������� ������ �� �����
            if (player.MovePlayer != null) { isRun = true; }
            else { isRun = false; print($"������ �� �������� Player"); }
        }
    }
    private void MoveActiv()
    {
        if (isRun)
        {
            rezultPositionZ = player.Transform.position.z - cameraPoint.transform.position.z+ setVector.z;
            rezultPositionX = player.Transform.position.x - cameraPoint.transform.position.x + setVector.x;

            if (rezultPositionZ > 0) { setZ = 1; }else if (rezultPositionZ < 0) { setZ = -1; }
            if (Math.Abs(rezultPositionZ) > tempLimitZ)
            {
                tempLimitZ = 1f;
                cameraPoint.transform.Translate(new Vector3(0, 0, setZ) * Time.deltaTime * speedMove, Space.World);
            }
            else { tempLimitZ = limitZ; }
            //
            if (rezultPositionX > 0) { setX = 1; } else if (rezultPositionX < 0) { setX = -1; }
            if (Math.Abs(rezultPositionX) > tempLimitX)
            {
                tempLimitX = 1f;
                cameraPoint.transform.Translate(new Vector3(setX, 0, 0) * Time.deltaTime * speedMove, Space.World);
            }
            else { tempLimitX = limitX; }
        }
    }
    private void Update()
    {
        if (NotActionClass) { return; }//�������� �����������

        if (cameraSettings.IsUpDate)
        {
            GetSetting();
        }

        if (!isRun)//���� ��� ����������, �������� ���������� ����
        {
            GetIsRun();
        }
        else
        {
            MoveActiv();
        }
    }
}
