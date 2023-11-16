using UnityEngine;
using static EventManager;

public class ParticleControllerShootPlayer : MonoBehaviour
{
    private bool NotActionClass = false;
    //кэш
    [SerializeField] private ParticleSystem partShoot;
    private bool isRun = false;

    private void OnEnable()
    {
        OnIsActivGunPlayerShoot += PartShoot;
        partShoot.Stop();
    }
    private void OnDisable()
    {
        OnIsActivGunPlayerShoot -= PartShoot;
    }

    void Start()
    {
        if (partShoot == null) { print($"Не установлен ParticleSystem в ParticleControllerShootPlayer"); NotActionClass = true; }
        if (NotActionClass) { return; }//Проверка разрешнения
    }

    private void GetIsRun()
    {
        if (!isRun)//если общее разрешение на запуск false
        {
            isRun = true;
            //
        }
    }
    private void PartShoot(bool isActiv)
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
        if (NotActionClass) { return; }//Проверка разрешнения

        if (!isRun)//если общее разрешение на запуск false
        {
            GetIsRun();
            return;
        }
        RunParticle();
    }
}
