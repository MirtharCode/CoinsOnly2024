using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ScreenSpaceOutlines : ScriptableRendererFeature
{
    [System.Serializable]
    private class ViewSpaceNormalsTextureSettings
    {
        public RenderTextureFormat colorFormat = RenderTextureFormat.ARGB32;
        public int depthBufferBits = 0;
        public Color backgroundColor = Color.black;
    }

    private class ViewSpaceNormalsTexturePass : ScriptableRenderPass
    {
        private ViewSpaceNormalsTextureSettings normalsTextureSettings;
        private readonly List<ShaderTagId> shaderTagIdList;
        private readonly RenderTargetHandle normals;
        private readonly Material normalsMaterial;
        private FilteringSettings filteringSettings;

        public ViewSpaceNormalsTexturePass(RenderPassEvent renderPassEvent, LayerMask outlinesLayerMask, ViewSpaceNormalsTextureSettings settings)
        {
            normalsMaterial = new Material(Shader.Find("Hidden/ViewSpaceNormalsShader"));
            shaderTagIdList = new List<ShaderTagId>()
            {
                new ShaderTagId("UniversalForward"),
                new ShaderTagId("UniversalForwardOnly"),
                new ShaderTagId("LightweightForward"),
                new ShaderTagId("SRPDefaultUnlit")
            };

            this.renderPassEvent = renderPassEvent;
            this.normalsTextureSettings = settings;

            normals.Init("_ScreenViewSpaceNormals");
            filteringSettings = new FilteringSettings(RenderQueueRange.opaque, outlinesLayerMask);
        }

        public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
        {
            RenderTextureDescriptor normalsTextureDescriptor = cameraTextureDescriptor;
            normalsTextureDescriptor.colorFormat = normalsTextureSettings.colorFormat;
            normalsTextureDescriptor.depthBufferBits = normalsTextureSettings.depthBufferBits;

            cmd.GetTemporaryRT(normals.id, normalsTextureDescriptor, FilterMode.Point);
            ConfigureTarget(normals.Identifier());
            ConfigureClear(ClearFlag.All, normalsTextureSettings.backgroundColor);
        }

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            if (!normalsMaterial)
                return;

            CommandBuffer cmd = CommandBufferPool.Get();
            using (new ProfilingScope(cmd, new ProfilingSampler("ScreenViewSpaceNormalsTextureCreation")))
            {
                context.ExecuteCommandBuffer(cmd);
                cmd.Clear();

                DrawingSettings drawSettings = CreateDrawingSettings(shaderTagIdList, ref renderingData, renderingData.cameraData.defaultOpaqueSortFlags);
                drawSettings.overrideMaterial = normalsMaterial;

                context.DrawRenderers(renderingData.cullResults, ref drawSettings, ref filteringSettings);
            }

            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }

        public override void OnCameraCleanup(CommandBuffer cmd)
        {
            cmd.ReleaseTemporaryRT(normals.id);
        }
    }

    private class ScreenSpaceOutlinePass : ScriptableRenderPass
    {
        private readonly Material screenSpaceOutlineMaterial;
        private RenderTargetIdentifier cameraColorTarget;
        private RenderTargetIdentifier temporaryBuffer;
        private int temporaryBufferID = Shader.PropertyToID("_TemporaryBuffer");

        public ScreenSpaceOutlinePass(RenderPassEvent renderPassEvent)
        {
            this.renderPassEvent = renderPassEvent;
            screenSpaceOutlineMaterial = new Material(Shader.Find("Hidden/OutlineShader"));
        }

        public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
        {
            cameraColorTarget = renderingData.cameraData.renderer.cameraColorTarget;

            RenderTextureDescriptor descriptor = renderingData.cameraData.cameraTargetDescriptor;
            cmd.GetTemporaryRT(temporaryBufferID, descriptor, FilterMode.Bilinear);
            temporaryBuffer = new RenderTargetIdentifier(temporaryBufferID);
        }

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            if (!screenSpaceOutlineMaterial)
                return;

            CommandBuffer cmd = CommandBufferPool.Get();
            using (new ProfilingScope(cmd, new ProfilingSampler("ScreenSpaceOutlines")))
            {
                Blit(cmd, cameraColorTarget, temporaryBuffer);
                Blit(cmd, temporaryBuffer, cameraColorTarget, screenSpaceOutlineMaterial);
            }
            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }

        public override void OnCameraCleanup(CommandBuffer cmd)
        {
            cmd.ReleaseTemporaryRT(temporaryBufferID);
        }
    }

    [SerializeField] private RenderPassEvent renderPassEvent = RenderPassEvent.AfterRenderingOpaques;
    [SerializeField] private ViewSpaceNormalsTextureSettings viewSpaceNormalsTextureSettings = new ViewSpaceNormalsTextureSettings();
    [SerializeField] private LayerMask outlinesLayerMask = ~0;

    private ViewSpaceNormalsTexturePass viewSpaceNormalsTexturePass;
    private ScreenSpaceOutlinePass screenSpaceOutlinePass;

    public override void Create()
    {
        viewSpaceNormalsTexturePass = new ViewSpaceNormalsTexturePass(renderPassEvent, outlinesLayerMask, viewSpaceNormalsTextureSettings);
        screenSpaceOutlinePass = new ScreenSpaceOutlinePass(renderPassEvent);
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        renderer.EnqueuePass(viewSpaceNormalsTexturePass);
        renderer.EnqueuePass(screenSpaceOutlinePass);
    }
}
