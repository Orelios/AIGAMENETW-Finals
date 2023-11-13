using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CharacterShooting : MonoBehaviour
{
    public GameObject bullet;

    [SerializeField]
    private Transform player;
    [SerializeField]
    private Transform bulletSpawnPoint;
    [SerializeField]
    private float RotSpeed = 20.0f;

    protected float shootRate;
    protected float elapsedTime;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
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
            if (elapsedTime >= shootRate)
            {
                //Reset the time
                elapsedTime = 0.0f;

                Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            }
        }
    }
}
