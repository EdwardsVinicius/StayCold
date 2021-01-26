// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:True,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:False,rfrpn:Refraction,coma:15,ufog:True,aust:False,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:34607,y:33024,varname:node_3138,prsc:2|emission-8658-OUT,voffset-9496-OUT;n:type:ShaderForge.SFN_Color,id:5903,x:32445,y:32766,ptovrint:False,ptlb:Deph0,ptin:_Deph0,varname:_Color_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.2431373,c2:0.8431373,c3:0.8,c4:1;n:type:ShaderForge.SFN_Color,id:8258,x:32183,y:32764,ptovrint:False,ptlb:Depth1,ptin:_Depth1,varname:node_8258,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.2901961,c2:0.4509804,c3:0.7176471,c4:1;n:type:ShaderForge.SFN_Lerp,id:4177,x:32689,y:32913,varname:node_4177,prsc:2|A-5903-RGB,B-8455-OUT,T-238-OUT;n:type:ShaderForge.SFN_DepthBlend,id:238,x:32445,y:33124,varname:node_238,prsc:2|DIST-1521-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1521,x:31541,y:33246,ptovrint:False,ptlb: ColorsPosition,ptin:_ColorsPosition,varname:node_1521,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Lerp,id:8455,x:32473,y:32962,varname:node_8455,prsc:2|A-8258-RGB,B-8783-RGB,T-9184-OUT;n:type:ShaderForge.SFN_DepthBlend,id:9184,x:32090,y:33092,varname:node_9184,prsc:2|DIST-6555-OUT;n:type:ShaderForge.SFN_Color,id:8783,x:32183,y:32947,ptovrint:False,ptlb:Depth2,ptin:_Depth2,varname:node_8783,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.1803922,c2:0.2117647,c3:0.4352941,c4:1;n:type:ShaderForge.SFN_Add,id:6555,x:32012,y:33337,varname:node_6555,prsc:2|A-1521-OUT,B-173-OUT;n:type:ShaderForge.SFN_ValueProperty,id:173,x:31487,y:33109,ptovrint:False,ptlb:COlorsPosition1,ptin:_COlorsPosition1,varname:node_173,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Lerp,id:4898,x:33504,y:32929,varname:node_4898,prsc:2|A-4177-OUT,B-8747-RGB,T-695-OUT;n:type:ShaderForge.SFN_Color,id:8747,x:32603,y:32500,ptovrint:False,ptlb:FresnelColor,ptin:_FresnelColor,varname:node_8747,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.4485582,c2:0.9056604,c3:0.8727969,c4:1;n:type:ShaderForge.SFN_Fresnel,id:695,x:32630,y:32683,varname:node_695,prsc:2|EXP-6629-OUT;n:type:ShaderForge.SFN_Slider,id:6629,x:32241,y:32600,ptovrint:False,ptlb:FresnelExponent,ptin:_FresnelExponent,varname:node_6629,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:10,max:10;n:type:ShaderForge.SFN_Multiply,id:1164,x:32681,y:34514,varname:node_1164,prsc:2|A-904-B,B-7491-OUT;n:type:ShaderForge.SFN_Multiply,id:7491,x:32456,y:34613,varname:node_7491,prsc:2|A-1911-OUT,B-6192-OUT;n:type:ShaderForge.SFN_Tex2d,id:904,x:32340,y:34376,varname:node_904,prsc:2,tex:bfa4d4c3e67527f4da5d64d649289f36,ntxv:3,isnm:False|TEX-6667-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:6667,x:30451,y:33245,ptovrint:False,ptlb:WavesNormal,ptin:_WavesNormal,varname:node_6667,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:bfa4d4c3e67527f4da5d64d649289f36,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Slider,id:1911,x:32046,y:34633,ptovrint:False,ptlb:WavesAmplitude,ptin:_WavesAmplitude,varname:node_1911,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:10,max:10;n:type:ShaderForge.SFN_Vector1,id:6192,x:32218,y:34765,varname:node_6192,prsc:2,v1:30;n:type:ShaderForge.SFN_Time,id:7810,x:32475,y:34118,varname:node_7810,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:8595,x:32490,y:34325,ptovrint:False,ptlb:WaveSpeed,ptin:_WaveSpeed,varname:node_8595,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:5478,x:32681,y:34272,varname:node_5478,prsc:2|A-7810-T,B-8595-OUT;n:type:ShaderForge.SFN_Subtract,id:5099,x:32952,y:34308,varname:node_5099,prsc:2|A-5478-OUT,B-1164-OUT;n:type:ShaderForge.SFN_Sin,id:5602,x:33120,y:34308,varname:node_5602,prsc:2|IN-5099-OUT;n:type:ShaderForge.SFN_Multiply,id:5390,x:33319,y:34308,varname:node_5390,prsc:2|A-5602-OUT,B-9228-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9228,x:33150,y:34502,ptovrint:False,ptlb:WaveInstensity,ptin:_WaveInstensity,varname:node_9228,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:1587,x:33525,y:34295,varname:node_1587,prsc:2|A-6893-OUT,B-5390-OUT;n:type:ShaderForge.SFN_NormalVector,id:6893,x:33296,y:34128,prsc:2,pt:False;n:type:ShaderForge.SFN_SwitchProperty,id:9496,x:33924,y:34212,ptovrint:False,ptlb:VertexOffset,ptin:_VertexOffset,varname:node_9496,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True|A-3621-OUT,B-1587-OUT;n:type:ShaderForge.SFN_Vector1,id:3621,x:33689,y:34132,varname:node_3621,prsc:2,v1:0;n:type:ShaderForge.SFN_DepthBlend,id:6592,x:32829,y:33724,varname:node_6592,prsc:2|DIST-8231-OUT;n:type:ShaderForge.SFN_OneMinus,id:9388,x:33508,y:33479,varname:node_9388,prsc:2|IN-8752-OUT;n:type:ShaderForge.SFN_Multiply,id:4596,x:33670,y:33479,varname:node_4596,prsc:2|A-9388-OUT,B-4985-OUT;n:type:ShaderForge.SFN_Slider,id:4985,x:33549,y:33765,ptovrint:False,ptlb:MAinFoamOpacity,ptin:_MAinFoamOpacity,varname:node_4985,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.9007923,max:1;n:type:ShaderForge.SFN_Color,id:9474,x:32742,y:33260,ptovrint:False,ptlb:FoamColor,ptin:_FoamColor,varname:node_9474,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:5897,x:33836,y:33375,varname:node_5897,prsc:2|A-9474-RGB,B-4596-OUT;n:type:ShaderForge.SFN_RemapRange,id:4988,x:32451,y:33585,varname:node_4988,prsc:2,frmn:0,frmx:1,tomn:0.2,tomx:0.3|IN-5602-OUT;n:type:ShaderForge.SFN_Multiply,id:8231,x:32650,y:33724,varname:node_8231,prsc:2|A-4988-OUT,B-9405-OUT;n:type:ShaderForge.SFN_Multiply,id:9405,x:32448,y:33919,varname:node_9405,prsc:2|A-9662-R,B-6373-OUT;n:type:ShaderForge.SFN_Slider,id:6373,x:32018,y:34087,ptovrint:False,ptlb:Faom Distance,ptin:_FaomDistance,varname:node_6373,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:8.807014,max:10;n:type:ShaderForge.SFN_Tex2d,id:9662,x:32049,y:33769,varname:node_9662,prsc:2,tex:40c0bdd1723ac62428469d06c0ebba28,ntxv:0,isnm:False|UVIN-9578-OUT,TEX-339-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:339,x:30943,y:34278,ptovrint:False,ptlb:FaomTexture,ptin:_FaomTexture,varname:node_339,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:40c0bdd1723ac62428469d06c0ebba28,ntxv:3,isnm:False;n:type:ShaderForge.SFN_TexCoord,id:4897,x:31348,y:33742,varname:node_4897,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:330,x:31569,y:33771,varname:node_330,prsc:2|A-4897-UVOUT,B-1228-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1228,x:31348,y:33967,ptovrint:False,ptlb:FoamScale,ptin:_FoamScale,varname:node_1228,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:5;n:type:ShaderForge.SFN_Time,id:3751,x:31348,y:33521,varname:node_3751,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:4214,x:31348,y:33429,ptovrint:False,ptlb:FoamSpeed,ptin:_FoamSpeed,varname:node_4214,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.2;n:type:ShaderForge.SFN_Multiply,id:4690,x:31569,y:33521,varname:node_4690,prsc:2|A-4214-OUT,B-3751-T;n:type:ShaderForge.SFN_Add,id:9578,x:31772,y:33598,varname:node_9578,prsc:2|A-4690-OUT,B-330-OUT;n:type:ShaderForge.SFN_Add,id:8658,x:34250,y:33073,varname:node_8658,prsc:2|A-3269-OUT,B-5897-OUT,C-5948-OUT;n:type:ShaderForge.SFN_Power,id:1937,x:33004,y:33724,varname:node_1937,prsc:2|VAL-6592-OUT,EXP-8795-OUT;n:type:ShaderForge.SFN_Vector1,id:8795,x:32829,y:33903,varname:node_8795,prsc:2,v1:15;n:type:ShaderForge.SFN_Clamp01,id:8071,x:33173,y:33724,varname:node_8071,prsc:2|IN-1937-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:8752,x:33342,y:33642,ptovrint:False,ptlb:MainFoamPower,ptin:_MainFoamPower,varname:node_8752,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True|A-6592-OUT,B-8071-OUT;n:type:ShaderForge.SFN_Tex2d,id:688,x:31296,y:34340,varname:node_688,prsc:2,tex:40c0bdd1723ac62428469d06c0ebba28,ntxv:0,isnm:False|UVIN-3805-OUT,TEX-339-TEX;n:type:ShaderForge.SFN_Multiply,id:6727,x:31560,y:34337,varname:node_6727,prsc:2|A-688-R,B-8703-OUT;n:type:ShaderForge.SFN_Slider,id:8703,x:31190,y:34553,ptovrint:False,ptlb:SecondaryFOamIntensity,ptin:_SecondaryFOamIntensity,varname:node_8703,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2251258,max:1;n:type:ShaderForge.SFN_Slider,id:7777,x:30981,y:34836,ptovrint:False,ptlb:SecondaryFoamDIstance,ptin:_SecondaryFoamDIstance,varname:node_7777,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2,max:10;n:type:ShaderForge.SFN_DepthBlend,id:436,x:31311,y:34836,varname:node_436,prsc:2|DIST-7777-OUT;n:type:ShaderForge.SFN_OneMinus,id:113,x:31518,y:34836,varname:node_113,prsc:2|IN-436-OUT;n:type:ShaderForge.SFN_Multiply,id:90,x:31770,y:34454,varname:node_90,prsc:2|A-113-OUT,B-6727-OUT;n:type:ShaderForge.SFN_Multiply,id:5948,x:33080,y:33463,varname:node_5948,prsc:2|A-9474-RGB,B-90-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8964,x:30472,y:34999,ptovrint:False,ptlb:SecondaryFoamScale,ptin:_SecondaryFoamScale,varname:_FoamScale_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:5;n:type:ShaderForge.SFN_TexCoord,id:6731,x:30472,y:34774,varname:node_6731,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Time,id:8838,x:30472,y:34553,varname:node_8838,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:7557,x:30472,y:34461,ptovrint:False,ptlb:SecondaryFoamSpeed,ptin:_SecondaryFoamSpeed,varname:_FoamSpeed_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.2;n:type:ShaderForge.SFN_Multiply,id:7085,x:30693,y:34553,varname:node_7085,prsc:2|A-7557-OUT,B-8838-T;n:type:ShaderForge.SFN_Multiply,id:5144,x:30693,y:34803,varname:node_5144,prsc:2|A-6731-UVOUT,B-8964-OUT;n:type:ShaderForge.SFN_Add,id:3805,x:30896,y:34630,varname:node_3805,prsc:2|A-7085-OUT,B-5144-OUT;n:type:ShaderForge.SFN_Tex2d,id:303,x:32683,y:31952,varname:node_303,prsc:2,tex:bfa4d4c3e67527f4da5d64d649289f36,ntxv:0,isnm:False|UVIN-2764-UVOUT,TEX-6667-TEX;n:type:ShaderForge.SFN_TexCoord,id:9370,x:32122,y:31945,varname:node_9370,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:3674,x:32326,y:31945,varname:node_3674,prsc:2|A-9370-UVOUT,B-7533-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7533,x:32101,y:32176,ptovrint:False,ptlb:TurbulanceScale,ptin:_TurbulanceScale,varname:node_7533,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Panner,id:2764,x:32506,y:31945,varname:node_2764,prsc:2,spu:0.01,spv:0.01|UVIN-3674-OUT;n:type:ShaderForge.SFN_Multiply,id:5539,x:33315,y:31991,varname:node_5539,prsc:2|A-303-G,B-2217-OUT;n:type:ShaderForge.SFN_Slider,id:2217,x:32580,y:32154,ptovrint:False,ptlb:TurbulanceDistancionIntensity,ptin:_TurbulanceDistancionIntensity,varname:node_2217,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.968979,max:6;n:type:ShaderForge.SFN_Set,id:6186,x:33452,y:34486,varname:Waves,prsc:2|IN-5390-OUT;n:type:ShaderForge.SFN_Slider,id:1210,x:32931,y:31830,ptovrint:False,ptlb:Wave Distortion Instesity,ptin:_WaveDistortionInstesity,varname:node_1210,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:4;n:type:ShaderForge.SFN_Get,id:4519,x:33010,y:31691,varname:node_4519,prsc:2|IN-6186-OUT;n:type:ShaderForge.SFN_Multiply,id:8582,x:33305,y:31718,varname:node_8582,prsc:2|A-4519-OUT,B-1210-OUT;n:type:ShaderForge.SFN_Add,id:7175,x:33611,y:31877,varname:node_7175,prsc:2|A-8582-OUT,B-5539-OUT;n:type:ShaderForge.SFN_Set,id:5571,x:33813,y:31867,varname:Turbulence,prsc:2|IN-7175-OUT;n:type:ShaderForge.SFN_Tex2d,id:4097,x:33160,y:32288,ptovrint:False,ptlb:ReflectionTxt,ptin:_ReflectionTxt,varname:node_4097,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Slider,id:2766,x:33003,y:32516,ptovrint:False,ptlb:Reflection Intesity,ptin:_ReflectionIntesity,varname:node_2766,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:3;n:type:ShaderForge.SFN_Multiply,id:6630,x:33450,y:32400,varname:node_6630,prsc:2|A-4097-RGB,B-2766-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:8403,x:33678,y:32419,ptovrint:False,ptlb:Realtime Refletcions,ptin:_RealtimeRefletcions,varname:node_8403,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True|A-5202-OUT,B-6630-OUT;n:type:ShaderForge.SFN_Vector1,id:5202,x:33500,y:32257,varname:node_5202,prsc:2,v1:0;n:type:ShaderForge.SFN_Blend,id:3269,x:34007,y:32670,varname:node_3269,prsc:2,blmd:10,clmp:True|SRC-8403-OUT,DST-4898-OUT;proporder:5903-8258-8783-1521-173-8747-6629-9496-1911-9228-8595-6667-339-8752-9474-4985-6373-1228-4214-8703-7777-8964-7557-4097-2766-8403;pass:END;sub:END;*/

