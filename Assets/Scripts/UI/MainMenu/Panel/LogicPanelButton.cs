using UnityEngine;
using static EventBus;
using static UnityEngine.PlayerLoop.PostLateUpdate;

public class LogicPanelButton : MonoBehaviour
{
    [SerializeField] private AudioSetting audioSetting;

    [Header("Панель кнопок")]
    [SerializeField] private GameObject panelButton;

    private AudioSource audioSource;
    private bool isTriger = false;
    private void OnEnable()
    {
        OnIsRunMainPanel += IsStartpanel;
        OnUpDateAudioParametr += UpDateAudio;
    }
    private void OnDisable()
    {
        OnIsRunMainPanel -= IsStartpanel;
        OnUpDateAudioParametr -= UpDateAudio;
    }
    private void Start()
    {
        if (panelButton != null)
        {
            panelButton.SetActive(false);
        }
        else { print($"Не заполнены поля в {gameObject.name}"); }

        if (audioSetting != null)//
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = audioSetting.AudioClipGnd;
            audioSource.volume = (audioSetting.MuzVol);
        }
    }
    private void UpDateAudio()
    {
        audioSource.volume = (audioSetting.MuzVol);
    }
    private void IsStartpanel(bool isRun)
    {
        if (isRun)
        {
            panelButton.SetActive(isRun);
            if (!isTriger) { audioSource.Play(); isTriger = true; }
        }
        else
        {
            panelButton.SetActive(isRun);
        }
    }
}
