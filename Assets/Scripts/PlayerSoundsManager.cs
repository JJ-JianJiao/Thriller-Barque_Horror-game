using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerSoundsManager : MonoBehaviour
{
    public static PlayerSoundsManager instance;

    [SerializeField]
    private AudioClip run, jump, fall;

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioSource BGM;

    [SerializeField]
    private AudioSource woodDoorAudio;
    [SerializeField]
    private List<AudioClip> woodDoorClips;

    [SerializeField]
    private GameObject AutoGate;

    [SerializeField]
    private AudioSource flackerLampAS;
    [SerializeField]
    private AudioSource NoSingalTVAS;
    [SerializeField]
    private AudioSource ServerDoorTVAS;
    [SerializeField]
    private AudioSource ServerGhost;

    private void Start()
    {
        instance = this;
        if (AudioListener.pause == true)
        {
            AudioListener.pause = false;
        }
    }

    public void Run()
    {
        audioSource.clip = run;
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void Jump() {
        audioSource.clip = jump;
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void Fall()
    {
        audioSource.clip = fall;
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void PlayBGM() {
        if (BGM.isPlaying == false)
        {
            BGM.Play();
        }
    }

    public bool IsBGMPlaying() {
        return BGM.isPlaying;
    }

    public void WoodDoorSqueaking(float time) {

        woodDoorAudio.clip = woodDoorClips[0];
        if (time < 0)
        {
            woodDoorAudio.pitch = 1;
        }
        else {
            woodDoorAudio.pitch = 8.5f / time;
        }
        woodDoorAudio.Play();
    }

    public void WoodDoorClose()
    {
        woodDoorAudio.pitch = 1;
        woodDoorAudio.clip = woodDoorClips[1];
        woodDoorAudio.Play();
    }
    public void PauseAudioSources_Listener()
    {
        AudioListener.pause = true;
    }

    public void UnPauseAudioSources_Listener() {
        AudioListener.pause = false;
    }

    public void PauseAudioSources() {

        if (flackerLampAS.isPlaying) {
            flackerLampAS.Pause();
        }
        if (NoSingalTVAS.isPlaying)
        {
            NoSingalTVAS.Pause();
        }
        if (ServerDoorTVAS.isPlaying)
        {
            ServerDoorTVAS.Pause();
        }
        if (ServerGhost.isPlaying)
        {
            ServerGhost.Pause();
        }

        AutoGate.GetComponent<AutoGateController>().PauseAllAudioSouces();

        audioSource.Pause();
        //audioSource.Stop();
        Debug.Log("Pause audioSource: " + audioSource.isPlaying);
        BGM.Pause();
        //BGM.Stop();
        Debug.Log("Pause BGM: " + BGM.isPlaying);
        woodDoorAudio.Pause();
        //woodDoorAudio.Stop();
        Debug.Log("Pause woodDoorAudio: " + woodDoorAudio.isPlaying);

    }

    public void UnPauseAudioSources() {

        flackerLampAS.Pause();
        NoSingalTVAS.Pause();
        ServerDoorTVAS.Pause();
        ServerGhost.Pause();

        AutoGate.GetComponent<AutoGateController>().UnPauseAllAudioSouces();

        audioSource.UnPause();
        Debug.Log("UnPause audioSource: " + audioSource.isPlaying);
        BGM.UnPause();
        Debug.Log("UnPause BGM: " + BGM.isPlaying);
        woodDoorAudio.UnPause();
        Debug.Log("UnPause woodDoorAudio: " + woodDoorAudio.isPlaying);
    }

}
