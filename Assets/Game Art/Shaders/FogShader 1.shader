// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True;n:type:ShaderForge.SFN_Final,id:4795,x:32724,y:32693,varname:node_4795,prsc:2|emission-3488-OUT;n:type:ShaderForge.SFN_DepthBlend,id:360,x:31588,y:32886,varname:node_360,prsc:2|DIST-8569-OUT;n:type:ShaderForge.SFN_Slider,id:8569,x:31226,y:32888,ptovrint:False,ptlb:FogAmmount,ptin:_FogAmmount,varname:node_8569,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:50;n:type:ShaderForge.SFN_Blend,id:3488,x:32407,y:33148,varname:node_3488,prsc:2,blmd:10,clmp:True|SRC-6386-OUT,DST-385-RGB;n:type:ShaderForge.SFN_Color,id:385,x:32113,y:33267,ptovrint:False,ptlb:FogColor,ptin:_FogColor,varname:node_385,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Fresnel,id:3725,x:31787,y:32844,varname:node_3725,prsc:2|EXP-360-OUT;n:type:ShaderForge.SFN_OneMinus,id:6386,x:32316,y:32992,varname:node_6386,prsc:2|IN-7547-OUT;n:type:ShaderForge.SFN_Slider,id:7973,x:31683,y:33095,ptovrint:False,ptlb:VI Volumetric Intensity,ptin:_VIVolumetricIntensity,varname:node_7973,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:2;n:type:ShaderForge.SFN_Multiply,id:7547,x:31996,y:33018,varname:node_7547,prsc:2|A-3725-OUT,B-7973-OUT;proporder:8569-385-7973;pass:END;sub:END;*/

Shader "Shader Forge/FogShader" {
    Properties {
        _FogAmmount ("FogAmmount", Range(0, 50)) = 1
        _FogColor ("FogColor", Color) = (0.5,0.5,0.5,1)
        _VIVolumetricIntensity ("VI Volumetric Intensity", Range(0, 2)) = 1
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _CameraDepthTexture;
            uniform float _FogAmmount;
            uniform float4 _FogColor;
            uniform float _VIVolumetricIntensity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                float4 projPos : TEXCOORD2;
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
////// Lighting:
////// Emissive:
                float node_360 = saturate((sceneZ-partZ)/_FogAmmount);
                float3 node_3488 = saturate(( _FogColor.rgb > 0.5 ? (1.0-(1.0-2.0*(_FogColor.rgb-0.5))*(1.0-(1.0 - (pow(1.0-max(0,dot(normalDirection, viewDirection)),node_360)*_VIVolumetricIntensity)))) : (2.0*_FogColor.rgb*(1.0 - (pow(1.0-max(0,dot(normalDirection, viewDirection)),node_360)*_VIVolumetricIntensity))) ));
                float3 emissive = node_3488;
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0,0,0,1));
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
