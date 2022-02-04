using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Interaction : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Meteor"))
            Destroy(this.gameObject);
    }
}
