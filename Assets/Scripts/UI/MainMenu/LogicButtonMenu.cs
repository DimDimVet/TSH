using UnityEngine;
using UnityEngine.UI;
using static EventManager;

public class LogicButtonMenu : MonoBehaviour
{
    [SerializeField] private AudioSetting audioSetting;

    [Header("Кнопка Игра")]
    [SerializeField] private Button gameButton;
    [Header("Кнопка Настройка")]
    [SerializeField] private Button settButton;
    [SerializeField] private GameObject settPanel;
    [Header("Кнопка Результат")]
    [SerializeField] private Button rezultButton;
    [SerializeField] private GameObject rezultPanel;
    [Header("Кнопка История")]
    [SerializeField] private Button historyButton;
    [SerializeField] private GameObject historyPanel;
    [Header("Кнопка Выход")]
    [SerializeField] private Button exitButton;

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
        else { print($"Не заполнены поля в {gameObject.name}");return; }

        if (audioSetting != null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = audioSetting.AudioClipButton;
            audioSource.volume = (audioSetting.EfectVol) / 100;
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
