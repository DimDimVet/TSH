using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static EventManager;

public struct ElementGrid
{
    public GameObject PrefabType;
    public GameObject Element;
}
public class LogicGridCharging : MonoBehaviour
{
    [SerializeField] private GridChargingSettings gridSett;
    //
    [SerializeField] private GridLayoutGroup grid;
    [SerializeField] private GameObject element—harging;
    [SerializeField] private GameObject elementGun;
    [SerializeField] private GameObject elementRif;
    private GameObject tempElement;
    private ElementGrid element;
    private List<ElementGrid> elements;
    private bool isStopElementGun = false, isStopElementRif = false;
    private Vector2 mode—harging, modeGun, modeRif;
    private Mode _mode;
    private void Start()
    {
        tempElement = GameObject.Instantiate(element—harging, grid.transform.position,
                                                            grid.transform.rotation, grid.transform);
        CreatList(element—harging, tempElement);
        //
        mode—harging.x = gridSett.SpacingX—harging;
        mode—harging.y = gridSett.SpacingY—harging;
        modeGun.x = gridSett.SpacingXGun;
        modeGun.y = gridSett.SpacingYGun;
        modeRif.x = gridSett.SpacingXRif;
        modeRif.y = gridSett.SpacingYRif;
    }
    private void OnEnable()
    {
        OnSelectParametr += Select;
        OnChargingParametr += Charging;
    }
    private void OnDisable()
    {
        OnSelectParametr -= Select;
        OnChargingParametr -= Charging;
    }
    private void Select(Mode mode)
    {
        _mode = mode;
    }
    private void Charging(Mode mode, bool isClipReLoad, int currentCountClip)
    {
        if (_mode == mode)
        {
            ControlList(mode, currentCountClip);
            SetGrid(_mode, isClipReLoad, currentCountClip);
        }
    }
    private bool ControlList(Mode mode, int currentCountClip)
    {
        if (_mode == Mode.Turn && !isStopElementGun)
        {
            for (int i = 0; i < currentCountClip; i++)
            {
                tempElement = GameObject.Instantiate(elementGun, grid.transform.position,
                                                      grid.transform.rotation, grid.transform);
                CreatList(elementGun, tempElement);
            }
            isStopElementGun = true;
        }
        if (_mode == Mode.AvtoRif && !isStopElementRif)
        {
            for (int i = 0; i < currentCountClip; i++)
            {
                tempElement = GameObject.Instantiate(elementRif, grid.transform.position,
                                                      grid.transform.rotation, grid.transform);
                CreatList(elementRif, tempElement);
            }
            isStopElementRif = true;
        }
        return true;
    }
    private void CreatList(GameObject prefabType, GameObject elementGrid)
    {
        elementGrid.SetActive(false);
        element = new ElementGrid { PrefabType = prefabType, Element = elementGrid };

        if (elements == null) { elements = new List<ElementGrid>() { element }; return; }
        else { elements.Add(element); }
    }
    private void SetGrid(Mode mode, bool isClipReLoad, int currentCountClip)
    {
        int tempCount = 0;
        if (currentCountClip == 0 & isClipReLoad)
        {
            grid.spacing = mode—harging;
            for (int i = 0; i < elements.Count; i++)
            {
                if (elements[i].PrefabType == element—harging)
                {
                    elements[i].Element.SetActive(true);
                }
                else
                {
                    elements[i].Element.SetActive(false);
                }
            }
        }
        if (Mode.Turn == mode)
        {
            grid.spacing = modeGun;
            if (!isClipReLoad)
            {
                tempCount = 0;
                for (int i = 0; i < elements.Count; i++)
                {
                    if (elements[i].PrefabType == elementGun & currentCountClip > tempCount)
                    {
                        elements[i].Element.SetActive(true);
                    }
                    else
                    {
                        elements[i].Element.SetActive(false);
                    }
                }
            }
        }
        if (Mode.AvtoRif == mode)
        {
            grid.spacing = modeRif;
            if (!isClipReLoad)
            {
                tempCount = 0;
                for (int i = 0; i < elements.Count; i++)
                {
                    if (elements[i].PrefabType == elementRif & currentCountClip > tempCount)
                    {
                        elements[i].Element.SetActive(true);
                        tempCount++;
                    }
                    else
                    {
                        elements[i].Element.SetActive(false);
                    }
                }
            }
        }
    }
}
