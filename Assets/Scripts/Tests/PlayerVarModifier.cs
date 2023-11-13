using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVarModifier : MonoBehaviour
{
    [SerializeField]
    private Character p1;

    public void DecreasePlayerHealth()
    {
        //Typically this would be, get the object that collided.GetComponent<Character>.DealDamage() or so?
        p1.TakeDamage(1);
    }
}
