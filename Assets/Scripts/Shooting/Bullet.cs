using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 50.0f;
    public float LifeTime = 3.0f;
    public int damage = 1;

    private Coroutine _returnToPoolTimerCoroutine;

    void Start()
    {
        //Destroy(gameObject, LifeTime);
    }

    void Update()
    {
        transform.position +=
            transform.forward * Speed * Time.deltaTime;
    }

    private void OnEnable()
    {
        _returnToPoolTimerCoroutine = StartCoroutine(ReturnToPoolAfterTime());
    }

    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        //Destroy(gameObject);
        ObjectPoolManager.ReturnObjectToPool(gameObject);
    }
    private IEnumerator ReturnToPoolAfterTime()
    {
        float elapsedTime = 0f;
        while(elapsedTime < LifeTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        ObjectPoolManager. ReturnObjectToPool(gameObject);
    }
}
