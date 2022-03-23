using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    static bool initialized = false;
    static AudioSource audioSource;
    static Dictionary<AudioClipName, AudioClip> audioClips = new Dictionary<AudioClipName, AudioClip>();

    public static bool isInitialized
    {
        get { return initialized; }
    }

    public static void Initialization(AudioSource source)
    {
        initialized = true;
        audioSource = source;

        audioClips.Add(AudioClipName.ArrowShoot, Resources.Load<AudioClip>("ArrowShoot"));
        audioClips.Add(AudioClipName.ArrowImpactEnemy, Resources.Load<AudioClip>("ArrowImpactEnemy"));
        audioClips.Add(AudioClipName.ArrowImpactGround, Resources.Load<AudioClip>("ArrowImpactGround"));
        audioClips.Add(AudioClipName.CrateBlast, Resources.Load<AudioClip>("CrateBlast"));
        audioClips.Add(AudioClipName.ChestBlast, Resources.Load<AudioClip>("ChestBlast"));
        audioClips.Add(AudioClipName.SpecialArrowShoot, Resources.Load<AudioClip>("SpecialArrowShoot"));
        audioClips.Add(AudioClipName.SpecialArrowImpact, Resources.Load<AudioClip>("SpecialArrowImpact"));
        audioClips.Add(AudioClipName.KeyCollect, Resources.Load<AudioClip>("KeyCollect"));
        audioClips.Add(AudioClipName.PearlCollect, Resources.Load<AudioClip>("PearlCollect"));
        audioClips.Add(AudioClipName.MapCollect, Resources.Load<AudioClip>("MapCollect"));
        audioClips.Add(AudioClipName.ZombieDie, Resources.Load<AudioClip>("ZombieDie"));
        audioClips.Add(AudioClipName.ZombieHeadWakeUp, Resources.Load<AudioClip>("ZombieHeadWakeUp"));
        audioClips.Add(AudioClipName.BatMovement, Resources.Load<AudioClip>("BatMovement"));
        audioClips.Add(AudioClipName.PlayerPain, Resources.Load<AudioClip>("PlayerPain"));
        audioClips.Add(AudioClipName.PlayerDie, Resources.Load<AudioClip>("PlayerDie"));
        audioClips.Add(AudioClipName.PlayerJump, Resources.Load<AudioClip>("PlayerJump"));
        audioClips.Add(AudioClipName.ShopSound, Resources.Load<AudioClip>("ShopSound"));
        audioClips.Add(AudioClipName.HealthPickup, Resources.Load<AudioClip>("HealthPickup"));
        audioClips.Add(AudioClipName.PowerPickup, Resources.Load<AudioClip>("PowerPickup"));
        audioClips.Add(AudioClipName.WinMusic, Resources.Load<AudioClip>("WinMusic"));
        audioClips.Add(AudioClipName.ClickSound, Resources.Load<AudioClip>("ClickSound"));
    }
    
    public static void PlayAudio(AudioClipName name)
    {
        if(name==null)
        {
            Debug.Log("HI");
            return;
        }
        audioSource.PlayOneShot(audioClips[name]);
    }
}
