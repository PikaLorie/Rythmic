using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    public Animator _transition;
    public GameObject _transitionGameObject;
    public float _transitionTime = 1f;

    private void Start() 
    {
        StartCoroutine(FadeOut());
    }
    
    IEnumerator FadeOut()
    {
        _transition.SetTrigger("FadeOut");
        yield return new WaitForSeconds(_transitionTime);
        _transitionGameObject.SetActive(false);
    }
}
