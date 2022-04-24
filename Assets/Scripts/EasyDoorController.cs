using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyDoorController : MonoBehaviour
{
    public int id;
    public float doorOpenTime = 8.5f;
    public float doorOpenAngle = 160f;
    public float doorCloseAngle = 0f;
    private float yOrignalAngle;

    void Start()
    {
        yOrignalAngle = transform.eulerAngles.y;
        GameEvent.instance.OnEasyDoorTriggerEnterEvent += EasyDoorOpen;
        GameEvent.instance.OnEasyDoorTriggerExitEvent += EasyDoorClose;
    }

    private void EasyDoorOpen(int id)
    {
        if (this.id == id) {
            LeanTween.cancel(gameObject);
            float angle = yOrignalAngle + doorOpenAngle;
            PlayerSoundsManager.instance.WoodDoorSqueaking(2f);
            LeanTween.rotateY(gameObject, angle, doorOpenTime).setEaseOutQuad();
        }
    }

    private void EasyDoorClose(int id)
    {
        if (this.id == id)
        {
            LeanTween.cancel(gameObject);
            float angle = yOrignalAngle + doorCloseAngle;
            PlayerSoundsManager.instance.WoodDoorSqueaking(doorOpenTime / 2f);
            LeanTween.rotateY(gameObject, angle, doorOpenTime / 2f).setEaseInQuad().setOnComplete(PlayCloseDoorSound);
        }
    }

    private void PlayCloseDoorSound() {

        PlayerSoundsManager.instance.WoodDoorClose();
    }
}
