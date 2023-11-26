using UnityEngine;

public class ParticleControllerShoot : MonoBehaviour
{
    private bool NotActionClass = false;
    //кэш
    [SerializeField] private ParticleSystem partShoot;
    public ParticleSystem PartSht { get { return partShoot; } set { value = partShoot; } }

    private int _thisHash;
    private bool isRun = false;

    private void OnEnable()
    {
        SetEventOnEneble();
    }
    private void OnDisable()
    {
        SetEventOnDisable();
    }
    public virtual void SetEventOnEneble()
    {
        //OnIsActivGunPlayerShoot += PartShoot;
        //partShoot.Stop();
    }
    public virtual void SetEventOnDisable()
    {
        //OnIsActivGunPlayerShoot -= PartShoot;
    }
    void Start()
    {
        if (partShoot == null) { print($"ParticleSystem не установлен ParticleControllerShootPlayer"); NotActionClass = true; }
        if (NotActionClass) { return; }
    }

    private void GetIsRun()
    {
        if (!isRun)
        {
            _thisHash = this.gameObject.GetHashCode();
            if (_thisHash != 0) { isRun = true; }
        }
    }
    public void PartShoot(int thisHash, bool isActiv)
    {
        if (isActiv && _thisHash == thisHash)
        {
            partShoot.Play();
        }
        else
        {
            partShoot.Stop();
        }
    }
    private void RunParticle()
    {

    }
    private void FixedUpdate()
    {
        if (NotActionClass) { return; }

        if (!isRun)
        {
            GetIsRun();
            return;
        }
        RunParticle();
    }
}
