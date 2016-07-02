// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True;n:type:ShaderForge.SFN_Final,id:4795,x:33300,y:32570,varname:node_4795,prsc:2|emission-8277-OUT;n:type:ShaderForge.SFN_Tex2d,id:6074,x:31959,y:32509,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:9673948bcd8f7e541b94102f478c5234,ntxv:0,isnm:False|UVIN-2150-UVOUT;n:type:ShaderForge.SFN_Multiply,id:2393,x:32211,y:32840,varname:node_2393,prsc:2|A-6074-B,B-1496-B,C-2053-RGB,D-797-RGB,E-9248-OUT;n:type:ShaderForge.SFN_VertexColor,id:2053,x:31959,y:32969,varname:node_2053,prsc:2;n:type:ShaderForge.SFN_Color,id:797,x:31959,y:33132,ptovrint:True,ptlb:Color,ptin:_TintColor,varname:_TintColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Vector1,id:9248,x:31959,y:33288,varname:node_9248,prsc:2,v1:2;n:type:ShaderForge.SFN_Panner,id:2150,x:31777,y:32509,varname:node_2150,prsc:2,spu:0.2,spv:0|UVIN-8014-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:8014,x:31604,y:32509,varname:node_8014,prsc:2,uv:0;n:type:ShaderForge.SFN_Tex2d,id:1496,x:31959,y:32727,ptovrint:False,ptlb:MainTex_copy,ptin:_MainTex_copy,varname:_MainTex_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:9673948bcd8f7e541b94102f478c5234,ntxv:0,isnm:False|UVIN-9756-UVOUT;n:type:ShaderForge.SFN_Panner,id:9756,x:31788,y:32727,varname:node_9756,prsc:2,spu:-0.2,spv:0|UVIN-9534-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:9534,x:31615,y:32727,varname:node_9534,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:8277,x:32674,y:32851,varname:node_8277,prsc:2|A-2393-OUT,B-2415-OUT;n:type:ShaderForge.SFN_Slider,id:2415,x:32264,y:33043,ptovrint:False,ptlb:FlimmerPower,ptin:_FlimmerPower,varname:node_2415,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:1;proporder:6074-797-1496-2415;pass:END;sub:END;*/

Shader "Shader Forge/SH_HologramBase" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _TintColor ("Color", Color) = (0.5,0.5,0.5,1)
        _MainTex_copy ("MainTex_copy", 2D) = "white" {}
        _FlimmerPower ("FlimmerPower", Range(0, 1)) = 0.5
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
            Cull Off
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
            uniform float4 _TimeEditor;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _TintColor;
            uniform sampler2D _MainTex_copy; uniform float4 _MainTex_copy_ST;
            uniform float _FlimmerPower;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
////// Lighting:
////// Emissive:
                float4 node_2609 = _Time + _TimeEditor;
                float2 node_2150 = (i.uv0+node_2609.g*float2(0.2,0));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_2150, _MainTex));
                float2 node_9756 = (i.uv0+node_2609.g*float2(-0.2,0));
                float4 _MainTex_copy_var = tex2D(_MainTex_copy,TRANSFORM_TEX(node_9756, _MainTex_copy));
                float3 emissive = ((_MainTex_var.b*_MainTex_copy_var.b*i.vertexColor.rgb*_TintColor.rgb*2.0)*_FlimmerPower);
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
