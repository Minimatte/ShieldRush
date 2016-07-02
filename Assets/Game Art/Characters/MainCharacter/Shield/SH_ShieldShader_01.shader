// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True;n:type:ShaderForge.SFN_Final,id:4795,x:33449,y:32661,varname:node_4795,prsc:2|emission-9994-OUT,custl-3490-OUT,olwid-8682-OUT,olcol-3924-RGB;n:type:ShaderForge.SFN_VertexColor,id:2053,x:32235,y:32772,varname:node_2053,prsc:2;n:type:ShaderForge.SFN_Color,id:797,x:32235,y:32437,ptovrint:True,ptlb:FrontColor,ptin:_TintColor,varname:_TintColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Fresnel,id:354,x:32609,y:32822,varname:node_354,prsc:2|EXP-7127-OUT;n:type:ShaderForge.SFN_Slider,id:7127,x:32205,y:32980,ptovrint:False,ptlb:Fresnel,ptin:_Fresnel,varname:node_7127,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5555556,max:1;n:type:ShaderForge.SFN_Blend,id:1083,x:32858,y:32701,varname:node_1083,prsc:2,blmd:2,clmp:True|SRC-8130-OUT,DST-354-OUT;n:type:ShaderForge.SFN_Color,id:2506,x:32235,y:32618,ptovrint:False,ptlb:BackColor,ptin:_BackColor,varname:node_2506,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.2394572,c2:0.6716322,c3:0.7573529,c4:1;n:type:ShaderForge.SFN_Lerp,id:8130,x:32559,y:32544,varname:node_8130,prsc:2|A-797-RGB,B-2506-RGB,T-2053-RGB;n:type:ShaderForge.SFN_Color,id:2911,x:33085,y:32896,ptovrint:False,ptlb:CustomLight,ptin:_CustomLight,varname:node_2911,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Color,id:3924,x:32865,y:33244,ptovrint:False,ptlb:OutlineColor,ptin:_OutlineColor,varname:node_3924,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Slider,id:8682,x:32597,y:33125,ptovrint:False,ptlb:OutlineWidth,ptin:_OutlineWidth,varname:node_8682,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Clamp,id:9994,x:33085,y:32701,varname:node_9994,prsc:2|IN-1083-OUT,MIN-8227-OUT,MAX-8281-OUT;n:type:ShaderForge.SFN_Vector1,id:8227,x:32868,y:32921,varname:node_8227,prsc:2,v1:0.05;n:type:ShaderForge.SFN_Vector1,id:8281,x:32868,y:33000,varname:node_8281,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:3490,x:33273,y:32825,varname:node_3490,prsc:2|A-9994-OUT,B-2911-RGB;proporder:797-7127-2506-2911-3924-8682;pass:END;sub:END;*/

Shader "Shader Forge/SH_ShieldShader_01" {
    Properties {
        _TintColor ("FrontColor", Color) = (1,0,0,1)
        _Fresnel ("Fresnel", Range(0, 1)) = 0.5555556
        _BackColor ("BackColor", Color) = (0.2394572,0.6716322,0.7573529,1)
        _CustomLight ("CustomLight", Color) = (1,1,1,1)
        _OutlineColor ("OutlineColor", Color) = (1,1,1,1)
        _OutlineWidth ("OutlineWidth", Range(0, 1)) = 0
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "Outline"
            Tags {
            }
            Cull Front
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _OutlineColor;
            uniform float _OutlineWidth;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_FOG_COORDS(0)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = mul(UNITY_MATRIX_MVP, float4(v.vertex.xyz + v.normal*_OutlineWidth,1) );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                return fixed4(_OutlineColor.rgb,0);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TintColor;
            uniform float _Fresnel;
            uniform float4 _BackColor;
            uniform float4 _CustomLight;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(2)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
////// Lighting:
////// Emissive:
                float3 node_9994 = clamp(saturate((1.0-((1.0-pow(1.0-max(0,dot(normalDirection, viewDirection)),_Fresnel))/lerp(_TintColor.rgb,_BackColor.rgb,i.vertexColor.rgb)))),0.05,1.0);
                float3 emissive = node_9994;
                float3 finalColor = emissive + (node_9994*_CustomLight.rgb);
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0,0,0,1));
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
