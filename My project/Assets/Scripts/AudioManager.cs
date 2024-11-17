using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [Header("#BGM")]
    public AudioClip bgmClip;
    public float bgmVolume;
    AudioSource bgmPlayer;
    public Slider bgmSlider;

    [Header("#SFX")]
    public AudioClip[] sfxClips;
    public float sfxVolume;
    public int channels;
    AudioSource[] sfxPlayers;
    int channelIndex;
    public Slider sfxSlider;


    public enum Sfx {Click }

    private void Awake()
    {

        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        Init();
    }
   
   
    void Init()
    {
        // 배경음 플레이어 초기화
        GameObject bgmobject = new GameObject("BgmPlayer");
        bgmobject.transform.parent = transform;
        bgmPlayer = bgmobject.AddComponent<AudioSource>();
        bgmPlayer.playOnAwake = false;
        bgmPlayer.loop = true;
        bgmPlayer.volume= bgmVolume;
        bgmPlayer.clip = bgmClip;

        // 효과음 플레이어 초기화
        GameObject sfxobject = new GameObject("SfxPlayer");
        sfxobject.transform.parent = transform;
        sfxPlayers=new AudioSource[channels]; // 오디오 소스를 담을 배열만 초기화 

        for(int index=0; index<sfxPlayers.Length; index++)
        {
            sfxPlayers[index] = sfxobject.AddComponent<AudioSource>();
            sfxPlayers[index].playOnAwake=false;
            sfxPlayers[index].volume = sfxVolume;
        }
    }

    public void PlayBgm(bool isplay)
    {
        if (isplay)
        {
            bgmPlayer.Play();
        }
        else
        {
            bgmPlayer.Stop();
        }
    }

    public void PlaySfx(Sfx sfx)
    {
        for(int index=0; index<sfxPlayers.Length; index++)
        {
            int loopIndex=(index + channelIndex) % sfxPlayers.Length;

            if (sfxPlayers[loopIndex].isPlaying) 
               continue;

            channelIndex = loopIndex;
            sfxPlayers[loopIndex].clip = sfxClips[(int)sfx];
            sfxPlayers[loopIndex].Play();
            break;
        }
       
    }


}
