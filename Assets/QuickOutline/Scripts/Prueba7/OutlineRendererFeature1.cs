using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class OutlineRendererFeature1 : ScriptableRendererFeature
{
    [System.Serializable]
    public class OutlineSettings
    {
        public Color outlineColor = Color.black;
        [Range(0.001f, 0.05f)]
        public float outlineWidth = 0.01f;
        public LayerMask outlineLayerMask = -1;
        public Material outlineMaterial;
    }

    public OutlineSettings settings = new OutlineSettings();

    private OutlinePass outlinePass;

    public override void Create()
    {
        outlinePass = new OutlinePass(settings);
        outlinePass.renderPassEvent = RenderPassEvent.AfterRenderingOpaques;
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        if (settings.outlineMaterial != null)
        {
            settings.outlineMaterial.SetColor("_OutlineColor", settings.outlineColor);
            settings.outlineMaterial.SetFloat("_OutlineWidth", settings.outlineWidth);
            renderer.EnqueuePass(outlinePass);
        }
    }

    protected override void Dispose(bool disposing)
    {
        outlinePass?.Dispose();
    }

    private class OutlinePass : ScriptableRenderPass
    {
        private OutlineSettings settings;
        private FilteringSettings filteringSettings;
        private ProfilingSampler profilingSampler = new ProfilingSampler("OutlinePass");
        private ShaderTagId shaderTagId = new ShaderTagId("UniversalForward");

        public OutlinePass(OutlineSettings settings)
        {
            this.settings = settings;
            this.filteringSettings = new FilteringSettings(RenderQueueRange.opaque, settings.outlineLayerMask);
        }

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            if (settings.outlineMaterial == null)
                return;

            CommandBuffer cmd = CommandBufferPool.Get();
            using (new ProfilingScope(cmd, profilingSampler))
            {
                // Crear configuración de dibujo CORREGIDA
                var drawSettings = CreateDrawingSettings(
                    shaderTagId,
                    ref renderingData,
                    renderingData.cameraData.defaultOpaqueSortFlags
                );

                drawSettings.overrideMaterial = settings.outlineMaterial;
                drawSettings.overrideMaterialPassIndex = 1; // Usar el segundo pass (outline)

                // Dibujar renderers
                context.DrawRenderers(
                    renderingData.cullResults,
                    ref drawSettings,
                    ref filteringSettings
                );
            }

            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }

        public void Dispose()
        {
            // Cleanup si es necesario
        }
    }
}