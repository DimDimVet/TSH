using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static EventManager;

public class LogicButtonMenuLvl : MonoBehaviour
{
    [SerializeField] private AudioSetting audioSetting;
    [SerializeField] private SceneSetting sceneSetting;
    //
    [Header("Кнопка пауза")]
    [SerializeField] private Button pauseMenuButton;
    [SerializeField] private GameObject pauseMenuPanel;
    [Header("Кнопка Настройка")]
    [SerializeField] private Button settButton;
    [SerializeField] private GameObject settPanel;
    [Header("Кнопка Меню")]
    [SerializeField] private Button menuButton;
    [Header("Кнопка переиграть")]
    [SerializeField] private Button reBootButton;
    [Header("Кнопка продолжить")]
    [SerializeField] private Button continButton;
    private AudioSource audioSource, audioSourceMuz;

    private void Start()
    {
        if (sceneSetting != null & settButton != null & menuButton != null &
            reBootButton != null & continButton != null & pauseMenuButton != null)
        {
            SetEventButton();
            SetPanel();
        }
        else { print($"Не заполнены поля в {gameObject.name}"); return; }

        if (audioSetting != null)
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
    }
    private void OnEnable()
    {
        OnUpDateAudioParametr += UpDateAudio;
        OnIsRunMainPanel += IsStartpanel;
    }
    private void OnDisable()
    {
        OnUpDateAudioParametr -= UpDateAudio;
        OnIsRunMainPanel -= IsStartpanel;
    }
    private void IsStartpanel(bool isRun)
    {
        if (isRun)
        {
            pauseMenuPanel.SetActive(isRun);
        }
    }
    private void UpDateAudio()
    {
        audioSource.volume = (audioSetting.EfectVol);
        audioSourceMuz.volume = (audioSetting.MuzVol);
    }
    private void SetEventButton()
    {
        pauseMenuButton.onClick.AddListener(ActivPause);
        settButton.onClick.AddListener(SettGame);
        menuButton.onClick.AddListener(MenuGame);
        reBootButton.onClick.AddListener(ReBootGame);
        continButton.onClick.AddListener(ContinGame);
    }
    private void SetPanel()
    {
        settPanel.SetActive(false);
        pauseMenuPanel.SetActive(false);

    }
    private void AudioClick()
    {
        audioSource.Play();
    }
    private void ActivPause()
    {
        AudioClick();
        Time.timeScale = 0f;
        pauseMenuPanel.SetActive(true);
        pauseMenuButton.gameObject.SetActive(false);
    }
    private void SettGame()
    {
        AudioClick();
        settPanel.SetActive(true);
        pauseMenuPanel.SetActive(false);
    }
    private void MenuGame()
    {
        AudioClick();
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneSetting.MenuSceneIndex);
    }
    private void ReBootGame()
    {
        ContinGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void ContinGame()
    {
        AudioClick();
        Time.timeScale = 1f;
        pauseMenuPanel.SetActive(false);
        pauseMenuButton.gameObject.SetActive(true);
    }

}
