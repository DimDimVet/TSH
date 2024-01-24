using UnityEngine;
using static EventBus;

public class ParticleControllerShoot : MonoBehaviour
{
    //кэш
    [SerializeField] private ParticleSystem partShoot;
    public ParticleSystem PartSht { get { return partShoot; } set { value = partShoot; } }

    private int thisHash;
    private bool isRun = false, isDead = false;

    private void OnEnable()
    {
        SetEventOnEneble();
        OnIsDead += StopRun;
    }
    private void OnDisable()
    {
        SetEventOnDisable();
        OnIsDead -= StopRun;
    }
    private void StopRun(int _thisHash, bool _isDead, int costObject)
    {
        if (thisHash == _thisHash) { isDead = _isDead; }
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

    private void GetIsRun()
    {
        if (!isRun)
        {
            thisHash = this.gameObject.GetHashCode();
            if (thisHash != 0) { isRun = true; }
            else { print($"ParticleSystem не установлен ParticleControllerShootPlayer"); isRun = false; }
        }
    }
    public void PartShoot(int _thisHash, bool isActiv)
    {
        if (isActiv && thisHash == _thisHash)
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
        if (isDead) { return; }

        if (!isRun)
        {
            GetIsRun();
            return;
        }
        RunParticle();
    }
}
