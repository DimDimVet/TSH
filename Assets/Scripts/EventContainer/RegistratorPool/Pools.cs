using System.Collections.Generic;
using UnityEngine;
using static PlasticGui.GetProcessName;

public class Pools : MonoBehaviour
{
    //Для входных префабов
    public GameObject _Bull; public Transform ContainerBull;
    //Для доступа к пулам
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
