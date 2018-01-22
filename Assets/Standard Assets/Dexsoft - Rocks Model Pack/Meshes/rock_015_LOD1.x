xof 0303txt 0032

// DirectX 9.0 file
// Creator: Ultimate Unwrap3D Pro v3.22
// Website: http://www.unwrap3d.com
// Time: Fri Mar 12 17:20:14 2010

// Start of Templates

template VertexDuplicationIndices {
 <b8d65549-d7c9-4995-89cf-53a9a8b031e3>
 DWORD nIndices;
 DWORD nOriginalVertices;
 array DWORD indices[nIndices];
}

template FVFData {
 <b6e70a0e-8ef9-4e83-94ad-ecc8b0c04897>
 DWORD dwFVF;
 DWORD nDWords;
 array DWORD data[nDWords];
}

template Header {
 <3D82AB43-62DA-11cf-AB39-0020AF71E433>
 WORD major;
 WORD minor;
 DWORD flags;
}

template Vector {
 <3D82AB5E-62DA-11cf-AB39-0020AF71E433>
 FLOAT x;
 FLOAT y;
 FLOAT z;
}

template Coords2d {
 <F6F23F44-7686-11cf-8F52-0040333594A3>
 FLOAT u;
 FLOAT v;
}

template Matrix4x4 {
 <F6F23F45-7686-11cf-8F52-0040333594A3>
 array FLOAT matrix[16];
}

template ColorRGBA {
 <35FF44E0-6C7C-11cf-8F52-0040333594A3>
 FLOAT red;
 FLOAT green;
 FLOAT blue;
 FLOAT alpha;
}

template ColorRGB {
 <D3E16E81-7835-11cf-8F52-0040333594A3>
 FLOAT red;
 FLOAT green;
 FLOAT blue;
}

template IndexedColor {
 <1630B820-7842-11cf-8F52-0040333594A3>
 DWORD index;
 ColorRGBA indexColor;
}

template Material {
 <3D82AB4D-62DA-11cf-AB39-0020AF71E433>
 ColorRGBA faceColor;
 FLOAT power;
 ColorRGB specularColor;
 ColorRGB emissiveColor;
 [...]
}

template TextureFilename {
 <A42790E1-7810-11cf-8F52-0040333594A3>
 STRING filename;
}

template MeshFace {
 <3D82AB5F-62DA-11cf-AB39-0020AF71E433>
 DWORD nFaceVertexIndices;
 array DWORD faceVertexIndices[nFaceVertexIndices];
}

template MeshTextureCoords {
 <F6F23F40-7686-11cf-8F52-0040333594A3>
 DWORD nTextureCoords;
 array Coords2d textureCoords[nTextureCoords];
}

template MeshMaterialList {
 <F6F23F42-7686-11cf-8F52-0040333594A3>
 DWORD nMaterials;
 DWORD nFaceIndexes;
 array DWORD faceIndexes[nFaceIndexes];
 [Material]
}

template MeshNormals {
 <F6F23F43-7686-11cf-8F52-0040333594A3>
 DWORD nNormals;
 array Vector normals[nNormals];
 DWORD nFaceNormals;
 array MeshFace faceNormals[nFaceNormals];
}

template MeshVertexColors {
 <1630B821-7842-11cf-8F52-0040333594A3>
 DWORD nVertexColors;
 array IndexedColor vertexColors[nVertexColors];
}

template Mesh {
 <3D82AB44-62DA-11cf-AB39-0020AF71E433>
 DWORD nVertices;
 array Vector vertices[nVertices];
 DWORD nFaces;
 array MeshFace faces[nFaces];
 [...]
}

template FrameTransformMatrix {
 <F6F23F41-7686-11cf-8F52-0040333594A3>
 Matrix4x4 frameMatrix;
}

template Frame {
 <3D82AB46-62DA-11cf-AB39-0020AF71E433>
 [...]
}

template FloatKeys {
 <10DD46A9-775B-11cf-8F52-0040333594A3>
 DWORD nValues;
 array FLOAT values[nValues];
}

