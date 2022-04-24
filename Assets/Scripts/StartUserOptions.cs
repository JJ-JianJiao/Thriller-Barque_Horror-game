using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUserOptions : MonoBehaviour
{
    public float startGameLoadingTime = 1f;

    public void StartGame() {
        StartCoroutine("LoadScene", SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator LoadScene(int index) {
        SceneTransition.Instance.CrossFadeExit();
        yield return new WaitForSeconds(startGameLoadingTime);
        SceneManager.LoadScene(index);
    }


    public void QuitGame() {
        Application.Quit();
    }
}
