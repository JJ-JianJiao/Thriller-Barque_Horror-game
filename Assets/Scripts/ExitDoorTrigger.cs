using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoorTrigger : MonoBehaviour
{
    public int id;
    public int isFront;
    public bool isExitTrigger;
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //TODO: call event;
            DoorPlayerPos doorPlayerPos = new DoorPlayerPos(id, isFront, isExitTrigger);
            GameEvent.instance.OnDoorTriggerExit(doorPlayerPos);
        }
    }
}
