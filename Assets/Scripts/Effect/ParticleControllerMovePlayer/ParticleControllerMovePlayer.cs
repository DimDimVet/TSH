using Unity.Mathematics;
using UnityEngine;

public class ParticleControllerMovePlayer : GetInputPlayer
{
    [SerializeField] private ParticleSystem partDinamic, partIdle;
    private float refDistance = 0.01f;
    private float2 distans;
    private bool isPartIdle = true;
    private bool isRun = false;
    private void GetIsRun()
    {
        if (!isRun)
        {
            if (partIdle != null) { isRun = true; }
            else if (partDinamic != null) { isRun = true; }
            else { isRun = false; print($"ParticleControllerPlayer не получила Particle"); }
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
        if (IsDead) { return; }

        if (!isRun)
        {
            GetIsRun();
            return;
        }
        RunParticle();
    }
}

