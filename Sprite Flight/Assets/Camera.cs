
using UnityEngine;

public class CameraBoundaryLock : MonoBehaviour
{
    public BoxCollider2D[] wallColliders;
    private Bounds arenaBounds;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        if (wallColliders != null && wallColliders.Length > 0)
        {
            arenaBounds = wallColliders[0].bounds;
            foreach (var collider in wallColliders)
            {
                arenaBounds.Encapsulate(collider.bounds);
            }
        }
    }

    void LateUpdate()
    {
        if (wallColliders == null || wallColliders.Length == 0 || mainCamera == null) return;
        float cameraHeight = mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;
        float minX = arenaBounds.min.x + cameraWidth;
        float maxX = arenaBounds.max.x - cameraWidth;
        float minY = arenaBounds.min.y + cameraHeight;
        float maxY = arenaBounds.max.y - cameraHeight;
        float clampedX = Mathf.Clamp(mainCamera.transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(mainCamera.transform.position.y, minY, maxY);
        mainCamera.transform.position = new Vector3(clampedX, clampedY, mainCamera.transform.position.z);
    }
}