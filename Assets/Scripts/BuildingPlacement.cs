using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//grab an object with the mouse/ place an objec then move the object
//according to mouse coordinates hit.point is where you move the object to
public class BuildingPlacement : MonoBehaviour
{
    public Camera cam;
    bool isMoving = false;
    public Vector3 offset = new Vector3(0,1f,0);
    GameObject building;
    public Material building_mat;   
    public Material transBuilding_mat;
 
    void Update()
    {
        //this is how we move the building
        //Check if is moving is true if it is do a raycast and set the buildings
        //position = to hit.point + offset
        if (isMoving)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 50))
            {                
                building.gameObject.transform.position = hit.point + offset;
            }
        }
        //if the building is moving and we press the left mouse button drop the building
        //by setting isMoving to false also we need to reenable the collider and set 
        //our building variable to null so that we can select our next building
        if (Input.GetMouseButtonDown(0) && isMoving)
        {
            isMoving = false;
            building.GetComponent<BoxCollider>().enabled = true;
            building.GetComponent<Renderer>().material = building_mat;
            building = null;
        }
        //else if the building is not moving and we press the left mouse button
        //check if we hit a building and if we did set isMoving to true
        //also set the collider to false so our raycast doesn't interfere with it
        else if (Input.GetMouseButtonDown(0) && !isMoving)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 50))
            {
                if (hit.collider.tag == "Building")
                {
                    building = hit.collider.gameObject;
                    building.GetComponent<BoxCollider>().enabled = false;
                    building.GetComponent<Renderer>().material = transBuilding_mat;
                    isMoving = true;
                }
            }
        }
    }
    //Draws a ray from the point on the screen where the mouse cursor is 
    //to where it is casting to on scene colliders useful for seeing where
    //the mouse is pointing to
    void DrawRay()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Debug.Log("hit: " + hit.collider.name + " location: " + hit.point);
            Debug.DrawRay(ray.origin, ray.direction * 50, Color.yellow, 1);
        }
        else
        {
            Debug.Log("Didn't hit");
        }
    }
}

