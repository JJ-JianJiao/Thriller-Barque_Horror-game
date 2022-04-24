using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostOneMovement : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GhostMove();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GhostMove() {
        float randomTime = Random.Range(6.0f, 10f);
        //LeanTween.moveLocalZ(gameObject, 45f, 10f).setOnComplete(GhostTurnFace).setLoopPingPong();
        LeanTween.moveLocalZ(gameObject, 45f, randomTime).setOnComplete(GhostTurnFace);
        //LeanTween.moveLocalZ(gameObject, 45f, 10f).setLoopClamp();
    }

    void GhostTurnFace() {
        LeanTween.rotateY(gameObject, 180f,0.2f).setOnComplete(GhostMoveBack);
    }

    void GhostMoveBack() {
        float randomTime = Random.Range(4.0f, 6f);
        LeanTween.moveLocalZ(gameObject, 5f, randomTime).setOnComplete(GhostTurnFaceBack);
    }

    void GhostTurnFaceBack()
    {
        LeanTween.rotateY(gameObject, 0f, 0.2f).setOnComplete(GhostMove);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine("LoadpreviousScene", 0);
        }
    }

    IEnumerator LoadpreviousScene(int index)
    {
        SceneTransition.Instance.CrossFadeExit();
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(index);
    }
}
