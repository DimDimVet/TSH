using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPool : MonoBehaviour
{
    [SerializeField] bool isTr=false;
    [SerializeField] private GameObject mPool;
    PoolComtainer poolComtainer = null;
    void Start()
    {
        poolComtainer = new PoolComtainer(mPool,10);
    }

    private void GetList()
    {
        GameObject[] list =poolComtainer.GetList();
         for (int i=0; i<list.Length; i++)
        {
            print(list[i].name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isTr)
        {
            GetList();
            isTr = false;
        }

    }
}
