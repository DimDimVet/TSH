using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static EventManager;

public class LogicSettPanel : MonoBehaviour
{
    [SerializeField] private AudioSetting audioSetting;

    [Header("Кнопка Назад")]
    [SerializeField] private Button returnButton;
    [SerializeField] private GameObject thisPanel;

    [Header("Звуковой файл")]
    [SerializeField] private AudioClip audioClip;

    private bool isStop = false;
    private AudioSource audioSource;

    private void Start()
    {
        if (returnButton != null & thisPanel!=null)
        {
            SetEventButton();
            SetPanel();
            isStop = false;
        }
        else { print($"Не заполнены поля в {gameObject.name}"); return; }

        if (audioClip != null & audioSetting != null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = audioClip;
            audioSource.volume = (audioSetting.efectVol) / 100;
        }
    }
    private void SetEventButton()
    {
        returnButton.onClick.AddListener(ReturnPanel);
    }
    private void SetPanel()
    {
        //thisPanel.SetActive(false);
        //rezultPanel.SetActive(false);
        //historyPanel.SetActive(false);
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
