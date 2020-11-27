using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePortal : MonoBehaviour
{

    public Transform player;
    public Transform teleportLocation;

    private bool Overlap = false;

    // Update is called once per frame
    void Update()
    {
        if(Overlap)
        {
            Vector3 playerToPortal = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, playerToPortal);

            //if entered from the correct side
            if(dotProduct < 0f)
            {
                float rotationDiff = -Quaternion.Angle(transform.rotation, teleportLocation.rotation);
                rotationDiff += 180;
                player.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * playerToPortal;
                player.position = teleportLocation.position + positionOffset;

                Overlap = false;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Overlap = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            Overlap = false;
        }
    }
}
