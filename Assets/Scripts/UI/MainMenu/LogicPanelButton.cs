using UnityEngine;
using static EventManager;

public class LogicPanelButton : MonoBehaviour
{
    [SerializeField] private AudioSetting audioSetting;

    [Header("������ ������")]
    [SerializeField] private GameObject panelButton;

    [Header("�������� ����")]
    [SerializeField] private AudioClip audioClip;

    private AudioSource audioSource;
    private bool isTriger = false;

    private void OnEnable()
    {
        OnIsRunMainPanel += IsStartpanel;
    }
    private void OnDisable()
    {
        OnIsRunMainPanel -= IsStartpanel;
    }
    private void Start()
    {
        if (panelButton != null)
        {
            panelButton.SetActive(false);
        }
        else { print($"�� ��������� ���� � {gameObject.name}"); }

        if (audioClip != null & audioSetting != null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = audioClip;
            audioSource.volume = (audioSetting.muzVol) / 100;
        }
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
