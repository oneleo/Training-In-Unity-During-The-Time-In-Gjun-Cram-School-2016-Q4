// Shader created with Shader Forge v1.27 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.27;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True;n:type:ShaderForge.SFN_Final,id:4795,x:30691,y:31961,varname:node_4795,prsc:2|emission-2393-OUT;n:type:ShaderForge.SFN_Tex2d,id:6074,x:29384,y:32631,varname:_MainTex,prsc:2,tex:e8d9d01e14b1fa44fa380f458876a4fe,ntxv:0,isnm:False|UVIN-8530-OUT,TEX-7773-TEX;n:type:ShaderForge.SFN_Multiply,id:2393,x:30380,y:32271,varname:node_2393,prsc:2|A-2053-RGB,B-3169-OUT,C-5639-OUT;n:type:ShaderForge.SFN_VertexColor,id:2053,x:30039,y:32210,varname:node_2053,prsc:2;n:type:ShaderForge.SFN_Color,id:797,x:29592,y:32849,ptovrint:True,ptlb:glow_color,ptin:_TintColor,varname:_TintColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5882353,c2:0.778499,c3:1,c4:1;n:type:ShaderForge.SFN_Slider,id:5639,x:29847,y:32806,ptovrint:False,ptlb:glow_strength,ptin:_glow_strength,varname:node_5639,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.5,cur:3.783269,max:8;n:type:ShaderForge.SFN_Multiply,id:3169,x:30018,y:32328,varname:node_3169,prsc:2|A-863-OUT,B-797-RGB;n:type:ShaderForge.SFN_Multiply,id:863,x:29618,y:32363,varname:node_863,prsc:2|A-7903-RGB,B-6074-RGB;n:type:ShaderForge.SFN_Tex2dAsset,id:7773,x:29161,y:32804,ptovrint:False,ptlb:glowLine_tex,ptin:_glowLine_tex,varname:node_7773,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:e8d9d01e14b1fa44fa380f458876a4fe,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:7903,x:29551,y:32097,ptovrint:False,ptlb:edgefade,ptin:_edgefade,varname:node_7903,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:a304aaad6a11ede4abbafeaa4c96173d,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Append,id:8530,x:29006,y:32486,varname:node_8530,prsc:2|A-977-U,B-5314-OUT;n:type:ShaderForge.SFN_Lerp,id:5314,x:27562,y:31721,varname:node_5314,prsc:2|A-977-V,B-3334-OUT,T-5307-OUT;n:type:ShaderForge.SFN_TexCoord,id:977,x:28133,y:31455,varname:node_977,prsc:2,uv:0;n:type:ShaderForge.SFN_Add,id:3334,x:27838,y:31719,varname:node_3334,prsc:2|A-977-V,B-1599-RGB;n:type:ShaderForge.SFN_Slider,id:5307,x:27772,y:32966,ptovrint:False,ptlb:noise_strength,ptin:_noise_strength,varname:node_5307,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.3474413,max:1;n:type:ShaderForge.SFN_Tex2d,id:1599,x:28193,y:31698,ptovrint:False,ptlb:noise,ptin:_noise,varname:node_1599,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:False|UVIN-6941-UVOUT;n:type:ShaderForge.SFN_Panner,id:6941,x:28933,y:32254,varname:node_6941,prsc:2,spu:0,spv:-1|UVIN-3131-UVOUT,DIST-5785-OUT;n:type:ShaderForge.SFN_TexCoord,id:3131,x:28843,y:31423,varname:node_3131,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:5785,x:28753,y:31784,varname:node_5785,prsc:2|A-356-OUT,B-2132-T;n:type:ShaderForge.SFN_Time,id:2132,x:29044,y:32010,varname:node_2132,prsc:2;n:type:ShaderForge.SFN_Slider,id:356,x:28994,y:31786,ptovrint:False,ptlb:panner,ptin:_panner,varname:node_356,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0.4351848,max:1;proporder:797-5639-7773-7903-5307-1599-356;pass:END;sub:END;*/

Shader "Shader Forge/Electrical" {
    Properties {
        _TintColor ("glow_color", Color) = (0.5882353,0.778499,1,1)
        _glow_strength ("glow_strength", Range(0.5, 8)) = 3.783269
        _glowLine_tex ("glowLine_tex", 2D) = "white" {}
        _edgefade ("edgefade", 2D) = "white" {}
        _noise_strength ("noise_strength", Range(0, 1)) = 0.3474413
        _noise ("noise", 2D) = "bump" {}
        _panner ("panner", Range(-1, 1)) = 0.4351848
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
            uniform float4 _TintColor;
            uniform float _glow_strength;
            uniform sampler2D _glowLine_tex; uniform float4 _glowLine_tex_ST;
            uniform sampler2D _edgefade; uniform float4 _edgefade_ST;
            uniform float _noise_strength;
            uniform sampler2D _noise; uniform float4 _noise_ST;
            uniform float _panner;
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
                float4 _edgefade_var = tex2D(_edgefade,TRANSFORM_TEX(i.uv0, _edgefade));
                float4 node_2132 = _Time + _TimeEditor;
                float2 node_6941 = (i.uv0+(_panner*node_2132.g)*float2(0,-1));
                float4 _noise_var = tex2D(_noise,TRANSFORM_TEX(node_6941, _noise));
                float4 node_8530 = float4(i.uv0.r,lerp(float3(i.uv0.g,i.uv0.g,i.uv0.g),(i.uv0.g+_noise_var.rgb),_noise_strength));
                float4 _MainTex = tex2D(_glowLine_tex,TRANSFORM_TEX(node_8530, _glowLine_tex));
                float3 emissive = (i.vertexColor.rgb*((_edgefade_var.rgb*_MainTex.rgb)*_TintColor.rgb)*_glow_strength);
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
