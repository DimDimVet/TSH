using Unity.Mathematics;
using UnityEngine;

public class ParticleControllerMovePlayer : GetInputPlayer
{
    private bool NotActionClass = false;
    //���
    [SerializeField] private ParticleSystem partDinamic, partIdle;
    private float refDistance = 0.01f;
    private float2 distans;
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
        distans.x = Mathf.Abs(InputData.Move.x);
        distans.y = Mathf.Abs(InputData.Move.y);
        if (distans.x >= refDistance || distans.y >= refDistance)
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

