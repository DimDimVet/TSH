using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static EventManager;

public class UIMainCanvas : MonoBehaviour
{
    [SerializeField] private Text CountPlayerText;
    [SerializeField] private Text InfoCountPlayerText;
    //[SerializeField] private Slider slider;
    //[SerializeField] private GameObject trackingObject;
    //кэш
    private int thisHash;
    private Camera currentCamera;
    private Canvas canvas;
    private Construction cameraObject, thisObject;

    private bool isRun = false;
    private void GetSet()
    {
        canvas = GetComponent<Canvas>();
        cameraObject = GetCamera();
        currentCamera = cameraObject.CameraComponent;
        canvas.worldCamera = currentCamera;
        //
        //thisHash = trackingObject.GetHashCode();
        //thisObject = GetObjectHash(thisHash);
        //if (thisObject.HealtEnemy != null)
        //{
        //    slider.maxValue = thisObject.HealtEnemy.HealtCount;
        //    slider.value = thisObject.HealtEnemy.HealtCount;
        //}
        //else if (thisObject.HealtPlayer != null)
        //{
        //    slider.maxValue = thisObject.HealtPlayer.HealtCount;
        //    slider.value = thisObject.HealtPlayer.HealtCount;
        //}
    }
    private void OnEnable()
    {
        //OnGetUIDamage += ThisUIDamage;
    }
    private void OnDisable()
    {
        //OnGetUIDamage -= ThisUIDamage;
    }
    //private void ThisUIDamage(int getHash, int healt)
    //{
    //    if (thisHash == getHash) { SetUIDamage(healt); }
    //}
    //private void SetUIDamage(int healt)
    //{
    //    slider.value = healt;
    //}
    private void GetIsRun()
    {
        if (!isRun)//если общее разрешение на запуск false
        {
            if (currentCamera != null ) { isRun = true; }
            else { isRun = false; GetSet(); print($"Не установлены компоненты в {gameObject.name}"); }
        }
    }
    void Update()
    {
        if (!isRun)//если общее разрешение на запуск false
        {
            GetIsRun();
            return;
        }
    }
    //private void LateUpdate()
    //{
    //    this.gameObject.transform.LookAt(currentCamera.transform);
    //}
}
