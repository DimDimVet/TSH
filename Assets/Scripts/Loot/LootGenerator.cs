using UnityEngine;
using static EventBus;

public class LootGenerator : MonoBehaviour
{
    public GameObject _HealtLoot; public Transform ContainerHealtLoot;
    private Pool healtLoot;
    private Vector3 pointCont;
    private bool isTriger = false;
    private int thisHash;
    void Start()
    {
        healtLoot = new Pool(_HealtLoot, ContainerHealtLoot);
        pointCont = ContainerHealtLoot.position;
        thisHash = this.gameObject.GetHashCode();
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
        pointCont = ContainerHealtLoot.position;
        if (!isTriger & _thisHash == thisHash)
        {
            healtLoot.GetObjectRandomPosition(pointDefault: pointCont, range: 1.5f);
            isTriger = true;
        }
    }
}
