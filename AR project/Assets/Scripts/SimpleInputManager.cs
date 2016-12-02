using UnityEngine;
using System.Collections;

public class SimpleInputManager : MonoBehaviour {

    private RaycastHit hit;
    private const string wearStudioURL = "http://wear-studio.com/";
    private const string targetTag = "Target";

    void Update () 
    {
        
        #if UNITY_ANDROID 
        {
            if(Input.touchCount > 0)
            {
                if(Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                    if(Physics.Raycast(ray, out hit))
                    {
                        if(hit.collider.tag == targetTag)
                        {
                            Application.OpenURL(wearStudioURL);
                        }
                    }
                }

            }
        }

        #elif UNITY_EDITOR
        {
            if(Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if(Physics.Raycast(ray, out hit))
                {
                    if(hit.collider.tag == targetTag)
                    {
                        Application.OpenURL(wearStudioURL);
                        Debug.Log("clicked");
                    }
                }
            } 
        }
        #endif
    }
}
