using UnityEngine;
using static EventManager;

public class ParticleDead : MonoBehaviour
{
    //кэш
    [SerializeField] private ParticleSystem partDead;
    private int thisHash;
    private bool isPart = true;
    private bool isRun = false, isDead = false;
    void Start()
    {
        if (partDead == null) { print($"Не установлен ParticleSystem в ParticleDead"); }
        thisHash = this.gameObject.GetHashCode();
        partDead.Stop();
    }
    private void OnEnable()
    {
        isDead = false;
        OnIsDead += StopRun;
    }
    private void OnDisable()
    {
        OnIsDead -= StopRun;
    }
    private void StopRun(int _thisHash, bool _isDead)
    {
        if (thisHash == _thisHash) { isDead = _isDead; }
    }
    private void GetIsRun()
    {
        if (!isRun)//если общее разрешение на запуск false
        {
            if (partDead != null) { isRun = true; }
            else { isRun = false; print($"ParticleDead не получила Particle"); }
        }
    }
    private void PartDead(bool isActiv)
    {
        if (isActiv)
        {
            partDead.Play();
        }
        else
        {
            partDead.Stop();
        }
    }
    private void RunParticle()
    {
        if (isDead)
        {
            if (isPart == true)
            {
                PartDead(isPart);
                isPart = false;
            }
        }
        else
        {
            if (isPart == false)
            {
                isPart = true;
            }
        }
        
    }
    private void FixedUpdate()
    {

        if (!isRun)//если общее разрешение на запуск false
        {
            GetIsRun();
            return;
        }
        RunParticle();
    }
}
