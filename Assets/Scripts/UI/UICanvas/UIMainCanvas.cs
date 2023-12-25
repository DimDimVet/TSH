using UnityEngine;
using UnityEngine.UI;
using static EventManager;

public class UIMainCanvas : MonoBehaviour
{
    [SerializeField] private Text CountPlayerText;
    [SerializeField] private Text InfoCountPlayerText;
    //кэш
    private Camera currentCamera;
    private Canvas canvas;
    private Construction cameraObject, thisObject;

    [SerializeField,Range(0,5)] private int timerAlfa;
    private int countAlfa = 0;
    private Color currColorAlfa;

    private bool isUpDate=false;
    private bool isRun = false;
    private void GetSet()
    {
        canvas = GetComponent<Canvas>();
        cameraObject = GetCamera();
        thisObject = GetPlayer();
        currentCamera = cameraObject.CameraComponent;
        canvas.worldCamera = currentCamera;
        canvas.planeDistance = 15f;
        //
        currColorAlfa = InfoCountPlayerText.color;
        currColorAlfa.a = 0f;
        InfoCountPlayerText.color = currColorAlfa;
    }
    private void OnEnable()
    {
        OnUIStaistic += GetStat;
        CountPlayerText.text = $"{0}";
        InfoCountPlayerText.text = $"{0}";
    }
    private void OnDisable()
    {
        OnUIStaistic -= GetStat;
    }
    private void GetStat(Statistic stat)
    {
        if (isRun & thisObject.Hash == stat.HashPlayer)
        {
            CountPlayerText.text = $"{stat.CountCost}";
            InfoCountPlayerText.text = $"+{stat.CostTargetObject}";
            //
            isUpDate = !isUpDate;
            currColorAlfa.a = 1f;
        }
    }
    private void InfoCountAlfa()
    {
        if (isUpDate )
        {
            if (countAlfa <= timerAlfa)
            {
                countAlfa++;
            }
            else
            {
                countAlfa = 0;
                currColorAlfa.a = currColorAlfa.a - 0.01f;
                if (currColorAlfa.a <= 0) { isUpDate = !isUpDate; }
                InfoCountPlayerText.color = currColorAlfa;
            }
        }
    }
    private void GetIsRun()
    {
        if (!isRun)//если общее разрешение на запуск false
        {
            if (currentCamera != null) { isRun = true; }
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
        //
        InfoCountAlfa();
    }
}
