using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGateEnterTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //TODO: call event;
            GameEvent.instance.OnAutoDoorTriggerEnter();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //TODO: call event;
            GameEvent.instance.OnAutoDoorTriggerExit();
        }


    }
}
