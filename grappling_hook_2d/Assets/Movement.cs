using UnityEngine;

public class Movement : MonoBehaviour
{
    //changed speed to 5 from 10
    public float speed = 5f;

    public bool Grapple;

    void Update()
    {
        
        Grapple = GetComponent<Grappler>().isGrappleOn;

        Vector3 pos = transform.position;

        if(!Grapple){
            // "w" can be replaced with any key
            // this section moves the character up
            if (Input.GetKey("w"))
            {
                pos.y += speed * Time.deltaTime;
            }

            // "s" can be replaced with any key
            // this section moves the character down
            if (Input.GetKey("s"))
            {
                pos.y -= speed * Time.deltaTime;
            }

            // "d" can be replaced with any key
            // this section moves the character right
            if (Input.GetKey("d"))
            {
                pos.x += speed * Time.deltaTime;
            }

            // "a" can be replaced with any key
            // this section moves the character left
            if (Input.GetKey("a"))
            {
                pos.x -= speed * Time.deltaTime;
            }


            transform.position = pos;
        }
    }
}
