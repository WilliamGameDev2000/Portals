using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkThrough : MonoBehaviour
{

    public GameObject other_portal;
    public Camera playerCam;
    public GameObject spawner;

    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Player" || other.tag == "Prop") && spawner.GetComponent<CreatePortal>().spawned1 == true && spawner.GetComponent<CreatePortal>().spawned2 == true)
        {
            Vector3 velocity = other.GetComponent<Rigidbody>().velocity;
            Quaternion newRotation = Quaternion.FromToRotation(other.transform.forward, other_portal.transform.forward);
            other.gameObject.transform.rotation = other_portal.transform.rotation;
            other.transform.position = other_portal.transform.position + other_portal.transform.forward * 2.5f;
            Rigidbody rigid = other.GetComponent<Rigidbody>();
            rigid.velocity = newRotation * velocity;
        }
    }
}

