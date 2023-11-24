using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 50.0f;
    public float LifeTime = 3.0f;
    public int damage = 1;

    private Rigidbody rb;

    private Coroutine _returnToPoolTimerCoroutine;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Destroy(gameObject, LifeTime);
    }

    void FixedUpdate()
    {
        rb.velocity = transform.forward * Speed;
    }

    private void OnEnable()
    {
        _returnToPoolTimerCoroutine = StartCoroutine(ReturnToPoolAfterTime());
    }

    private void OnDisable()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
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
