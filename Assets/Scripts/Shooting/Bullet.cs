using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float Speed = 50.0f;
    [SerializeField]
    private float LifeTime = 3.0f;
    public int damage;

    [SerializeField]
    private int bounceLimit = 1;
    private int bounceNo = 0;

    public Vector3 Direction;

    private Rigidbody rb;
    public Player Owner { get; private set; }
    //private Coroutine _returnToPoolTimerCoroutine;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Destroy(gameObject, LifeTime);
        Direction = transform.forward;
    }

    public void InitializeValues( Player owner)
    {
        damage = 1;
        this.Owner = owner;
    }

    void FixedUpdate()
    {
        rb.velocity = Direction * Speed;
    }

    private void OnEnable()
    {
        Direction = transform.forward;
        //_returnToPoolTimerCoroutine = StartCoroutine(ReturnToPoolAfterTime());
    }

    private void OnDisable()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        Direction = Vector3.zero;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            return;
        }

        if (bounceNo >= bounceLimit)
        {
            this.gameObject.SetActive(false);
            //ObjectPoolManager.ReturnObjectToPool(gameObject);
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Bounce(Vector3.Reflect(Direction, collision.GetContact(0).normal));
        }
        else
        {
            this.gameObject.SetActive(false);
            //ObjectPoolManager.ReturnObjectToPool(gameObject);
        }
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

        //ObjectPoolManager. ReturnObjectToPool(gameObject);
    }
}
