using UnityEngine;

public class Shoot : GetInputPlayer
{
    [SerializeField] private ShootSettings shootSettings;
    private bool NotActionClass = false;
    //���
    private int thisHash;
    public int ThisHash { get { return thisHash; } }
    private float currentTime, defaultTime;
    private bool isBullReLoad = false, isTrigerSleeve = true, isInputPlayer,isScriptAction=false;
    public bool IsScriptAction { get { return isScriptAction; } set { isScriptAction = value; } }
    private bool isRun = false;
    void Start()
    {
        if (shootSettings == null) { print($"�� ���������� Settings � ShootPlayer"); NotActionClass = true; }
        if (NotActionClass) { return; }//�������� �����������
        GetIsRun();
        GetSetting();
        Set();
    }
    public virtual void Set()
    {
        //
    }
    private void GetSetting()
    {
        currentTime = shootSettings.CurrentTime;
        defaultTime = currentTime;
        isInputPlayer = shootSettings.IsInputPlayer;
        shootSettings.IsUpDate = false;
    }
    private void GetIsRun()
    {
        if (!isRun)//���� ����� ���������� �� ������ false
        {
            if (thisHash != 0) { isRun = true;  }
            else { thisHash = this.gameObject.GetHashCode(); }
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
                isTrigerSleeve = false;
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
            if (isInputPlayer)
            {
                if (InputData.MouseLeftButton != 0)
                {
                    ShootBullet();
                    isBullReLoad = true;
                }
            }
            else
            {
                if (isScriptAction)
                {
                    ShootBullet();
                    isBullReLoad = true;
                }
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
        ShootActiv();
    }
}
