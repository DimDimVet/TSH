using Codice.CM.Client.Differences.Merge;
using System;
using UnityEngine;

public class Pool
{
    private GameObject prefab;
    private Element[] containerObject;
    private Transform containerTransform;

    public Pool(GameObject prefab, Transform containerTransform)
    {
        this.prefab = prefab;
        this.containerTransform = containerTransform;
        containerObject = new Element[] { CreatObject() };
    }
    private Element CreatObject(bool isSetActiv = false)
    {
        GameObject temp = GameObject.Instantiate(prefab, containerTransform.position,Quaternion.identity);
        temp.SetActive(isSetActiv);
        Element element = new Element
        {
            Object = temp,
            HashCodeObject = temp.GetHashCode(),
        };
        SetTransform(element);
        return element;
    }
    private void SetTransform(Element element)
    {
        if (element.Object.transform != containerTransform)
        {
            element.Object.transform.position = containerTransform.position;
            element.Object.transform.rotation = containerTransform.rotation;
        }
    }
    public GameObject GetObject()
    {
        int index = GetQueue();
        SetTransform(containerObject[index]);
        containerObject[index].Object.gameObject.SetActive(true);
        return containerObject[index].Object;
    }
    private int GetQueue()
    {
        for (int i = 0; i < containerObject.Length; i++)
        {
            if (!containerObject[i].Object.activeSelf)
            {
                return i;
            }
        }

        int newLength = containerObject.Length + 1;
        Array.Resize(ref containerObject, newLength);
        containerObject[newLength - 1] = CreatObject();
        return newLength - 1;
    }
    public bool ReternObject(int _hash)
    {
        int hash = _hash;

        for (int i = 0; i < containerObject.Length; i++)
        {
            if (containerObject[i].HashCodeObject == hash)
            {
                containerObject[i].Object.SetActive(false);
                containerObject[i].Object.transform.position = containerTransform.position;
                containerObject[i].Object.transform.rotation = containerTransform.rotation;
                return true;
            }
        }
        return false;
    }
}
