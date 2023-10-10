using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBG : MonoBehaviour
{
    private float startPos; //starting position of bg element
    private GameObject cam; //where the camera is in comparison to the game object above
    [SerializeField] private float parallexEffect; //amount of parallex
                                                   //SerializeField shows private fields in the editor

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera");
        startPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (cam.transform.position.x * parallexEffect);  //get the camera position and multiply with parallax
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);


            //move the actual bg elements
            //y and z remain the same

    }
}
