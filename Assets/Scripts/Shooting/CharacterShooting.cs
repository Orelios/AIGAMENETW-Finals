using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using Photon.Pun;
using Photon.Realtime;
using Photon.Pun.UtilityScripts;

public class CharacterShooting : MonoBehaviourPunCallbacks
{
    //public GameObject bullet;

    [SerializeField]
    //What is the ID of the pooled object that we want as a bullet
    private string bulletId;

    [SerializeField]
    private Transform player;
    [SerializeField]
    private Transform bulletSpawnPoint;
    [SerializeField]
    private float RotSpeed = 20.0f;
    [SerializeField]
    protected float shootRate;
    protected float elapsedTime;
    private PhotonView photonView;

    private void Awake()
    {
        photonView = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        UpdateAim();
        UpdateWeapon();
    }

    void UpdateAim()
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position + new Vector3(0, 0, 0));

        Ray RayCast = Camera.main.ScreenPointToRay(Input.mousePosition);

        float HitDist = 0;

        if (playerPlane.Raycast(RayCast, out HitDist))
        {
            Vector3 RayHitPoint = RayCast.GetPoint(HitDist);

            Quaternion targetRotation = Quaternion.LookRotation(RayHitPoint - transform.position);
            player.transform.rotation = Quaternion.Slerp(player.transform.rotation, targetRotation, Time.deltaTime * RotSpeed);
        }
    }
    void UpdateWeapon()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Ensure that the RPC call will be handled only by the local player
            if (!photonView.IsMine)
            {
                return;
            }

            if (elapsedTime >= shootRate)
            {
                //Reset the time
                elapsedTime = 0.0f;


                photonView.RPC("RPCShootBullet", RpcTarget.AllViaServer);
                //Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                //ObjectPoolManager.SpawnObject(bullet, bulletSpawnPoint.position, //bulletSpawnPoint.rotation, ObjectPoolManager.PoolType.Bullets);
            }
        }
    }

    [PunRPC]
    private void RPCShootBullet()
    {
        //Instead of manually instantiating a bullet, we need to have it pooled to save up memory and for better performance
        //Instantiate(bullet, transform.position, transform.rotation);

        //Get a prefab from the object pool manager
        GameObject pooledBullet = ObjectPoolManager.Instance.GetPooledObject(bulletId);
        if (pooledBullet != null)
        {
            //Modify the bullet's position and rotation
            pooledBullet.transform.position = transform.position;
            pooledBullet.transform.rotation = transform.rotation;
            pooledBullet.GetComponent<Bullet>().InitializeValues(photonView.Owner);
            //Enable the gameObject
            pooledBullet.SetActive(true);
        }
    }
}
