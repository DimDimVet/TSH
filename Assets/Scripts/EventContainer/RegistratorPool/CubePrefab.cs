using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CubePrefab : MonoBehaviour
{

    [SerializeField] bool _isPrefab = false;
    [SerializeField] bool _isPrefabDestory = false;

    private List<GameObject> list = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_isPrefab)
        {
            list.Add(Pools.Bull.GetObject());
            _isPrefab = false; 
        }
        if (_isPrefabDestory) 
        {
            for (int i = 0; i < list.Count; i++) { Pools.Bull.ReternObject(list[i]); }
        }
        if (list.Count > 10)
        {

        }
    }
}
