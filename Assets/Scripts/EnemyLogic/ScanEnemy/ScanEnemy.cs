using UnityEngine;
using static EventManager;

public class ScanEnemy : MonoBehaviour
{
    [SerializeField] private SphereCollider scanCollider;
    [SerializeField] private ScanEnemySettings scanEnemySettings;
    private bool NotActionClass = false;
    //���
    private float dimCollider;
    private int hashGetObject;
    private Construction objectGetScaner;
    private Construction[] objects;
    private bool isRun = false;
    void Start()
    {
        if (scanEnemySettings == null) { print($"�� ���������� Settings � {gameObject.name}"); NotActionClass = true; }
        if (NotActionClass) { return; }//�������� �����������
        GetSetting();
        GetIsRun();
    }
    private void GetSetting()
    {
        dimCollider = scanEnemySettings.DimCollider;
    }
    private void GetIsRun()
    {
        if (!isRun)//���� ����� ���������� �� ������ false
        {
            if (scanCollider != null) { isRun = true; scanCollider.radius = dimCollider; }
            else { isRun = false; print($"�� ���������� Collider � {gameObject.name}"); }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        hashGetObject = other.gameObject.GetHashCode();
    }
    private void EnemyScan()
    {
        if (isRun)
        {
            if (objects != null)
            {
                for (int i = 0; i < objects.Length; i++)
                {
                    if (objects[i].Hash != hashGetObject) 
                    {
                        objectGetScaner = GetObjectHash(hashGetObject);
                        
                    }
                };
            }

            
            print($"{gameObject.GetHashCode()} - {scanCollider.GetHashCode()}");
            //print($"{gameObject.GetHashCode()} - {scanCollider.GetHashCode()}");
        }
    }
    private void FixedUpdate()
    {
        if (NotActionClass) { return; }//�������� �����������

        if (scanEnemySettings.IsUpDate)
        {
            GetSetting();
            scanEnemySettings.IsUpDate = false;
        }
        if (!isRun)//���� ����� ���������� �� ������ false
        {
            GetIsRun();
            return;
        }
        EnemyScan();
    }
}
