using UnityEngine;

[ExecuteAlways]
public class LightingHandler : MonoBehaviour
{
    //References
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset UniqueLightPreset;//Create in Unity to use script!
    //Variables
    [SerializeField, Range(0, 240)] private float ActualTimeInGame;

    private void Update()
    {
        if (UniqueLightPreset == null) return;
        if (Application.isPlaying)
        {
            ActualTimeInGame += Time.deltaTime;
            //Clamp between 0-24 
            ActualTimeInGame %= 240;
            UpdateLighting(ActualTimeInGame / 240f);
        }
        else
        {
            UpdateLighting(ActualTimeInGame / 240f);
        }

    }

    private void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = UniqueLightPreset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = UniqueLightPreset.FogColor.Evaluate(timePercent);

        if (DirectionalLight != null)
        {
            DirectionalLight.color = UniqueLightPreset.DirectionalColor.Evaluate(timePercent);
            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90, -170, 0));
        }
    }

    private void OnValidate()
    {
        if (DirectionalLight != null) return;

        if (RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        }
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                if (light.type == LightType.Directional)
                {
                    DirectionalLight = light;
                    return;
                }
            }
        }
    }
}
