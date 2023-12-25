using UnityEngine;

public class LogicOverPanel : LogicPanel
{
    [SerializeField] private SceneSetting sceneSetting;
    private AudioSource audioSourceMuz;
    public override void SetPanel()
    {
        audioSourceMuz = gameObject.AddComponent<AudioSource>();
        audioSourceMuz.clip = AudioSetting.AudioClipGnd;
        audioSourceMuz.volume = (AudioSetting.MuzVol);
        audioSourceMuz.Play();
    }
    public override void ReturnPanel()
    {
        AudioClick();
        sceneSetting.ReturnMainMenu();
    }
}
