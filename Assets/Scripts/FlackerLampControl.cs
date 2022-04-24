using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlackerLampControl : MonoBehaviour
{
    [SerializeField]
    private Animator flackerLampAnim;


    float timestamp = 0;
    float timeLoopRate = 12.0f;


    [SerializeField]
    private AudioSource lampAudio;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timestamp + timeLoopRate) {
            int ram = Random.Range(0, 50) % 6;
            if (ram == 3)
            {
                lampAudio.Play();
                flackerLampAnim.SetTrigger("flicker1");
            }
            else if (ram == 1 || ram == 4)
            {
                lampAudio.Play();
                flackerLampAnim.SetTrigger("flicker2");
            }
            timestamp = Time.time;
        }
    }

    public void TurnToIdle() {
        lampAudio.Stop();
        flackerLampAnim.SetTrigger("finish");

    }
}
