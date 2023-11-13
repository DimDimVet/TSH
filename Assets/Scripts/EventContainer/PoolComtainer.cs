using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolComtainer
{
    private GameObject prefab;
    private List<GameObject> listObject;
    private GameObject[] myArr;

    public PoolComtainer(GameObject _prefab, int _countObject)
    {
        prefab = _prefab;
        listObject = new List<GameObject>();
        myArr=new GameObject[1];
        for (int i = 0; i < _countObject; i++)
        {
            GameObject obj = GameObject.Instantiate(prefab);
            if (_countObject!= myArr.Length)
            {
                Array.Resize(ref myArr, _countObject);
            }
            myArr[i] = obj;
            //listObject.Add(obj);
        }
    }
    public GameObject[] GetList()
    {
        return myArr;
    }
    public GameObject GetObject()
    {

        return listObject[0];
    }
}
