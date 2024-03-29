using UnityEngine;

public class Shoot : GetInputPlayer
{
    [SerializeField] private ShootSettings shootSettings;
    public bool IsClipReLoad { get { return isClipReLoad; } }
    public int CurrentCountClip { get { return currentCountClip; } set { currentCountClip = value; } }
    private float currentTime, defaultTime, currentTimeClip, defaultTimeClip;
    private int maxCountClip, currentCountClip;
    private bool isBullReLoad = false, isClipReLoad = false, isTrigerSleeve = true, isInputPlayer, isScriptAction = false;
    public bool IsScriptAction { get { return isScriptAction; } set { isScriptAction = value; } }
    private bool isRun = false;

    void Start()
    {
        if (shootSettings == null) { print($"�� ���������� Settings � ShootPlayer"); }
        GetSetting();
        Set();
    }
    public virtual void Set()
    {
    }
    private void GetSetting()
    {
        currentTime = shootSettings.CurrentTime;
        defaultTime = currentTime;

        maxCountClip = shootSettings.MaxCountClip;
        currentCountClip = maxCountClip;
        if (maxCountClip == 1)
        {
            currentTimeClip = defaultTime;
            defaultTimeClip = currentTimeClip;
        }
        else
        {
            currentTimeClip = shootSettings.CurrentTimeClip;
            defaultTimeClip = currentTimeClip;
        }

        isInputPlayer = shootSettings.IsInputPlayer;
        shootSettings.IsUpDate = false;
    }
    private void GetIsRun()
    {
        if (!isRun)
        {
            if (ThisHash != 0) { isRun = true; }
            else { ThisHash = this.gameObject.GetHashCode(); }
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
    private bool ReLoadClip()
    {
        if (currentCountClip <= 0)
        {
            currentTimeClip -= Time.deltaTime;
            if (currentTimeClip <= 0)
            {
                currentTimeClip = defaultTimeClip; isClipReLoad = false; currentCountClip = maxCountClip;
                return true;
            }
            isClipReLoad = true;
            return false;
        }
        return true;
    }
    private void ShootActiv()
    {
        if (isRun & ReLoadBullet() & ReLoadClip())
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
    }
    public virtual void ShootBulletSleeve()
    {
    }
    private void FixedUpdate()
    {
        if (IsDead) { return; }

        if (shootSettings.IsUpDate)
        {
            GetSetting();
        }
        if (!isRun)
        {
            GetIsRun();
            return;
        }
        ShootActiv();
    }
}
