using UnityEngine;

public class ShootPlayer : GetInputPlayer
{
    [SerializeField] private ShootSettings shootSettings;
    private bool NotActionClass = false;
    //���
    private float currentTime, defaultTime;
    private bool isBullReLoad = false;
    private bool isRun = false;
    void Start()
    {
        if (shootSettings == null) { print($"�� ���������� Settings � ShootPlayer"); NotActionClass = true; }
        if (NotActionClass) { return; }//�������� �����������
        GetIsRun();
        GetSetting();
    }
    private void GetSetting()
    {
        currentTime = shootSettings.CurrentTime;
        defaultTime = currentTime;
        shootSettings.IsUpDate = false;
    }
    private void GetIsRun()
    {
        if (!isRun)//���� ����� ���������� �� ������ false
        {
            isRun = true;
            //

        }
    }
    private bool ReLoadBullet()
    {
        if (isBullReLoad) 
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            { 
                currentTime = defaultTime; isBullReLoad = false; return true; 
            }
            return false;
        }
        return true;
    }
    private void Shoot()
    {
        if (isRun && ReLoadBullet())
        {
            if (InputData.MouseLeftButton != 0)
            {
                Pools.BullBB.GetObject();
                isBullReLoad=true;
            }
        }
    }
    private void FixedUpdate()
    {
        if (NotActionClass) { return; }//�������� �����������

        if (shootSettings.IsUpDate)
        {
            GetSetting();
        }
        if (!isRun)//���� ����� ���������� �� ������ false
        {
            GetIsRun();
            return;
        }
        Shoot();
    }
}
