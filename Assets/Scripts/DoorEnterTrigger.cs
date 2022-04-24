using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEnterTrigger : MonoBehaviour
{
    public int id;
    public int isFront;
    public bool isExitTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            //TODO: call event;
            DoorPlayerPos doorPlayerPos = new DoorPlayerPos(id, isFront, isExitTrigger);
            GameEvent.instance.OnDoorTriggerEnter(doorPlayerPos);
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        //TODO: call event;
    //        DoorPlayerPos doorPlayerPos = new DoorPlayerPos(id, isFront);
    //        GameEvent.instance.OnDoorTriggerExit(doorPlayerPos);
    //    }
    //}
}
