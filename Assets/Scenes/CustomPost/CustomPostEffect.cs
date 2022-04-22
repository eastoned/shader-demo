using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

//from https://docs.unity3d.com/Packages/com.unity.postprocessing@3.1/manual/Writing-Custom-Effects.html

[Serializable]
[PostProcess(typeof(CustomPostEffectRenderer), PostProcessEvent.AfterStack, "ShaderDemo/PostEffect")]
public sealed class CustomPostEffect : PostProcessEffectSettings
{
    [Range(0f, 1f), Tooltip("Post effect intensity")]
    public FloatParameter blend = new FloatParameter { value = 0.5f };
}
public sealed class CustomPostEffectRenderer: PostProcessEffectRenderer<CustomPostEffect>
{
    public override void Render(PostProcessRenderContext context)
    {
        var sheet = context.propertySheets.Get(Shader.Find("Hidden/ShaderDemo/PostEffect"));
        sheet.properties.SetFloat("_Blend", settings.blend);
        context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
        
    }
}
