using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static EventManager;

public class LogicGamePanel : MonoBehaviour
{
    [SerializeField] private AudioSetting audioSetting;
    [SerializeField] private SceneSetting sceneSetting;

    private AudioSource audioSource;
    private AudioSource audioSourceMuz;

    [Header("Кнопка Пауза")]
    [SerializeField] private Button pauseButton;
    [SerializeField] private GameObject pausePanel;

    private void Start()
    {
        if (pauseButton != null)
        {
            SetEventReturnButton();
            SetEventButton();
            SetPanel();
        }
        else { print($"Не заполнены поля в {gameObject.name}"); return; }
    }
    private void OnEnable()
    {
        OnUpDateAudioParametr += UpDateAudio;
    }
    private void OnDisable()
    {
        OnUpDateAudioParametr -= UpDateAudio;
    }
    private void UpDateAudio()
    {
        audioSource.volume = (audioSetting.EfectVol);
    }
    private void SetEventReturnButton()
    {
        //returnButton.onClick.AddListener(ReturnPanel);
    }
    public virtual void SetEventButton()
    {
        pauseButton.onClick.AddListener(ActivPause);
    }
    public virtual void SetPanel()
    {
        if (audioSetting != null)//
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = audioSetting.AudioClipButton;
            audioSource.volume = (audioSetting.EfectVol);
            //
            audioSourceMuz = gameObject.AddComponent<AudioSource>();
            audioSourceMuz.clip = audioSetting.AudioClipGnd;
            audioSourceMuz.volume = (audioSetting.MuzVol);
            audioSourceMuz.Play();
        }

        if (pausePanel == null) { print($"Нет в панели ПАУЗА"); return; }
        pausePanel.SetActive(false);
    }
    public void AudioClick()
    {
        audioSource.Play();
    }
    public virtual void ReturnPanel()
    {
        AudioClick();
        //sceneSetting.ReturnMainMenu();
    }
    private void ActivPause()
    {
        AudioClick();
        if (Time.timeScale != 0f) { Time.timeScale = 0f; pausePanel.SetActive(true); }
        else { Time.timeScale = 1f; pausePanel.SetActive(false); }
    }
}
