using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableAudioClips", menuName = "Scriptable Object: AudioClips")]

public class AudioClips : ScriptableObject
{
    [Header("Music")]
    public AudioClip MainMusic;  

    [Header("AudioClips For Rocket")]
    public AudioClip Booster;
    public AudioClip Thruster1;
    public AudioClip Thruster2;


    [Header("Collectable Sounds")]
    public AudioClip FuelCollect; 

    [Header("Misc")]
    public AudioClip GameOver;
    public AudioClip RespawnSound;
    public AudioClip UIClick;
}
