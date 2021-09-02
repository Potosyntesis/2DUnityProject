using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    public GameObject player;
    public Vector3 cameraOffset;

    void Update()
    {
        Vector3 newPosition = player.transform.position + cameraOffset;
        Vector3 smoothedCamera = Vector3.Lerp(transform.position, player.transform.position, 10 * Time.deltaTime);
        transform.position = new Vector3(newPosition.x, 0, newPosition.z - 10);

    }
}
