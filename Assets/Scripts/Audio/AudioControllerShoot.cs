using UnityEngine;
using static EventBus;

public class AudioControllerShoot : MonoBehaviour
{
    [SerializeField] private AudioSetting audioSetting;
    [SerializeField] private AudioGunSetting audioGunSetting;
    public AudioGunSetting AudioGunSetting { get { return audioGunSetting; } set { value = audioGunSetting; } }

    private AudioSource audioSource;

    private int thisHash;
    private bool isRun = false, isDead = false;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioGunSetting.AudioClipGun;
        audioSource.volume = (audioSetting.EfectVol);
    }
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
    }
    public virtual void SetEventOnDisable()
    {
    }
    private void GetIsRun()
    {
        if (!isRun)
        {
            thisHash = this.gameObject.GetHashCode();
            if (thisHash != 0) { isRun = true; }
            else { isRun = false; }
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
    private void FixedUpdate()
    {
        if (isDead) { return; }

        if (!isRun)
        {
            GetIsRun();
            return;
        }
    }
}
