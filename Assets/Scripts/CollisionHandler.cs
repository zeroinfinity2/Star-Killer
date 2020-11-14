using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField][Tooltip("In Seconds")]
    private float _levelLoadDelay = 3f;

    [SerializeField][Tooltip("Particle Effect Prefab")]
    private GameObject _deathFXPrefab;

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
        _deathFXPrefab.SetActive(true);
        StartCoroutine(ReloadScene());
    }

    IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(_levelLoadDelay);
        SceneManager.LoadScene(1);
    }
}
