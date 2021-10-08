using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DestroyObjectTag")
        {
            Destroy(this.gameObject);
        }
    }
}
