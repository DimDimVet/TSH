using System.Collections.Generic;
using UnityEngine;
using static PlasticGui.GetProcessName;

public class Pools : MonoBehaviour
{
    //��� ������� ��������
    public GameObject _Bull; public Transform ContainerBull;
    //��� ������� � �����
    public static Pool Bull;

    void Start()
    {
        Set();
    }
    private void Set()
    {
        Bull=new Pool(_Bull, ContainerBull);
    }
}
