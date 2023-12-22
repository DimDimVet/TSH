using UnityEngine;
using UnityEngine.UI;
using static EventManager;

public class LogicMainText : MonoBehaviour
{

    [SerializeField] private AudioSetting audioSetting;

    [Header("Текст наименования")]
    [SerializeField] private string mainName;

    [Header("Объект текст ")]
    [SerializeField] private Text uiText;

    [Header("Скорость вывода текста"), Range(0, 5)]
    [SerializeField] private float timer;

    [Header("Цикличность")]
    [SerializeField] private bool loop = false;

    [Header("Звуковой файл")]
    [SerializeField] private AudioClip audioClip;

    private int index;
    private float countTime = 0;
    private bool isRun = false, isStop = false;
    private AudioSource audioSource;

    private void Start()
    {
        if (audioClip != null & audioSetting != null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = audioClip;
            audioSource.volume = (audioSetting.efectVol) / 100;
        }
    }
    private void AddWrite(bool _isRun)
    {
        if (!isStop & _isRun & mainName != "" & uiText != null)
        {
            index++;
            if (index <= mainName.Length)
            {
                uiText.text = mainName.Substring(0, index);
                audioSource.Play();
            }
            else
            {
                if (loop) { index = 0; }
                else { isStop = true; IsRunMainPanel(isStop); return; }
            }
        }
        else { print($"Не заполнены поля в {gameObject.name}"); }
    }
    private void Update()
    {
        if (isStop) { return; }
        if (countTime <= timer)
        {
            countTime += Time.deltaTime;
        }
        else
        {
            if (isRun) { isRun = !isRun; }
            else { isRun = !isRun; AddWrite(isRun); }
            countTime = 0;
        }
    }
}
