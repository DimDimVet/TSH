using System;
using UnityEngine;
using UnityEngine.UI;
using static EventBus;

public class UIMainCanvas : MonoBehaviour
{
    [SerializeField] private Text CountPlayerText;
    [SerializeField] private Text InfoCountPlayerText;
    [SerializeField] private Image gndPanel;
    //
    [SerializeField] private Text CountEnemysText;
    //кэш
    private Camera currentCamera;
    private Canvas canvas;
    private Construction cameraObject, thisObject;

    [SerializeField,Range(0,1)] private float timerAlfa;
    private float countAlfa = 0.5f;
    private Color currColorAlfa;

    [SerializeField, Range(0, 1)] private float timerGndPanel;
    private float countGndPanel = 0.5f;
    private Color colorGndPanel;

    private bool isDeadPlayer=false, isVictory=false;
    private bool isUpDate=false;
    private bool isRun = false;
    private void GetSet()
    {
        canvas = GetComponent<Canvas>();
        cameraObject = GetCamera();
        thisObject = GetPlayer();
        currentCamera = cameraObject.CameraComponent;
        canvas.worldCamera = currentCamera;
        canvas.planeDistance = 5f;
        //
        currColorAlfa = InfoCountPlayerText.color;
        currColorAlfa.a = 0f;
        InfoCountPlayerText.color = currColorAlfa;
        //
        colorGndPanel = new Color(0f, 0f, 0f, 0f);
        gndPanel.color= colorGndPanel;
    }
    private void OnEnable()
    {
        OnUIStaistic += GetStat;
        CountEnemysText.text = $"{0}";
        CountPlayerText.text = $"{0}";
        InfoCountPlayerText.text = $"{0}";
        OnIsDead += KillPlayer;
        OnIsVictory += VictoryPlayer;
        //
        OnUICountEnemys += GetEnemys;
    }
    private void OnDisable()
    {
        OnUIStaistic -= GetStat;
        OnUICountEnemys -= GetEnemys;
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
                countAlfa= countAlfa+0.1f;
            }
            else
            {
                countAlfa = 0;
                currColorAlfa.a = currColorAlfa.a - 0.1f;
                if (currColorAlfa.a <= 0) { isUpDate = !isUpDate; }
                InfoCountPlayerText.color = currColorAlfa;
            }
        }
    }
    private void GetEnemys(int enemys)
    {
        CountEnemysText.text = $"{enemys}";
    }
    private void VictoryPlayer(int thisHash, bool _isVictory)
    {
        if (thisObject.Hash == thisHash & _isVictory == true) { isVictory = _isVictory; }
    }
    private void KillPlayer(int thisHash, bool isDead, int costObject)//kill player
    {
        if (thisObject.Hash == thisHash & isDead==true) { isDeadPlayer=isDead; }
    }

    private void ColorGndPanel()
    {
        if (isDeadPlayer || isVictory)
        {
            if (countGndPanel <= timerGndPanel)
            {
                countGndPanel = countGndPanel + 0.1f;
            }
            else
            {
                countGndPanel = 0;
                colorGndPanel.a = colorGndPanel.a + 0.1f;

                if (isDeadPlayer) { colorGndPanel.r = colorGndPanel.r + 0.1f; }
                if (isVictory) { colorGndPanel.g = colorGndPanel.g + 0.1f; }

                if (colorGndPanel.a >= 1) { /*isDeadPlayer = !isDeadPlayer;*/ EnableUIElement(true); OffUIElement(true); }
                gndPanel.color = colorGndPanel;
            }
        }
    }
    private void OffUIElement(bool isOffUIElement)
    {
        CountPlayerText.gameObject.SetActive(!isOffUIElement);
    }
    private void GetIsRun()
    {
        if (!isRun)//если общее разрешение на запуск false
        {
            if (currentCamera != null) { isRun = true; }
            else { isRun = false; GetSet(); }
        }
    }
    private void FixedUpdate()
    {
        if (!isRun)//если общее разрешение на запуск false
        {
            GetIsRun();
            return;
        }
        //
        InfoCountAlfa();
        ColorGndPanel();
    }
}
