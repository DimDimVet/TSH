using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    //[SerializeField] private ParticleSystem particle;
    //[SerializeField] private TrailRenderer trailRender;
    [SerializeField] private BulletSettings bullSettings;

    private bool NotActionClass = false;
    //���
    private float speedBullet;
    private float killTime, defaultTime;
    private bool isBullKill = true;
    private bool isRun = false;
    void Start()
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
        if (isRun)
        {
            gameObject.transform.Translate(Vector3.forward * speedBullet * Time.deltaTime);
            isBullKill=true;
            if (KillTimeBullet())
            { ReternBullet(); }
        }
    }
    public virtual void ReternBullet()
    {
        //
    }
    private void FixedUpdate()
    {
        if (NotActionClass) { return; }//�������� �����������

        if (bullSettings.IsUpDate)
        {
            GetSetting();
        }
        if (!isRun)//���� ����� ���������� �� ������ false
        {
            GetIsRun();
            return;
        }
        RunBullet();
    }
}
