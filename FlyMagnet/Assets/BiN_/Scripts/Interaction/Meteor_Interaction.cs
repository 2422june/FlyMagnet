using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor_Interaction : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Planet"))
            Destroy(this.gameObject);

        if (collision.gameObject.CompareTag("Coin"))
            Destroy(collision.gameObject);

        if (collision.gameObject.CompareTag("Heal"))
            Destroy(this.gameObject);
    }
}
