using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;


    private void LateUpdate()
    {
        
        if (player == null)
        {
            return;
        }
        transform.position = new Vector3(player.position.x + offset.x, transform.position.y, transform.position.z);
        


      

    
    }

}
