using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    private float _waitTime = 5f;

    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        SceneLoader();
    }

    public void SceneLoader()
    {
        StartCoroutine(SceneLoadRoutine());
  
    }

    IEnumerator SceneLoadRoutine()
    {
        yield return new WaitForSeconds(_waitTime);
        SceneManager.LoadScene(1);
    }
}
