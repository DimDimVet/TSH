using UnityEngine;
using static EventManager;

public class ParticleControllerMoveEnemyTank : MonoBehaviour
{
    private bool NotActionClass = false;
    //кэш
    [SerializeField] private ParticleSystem partDinamic, partIdle;
    private Construction thisObject;
    private float currentVelocity;
    private bool isPartIdle = true;
    private bool isRun = false;
    void Start()
    {
        if (partDinamic == null & partIdle == null) { print($"Не установлен ParticleSystem в ParticleDrive"); NotActionClass = true; }
        if (NotActionClass) { return; }//Проверка разрешнения
    }

    private void GetIsRun()
    {
        if (!isRun)//если общее разрешение на запуск false
        {
            if (partIdle != null) { isRun = true; }
            else if (partDinamic != null) { isRun = true; }
            else { isRun = false; print($"ParticleControllerPlayer не получила Particle"); }

            int hash = this.gameObject.GetHashCode();
            thisObject = GetObjectHash(hash);//получаем данные из листа
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
        if (NotActionClass) { return; }//Проверка разрешнения

        if (!isRun)//если общее разрешение на запуск false
        {
            GetIsRun();
            return;
        }
        RunParticle();
    }
}
