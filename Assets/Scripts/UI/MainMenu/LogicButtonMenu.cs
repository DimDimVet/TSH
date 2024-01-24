using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static EventBus;

public class LogicButtonMenu : MonoBehaviour
{
    [SerializeField] private AudioSetting audioSetting;
    [SerializeField] private SceneSetting sceneSetting;
    //
    [Header("������ ����")]
    [SerializeField] private Button gameButton;
    [Header("������� ������ ����� ����")]
    private int gameSceneIndex;
    [Header("������ ���������")]
    [SerializeField] private Button settButton;
    [SerializeField] private GameObject settPanel;
    [Header("������ ���������")]
    [SerializeField] private Button rezultButton;
    [SerializeField] private GameObject rezultPanel;
    [Header("������ �����")]
    [SerializeField] private Button exitButton;
    private AudioSource audioSource;

    private void Start()
    {
        if (sceneSetting!=null & gameButton != null & settButton != null &
            rezultButton != null & exitButton != null)
        {
            SetEventButton();
            SetPanel();
        }
        else { print($"�� ��������� ���� � {gameObject.name}"); return; }

        if (audioSetting != null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = audioSetting.AudioClipButton;
            audioSource.volume = (audioSetting.EfectVol);
        }
        if (sceneSetting != null) { gameSceneIndex = sceneSetting.GameSceneIndex; }
        else { print($"�� �������� ������ �����");}
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
    private void SetEventButton()
    {
        gameButton.onClick.AddListener(StartGame);
        settButton.onClick.AddListener(SettGame);
        rezultButton.onClick.AddListener(RezultGame);
        exitButton.onClick.AddListener(ExitGame);
    }
    private void SetPanel()
    {
        settPanel.SetActive(false);
        rezultPanel.SetActive(false);
    }
    private void AudioClick()
    {
        audioSource.Play();
    }
    private void StartGame()
    {
        AudioClick();
        SceneManager.LoadScene(gameSceneIndex);
    }
    private void SettGame()
    {
        AudioClick();
        settPanel.SetActive(true);
        IsRunMainPanel(false);
    }
    private void RezultGame()
    {
        AudioClick();
        rezultPanel.SetActive(true);
        IsRunMainPanel(false);
    }
    private void ExitGame()
    {
        AudioClick();
        Application.Quit();
    }
}
