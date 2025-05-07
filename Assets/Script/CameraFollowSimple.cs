using UnityEngine;

public class CameraFollowSimple : MonoBehaviour
{
    private Transform target;

    public Vector3 offset = new Vector3(0, 0, -10);
    public float followSpeed = 5f;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    void Update()
    {
        if (target == null) return;
        transform.position = Vector3.Lerp(transform.position, target.position + offset, followSpeed * Time.deltaTime);
    }
}
