using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class OutlineEffect : MonoBehaviour
{
    public Color outlineColor = Color.black;
    public float outlineWidth = 0.03f;
    private Material outlineMaterial;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();

        // Crea un material temporal con el shader de outline
        Shader outlineShader = Shader.Find("Custom/OutlineShader");
        if (outlineShader != null)
        {
            outlineMaterial = new Material(outlineShader);
            outlineMaterial.SetColor("_OutlineColor", outlineColor);
            outlineMaterial.SetFloat("_OutlineWidth", outlineWidth);
            rend.materials = new Material[] { rend.material, outlineMaterial };
        }
    }
}
