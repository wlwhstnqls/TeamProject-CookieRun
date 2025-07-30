using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    //public float smoothSpeed = 5f;
    //public Vector2 minBounds;
    //public Vector2 maxBounds;


    
    // Start is called before the first frame update


    private void LateUpdate()
    {
        
        if (player == null)
        {
            return;
        }
        transform.position = new Vector3(player.position.x + offset.x, transform.position.y, transform.position.z);
        


        //Vector3 desiredPosition = player.position + offset;
        //desiredPosition.z = transform.position.z;

        //desiredPosition.x = Mathf.Clamp(desiredPosition.x, minBounds.x, maxBounds.x);
        //desiredPosition.y = Mathf.Clamp(desiredPosition.y, minBounds.y, maxBounds.y);

        //transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);
    }

}
