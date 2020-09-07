using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
  

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(player.position.x + offset.x , 0.45f , 50f),
            Mathf.Clamp(player.position.y + offset.y , 1f , 20f),
            transform.position.z
            );

/*        transform.position = player.position + offset;*/
    }
}
