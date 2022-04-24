using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    Button continueBtn, ReturnBtn, QuitBtn;
    [SerializeField]
    float btnShowTime;

    internal bool fullyOpen;

    private void Start()
    {
        fullyOpen = false;
    }

    private void OnEnable()
    {
        StartCoroutine("ButtonsMoveTween");
    }

    IEnumerator  ButtonsMoveTween() {

        //LeanTween.moveLocalX(gameObject, -1250f, 0.3f).setIgnoreTimeScale(true);
        //LeanTween.moveX(gameObject, -500f, 0.3f).setIgnoreTimeScale(true);
        //yield return new WaitForSecondsRealtime(0.3f);

        LeanTween.moveLocalX(continueBtn.gameObject, 750f, btnShowTime).setIgnoreTimeScale(true);
        yield return new WaitForSecondsRealtime(btnShowTime);
        LeanTween.moveLocalX(ReturnBtn.gameObject, 750f, btnShowTime).setIgnoreTimeScale(true);
        yield return new WaitForSecondsRealtime(btnShowTime);
        LeanTween.moveLocalX(QuitBtn.gameObject, 750f, btnShowTime).setIgnoreTimeScale(true);
        yield return new WaitForSecondsRealtime(btnShowTime);
        gameObject.GetComponent<CanvasGroup>().interactable = true;
        gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
        fullyOpen = true;
    }

    public void ContinueBtnOnClick() {
        StartCoroutine("ButtonsMoveBackTween");
    }

    public void ReturnMainBtnOnClick()
    {
        StartCoroutine("LoadpreviousScene", 0);
    }

    IEnumerator LoadpreviousScene(int index) {
        SceneTransition.Instance.CrossFadeExit();
        yield return new WaitForSecondsRealtime(1f);
        ResumeTimeScale();
        SceneManager.LoadScene(index);
    }

    IEnumerator ButtonsMoveBackTween()
    {
        gameObject.GetComponent<CanvasGroup>().interactable = false;
        gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
        LeanTween.moveLocalX(QuitBtn.gameObject, 0f, btnShowTime).setIgnoreTimeScale(true);
        yield return new WaitForSecondsRealtime(btnShowTime);
        LeanTween.moveLocalX(ReturnBtn.gameObject, 0f, btnShowTime).setIgnoreTimeScale(true);
        yield return new WaitForSecondsRealtime(btnShowTime);
        LeanTween.moveLocalX(continueBtn.gameObject, 0f, btnShowTime).setIgnoreTimeScale(true);
        yield return new WaitForSecondsRealtime(btnShowTime);
        //LeanTween.moveLocalX(gameObject, -1500f, 0.3f).setIgnoreTimeScale(true);
        //yield return new WaitForSecondsRealtime(0.3f);
        ResumeTimeScale();
        fullyOpen = false;
        //PlayerSoundsManager.instance.UnPauseAudioSources();
        PlayerSoundsManager.instance.UnPauseAudioSources_Listener();

        gameObject.SetActive(false);
    }

    private void ResumeTimeScale() {
        Time.timeScale = 1;
    }

    public void QuitGameApplication() {
        Application.Quit();
    }

    private void CancelPauseMenu() {
        StartCoroutine("ButtonsMoveBackTween");
    }

}
