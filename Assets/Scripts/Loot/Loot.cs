using UnityEngine;
using static EventManager;

public class Loot : MonoBehaviour
{
    [SerializeField] private LootSettings lootSettings;
    private Construction hitObject;
    private bool isHealt;
    private int hashGetObject;
    private Vector3 startPos,endPos;
    private RaycastHit hit;
    public float Healt { get { return healt; } }
    private float healt;
    //
    private bool isRun = false;
    void Awake()
    {
        if (lootSettings == null) { print($"Не установлен {lootSettings.name} в Loot"); }
        GetIsRun();
        GetSetting();
    }
    private void OnEnable()
    {
        startPos = this.gameObject.transform.position;
        endPos = startPos + (new Vector3(1f, 1f, 1f));
    }
    private void GetSetting()
    {
        healt = lootSettings.Healt;
        isHealt = lootSettings.IsHealt;//true-триггер по HealtPlayer, false-триггер по HealtEnemy
    }
    private void GetIsRun()
    {
        if (!isRun)//если общее разрешение на запуск false
        {
            isRun = true;
        }
    }
    private bool DetectObject()
    {
        if (Physics.Linecast(startPos, endPos, out hit))
        {
            hashGetObject = hit.collider.gameObject.GetHashCode();
            hitObject = GetObjectHash(hashGetObject);

            if (hitObject.HealtEnemy != null & isHealt == false)
            {
                SetEssence(hitObject.Hash);
                return true;
            }
            else if (hitObject.HealtPlayer != null & isHealt == true)
            {
                SetEssence(hitObject.Hash);
                return true;
            }
        }
        return false;
    }

    public virtual void SetEssence(int hash)//что то предаем в найденый объект
    {
        //
    }
    public virtual void ReternEssence()//возвращаем лут
    {
        //
    }
    private void RunLoot()
    {
        if (isRun)
        {
            if (DetectObject()) { ReternEssence(); }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(startPos, transform.position);
    }
    private void FixedUpdate()
    {
        if (lootSettings.IsUpDate)
        {
            GetSetting();
            lootSettings.IsUpDate = false;
        }
        if (!isRun)//если общее разрешение на запуск false
        {
            GetIsRun();
            return;
        }
        RunLoot();
    }
}
