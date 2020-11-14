using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private float _waitTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        SceneLoad();
    }

    public void SceneLoad()
    {
        StartCoroutine(SceneLoadRoutine());

    }

    IEnumerator SceneLoadRoutine()
    {
        yield return new WaitForSeconds(_waitTime);
        SceneManager.LoadScene(1);
    }
}
