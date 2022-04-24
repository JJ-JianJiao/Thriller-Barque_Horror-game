using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerControl : MonoBehaviour
{
    [SerializeField]
    private GameObject openingServerDoor;
    [SerializeField]
    private AudioSource openingServerDoorAudio;

    [SerializeField]
    private GameObject openingDoorTirggerGO;
    private float originalDoorYAngle;
    // Start is called before the first frame update
    void Start()
    {
        originalDoorYAngle = openingServerDoor.transform.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpeningDoorHook()
    {
        openingDoorTirggerGO.GetComponent<BoxCollider>().enabled = true;
        openingServerDoorAudio.Play();
        LeanTween.rotateY(openingServerDoor, originalDoorYAngle - 60f, 0.77f/3f).setLoopPingPong();
    }

    public void CloseOpeningDoorHook()
    {
        openingServerDoorAudio.Stop();
        LeanTween.cancel(openingServerDoor);
    }

}
