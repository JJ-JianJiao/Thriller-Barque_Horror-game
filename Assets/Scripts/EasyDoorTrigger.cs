using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyDoorTrigger : MonoBehaviour
{
    public int id;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //TODO: call event;
            GameEvent.instance.OnEasyDoorTriggerEnter(id);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //TODO: call event;
            GameEvent.instance.OnEasyDoorTriggerExit(id);
        }
    }
}
