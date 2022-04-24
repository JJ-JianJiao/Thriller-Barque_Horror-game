using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    public static SceneTransition Instance;

    [SerializeField]
    private Animator sceneTransitionAnim;
    private void Awake()
    {
        Instance = this;
    }

    public void CrossFadeExit()
    {
        sceneTransitionAnim.SetTrigger("Start");
    }
}
