using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 50.0f;
    public float LifeTime = 10.0f;
    public int damage = 1;

    private Rigidbody rb;

    private Coroutine _returnToPoolTimerCoroutine;

    [SerializeField]
    private int bounceLimit = 1;

    public Vector3 Direction;
    private int bounceNo = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Destroy(gameObject, LifeTime);
        Direction = transform.forward;
    }

    void FixedUpdate()
    {
        rb.velocity = Direction * Speed;
    }

    private void OnEnable()
    {
        Direction = transform.forward;
        _returnToPoolTimerCoroutine = StartCoroutine(ReturnToPoolAfterTime());
    }

    private void OnDisable()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        Direction = Vector3.zero;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (bounceNo >= bounceLimit)
        {
            ObjectPoolManager.ReturnObjectToPool(gameObject);
        }

        Bounce(Vector3.Reflect(Direction, collision.GetContact(0).normal));
    }

    public void Bounce(Vector3 direction)
    {
        Direction = direction;
        rb.velocity = Direction * Speed;
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
