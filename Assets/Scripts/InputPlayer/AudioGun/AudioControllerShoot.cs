using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;
using static UnityEngine.PlayerLoop.PostLateUpdate;

public class AudioControllerShoot : MonoBehaviour
{
    //кэш
    [SerializeField] private AudioSetting audioSetting;
    [SerializeField] private AudioGunSetting audioGunSetting;
    public AudioGunSetting AudioGunSetting { get { return audioGunSetting; } set { value = audioGunSetting; } }

    private AudioSource audioSource;

    private int thisHash;
    private bool isRun = false, isDead = false;

    private void OnEnable()
    {
        SetEventOnEneble();
        OnIsDead += StopRun;
        OnUpDateAudioParametr += UpDateAudio;
    }
    private void OnDisable()
    {
        SetEventOnDisable();
        OnIsDead -= StopRun;
        OnUpDateAudioParametr -= UpDateAudio;
    }
    private void UpDateAudio()
    {
        audioSource.volume = (audioSetting.EfectVol);
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
    public void AudioShoot(int _thisHash, bool isActiv)
    {
        if (isActiv && thisHash == _thisHash)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
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
