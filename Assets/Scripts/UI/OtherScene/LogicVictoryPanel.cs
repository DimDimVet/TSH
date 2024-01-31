using UnityEngine;
using UnityEngine.UI;

public class LogicVictoryPanel : LogicPanel
{
    [SerializeField] private SceneSetting sceneSetting;
    private AudioSource audioSourceMuz;

    [Header("Подключим ScriptableObjectStstistic")]
    [SerializeField] private ScriptableObjectStstistic scriptableObjectStstistic;
    [Header("Подключим текстовое поле")]
    [SerializeField] private Text rezultText;
    [SerializeField] private string dopText;
    private Statistic statistic;
    public override void SetPanel()
    {
        audioSourceMuz = gameObject.AddComponent<AudioSource>();
        audioSourceMuz.clip = AudioSetting.AudioClipGnd;
        audioSourceMuz.volume = (AudioSetting.MuzVol);
        audioSourceMuz.Play();

        statistic = scriptableObjectStstistic.LoadStat();
        rezultText.text = $"{dopText} \n{statistic.CountCost}";
    }
    public override void ReturnPanel()
    {
        AudioClick();
        sceneSetting.ReturnMainMenu();
    }
}
