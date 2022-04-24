using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUIController : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;

    public bool timeStop;

    private void Start()
    {
        timeStop = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)  && !pausePanel.GetComponent<PauseMenu>().fullyOpen) {
            pausePanel.SetActive(true);
            //timeStop = true;

            PauseIsOn();
        }
        else if (Input.GetKeyDown(KeyCode.Escape)  && pausePanel.GetComponent<PauseMenu>().fullyOpen) {
            //TODO:here may can use broadcast
            //if (pausePanel.gameObject.activeSelf)
            //if (pausePanel.GetComponent<PauseMenu>().fullyOpen)
            //{
            //    BroadcastMessage("CancelPauseMenu");
            //    timeStop = false;
            //}
            BroadcastMessage("CancelPauseMenu");
            //timeStop = false;
            Debug.Log("Want to close the pause pannel");
        }
    }

    private void PauseIsOn()
    {
        //PlayerSoundsManager.instance.PauseAudioSources();
        PlayerSoundsManager.instance.PauseAudioSources_Listener();
        Time.timeScale = 0;
    }
}
