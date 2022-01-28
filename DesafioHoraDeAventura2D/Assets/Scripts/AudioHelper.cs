using UnityEngine.Audio;
using UnityEngine;

public class AudioHelper : MonoBehaviour
{

public static AudioHelper instance;
[Header("lista de sons de efeito")]
[SerializeField] private AudioClip[] audios;

[Header("radio")]
public bool TurnOnRadio = false;

[Header("Lista de musicas")]
[SerializeField] private AudioClip[] musics;
private int musicCount = 0;

[Header("Audio sources")]
[SerializeField] private AudioSource audioSourceSFX;
[SerializeField] private AudioSource audioSourceMusic;


private void Awake() {
    if(!instance)
    {
        instance = this;
    }
    else
    {
        Destroy(gameObject);
    }
    DontDestroyOnLoad(this.gameObject);
}

    public void PlayAudio(string audioName)
    {
        audioSourceSFX.Stop();
        audioSourceSFX.clip = SearchAudio(audioName,audios);
        audioSourceSFX.Play();
    }

    public void PlayMusic(string musicName)
    {
        audioSourceMusic.clip = SearchAudio(musicName,musics);
        audioSourceMusic.Play();
    }

    public void PauseMusic()
    {
        audioSourceMusic.Pause();
        
    }

    private void Update() 
    {
        verifyMusicState();

    }
    private void verifyMusicState()
    {
        if(!audioSourceMusic.isPlaying && TurnOnRadio)
        {
            NextMusic();
        }
        if(!TurnOnRadio)
        {
            audioSourceMusic.Stop();
        }

    }
    private void NextMusic()
    {
        if(musicCount >= musics.Length)
        {
            musicCount = 0;
        }
        audioSourceMusic.clip = musics[musicCount];
        audioSourceMusic.Play();
        musicCount ++;
    }
    public void UnPauseMusic()
    {
        audioSourceMusic.UnPause();

    }

    private AudioClip SearchAudio(string audioName, AudioClip[] audioClip)
    {
        for(int i = 0; i< audioClip.Length; i++)
        {
          if(audioName == audioClip[i].name)
          {
              return audioClip[i];
          }
        }
        return null;
    }

}
