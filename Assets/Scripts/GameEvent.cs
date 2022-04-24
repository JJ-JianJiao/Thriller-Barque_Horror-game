using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvent : MonoBehaviour
{
    public static GameEvent instance;

    void Awake() {
        instance = this;
    }

    private void Update()
    {
        
    }

    public event Action<DoorPlayerPos> OnDoorTriggerEnterEvent;
    public void OnDoorTriggerEnter(DoorPlayerPos para) {
        if (OnDoorTriggerEnterEvent != null) {
            OnDoorTriggerEnterEvent(para);
        }    
    }

    public event Action<int> OnEasyDoorTriggerEnterEvent;
    public void OnEasyDoorTriggerEnter(int id)
    {
        if (OnEasyDoorTriggerEnterEvent != null)
        {
            OnEasyDoorTriggerEnterEvent(id);
        }
    }

    public event Action<DoorPlayerPos> OnDoorTriggerExitEvent;
    public void OnDoorTriggerExit(DoorPlayerPos para)
    {
        if (OnDoorTriggerExitEvent != null)
        {
            OnDoorTriggerExitEvent(para);
        }
    }

    public event Action<int> OnEasyDoorTriggerExitEvent;
    public void OnEasyDoorTriggerExit(int id)
    {
        if (OnEasyDoorTriggerExitEvent != null)
        {
            OnEasyDoorTriggerExitEvent(id);
        }
    }

    public event Action OnAutoDoorTriggerEnterEvent;
    public void OnAutoDoorTriggerEnter()
    {
        if (OnDoorTriggerExitEvent != null)
        {
            OnAutoDoorTriggerEnterEvent();
        }
    }

    public event Action OnAutoDoorTriggerExitEvent;
    public void OnAutoDoorTriggerExit()
    {
        if (OnAutoDoorTriggerExitEvent != null)
        {
            OnAutoDoorTriggerExitEvent();
        }
    }
}
