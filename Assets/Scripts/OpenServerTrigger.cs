using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenServerTrigger : MonoBehaviour
{
    //[SerializeField]
    //private ParticleSystem openingDoorPS1, openingDoorPS2, openingDoorPS3, openingDoorPS4;
    [SerializeField]
    private List<ParticleSystem> openingDoorPSs;

    [SerializeField]
    private GameObject ServerGhostGB;

    [SerializeField]
    private GameObject openingDoorServer;

    [SerializeField]
    private Transform playerTransform;

    private bool hooked;
    private void Start()
    {
        hooked = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hooked) {
            hooked = true;
            //TODO: ParticalSystem, and ghost
            Debug.Log("I see you player!");
            PlayParticleSystemList();
            StartCoroutine("GhostShowTime");
        }
    }

    void PlayParticleSystemList() {
        foreach (var ps in openingDoorPSs)
        {
            ps.Play();
        }
    }

    IEnumerator GhostShowTime() {
        yield return new WaitForSeconds(3f);
        ServerGhostGB.SetActive(true);
        StopParticleSystemList();
        openingDoorServer.GetComponent<ServerControl>().CloseOpeningDoorHook();
        ServerGhostGB.transform.LookAt(new Vector3(playerTransform.position.x, ServerGhostGB.transform.position.y, playerTransform.position.z));
        LeanTween.moveLocalZ(ServerGhostGB, 29f, 3f).setOnComplete(MoveToPlayer);
    }

    void StopParticleSystemList()
    {
        foreach (var ps in openingDoorPSs)
        {
            ps.Clear();
            ps.Stop();
        }
    }

    void MoveToPlayer() {
        if (Vector3.Distance(ServerGhostGB.transform.position, playerTransform.position) < 1.5f)
        {
            ServerGhostGB.GetComponent<AudioSource>().Stop();
            return;
        }
        ServerGhostGB.GetComponent<AudioSource>().Play();
        //ServerGhostGB.transform.LookAt(playerTransform,);
        ServerGhostGB.transform.LookAt(new Vector3(playerTransform.position.x, ServerGhostGB.transform.position.y, playerTransform.position.z));
        //LeanTween.move(ServerGhostGB, playerTransform, 2f).setOnComplete(MoveToPlayer);
        LeanTween.move(ServerGhostGB, new Vector3(playerTransform.position.x, ServerGhostGB.transform.position.y, playerTransform.position.z), 2f).setOnComplete(MoveToPlayer);
    }

}
