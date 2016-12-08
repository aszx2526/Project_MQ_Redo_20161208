using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class HSBCImageEffect : MonoBehaviour {
    [Range(0, 1.0f)]
    public float hue = 0;
    [Range(0, 1.0f)]
    public float saturation = 0.5f;
    [Range(0, 1.0f)]
    public float brightness = 0.5f;
    [Range(0, 1.0f)]
    public float constract = 0.5f;

    private string m_huePropertyName = "_Hue";
    private string m_saturationPropertyName = "_Saturation";
    private string m_brightnessPropertyName = "_Brightness";
    private string m_constractPropertyName = "_Contrast";

    private int m_hueID;
    private int m_saturationID;
    private int m_brightnessID;
    private int m_constractID;

    private Material m_material;

    void Awake()
    {
        InitPropertyIDs();
    }


    private void InitPropertyIDs()
    {
        if (m_material == null)
            m_material = new Material(Shader.Find("Unlit/HSBC Effect"));

        m_hueID = Shader.PropertyToID(m_huePropertyName);
        m_saturationID = Shader.PropertyToID(m_saturationPropertyName);
        m_brightnessID = Shader.PropertyToID(m_brightnessPropertyName);
        m_constractID = Shader.PropertyToID(m_constractPropertyName);
    }


    private void OnValidate()
    {
        if (m_material == null)
            m_material = new Material(Shader.Find("Unlit/HSBC Effect"));

        m_material.SetFloat(m_hueID, hue);
        m_material.SetFloat(m_saturationID, saturation);
        m_material.SetFloat(m_brightnessID, brightness);
        m_material.SetFloat(m_constractID, constract);
    }


    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, m_material);
    }
}
