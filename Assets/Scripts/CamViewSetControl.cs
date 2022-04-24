using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamViewSetControl : MonoBehaviour
{
    [SerializeField]
    List<Material> tvMaterials;

    [SerializeField]
    private GameObject screenOB;

    [SerializeField]
    private AudioSource tvNoSingleAudio;

    [SerializeField]
    private Animator tvDisplayAnima;

    //[SerializeField]
    //private GameObject openingServerDoor;
    //private float originalDoorYAngle;
    [SerializeField]
    private GameObject openingServer;


    private int indexTvCam;

    private bool enoughClose;
    private bool startHook;
    private void Start()
    {
        startHook = false;
        //originalDoorYAngle = openingServerDoor.transform.eulerAngles.y;
        indexTvCam = 0;
        enoughClose = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Time.timeScale != 0 && enoughClose)
        {

            if (!startHook)
            {
                startHook = true;
                openingServer.GetComponent<ServerControl>().OpeningDoorHook();
                //openingServer.GetComponent<BoxCollider>().OpeningDoorHook();
            }
            indexTvCam++;
            if (indexTvCam == tvMaterials.Count)
            {
                indexTvCam = 0;
            }
            screenOB.GetComponent<MeshRenderer>().material = tvMaterials[indexTvCam];
            if (indexTvCam == 1)
            {
                tvNoSingleAudio.Stop();
                tvDisplayAnima.enabled = false;
            }
            else if (indexTvCam == 0)
            {
                tvDisplayAnima.enabled = true;

            }
        }

    }

    public void PlayTVNOSingleAudio()
    {
        tvNoSingleAudio.Play();
    }
    public void StopTVNOSingleAudio()
    {
        tvNoSingleAudio.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enoughClose = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enoughClose = false;
        }
    }

}
