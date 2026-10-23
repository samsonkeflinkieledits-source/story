using UnityEngine;

public class FloorLightSwitch : MonoBehaviour
{

    public Light floorLight;
    public Renderer floorRenderer;

    public Color red = Color.red;
    public Color blue = Color.blue;

    public float switchSpeed = 0.5f;
    public float emissionIntensity = 3f;

    private Material floorMaterial;

    void Start()
    {
        if (floorRenderer != null)
        {
            floorMaterial = floorRenderer.material;
        }
    }

    void Update()
    {
        float t = Mathf.PingPong(Time.time * switchSpeed, 1f);
        Color currentColor = Color.Lerp(red, blue, t);

        if (floorLight != null)
            floorLight.color = currentColor;

        if (floorMaterial != null)
            floorMaterial.SetColor(
                "_EmissionColor",
                currentColor * emissionIntensity
            );
    }
}
