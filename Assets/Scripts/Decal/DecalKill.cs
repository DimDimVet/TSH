using UnityEngine;
using static EventBus;

public class DecalKill : MonoBehaviour
{
    private int timeKill = 155;
    private int time = 0;
    private RaycastHit hit;
    private int _damage = 0, hashObjectDamagAcceptance = 0, costTargetObject = 0;
    private bool isKillObjectAcceptance = false;

    private void OnEnable()
    {
        time = 0;
    }
    void Update()
    {
        if (time <= timeKill)
        {
            time++;
        }
        else
        {
            IsReternBull(this.gameObject.GetHashCode(), hashObjectDamagAcceptance, costTargetObject, isKillObjectAcceptance, _damage, hit);
            time = 0;
        }
    }
}
