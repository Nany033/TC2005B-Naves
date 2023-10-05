using UnityEngine;

public class DestroyOnCameraExit : MonoBehaviour
{
    private Camera cameraToWatch;

    public void SetCamera(Camera camera)
    {
        cameraToWatch = camera;
    }

    private void Update()
    {
        if (cameraToWatch != null)
        {
            // Verifica si el objeto está dentro de la vista de la cámara
            Vector3 screenPoint = cameraToWatch.WorldToViewportPoint(transform.position);
            if (screenPoint.x >= 0 && screenPoint.x <= 1 && screenPoint.y >= 0 && screenPoint.y <= 1)
            {
                // The enemy is within the camera's view, so destroy it.
                Destroy(gameObject);
            }
        }
    }
}