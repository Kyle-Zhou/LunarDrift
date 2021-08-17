using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Loader : MonoBehaviour
{


   public static Loader instance;

    public Animator transition;
    public float transitionTime = 1f;

    private void Start()
    {
        instance = this;
    }

    public void LoadGameOverScreen(int scene)
    {
        StartCoroutine(Load(scene));
    }

    IEnumerator Load(int indexNumber)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(indexNumber);
    }


}
