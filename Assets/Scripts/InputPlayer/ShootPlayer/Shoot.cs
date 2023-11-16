using UnityEngine;

public class Shoot : GetInputPlayer
{
    [SerializeField] private ShootSettings shootSettings;
    private bool NotActionClass = false;
    //кэш
    private float currentTime, defaultTime;
    private bool isBullReLoad = false, isTrigerSleeve=true;
    private bool isRun = false;
    void Start()
    {
        if (shootSettings == null) { print($"Не установлен Settings в ShootPlayer"); NotActionClass = true; }
        if (NotActionClass) { return; }//Проверка разрешнения
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
        if (!isRun)//если общее разрешение на запуск false
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
            if (currentTime <= 2 && isTrigerSleeve)
            {
                ShootBulletSleeve();
                isTrigerSleeve=false;
            }
            if (currentTime <= 0)
            { 
                currentTime = defaultTime; isBullReLoad = false; isTrigerSleeve = true;
                return true; 
            }
            return false;
        }
        return true;
    }
    private void ShootActiv()
    {
        if (isRun && ReLoadBullet())
        {
            if (InputData.MouseLeftButton != 0)
            {
                ShootBullet();
                isBullReLoad =true;
            }
        }
    }
    public virtual void ShootBullet()
    {
        //
    }
    public virtual void ShootBulletSleeve()
    {
        //
    }
    private void FixedUpdate()
    {
        if (NotActionClass) { return; }//Проверка разрешнения

        if (shootSettings.IsUpDate)
        {
            GetSetting();
        }
        if (!isRun)//если общее разрешение на запуск false
        {
            GetIsRun();
            return;
        }
        ShootActiv();
    }
}
