using UnityEngine;

public class Pools : MonoBehaviour
{
    //��� ������� �������� Player
    public GameObject _BullBB; public Transform ContainerBullBB;
    //public GameObject _BullFB; public Transform ContainerBullFB;
    public GameObject _BullRif; public Transform ContainerBullRif;
    //public GameObject _BullSmog; public Transform ContainerBullSmog;
    public GameObject _BullRifSleeve; public Transform ContainerBullRifSleeve;
    public GameObject _BullSleeve; public Transform ContainerBullSleeve;
    //��� ������� �������� Enemy
    public GameObject _BullEnemyTank; public Transform ContainerBullEnemyTank;
    public GameObject _BullEnemyTankSleeve; public Transform ContainerBullEnemyTankSleeve;
    public GameObject _BullEnemyAvto; public Transform ContainerBullEnemyAvto;
    public GameObject _BullEnemyAvtoSleeve; public Transform ContainerBullEnemyAvtoSleeve;
    //��� ������� � ����� Player
    public static Pool BullBB, BullFB, BullRif, BullSmog;
    public static Pool BullRifSleeve, BullSleeve;
    //��� ������� � ����� Enemy
    public static Pool BullEnemyTank;
    public static Pool BullEnemyTankSleeve;
    public static Pool BullEnemyAvto;
    public static Pool BullEnemyAvtoSleeve;

    void Start()
    {
        Set();
    }
    private void Set()
    {
        //���� Player
        BullBB = new Pool(_BullBB, ContainerBullBB);
        //BullFB = new Pool(_BullFB, ContainerBullFB);
        BullRif = new Pool(_BullRif, ContainerBullRif);
        //BullSmog = new Pool(_BullSmog, ContainerBullSmog);
        BullRifSleeve = new Pool(_BullRifSleeve, ContainerBullRifSleeve);
        BullSleeve = new Pool(_BullSleeve, ContainerBullSleeve);
        //���� Enemy
        BullEnemyTank = new Pool(_BullEnemyTank, ContainerBullEnemyTank);
        BullEnemyTankSleeve = new Pool(_BullEnemyTankSleeve, ContainerBullEnemyTankSleeve);
        BullEnemyAvto = new Pool(_BullEnemyAvto, ContainerBullEnemyAvto);
        BullEnemyAvtoSleeve = new Pool(_BullEnemyAvtoSleeve, ContainerBullEnemyAvtoSleeve);
    }
}
