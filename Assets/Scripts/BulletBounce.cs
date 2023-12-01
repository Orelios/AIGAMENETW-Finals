using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class BulletBounce : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    public int bounceLimit = 1;

    private Vector3 lastVelocity;
    private float currentSpeed;
    private Vector3 direction;
    private int bounceNo = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void LateUpdate()
    {
        lastVelocity = rb.velocity;
    }

    private void OnDisable()
    {
        bounceNo = 0;
    }

   // private void OnCollisionEnter(Collision collision)
    //{
       // if (collision.gameObject.CompareTag("Obstacle"))
        //{
          //  Bounce(collision);
       // }
       // else
       // {
         //   ObjectPoolManager.ReturnObjectToPool(gameObject);
      //  }
  //  }

    private void Bounce(Collision collision)
    {
        if (bounceNo >= bounceLimit)
        {
            //ObjectPoolManager.ReturnObjectToPool(gameObject);
            this.gameObject.SetActive(false);
        }

        currentSpeed = lastVelocity.magnitude;
        direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        rb.velocity = direction * Mathf.Max(currentSpeed, 0);
        bounceNo++;
    }
}
