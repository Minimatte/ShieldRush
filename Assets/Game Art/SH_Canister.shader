// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:33201,y:33046,varname:node_4013,prsc:2|diff-2877-RGB,normal-3485-RGB,emission-4619-OUT,alpha-2212-OUT,olwid-3164-OUT,olcol-7069-RGB;n:type:ShaderForge.SFN_Tex2d,id:185,x:31989,y:33358,ptovrint:False,ptlb:Mask,ptin:_Mask,varname:node_185,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:738b8c7313c99a741bd0b332c5b5bc51,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:2877,x:32112,y:32564,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_2877,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:5e2ac0a75565c3547b12c367be2740c2,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:3485,x:32112,y:32774,ptovrint:False,ptlb:Normal,ptin:_Normal,varname:node_3485,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:f367078edd2fbf947a0eb20deb03c705,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Lerp,id:7229,x:32651,y:33233,varname:node_7229,prsc:2|A-2455-OUT,B-9992-RGB,T-2455-OUT;n:type:ShaderForge.SFN_Color,id:9992,x:31995,y:33006,ptovrint:False,ptlb:EmiColor,ptin:_EmiColor,varname:node_9992,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_OneMinus,id:2860,x:32214,y:33253,varname:node_2860,prsc:2|IN-185-G;n:type:ShaderForge.SFN_Multiply,id:2455,x:32451,y:33253,varname:node_2455,prsc:2|A-2860-OUT,B-185-B;n:type:ShaderForge.SFN_Multiply,id:4619,x:32592,y:32980,varname:node_4619,prsc:2|A-7229-OUT,B-8492-OUT;n:type:ShaderForge.SFN_Slider,id:8492,x:32189,y:33022,ptovrint:False,ptlb:EmissivePower,ptin:_EmissivePower,varname:node_8492,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:5;n:type:ShaderForge.SFN_OneMinus,id:6428,x:32206,y:33659,varname:node_6428,prsc:2|IN-7229-OUT;n:type:ShaderForge.SFN_ComponentMask,id:2212,x:32693,y:33593,varname:node_2212,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-892-OUT;n:type:ShaderForge.SFN_Multiply,id:7642,x:32358,y:33742,varname:node_7642,prsc:2|A-6428-OUT,B-752-OUT;n:type:ShaderForge.SFN_Vector1,id:752,x:32166,y:33828,varname:node_752,prsc:2,v1:0.6;n:type:ShaderForge.SFN_Add,id:892,x:32528,y:33613,varname:node_892,prsc:2|A-5514-OUT,B-7642-OUT;n:type:ShaderForge.SFN_OneMinus,id:5514,x:32261,y:33396,varname:node_5514,prsc:2|IN-185-B;n:type:ShaderForge.SFN_Vector1,id:3164,x:32893,y:33465,varname:node_3164,prsc:2,v1:0.0015;n:type:ShaderForge.SFN_Color,id:7069,x:32893,y:33625,ptovrint:False,ptlb:ColorOutline,ptin:_ColorOutline,varname:node_7069,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.112576,c2:1,c3:0.08088237,c4:1;proporder:3485-2877-185-9992-8492-7069;pass:END;sub:END;*/

Shader "Shader Forge/SH_Canister" {
    Properties {
        _Normal ("Normal", 2D) = "white" {}
        _Color ("Color", 2D) = "white" {}
        _Mask ("Mask", 2D) = "white" {}
        _EmiColor ("EmiColor", Color) = (0.5,0.5,0.5,1)
        _EmissivePower ("EmissivePower", Range(0, 5)) = 0
        _ColorOutline ("ColorOutline", Color) = (0.112576,1,0.08088237,1)
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
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
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _ColorOutline;
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
                o.pos = mul(UNITY_MATRIX_MVP, float4(v.vertex.xyz + v.normal*0.0015,1) );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                return fixed4(_ColorOutline.rgb,0);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
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
            uniform float4 _LightColor0;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            uniform sampler2D _Color; uniform float4 _Color_ST;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform float4 _EmiColor;
            uniform float _EmissivePower;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 _Normal_var = tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 _Color_var = tex2D(_Color,TRANSFORM_TEX(i.uv0, _Color));
                float3 diffuseColor = _Color_var.rgb;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float4 _Mask_var = tex2D(_Mask,TRANSFORM_TEX(i.uv0, _Mask));
                float node_2455 = ((1.0 - _Mask_var.g)*_Mask_var.b);
                float3 node_7229 = lerp(float3(node_2455,node_2455,node_2455),_EmiColor.rgb,node_2455);
                float3 emissive = (node_7229*_EmissivePower);
/// Final Color:
                float3 finalColor = diffuse + emissive;
                fixed4 finalRGBA = fixed4(finalColor,((1.0 - _Mask_var.b)+((1.0 - node_7229)*0.6)).r);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            uniform sampler2D _Color; uniform float4 _Color_ST;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform float4 _EmiColor;
            uniform float _EmissivePower;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 _Normal_var = tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _Color_var = tex2D(_Color,TRANSFORM_TEX(i.uv0, _Color));
                float3 diffuseColor = _Color_var.rgb;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                float4 _Mask_var = tex2D(_Mask,TRANSFORM_TEX(i.uv0, _Mask));
                float node_2455 = ((1.0 - _Mask_var.g)*_Mask_var.b);
                float3 node_7229 = lerp(float3(node_2455,node_2455,node_2455),_EmiColor.rgb,node_2455);
                fixed4 finalRGBA = fixed4(finalColor * ((1.0 - _Mask_var.b)+((1.0 - node_7229)*0.6)).r,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
