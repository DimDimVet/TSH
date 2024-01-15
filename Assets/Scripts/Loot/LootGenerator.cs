using System;
using UnityEngine;
using static EventManager;

public class LootGenerator : MonoBehaviour
{
    public GameObject _HealtLoot; public Transform ContainerHealtLoot;
    private Pool healtLoot;
    private bool isTriger=false;
    private int thisHash;
    void Start()
    {
        healtLoot = new Pool(_HealtLoot, ContainerHealtLoot);
        thisHash=this.gameObject.GetHashCode();
    }

    private void OnEnable()
    {
        OnIsDead += SetLoot;
        OnIsReternLoot += ReternLoot;
    }
    private void OnDisable()
    {
        OnIsDead -= SetLoot;
        OnIsReternLoot -= ReternLoot;
    }

    private void ReternLoot(int thisHash)
    {
        healtLoot.ReternObject(thisHash);
    }

    private void SetLoot(int _thisHash, bool isDead, int costObject)
    {
        if (!isTriger & _thisHash == thisHash)
        {
            healtLoot.GetObject();
            isTriger = true;
        }
    }
}
