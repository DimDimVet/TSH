using UnityEngine;
using UnityEngine.UI;
using static EventManager;

public class LogicButtonMenu : MonoBehaviour
{
    [SerializeField] private AudioSetting audioSetting;

    [Header("������ ����")]
    [SerializeField] private Button gameButton;
    [Header("������ ���������")]
    [SerializeField] private Button settButton;
    [SerializeField] private GameObject settPanel;
    [Header("������ ���������")]
    [SerializeField] private Button rezultButton;
    [SerializeField] private GameObject rezultPanel;
    [Header("������ �������")]
    [SerializeField] private Button historyButton;
    [SerializeField] private GameObject historyPanel;
    [Header("������ �����")]
    [SerializeField] private Button exitButton;

    [Header("�������� ����")]
    [SerializeField] private AudioClip audioClip;

    private bool isStop = false;
    private AudioSource audioSource;

    private void Start()
    {
        if (gameButton != null & settButton!=null & rezultButton!=null 
            & historyButton!=null & exitButton!=null)
        {
            SetEventButton();
            SetPanel();
            isStop = false;
        }
        else { print($"�� ��������� ���� � {gameObject.name}");return; }

        if (audioClip != null & audioSetting != null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = audioClip;
            audioSource.volume = (audioSetting.efectVol) / 100;
        }
    }
    private void SetEventButton()
    {
        gameButton.onClick.AddListener(StartGame);
        settButton.onClick.AddListener(SettGame);
        rezultButton.onClick.AddListener(RezultGame);
        historyButton.onClick.AddListener(HistoryGame);
        exitButton.onClick.AddListener(ExitGame);
    }
    private void SetPanel()
    {
        settPanel.SetActive(false);
        rezultPanel.SetActive(false);
        historyPanel.SetActive(false);
    }
    private void AudioClick()
    {
        audioSource.Play();
    }
    private void StartGame()
    {
        AudioClick();
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
    private void HistoryGame()
    {
        AudioClick();
        historyPanel.SetActive(true);
        IsRunMainPanel(false);
    }
    private void ExitGame()
    {
        AudioClick();
        Application.Quit();
    }
}
