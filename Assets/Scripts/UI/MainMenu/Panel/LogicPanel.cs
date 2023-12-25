using UnityEngine;
using UnityEngine.UI;
using static EventManager;

public class LogicPanel : MonoBehaviour
{
    public AudioSetting AudioSetting { get { return audioSetting; } set{ audioSetting = value; } }
    [SerializeField] private AudioSetting audioSetting;

    [Header("������ �����")]
    [SerializeField] private Button returnButton;
    [SerializeField] private GameObject thisPanel;

    private AudioSource audioSource;
    private void Start()
    {
        if (returnButton != null & thisPanel != null)
        {
            SetEventReturnButton();
            SetEventButton();
            SetPanel();
        }
        else { print($"�� ��������� ���� � {gameObject.name}"); return; }

        if (audioSetting != null)//
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = audioSetting.AudioClipButton;
            audioSource.volume = (audioSetting.EfectVol);
        }
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
        returnButton.onClick.AddListener(ReturnPanel);
    }
    public virtual void SetEventButton()
    {
        //
    }
    public virtual void SetPanel()
    {
        //
    }
    public void AudioClick()
    {
        audioSource.Play();
    }
    public virtual void ReturnPanel()
    {
        AudioClick();
        thisPanel.SetActive(false);
        IsRunMainPanel(true);
    }
}
