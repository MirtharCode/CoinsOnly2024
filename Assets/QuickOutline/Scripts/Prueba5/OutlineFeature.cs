using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class OutlineFeature : ScriptableRendererFeature
{
    class OutlinePass : ScriptableRenderPass
    {
        public Material outlineMaterial;
        private RenderTargetIdentifier source;
        private RenderTargetHandle tempTexture;

        public OutlinePass(Material mat)
        {
            outlineMaterial = mat;
            tempTexture.Init("_TempOutlineTex");
        }

        public void Setup(RenderTargetIdentifier src)
        {
            source = src;
        }

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            if (outlineMaterial == null) return;

            CommandBuffer cmd = CommandBufferPool.Get("OutlinePass");

            RenderTextureDescriptor desc = renderingData.cameraData.cameraTargetDescriptor;
            cmd.GetTemporaryRT(tempTexture.id, desc);

            Blit(cmd, source, tempTexture.Identifier(), outlineMaterial, 0);
            Blit(cmd, tempTexture.Identifier(), source);

            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }
    }

    public Material outlineMaterial;
    OutlinePass outlinePass;

    public override void Create()
    {
        outlinePass = new OutlinePass(outlineMaterial);
        outlinePass.renderPassEvent = RenderPassEvent.AfterRenderingTransparents;
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        outlinePass.Setup(renderer.cameraColorTarget);
        renderer.EnqueuePass(outlinePass);
    }
}