using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject _deathFX;
    [SerializeField]
    private Transform parent;

    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerBoxCollider();
        
    }

    private void OnParticleCollision(GameObject other)
    {
        GameObject fx = Instantiate(_deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent.transform;
        Destroy(this.gameObject);
    }
    private void AddNonTriggerBoxCollider()
    {
        Collider shipCollider = gameObject.AddComponent<BoxCollider>();
        shipCollider.isTrigger = false;
    }
}
