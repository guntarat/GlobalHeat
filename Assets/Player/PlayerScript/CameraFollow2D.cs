using Unity.Netcode;
using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    private Transform target;

    void Start()
    {
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            if (player.GetComponent<NetworkObject>().IsOwner)
            {
                target = player.transform;
                break;
            }
        }
    }

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 newPos = target.position;
        newPos.z = -10f;
        transform.position = newPos;
    }
}
