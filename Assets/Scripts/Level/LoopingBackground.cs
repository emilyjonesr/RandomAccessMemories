using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingBackground : MonoBehaviour
{
    public GameObject[] levelObjects;
    private Camera camera;
    private Vector2 bounds;
    public float choke;

    void Start()
    {
        camera = gameObject.GetComponent<Camera>();
        bounds = camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, camera.transform.position.z));
        
        foreach (GameObject obj in levelObjects)
        {
            ChildObjects(obj);
        }
    }

    //Creates child objects to the left and right of the background so that it seems infinite even though it is just creating 
    // a copy of the background objects. Does this to fit the bounds of the screen. 
    void ChildObjects(GameObject obj)
    {
        float widthOfObject = obj.GetComponent<SpriteRenderer>().bounds.size.x - choke;
        int objNeeded = (int)Mathf.Ceil(bounds.x * 2 / widthOfObject);
        GameObject copy = Instantiate(obj) as GameObject;

        for (int i = 0; i <= objNeeded; i++)
        {
            GameObject temp = Instantiate(copy) as GameObject;
            temp.transform.SetParent(obj.transform);
            temp.transform.position = new Vector3(widthOfObject * i, obj.transform.position.y, obj.transform.position.z);
            temp.name = obj.name + i;
        }
        Destroy(copy);
        Destroy(obj.GetComponent<SpriteRenderer>());

    }
    //Repositions the child objects to the left or right depending on where the Camera is and the bounds of the screen.
    void reposition(GameObject obj)
    {
        Transform[] objectsToMove = obj.GetComponentsInChildren<Transform>();
        
        if (objectsToMove.Length > 1)
        {
            GameObject firstObj = objectsToMove[1].gameObject;
            GameObject lastObj = objectsToMove[objectsToMove.Length - 1].gameObject;
            float halfWidth = lastObj.GetComponent<SpriteRenderer>().bounds.extents.x - choke;
            
            if (transform.position.x + bounds.x > lastObj.transform.position.x + halfWidth)
            {
                firstObj.transform.SetAsLastSibling();
                firstObj.transform.position = new Vector3(lastObj.transform.position.x + halfWidth * 2, lastObj.transform.position.y,lastObj.transform.position.z);

            }
            else if (transform.position.x - bounds.x < firstObj.transform.position.x - halfWidth)
            {
                lastObj.transform.SetAsFirstSibling();
                lastObj.transform.position = new Vector3(firstObj.transform.position.x - halfWidth * 2, firstObj.transform.position.y, firstObj.transform.position.z);

            }
        }
    }

    void LateUpdate()
    {
        foreach (GameObject obj in levelObjects)
        {
            reposition(obj);
        }
    }
}
