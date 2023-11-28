using UnityEngine;
using static EventManager;

public class ParticleControllerMoveEnemyTank : MonoBehaviour
{
    private bool NotActionClass = false;
    //���
    [SerializeField] private ParticleSystem partDinamic, partIdle;
    private Construction thisObject;
    private float currentVelocity;
    private bool isPartIdle = true;
    private bool isRun = false;
    void Start()
    {
        if (partDinamic == null & partIdle == null) { print($"�� ���������� ParticleSystem � ParticleDrive"); NotActionClass = true; }
        if (NotActionClass) { return; }//�������� �����������
    }

    private void GetIsRun()
    {
        if (!isRun)//���� ����� ���������� �� ������ false
        {
            if (partIdle != null) { isRun = true; }
            else if (partDinamic != null) { isRun = true; }
            else { isRun = false; print($"ParticleControllerPlayer �� �������� Particle"); }

            int hash = this.gameObject.GetHashCode();
            thisObject = GetObjectHash(hash);//�������� ������ �� �����
            if (thisObject.NavMeshAgent != null) { isRun = true; }
            else { isRun = false; print($"{gameObject.name} �� ������� LogicMoveEnemy"); }
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
        if (NotActionClass) { return; }//�������� �����������

        if (!isRun)//���� ����� ���������� �� ������ false
        {
            GetIsRun();
            return;
        }
        RunParticle();
    }
}
