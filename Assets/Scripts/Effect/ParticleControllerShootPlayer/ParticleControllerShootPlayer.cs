using UnityEngine;
using static EventManager;

public class ParticleControllerShootPlayer : MonoBehaviour
{
    private bool NotActionClass = false;
    //���
    [SerializeField] private ParticleSystem partShoot;
    public ParticleSystem PartSht{get{return partShoot;}set{value=partShoot;}}
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
        if (partShoot == null) { print($"�� ���������� ParticleSystem � ParticleControllerShootPlayer"); NotActionClass = true; }
        if (NotActionClass) { return; }//�������� �����������
    }

    private void GetIsRun()
    {
        if (!isRun)//���� ����� ���������� �� ������ false
        {
            isRun = true;
            //
        }
    }
    public void PartShoot(bool isActiv)
    {
        if (isActiv)
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
        if (NotActionClass) { return; }//�������� �����������

        if (!isRun)//���� ����� ���������� �� ������ false
        {
            GetIsRun();
            return;
        }
        RunParticle();
    }
}
