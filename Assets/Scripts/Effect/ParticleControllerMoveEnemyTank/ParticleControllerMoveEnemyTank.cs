using UnityEngine;
using static EventManager;

public class ParticleControllerMoveEnemyTank : MonoBehaviour
{
    //кэш
    [SerializeField] private ParticleSystem partDinamic, partIdle;
    private Construction thisObject;
    private int thisHash;
    private float currentVelocity;
    private bool isPartIdle = true;
    private bool isRun = false, isDead = false;
    void Start()
    {
        if (partDinamic == null & partIdle == null) { print($"Ќе установлен ParticleSystem в ParticleDrive"); }
        thisHash=this.gameObject.GetHashCode();
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
    private void StopRun(int _thisHash, bool _isDead, int costObject)
    {
        if (thisHash == _thisHash) { isDead = _isDead; }
        partDinamic.Stop();
        partIdle.Stop();
    }
    private void GetIsRun()
    {
        if (!isRun)//если общее разрешение на запуск false
        {
            if (partIdle != null) { isRun = true; }
            else if (partDinamic != null) { isRun = true; }
            else { isRun = false; print($"ParticleControllerPlayer не получила Particle"); }

            thisHash = this.gameObject.GetHashCode();
            thisObject = GetObjectHash(thisHash);//получаем данные из листа
            if (thisObject.NavMeshAgent != null) { isRun = true; }
            else { isRun = false; print($"{gameObject.name} не получил LogicMoveEnemy"); }
        }
    }
    private void PartIdle(bool isActiv)
    {
        if (isActiv)
        {
            partIdle.Play();
        }
        else
        {
            partIdle.Stop();
        }
    }
    private void PartDinamic(bool isActiv)
    {
        if (isActiv)
        {
            partDinamic.Stop();
        }
        else
        {
            partDinamic.Play();
        }
    }
    private void RunParticle()
    {
        currentVelocity = Mathf.Abs(thisObject.NavMeshAgent.velocity.magnitude);
        if (currentVelocity > 0.1f)
        {
            if (isPartIdle == false)
            {
                PartIdle(isPartIdle);
                PartDinamic(isPartIdle);
                isPartIdle = true;
            }
        }
        else
        {
            if (isPartIdle == true)
            {
                PartIdle(isPartIdle);
                PartDinamic(isPartIdle);
                isPartIdle = false;
            }
        }
    }
    private void FixedUpdate()
    {
        if (isDead) { return; }

        if (!isRun)//если общее разрешение на запуск false
        {
            GetIsRun();
            return;
        }
        RunParticle();
    }
}