Shader "VaxKun/WaterColor" {
    Properties {
        _Deph0 ("Deph0", Color) = (0.2431373,0.8431373,0.8,1)
        _Depth1 ("Depth1", Color) = (0.2901961,0.4509804,0.7176471,1)
        _Depth2 ("Depth2", Color) = (0.1803922,0.2117647,0.4352941,1)
        _ColorsPosition (" ColorsPosition", Float ) = 1
        _COlorsPosition1 ("COlorsPosition1", Float ) = 1
        _FresnelColor ("FresnelColor", Color) = (0.4485582,0.9056604,0.8727969,1)
        _FresnelExponent ("FresnelExponent", Range(0, 10)) = 10
        [MaterialToggle] _VertexOffset ("VertexOffset", Float ) = 0
        _WavesAmplitude ("WavesAmplitude", Range(0, 10)) = 10
        _WaveInstensity ("WaveInstensity", Float ) = 1
        _WaveSpeed ("WaveSpeed", Float ) = 1
        _WavesNormal ("WavesNormal", 2D) = "bump" {}
        _FaomTexture ("FaomTexture", 2D) = "bump" {}
        [MaterialToggle] _MainFoamPower ("MainFoamPower", Float ) = 0
        _FoamColor ("FoamColor", Color) = (1,1,1,1)
        _MAinFoamOpacity ("MAinFoamOpacity", Range(0, 1)) = 0.9007923
        _FaomDistance ("Faom Distance", Range(0, 10)) = 8.807014
        _FoamScale ("FoamScale", Float ) = 5
        _FoamSpeed ("FoamSpeed", Float ) = 0.2
        _SecondaryFOamIntensity ("SecondaryFOamIntensity", Range(0, 1)) = 0.2251258
        _SecondaryFoamDIstance ("SecondaryFoamDIstance", Range(0, 10)) = 2
        _SecondaryFoamScale ("SecondaryFoamScale", Float ) = 5
        _SecondaryFoamSpeed ("SecondaryFoamSpeed", Float ) = 0.2
        _ReflectionTxt ("ReflectionTxt", 2D) = "white" {}
        _ReflectionIntesity ("Reflection Intesity", Range(0, 3)) = 1
        [MaterialToggle] _RealtimeRefletcions ("Realtime Refletcions", Float ) = 0
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
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma target 3.0
            uniform sampler2D _CameraDepthTexture;
            uniform sampler2D _WavesNormal; uniform float4 _WavesNormal_ST;
            uniform sampler2D _FaomTexture; uniform float4 _FaomTexture_ST;
            uniform sampler2D _ReflectionTxt; uniform float4 _ReflectionTxt_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _Deph0)
                UNITY_DEFINE_INSTANCED_PROP( float4, _Depth1)
                UNITY_DEFINE_INSTANCED_PROP( float, _ColorsPosition)
                UNITY_DEFINE_INSTANCED_PROP( float4, _Depth2)
                UNITY_DEFINE_INSTANCED_PROP( float, _COlorsPosition1)
                UNITY_DEFINE_INSTANCED_PROP( float4, _FresnelColor)
                UNITY_DEFINE_INSTANCED_PROP( float, _FresnelExponent)
                UNITY_DEFINE_INSTANCED_PROP( float, _WavesAmplitude)
                UNITY_DEFINE_INSTANCED_PROP( float, _WaveSpeed)
                UNITY_DEFINE_INSTANCED_PROP( float, _WaveInstensity)
                UNITY_DEFINE_INSTANCED_PROP( fixed, _VertexOffset)
                UNITY_DEFINE_INSTANCED_PROP( float, _MAinFoamOpacity)
                UNITY_DEFINE_INSTANCED_PROP( float4, _FoamColor)
                UNITY_DEFINE_INSTANCED_PROP( float, _FaomDistance)
                UNITY_DEFINE_INSTANCED_PROP( float, _FoamScale)
                UNITY_DEFINE_INSTANCED_PROP( float, _FoamSpeed)
                UNITY_DEFINE_INSTANCED_PROP( fixed, _MainFoamPower)
                UNITY_DEFINE_INSTANCED_PROP( float, _SecondaryFOamIntensity)
                UNITY_DEFINE_INSTANCED_PROP( float, _SecondaryFoamDIstance)
                UNITY_DEFINE_INSTANCED_PROP( float, _SecondaryFoamScale)
                UNITY_DEFINE_INSTANCED_PROP( float, _SecondaryFoamSpeed)
                UNITY_DEFINE_INSTANCED_PROP( float, _ReflectionIntesity)
                UNITY_DEFINE_INSTANCED_PROP( fixed, _RealtimeRefletcions)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 projPos : TEXCOORD3;
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_7810 = _Time;
                float _WaveSpeed_var = UNITY_ACCESS_INSTANCED_PROP( Props, _WaveSpeed );
                float3 node_904 = UnpackNormal(tex2Dlod(_WavesNormal,float4(TRANSFORM_TEX(o.uv0, _WavesNormal),0.0,0)));
                float _WavesAmplitude_var = UNITY_ACCESS_INSTANCED_PROP( Props, _WavesAmplitude );
                float node_5602 = sin(((node_7810.g*_WaveSpeed_var)-(node_904.b*(_WavesAmplitude_var*30.0))));
                float _WaveInstensity_var = UNITY_ACCESS_INSTANCED_PROP( Props, _WaveInstensity );
                float node_5390 = (node_5602*_WaveInstensity_var);
                float3 _VertexOffset_var = lerp( 0.0, (v.normal*node_5390), UNITY_ACCESS_INSTANCED_PROP( Props, _VertexOffset ) );
                v.vertex.xyz += _VertexOffset_var;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
////// Lighting:
////// Emissive:
                float4 _ReflectionTxt_var = tex2D(_ReflectionTxt,TRANSFORM_TEX(i.uv0, _ReflectionTxt));
                float _ReflectionIntesity_var = UNITY_ACCESS_INSTANCED_PROP( Props, _ReflectionIntesity );
                float3 _RealtimeRefletcions_var = lerp( 0.0, (_ReflectionTxt_var.rgb*_ReflectionIntesity_var), UNITY_ACCESS_INSTANCED_PROP( Props, _RealtimeRefletcions ) );
                float4 _Deph0_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Deph0 );
                float4 _Depth1_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Depth1 );
                float4 _Depth2_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Depth2 );
                float _ColorsPosition_var = UNITY_ACCESS_INSTANCED_PROP( Props, _ColorsPosition );
                float _COlorsPosition1_var = UNITY_ACCESS_INSTANCED_PROP( Props, _COlorsPosition1 );
                float4 _FresnelColor_var = UNITY_ACCESS_INSTANCED_PROP( Props, _FresnelColor );
                float _FresnelExponent_var = UNITY_ACCESS_INSTANCED_PROP( Props, _FresnelExponent );
                float4 _FoamColor_var = UNITY_ACCESS_INSTANCED_PROP( Props, _FoamColor );
                float4 node_7810 = _Time;
                float _WaveSpeed_var = UNITY_ACCESS_INSTANCED_PROP( Props, _WaveSpeed );
                float3 node_904 = UnpackNormal(tex2D(_WavesNormal,TRANSFORM_TEX(i.uv0, _WavesNormal)));
                float _WavesAmplitude_var = UNITY_ACCESS_INSTANCED_PROP( Props, _WavesAmplitude );
                float node_5602 = sin(((node_7810.g*_WaveSpeed_var)-(node_904.b*(_WavesAmplitude_var*30.0))));
                float _FoamSpeed_var = UNITY_ACCESS_INSTANCED_PROP( Props, _FoamSpeed );
                float4 node_3751 = _Time;
                float _FoamScale_var = UNITY_ACCESS_INSTANCED_PROP( Props, _FoamScale );
                float2 node_9578 = ((_FoamSpeed_var*node_3751.g)+(i.uv0*_FoamScale_var));
                float4 node_9662 = tex2D(_FaomTexture,TRANSFORM_TEX(node_9578, _FaomTexture));
                float _FaomDistance_var = UNITY_ACCESS_INSTANCED_PROP( Props, _FaomDistance );
                float node_6592 = saturate((sceneZ-partZ)/((node_5602*0.1+0.2)*(node_9662.r*_FaomDistance_var)));
                float _MainFoamPower_var = lerp( node_6592, saturate(pow(node_6592,15.0)), UNITY_ACCESS_INSTANCED_PROP( Props, _MainFoamPower ) );
                float _MAinFoamOpacity_var = UNITY_ACCESS_INSTANCED_PROP( Props, _MAinFoamOpacity );
                float _SecondaryFoamDIstance_var = UNITY_ACCESS_INSTANCED_PROP( Props, _SecondaryFoamDIstance );
                float _SecondaryFoamSpeed_var = UNITY_ACCESS_INSTANCED_PROP( Props, _SecondaryFoamSpeed );
                float4 node_8838 = _Time;
                float _SecondaryFoamScale_var = UNITY_ACCESS_INSTANCED_PROP( Props, _SecondaryFoamScale );
                float2 node_3805 = ((_SecondaryFoamSpeed_var*node_8838.g)+(i.uv0*_SecondaryFoamScale_var));
                float4 node_688 = tex2D(_FaomTexture,TRANSFORM_TEX(node_3805, _FaomTexture));
                float _SecondaryFOamIntensity_var = UNITY_ACCESS_INSTANCED_PROP( Props, _SecondaryFOamIntensity );
                float3 emissive = (saturate(( lerp(lerp(_Deph0_var.rgb,lerp(_Depth1_var.rgb,_Depth2_var.rgb,saturate((sceneZ-partZ)/(_ColorsPosition_var+_COlorsPosition1_var))),saturate((sceneZ-partZ)/_ColorsPosition_var)),_FresnelColor_var.rgb,pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelExponent_var)) > 0.5 ? (1.0-(1.0-2.0*(lerp(lerp(_Deph0_var.rgb,lerp(_Depth1_var.rgb,_Depth2_var.rgb,saturate((sceneZ-partZ)/(_ColorsPosition_var+_COlorsPosition1_var))),saturate((sceneZ-partZ)/_ColorsPosition_var)),_FresnelColor_var.rgb,pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelExponent_var))-0.5))*(1.0-_RealtimeRefletcions_var)) : (2.0*lerp(lerp(_Deph0_var.rgb,lerp(_Depth1_var.rgb,_Depth2_var.rgb,saturate((sceneZ-partZ)/(_ColorsPosition_var+_COlorsPosition1_var))),saturate((sceneZ-partZ)/_ColorsPosition_var)),_FresnelColor_var.rgb,pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelExponent_var))*_RealtimeRefletcions_var) ))+(_FoamColor_var.rgb*((1.0 - _MainFoamPower_var)*_MAinFoamOpacity_var))+(_FoamColor_var.rgb*((1.0 - saturate((sceneZ-partZ)/_SecondaryFoamDIstance_var))*(node_688.r*_SecondaryFOamIntensity_var))));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Back
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma target 3.0
            uniform sampler2D _WavesNormal; uniform float4 _WavesNormal_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _WavesAmplitude)
                UNITY_DEFINE_INSTANCED_PROP( float, _WaveSpeed)
                UNITY_DEFINE_INSTANCED_PROP( float, _WaveInstensity)
                UNITY_DEFINE_INSTANCED_PROP( fixed, _VertexOffset)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float2 uv0 : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_7810 = _Time;
                float _WaveSpeed_var = UNITY_ACCESS_INSTANCED_PROP( Props, _WaveSpeed );
                float3 node_904 = UnpackNormal(tex2Dlod(_WavesNormal,float4(TRANSFORM_TEX(o.uv0, _WavesNormal),0.0,0)));
                float _WavesAmplitude_var = UNITY_ACCESS_INSTANCED_PROP( Props, _WavesAmplitude );
                float node_5602 = sin(((node_7810.g*_WaveSpeed_var)-(node_904.b*(_WavesAmplitude_var*30.0))));
                float _WaveInstensity_var = UNITY_ACCESS_INSTANCED_PROP( Props, _WaveInstensity );
                float node_5390 = (node_5602*_WaveInstensity_var);
                float3 _VertexOffset_var = lerp( 0.0, (v.normal*node_5390), UNITY_ACCESS_INSTANCED_PROP( Props, _VertexOffset ) );
                v.vertex.xyz += _VertexOffset_var;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
