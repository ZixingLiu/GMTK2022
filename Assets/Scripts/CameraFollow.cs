using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;


    private void Awake()
    {
        if(player == null)
        player = FindObjectOfType<PlayerControl>().gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newCameraPosition = new Vector3(player.transform.position.x, player.transform.position.y,transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newCameraPosition, 1);
    }
}
