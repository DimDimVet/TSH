using UnityEngine;
using static EventManager;

public class DecalKill : MonoBehaviour
{
    private int timeKill = 155;
    private int time = 0;
    private RaycastHit hit;

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
            IsReternBull(this.gameObject.GetHashCode(), hit);
            time = 0; 
        }
    }
}
