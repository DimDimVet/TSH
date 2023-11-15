using UnityEditor.SceneManagement;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //[SerializeField] private ParticleSystem particle;
    //[SerializeField] private TrailRenderer trailRender;
    [SerializeField] private BulletSettings bullSettings;
    [SerializeField] private bool typeSleeve=false;
    [SerializeField] private Rigidbody body;
    private bool NotActionClass = false;
    //���
    private float speedBullet;
    private float killTime, defaultTime;
    private bool isBullKill = true,isShootTriger=true;
    private bool isRun = false;

    void Awake()
    {
        if (bullSettings == null) { print($"�� ���������� {bullSettings.name} � Bullet"); NotActionClass = true; }
        if (NotActionClass) { return; }//�������� �����������
        GetIsRun();
        GetSetting();
    }
    private void GetSetting()
    {
        speedBullet = bullSettings.SpeedBullet;
        killTime = bullSettings.KillTime;
        defaultTime = killTime;
        bullSettings.IsUpDate = false;
    }
    private void GetIsRun()
    {
        if (!isRun)//���� ����� ���������� �� ������ false
        {
            isRun = true;
            ///
        }
    }
    private bool KillTimeBullet()
    {
        if (isBullKill)
        {
            killTime -= Time.deltaTime;
            if (killTime <= 0)
            {
                killTime = defaultTime; isBullKill = false; return true;
            }
            return false;
        }
        return false;
    }
    private void RunBullet()
    {
        if (isRun && !typeSleeve)
        {
            gameObject.transform.Translate(Vector3.forward * speedBullet * Time.deltaTime);

            isBullKill = true;
            if (KillTimeBullet())
            { ReternBullet();}
        }
        else if(typeSleeve)
        {
            if (isShootTriger) { body.AddForce(body.position * speedBullet, ForceMode.Acceleration); }

            isShootTriger =false;
            isBullKill = true;
            if (KillTimeBullet())
            { isShootTriger=true; ShootSleeve(); }
        }
    }
    public virtual void ReternBullet()
    {
        //
    }
    public virtual void ShootSleeve()
    {
        //
    }
    private void FixedUpdate()
    {
        if (NotActionClass) { return; }//�������� �����������

        if (bullSettings.IsUpDate)
        {
            GetSetting();
            bullSettings.IsUpDate=false;
        }
        if (!isRun)//���� ����� ���������� �� ������ false
        {
            GetIsRun();
            return;
        }
        RunBullet();
    }
}
