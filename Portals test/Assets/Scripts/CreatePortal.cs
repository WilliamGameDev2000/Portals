using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePortal : MonoBehaviour
{
    public Camera camera;

    public GameObject Portal_A;
    public GameObject Portal_B;

    public bool spawned1 = false;
    public bool spawned2 = false;


    GameObject surface;
    Vector3 initialLocationA;
    Vector3 linitiaLocationB;

    // Start is called before the first frame update
    void Start()
    {
        initialLocationA = Portal_A.transform.position;        
        linitiaLocationB = Portal_B.transform.position;        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            spawnPortal(Portal_A);
            spawned1 = true;
        }

        if(Input.GetMouseButtonDown(1))
        {
            spawnPortal(Portal_B);
            spawned2 = true;
        }
        if(Input.GetMouseButtonDown(2))
        {
            removePortals();
        }
    }

    void spawnPortal(GameObject portal)
    {
        int middleX = Screen.width / 2;
        int middleY = Screen.height / 2;
        

        Ray ray = camera.ScreenPointToRay(new Vector3(middleX, middleY));
        

        RaycastHit hit;

        
        if (Physics.Raycast(ray, out hit))
        {
            surface = hit.collider.gameObject;
            if(surface.tag == "CanPortal")
            {
                Quaternion collisionRotation = Quaternion.LookRotation(hit.normal);

                portal.transform.position = hit.point;
                portal.transform.rotation = collisionRotation;
            }
        }
    }

    private void removePortals()
    {
      Portal_A.transform.position = initialLocationA;
      Portal_B.transform.position = linitiaLocationB;
      spawned1 = false;
      spawned2 = false;
    }
}