template TimedFloatKeys {
 <F406B180-7B3B-11cf-8F52-0040333594A3>
 DWORD time;
 FloatKeys tfkeys;
}

template AnimationKey {
 <10DD46A8-775B-11cf-8F52-0040333594A3>
 DWORD keyType;
 DWORD nKeys;
 array TimedFloatKeys keys[nKeys];
}

template AnimationOptions {
 <E2BF56C0-840F-11cf-8F52-0040333594A3>
 DWORD openclosed;
 DWORD positionquality;
}

template Animation {
 <3D82AB4F-62DA-11cf-AB39-0020AF71E433>
 [...]
}

template AnimationSet {
 <3D82AB50-62DA-11cf-AB39-0020AF71E433>
 [Animation]
}

template XSkinMeshHeader {
 <3CF169CE-FF7C-44ab-93C0-F78F62D172E2>
 WORD nMaxSkinWeightsPerVertex;
 WORD nMaxSkinWeightsPerFace;
 WORD nBones;
}

template SkinWeights {
 <6F0D123B-BAD2-4167-A0D0-80224F25FABB>
 STRING transformNodeName;
 DWORD nWeights;
 array DWORD vertexIndices[nWeights];
 array FLOAT weights[nWeights];
 Matrix4x4 matrixOffset;
}

template AnimTicksPerSecond {
 <9E415A43-7BA6-4a73-8743-B73D47E88476>
 DWORD AnimTicksPerSecond;
}

AnimTicksPerSecond {
 4800;
}

// Start of Frames

