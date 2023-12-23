using UnityEngine;
using UnityEngine.UI;
using static EventManager;

public class LogicPanel : MonoBehaviour
{
    [SerializeField] private AudioSetting audioSetting;

    [Header("Кнопка Назад")]
    [SerializeField] private Button returnButton;
    [SerializeField] private GameObject thisPanel;

    private AudioSource audioSource;
    private void Start()
    {
        if (returnButton != null & thisPanel != null)
        {
            SetEventButton();
            SetPanel();
        }
        else { print($"Не заполнены поля в {gameObject.name}"); return; }

        if (audioSetting != null)//
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = audioSetting.AudioClipButton;
            audioSource.volume = (audioSetting.EfectVol) / 100;
        }
    }
    private void SetEventButton()
    {
        returnButton.onClick.AddListener(ReturnPanel);
    }
    public virtual void SetPanel()
    {
        //
    }
    private void AudioClick()
    {
        audioSource.Play();
    }
    private void ReturnPanel()
    {
        AudioClick();
        thisPanel.SetActive(false);
        IsRunMainPanel(true);
    }
}
