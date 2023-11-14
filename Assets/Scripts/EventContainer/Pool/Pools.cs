using UnityEngine;

public class Pools : MonoBehaviour
{
    //Для входных префабов
    public GameObject _BullBB; public Transform ContainerBullBB;
    //public GameObject _BullFB; public Transform ContainerBullFB;
    //public GameObject _BullRif; public Transform ContainerBullRif;
    //public GameObject _BullSmog; public Transform ContainerBullSmog;
    //public GameObject _BullRifSleeve; public Transform ContainerBullRifSleeve;
    //public GameObject _BullSleeve; public Transform ContainerBullSleeve;
    //Для доступа к пулам Player
    public static Pool BullBB, BullFB, BullRif, BullSmog;
    public static Pool BullRifSleeve, BullSleeve;

    void Start()
    {
        Set();
    }
    private void Set()
    {
        BullBB = new Pool(_BullBB, ContainerBullBB);
        //BullFB = new Pool(_BullFB, ContainerBullFB);
        //BullRif = new Pool(_BullRif, ContainerBullRif);
        //BullSmog = new Pool(_BullSmog, ContainerBullSmog);
        //BullRifSleeve = new Pool(_BullRifSleeve, ContainerBullRifSleeve);
        //BullSleeve = new Pool(_BullSleeve, ContainerBullSleeve);
    }
}
