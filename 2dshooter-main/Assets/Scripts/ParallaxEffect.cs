using UnityEngine;

[System.Serializable]
public class ParallaxLayer
{
    public Transform background;  // Transform del fondo
    [Range(0, 1)] public float parallaxFactor;  // Factor de desplazamiento
}

public class ParallaxEffect : MonoBehaviour
{
    public ParallaxLayer[] layers;  // Capas del fondo
    private Vector3 previousCameraPosition;

    void Start()
    {
        previousCameraPosition = Camera.main.transform.position;
    }

    void Update()
    {
        Vector3 deltaMovement = Camera.main.transform.position - previousCameraPosition;

        foreach (ParallaxLayer layer in layers)
        {
            Vector3 newPosition = layer.background.position;
            newPosition.x += deltaMovement.x * layer.parallaxFactor;
            newPosition.y += deltaMovement.y * layer.parallaxFactor;
            layer.background.position = newPosition;
        }

        previousCameraPosition = Camera.main.transform.position;
    }
}
