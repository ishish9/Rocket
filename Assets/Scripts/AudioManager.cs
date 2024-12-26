using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] public AudioClips audioClips;
    [SerializeField] private AudioSource MusicSource, EffectsSource, EffectsSourceLooped;
    private float defaultPitch;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        defaultPitch = MusicSource.pitch;
       // MusicSource = GetComponentInChildren<AudioSource>();
        //EffectsSource = GetComponentInChildren<AudioSource>();

    }
    public void PlayMusic(AudioClip clip)
    {
        MusicSource.clip = clip;
        MusicSource.Play(0);
        MusicSource.loop = true;
    }

    public void PlaySound(AudioClip clip)
    {
        EffectsSource.PlayOneShot(clip);
    }

    public void PlaySoundLooped(AudioClip clip)
    {
        EffectsSourceLooped.PlayOneShot(clip);
    }

    public void PlaySoundLoopedStop()
    {
        EffectsSourceLooped.Stop();
    }

    public void PlaySoundDelayed(AudioClip clip, float delay)
    {
        EffectsSource.clip = clip;
        EffectsSource.PlayDelayed(delay);
    }

    public void MasterVolumeControl(float volumeLevel)
    {
        AudioListener.volume = volumeLevel;
    }

    public void ToggleMusic()
    {
        MusicSource.mute = !MusicSource.mute;
    }

    public void ToggleEffects()
    {
        EffectsSource.mute = !EffectsSource.mute;
    }

    public void MusicOn()
    {
        MusicSource.mute = false;
    }

    public void MusicOff()
    {
        MusicSource.mute = true;
    }

    public void ChangeMusicVolume(float volume)
    {
        MusicSource.volume = volume;
    }

    public void ChangeMusicPitch(float pitch)
    {        
        MusicSource.pitch = pitch;       
    }
}

