using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGateController : MonoBehaviour
{
    private float AudoDoorOpenDuringTime;

    [SerializeField]
    GameObject LeftDoor, RightDoor;

    [SerializeField]
    private ParticleSystem UpLeftDoorSpark, BottomLeftDoorSpark;

    [SerializeField]
    private AudioSource DoorOpenCloseAS;
    [SerializeField]
    private AudioSource WelcomeDoorOpenCloseAS;
    [SerializeField]
    private AudioSource LeftDoorStuckAS;

    float LeftDoorOriginal;
    float RightDoorOriginal;

    private bool isWelcome;
    // Start is called before the first frame update
    void Start()
    {
        isWelcome = false;
        AudoDoorOpenDuringTime = 1.8f;
           LeftDoorOriginal = LeftDoor.transform.localPosition.z;
        RightDoorOriginal = RightDoor.transform.localPosition.z;
        GameEvent.instance.OnAutoDoorTriggerEnterEvent += AutoDoolOpen;
        GameEvent.instance.OnAutoDoorTriggerExitEvent += AutoDoolClose;
    }

    private void AutoDoolOpen() {
        //if (!DoorOpenCloseAS.isPlaying)
        //{
        //    DoorOpenCloseAS.Play();
        //}
        StartCoroutine("AutoDoorOpenSounds");
        LeanTween.cancel(RightDoor);
        LeanTween.cancel(LeftDoor);
        LeanTween.moveLocalZ(RightDoor, -3.34f, AudoDoorOpenDuringTime);
        LeanTween.moveLocalZ(LeftDoor, 0.5f, AudoDoorOpenDuringTime / 4).setOnComplete(stuckDoor);

    }

    private void stuckDoor() {
        LeftDoorStuckAS.Play();
        if (!UpLeftDoorSpark.isPlaying) { 
            UpLeftDoorSpark.Play();
        }
        if (!BottomLeftDoorSpark.isPlaying)
        {
            BottomLeftDoorSpark.Play();
        }
        int a = 1;
        Debug.Log(a++);
        LeanTween.moveLocalZ(LeftDoor, 1f, AudoDoorOpenDuringTime / 6).setLoopPingPong();
        //LeanTween.moveLocalZ(LeftDoor, 1f, 1f / 4).setEasePunch().setLoopPingPong();
    }

    private void OnDestroy()
    {
        if (GameEvent.instance != null)
        {
            GameEvent.instance.OnAutoDoorTriggerEnterEvent -= AutoDoolOpen;
            GameEvent.instance.OnAutoDoorTriggerExitEvent -= AutoDoolClose;

        }
    }
    private void AutoDoolClose()
    {
        DoorOpenCloseAS.Play();
        LeanTween.cancel(RightDoor);
        LeanTween.cancel(LeftDoor);
        StopLeftDoorSpark();
        LeanTween.moveLocalZ(RightDoor, -1.433132f, AudoDoorOpenDuringTime);
        LeanTween.moveLocalZ(LeftDoor, LeftDoorOriginal, AudoDoorOpenDuringTime);

    }

    IEnumerator AutoDoorOpenSounds() {

        if (DoorOpenCloseAS.isPlaying)
        {
            DoorOpenCloseAS.Stop();
        }
        if (WelcomeDoorOpenCloseAS.isPlaying) {
            WelcomeDoorOpenCloseAS.Stop();
        }
        DoorOpenCloseAS.Play();
        yield return new WaitForSeconds(1.6f);
        if (!isWelcome)
        {
            isWelcome = true;
            WelcomeDoorOpenCloseAS.Play();
        }
    }

    private void StopLeftDoorSpark() {

        LeftDoorStuckAS.Stop();
        if (UpLeftDoorSpark.isPlaying)
        {
            UpLeftDoorSpark.Stop();
        }
        if (BottomLeftDoorSpark.isPlaying)
        {
            BottomLeftDoorSpark.Stop();
        }
    }

    public void PauseAllAudioSouces() {
        DoorOpenCloseAS.Pause();
        WelcomeDoorOpenCloseAS.Pause();
        LeftDoorStuckAS.Pause();
    }

    public void UnPauseAllAudioSouces()
    {
        DoorOpenCloseAS.UnPause();
        WelcomeDoorOpenCloseAS.UnPause();
        LeftDoorStuckAS.UnPause();
    }
}
