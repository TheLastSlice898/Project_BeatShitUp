using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ProjectileSystem : MonoBehaviour
{
    public GameObject PlayerProject;

    public GameObject ProjectilePoint;
    public RaycastHit raycastHit;
    public float MaxDistance;

    public GameObject[] ProjectileList;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void OnDrawGizmos()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit = raycastHit;


        if (Physics.Raycast(ray, out raycastHit, Mathf.Infinity))
        {
            //Gizmos.DrawLine(PlayerProject.transform.position, raycastHit.point);
            Gizmos.DrawLine(ProjectilePoint.transform.position, raycastHit.point);

        }
        else
        {
            Debug.Log("NO HITBOX KEK");

        }
    }
        void Update()
    {
        

        ProjectilePoint.transform.LookAt(raycastHit.point);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(ProjectileList[0], ProjectilePoint.transform);
        }

        //if (raycastHit.collider != null)
        //{
        //    PlayerProject.transform.LookAt(raycastHit.point);
        //}
        //else
        //{
        //   
        //}



    }
}
