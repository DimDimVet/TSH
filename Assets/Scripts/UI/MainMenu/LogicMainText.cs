using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicMainText : MonoBehaviour
{
    [Header("����� ������������")]
    [SerializeField] private string mainName;

    [Header("������ ����� ")]
    [SerializeField] private Text uiText;

    [Header("�������� ������ ������"), Range(0, 5)]
    [SerializeField] private float timer;

    [Header("�����������")]
    [SerializeField] private bool loop = false;

    [Header("�������� ����")]
    [SerializeField] private AudioClip audioClip;

    private int index;
    private float countTime = 0;
    private bool isRun = false;
    private AudioSource audioSource;

    private void Start()
    {
        if (audioClip != null)
        { 
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = audioClip;
            
        }
    }
    private void AddWrite(bool _isRun)
    {
        if (_isRun & mainName != "" & uiText != null)
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
                else { return; }
            }
        }
        else { print($"�� ��������� ���� � {gameObject.name}"); }
    }
    private void Update()
    {
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
