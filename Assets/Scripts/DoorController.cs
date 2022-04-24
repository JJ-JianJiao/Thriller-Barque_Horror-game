using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPlayerPos{
    public int ID;
    public int isFront;
    public bool isExitTrigger;
    public DoorPlayerPos(int id, int isfront, bool exit) {
        this.ID = id;
        this.isFront = isfront;
        this.isExitTrigger = exit;
    }
}

public class DoorController : MonoBehaviour
{
    public int id;

    public float doorOpenTime = 2f;
    public float doorOpenAngle = 120f;
    public float doorCloseAngle = 0f;

    public bool isClosed;

    private float yOrignalAngle;
    void Start()
    {
        isClosed = true;
        yOrignalAngle = transform.eulerAngles.y;
        GameEvent.instance.OnDoorTriggerEnterEvent += DoorOpen;
        GameEvent.instance.OnDoorTriggerExitEvent += DoorClose;
    }


    private void DoorOpen(DoorPlayerPos para)
    {
        if (para.ID == this.id && para.isFront == 1 && isClosed)
        {
            isClosed = false;
            Debug.Log("Call DoorOpen from front trigger");
            LeanTween.cancel(gameObject);
            float angle = yOrignalAngle + doorOpenAngle;
            PlayerSoundsManager.instance.WoodDoorSqueaking(doorOpenTime / 2f);
            //LeanTween.rotateY(gameObject, doorOpenAngle, doorOpenTime).setEaseOutQuad();
            LeanTween.rotateY(gameObject, angle, doorOpenTime).setEaseOutQuad();
        }
        else if(para.ID == this.id && para.isFront == -1&& isClosed)
        {
            isClosed = false;
            Debug.Log("Call DoorOpen from front trigger");
            LeanTween.cancel(gameObject);
            float angle = yOrignalAngle - doorOpenAngle;
            PlayerSoundsManager.instance.WoodDoorSqueaking(doorOpenTime / 2f);
            //LeanTween.rotateY(gameObject, doorOpenAngle, doorOpenTime).setEaseOutQuad();
            LeanTween.rotateY(gameObject, angle, doorOpenTime).setEaseOutQuad();
        }
    }
    private void DoorClose(DoorPlayerPos para)
    {
        if (para.ID == this.id && para.isFront ==0 && !isClosed)
        {
            isClosed = true;
            Debug.Log("Call DoorClose");
            LeanTween.cancel(gameObject);
            float angle = yOrignalAngle + doorCloseAngle;
            PlayerSoundsManager.instance.WoodDoorSqueaking(doorOpenTime / 2f);
            //LeanTween.rotateY(gameObject, 0.1f, doorOpenTime / 2f).setEaseInQuad();
            LeanTween.rotateY(gameObject, angle, doorOpenTime / 2f).setEaseInQuad().setOnComplete(PlayCloseDoorSound) ;
        }
        //else if (para.ID == this.id && para.isFront ==0)
        //{
        //    Debug.Log("Call DoorOpen from front trigger");
        //    LeanTween.cancel(gameObject);
        //    float angle = yOrignalAngle - doorCloseAngle;
        //    //LeanTween.rotateY(gameObject, doorOpenAngle, doorOpenTime).setEaseOutQuad();
        //    LeanTween.rotateY(gameObject, angle, doorOpenTime).setEaseOutQuad();
        //}
    }

    private void OnDestroy()
    {
        if (GameEvent.instance != null)
        {
            GameEvent.instance.OnDoorTriggerEnterEvent -= DoorOpen;
            GameEvent.instance.OnDoorTriggerExitEvent -= DoorClose;
        }
    }
    private void PlayCloseDoorSound()
    {

        PlayerSoundsManager.instance.WoodDoorClose();
    }
}
