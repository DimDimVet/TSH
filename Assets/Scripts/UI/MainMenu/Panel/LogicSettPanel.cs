using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static EventManager;

public class LogicSettPanel : LogicPanel
{
    [SerializeField] private Dropdown screenDropdown;
    [SerializeField] private Slider muzSlider;
    [SerializeField] private Slider effectSlider;
    private Resolution[] resolutions;
    private List<string> textScreen;
    public override void SetPanel()
    {
        textScreen=new List<string>();
        resolutions = Screen.resolutions;
        screenDropdown.ClearOptions();

        for (int i = 0; i < resolutions.Length; i++)
        {
            textScreen.Add($"{resolutions[i].width}x{resolutions[i].height}");
        }
        screenDropdown.AddOptions(textScreen);
    }
}