Frame rock_015_LOD1 {
   FrameTransformMatrix {
    1.000000, 0.000000, 0.000000, 0.000000,
    0.000000, 1.000000, 0.000000, 0.000000,
    0.000000, 0.000000, 1.000000, 0.000000,
    0.000000, 0.000000, 0.000000, 1.000000;;
   }

   Mesh rock_015_LOD1 {
    121;
    0.469760; -0.022847; 0.273700;,
    0.214580; 0.117964; 0.030227;,
    0.414599; 0.093914; 0.250266;,
    -0.011713; -0.007132; 0.157376;,
    0.227258; -0.029560; 0.454010;,
    0.206365; 0.122433; 0.400159;,
    0.251488; 0.204961; 0.121830;,
    0.282086; 0.240757; 0.280613;,
    0.031460; 0.115871; 0.178637;,
    0.214580; 0.117964; 0.030227;,
    0.211317; -0.001628; 0.005212;,
    -0.011713; -0.007132; 0.157376;,
    0.414599; 0.093914; 0.250266;,
    0.206365; 0.122433; 0.400159;,
    0.469760; -0.022847; 0.273700;,
    0.227258; -0.029560; 0.454010;,
    0.211317; -0.001628; 0.005212;,
    0.482883; -0.039145; 0.684957;,
    0.556262; -0.032649; 0.727854;,
    0.392575; 0.092166; 0.735064;,
    0.572794; 0.278226; 0.671589;,
    0.380487; 0.179423; 0.572279;,
    0.816583; 0.131611; 0.758149;,
    0.743249; -0.003614; 0.688457;,
    0.739868; 0.256047; 0.627312;,
    0.748546; 0.160618; 0.363118;,
    0.712385; 0.185406; 0.739556;,
    0.696822; 0.007145; 0.443596;,
    0.470051; -0.009599; 0.436861;,
    0.748546; 0.160618; 0.363118;,
    0.391859; 0.128449; 0.389166;,
    0.568027; 0.217712; 0.367327;,
    0.816583; 0.131611; 0.758149;,
    0.743249; -0.003614; 0.688457;,
    0.470051; -0.009599; 0.436861;,
    0.482883; -0.039145; 0.684957;,
    0.392575; 0.092166; 0.735064;,
    0.696822; 0.007145; 0.443596;,
    0.704648; 0.231324; 0.477065;,
    -0.399046; 0.001651; -0.018900;,
    -0.269497; 0.000000; 0.055442;,
    -0.363802; 0.168877; -0.061207;,
    -0.159184; 0.363949; -0.144920;,
    -0.338856; 0.299902; -0.226055;,
    0.065669; -0.001730; 0.002983;,
    -0.014296; 0.169886; -0.417444;,
    0.023713; 0.169085; -0.062588;,
    -0.058815; 0.245192; -0.071802;,
    -0.051178; 0.306472; -0.299802;,
    -0.014296; 0.169886; -0.417444;,
    -0.365355; 0.175639; -0.409147;,
    -0.172672; 0.313465; -0.368167;,
    0.001913; 0.000000; -0.435415;,
    -0.400627; -0.001952; -0.460392;,
    0.023713; 0.169085; -0.062588;,
    0.065669; -0.001730; 0.002983;,
    -0.363802; 0.168877; -0.061207;,
    -0.400627; -0.001952; -0.460392;,
    -0.399046; 0.001651; -0.018900;,
    0.001913; 0.000000; -0.435415;,
    -0.684129; 0.001313; 0.556955;,
    -0.661024; 0.111924; 0.570544;,
    -0.813831; 0.111076; 0.613003;,
    -0.822198; -0.019907; 0.298687;,
    -0.839346; 0.053385; 0.256426;,
    -0.615654; -0.011439; 0.380261;,
    -0.580975; 0.102256; 0.356365;,
    -0.661024; 0.111924; 0.570544;,
    -0.684129; 0.001313; 0.556955;,
    -0.580975; 0.102256; 0.356365;,
    -0.615654; -0.011439; 0.380261;,
    -0.839346; 0.053385; 0.256426;,
    -0.822198; -0.019907; 0.298687;,
    -0.949456; 0.102706; 0.506116;,
    -0.913945; -0.011285; 0.497502;,
    -0.733906; 0.270397; 0.406668;,
    -0.747571; 0.277021; 0.418179;,
    -0.949456; 0.102706; 0.506116;,
    -0.913945; -0.011285; 0.497502;,
    -0.549228; 0.013341; 0.586445;,
    -0.549068; -0.014511; 0.683319;,
    -0.477042; 0.104713; 0.656132;,
    -0.445420; 0.005889; 0.578451;,
    -0.549228; 0.013341; 0.586445;,
    -0.443279; -0.025214; 0.658654;,
    -0.445420; 0.005889; 0.578451;,
    -0.549068; -0.014511; 0.683319;,
    -0.443279; -0.025214; 0.658654;,
    0.871634; -0.006207; 0.314368;,
    0.934450; -0.027266; 0.220264;,
    0.894585; 0.054525; 0.304086;,
    0.760041; -0.042654; 0.131179;,
    0.694671; -0.005278; 0.234263;,
    0.847653; 0.116888; 0.184230;,
    0.934450; -0.027266; 0.220264;,
    0.760041; -0.042654; 0.131179;,
    0.871634; -0.006207; 0.314368;,
    0.694671; -0.005278; 0.234263;,
    -0.438283; -0.071593; -0.544219;,
    -0.443727; -0.064232; -0.632720;,
    -0.396185; 0.008359; -0.627286;,
    -0.662611; 0.019871; -0.633431;,
    -0.491205; 0.037119; -0.761418;,
    -0.518101; -0.032468; -0.735627;,
    -0.396185; 0.008359; -0.627286;,
    -0.443727; -0.064232; -0.632720;,
    -0.491205; 0.037119; -0.761418;,
    -0.518101; -0.032468; -0.735627;,
    -0.662611; 0.019871; -0.633431;,
    -0.565252; -0.019472; -0.484438;,
    -0.483201; 0.143758; -0.633548;,
    -0.565252; -0.019472; -0.484438;,
    0.442676; -0.003426; -0.187111;,
    0.476462; -0.015992; -0.062266;,
    0.558842; 0.119629; -0.149631;,
    0.568194; -0.024246; -0.230319;,
    0.442676; -0.003426; -0.187111;,
    0.598807; -0.045411; -0.125276;,
    0.568194; -0.024246; -0.230319;,
    0.476462; -0.015992; -0.062266;,
    0.598807; -0.045411; -0.125276;;
    97;
    3;0, 1, 2;,
    3;3, 4, 5;,
    3;2, 1, 6;,
    3;7, 2, 6;,
    3;8, 6, 9;,
    3;10, 11, 9;,
    3;11, 8, 9;,
    3;12, 13, 14;,
    3;13, 15, 14;,
    3;7, 13, 2;,
    3;3, 5, 8;,
    3;1, 0, 16;,
    3;8, 13, 6;,
    3;13, 7, 6;,
    3;17, 18, 19;,
    3;19, 20, 21;,
    3;22, 23, 24;,
    3;23, 25, 24;,
    3;20, 26, 24;,
    3;27, 28, 29;,
    3;28, 30, 29;,
    3;29, 30, 31;,
    3;20, 19, 32;,
    3;19, 18, 32;,
    3;32, 18, 33;,
    3;20, 32, 26;,
    3;30, 34, 21;,
    3;34, 35, 21;,
    3;21, 35, 36;,
    3;25, 23, 37;,
    3;24, 25, 38;,
    3;31, 20, 38;,
    3;20, 24, 38;,
    3;30, 21, 31;,
    3;21, 20, 31;,
    3;39, 40, 41;,
    3;41, 42, 43;,
    3;44, 45, 46;,
    3;47, 46, 48;,
    3;46, 45, 48;,
    3;42, 47, 48;,
    3;49, 50, 48;,
    3;50, 51, 48;,
    3;52, 53, 49;,
    3;53, 50, 49;,
    3;54, 41, 55;,
    3;41, 40, 55;,
    3;41, 42, 47;,
    3;41, 47, 54;,
    3;50, 56, 43;,
    3;50, 57, 56;,
    3;57, 58, 56;,
    3;45, 44, 59;,
    3;42, 48, 51;,
    3;50, 43, 51;,
    3;43, 42, 51;,
    3;60, 61, 62;,
    3;63, 64, 65;,
    3;64, 66, 65;,
    3;67, 68, 69;,
    3;68, 70, 69;,
    3;71, 72, 73;,
    3;72, 74, 73;,
    3;75, 71, 76;,
    3;71, 73, 76;,
    3;75, 66, 64;,
    3;76, 67, 75;,
    3;67, 69, 75;,
    3;62, 61, 76;,
    3;77, 62, 76;,
    3;77, 78, 62;,
    3;78, 60, 62;,
    3;79, 80, 81;,
    3;81, 82, 83;,
    3;84, 85, 81;,
    3;86, 87, 81;,
    3;88, 89, 90;,
    3;91, 92, 93;,
    3;93, 94, 95;,
    3;90, 89, 93;,
    3;96, 90, 93;,
    3;97, 96, 93;,
    3;98, 99, 100;,
    3;101, 102, 103;,
    3;104, 105, 106;,
    3;105, 107, 106;,
    3;108, 109, 110;,
    3;110, 102, 101;,
    3;104, 106, 110;,
    3;98, 104, 110;,
    3;111, 98, 110;,
    3;112, 113, 114;,
    3;114, 115, 116;,
    3;117, 118, 114;,
    3;119, 120, 114;,
    3;22, 24, 26;,
    3;31, 38, 29;;

   MeshTextureCoords {
    121;
    0.059739; 0.483130;,
    0.105581; 0.486284;,
    0.070997; 0.458930;,
    0.117332; 0.413400;,
    0.088749; 0.407338;,
    0.096635; 0.431359;,
    0.101203; 0.460265;,
    0.092126; 0.448164;,
    0.121945; 0.444668;,
    0.113851; 0.477358;,
    0.125799; 0.486085;,
    0.142814; 0.455581;,
    0.070435; 0.454174;,
    0.095485; 0.432004;,
    0.050286; 0.450340;,
    0.070361; 0.417583;,
    0.101757; 0.505646;,
    0.075448; 0.413501;,
    0.065273; 0.421664;,
    0.089046; 0.427079;,
    0.088877; 0.447012;,
    0.106066; 0.431118;,
    0.066220; 0.465090;,
    0.059739; 0.483130;,
    0.085621; 0.468253;,
    0.105581; 0.486284;,
    0.075774; 0.452769;,
    0.125799; 0.486085;,
    0.142814; 0.455581;,
    0.113851; 0.477358;,
    0.121945; 0.444668;,
    0.116142; 0.457804;,
    0.065097; 0.455579;,
    0.050286; 0.450340;,
    0.129437; 0.416777;,
    0.096988; 0.408681;,
    0.091346; 0.425788;,
    0.101757; 0.505646;,
    0.101206; 0.467743;,
    0.075448; 0.413501;,
    0.065273; 0.421664;,
    0.089046; 0.427079;,
    0.092126; 0.448164;,
    0.101924; 0.436929;,
    0.059739; 0.483130;,
    0.105581; 0.486284;,
    0.066220; 0.465090;,
    0.075774; 0.452769;,
    0.093876; 0.464605;,
    0.113851; 0.477358;,
    0.121945; 0.444668;,
    0.108530; 0.455925;,
    0.125799; 0.486085;,
    0.142814; 0.455581;,
    0.065097; 0.455579;,
    0.050286; 0.450340;,
    0.091346; 0.425788;,
    0.129437; 0.416777;,
    0.096988; 0.408681;,
    0.101757; 0.505646;,
    2.138603; 0.454917;,
    2.125261; 0.441985;,
    2.120748; 0.459832;,
    2.055365; 0.450110;,
    2.064486; 0.456513;,
    2.063116; 0.422489;,
    2.078755; 0.423120;,
    2.119651; 0.428766;,
    2.123255; 0.413762;,
    2.092686; 0.416698;,
    2.102385; 0.404411;,
    2.066793; 0.461534;,
    2.063199; 0.472081;,
    2.097571; 0.479813;,
    2.085509; 0.489472;,
    2.088364; 0.444937;,
    2.101510; 0.449610;,
    2.110022; 0.476634;,
    2.125000; 0.482536;,
    2.064996; 0.466807;,
    2.091540; 0.484643;,
    2.094937; 0.447274;,
    2.070935; 0.422805;,
    2.059926; 0.453312;,
    2.121453; 0.421264;,
    2.097535; 0.410554;,
    2.117511; 0.479585;,
    2.130005; 0.448171;,
    2.123255; 0.413762;,
    2.097535; 0.410554;,
    2.112195; 0.435722;,
    2.064996; 0.466807;,
    2.091540; 0.484643;,
    2.093322; 0.450740;,
    2.070935; 0.422805;,
    2.059926; 0.453312;,
    2.134749; 0.454357;,
    2.117511; 0.479585;,
    2.128455; 0.460951;,
    2.141043; 0.447764;,
    2.115000; 0.442331;,
    2.059926; 0.453312;,
    2.078755; 0.423120;,
    2.063116; 0.422489;,
    2.112195; 0.435722;,
    2.123255; 0.413762;,
    2.092686; 0.416698;,
    2.102385; 0.404411;,
    2.064996; 0.466807;,
    2.091540; 0.484643;,
    2.093322; 0.450740;,
    2.117511; 0.479585;,
    2.064996; 0.466807;,
    2.091540; 0.484643;,
    2.094937; 0.447274;,
    2.070935; 0.422805;,
    2.059926; 0.453312;,
    2.121453; 0.421264;,
    2.097535; 0.410554;,
    2.117511; 0.479585;,
    2.130005; 0.448171;;
   }

   MeshMaterialList {
    1;
    97;
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0;

    Material rocks_zusaetze_lambert14SG_Smoothing {
     1.000000; 1.000000; 1.000000; 1.000000;;
     128.000000;
     0.050000; 0.050000; 0.050000;;
     0.000000; 0.000000; 0.000000;;

     TextureFilename {
      "rock_007_c.tga";
     }
    }

   }
  }
}
