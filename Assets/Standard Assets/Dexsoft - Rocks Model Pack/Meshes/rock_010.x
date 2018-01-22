xof 0303txt 0032

// DirectX 9.0 file
// Creator: Ultimate Unwrap3D Pro v3.22
// Website: http://www.unwrap3d.com
// Time: Fri Mar 12 17:01:19 2010

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

Frame rock_010 {
   FrameTransformMatrix {
    1.000000, 0.000000, 0.000000, 0.000000,
    0.000000, 1.000000, 0.000000, 0.000000,
    0.000000, 0.000000, 1.000000, 0.000000,
    0.000000, 0.000000, 0.000000, 1.000000;;
   }

   Mesh rock_010 {
    139;
    0.195255; 0.448520; 1.528606;,
    -0.663852; 0.439778; 1.528550;,
    0.204823; 0.000000; 1.220287;,
    0.036544; 2.037579; 0.299631;,
    -0.310376; 2.017379; 0.205946;,
    -0.327878; 1.958284; 0.553150;,
    0.112575; 1.947635; 0.730958;,
    0.204823; 0.000000; 1.220287;,
    -0.735261; 0.093153; 0.914689;,
    -0.044052; -0.167123; -0.024867;,
    -0.798712; 0.047887; 0.410070;,
    1.305905; 0.513623; 0.419301;,
    1.231255; 0.505538; 0.865625;,
    0.720754; 0.095521; 1.021134;,
    0.954636; 0.000000; -0.070509;,
    -0.969819; 0.435519; 1.118605;,
    -1.054471; 0.401759; 0.465863;,
    -0.735261; 0.093153; 0.914689;,
    -0.798712; 0.047887; 0.410070;,
    -0.807817; 1.336404; 1.021992;,
    -0.908405; 1.367184; 0.455518;,
    -1.039334; 0.962336; 0.510981;,
    -0.947546; 0.916166; 1.083400;,
    -0.891689; 1.423882; -1.330839;,
    -0.479807; 1.417643; -1.163450;,
    -0.574549; 1.115710; -1.288614;,
    -0.785668; 1.539432; -1.246174;,
    0.779999; 1.728021; 0.505181;,
    0.849844; 1.416214; 0.662326;,
    0.942188; 1.320981; -0.023932;,
    0.881002; 1.728021; -0.020437;,
    0.212813; 1.350981; 1.333667;,
    0.212669; 1.685161; 1.005142;,
    -0.239919; 1.314495; 1.329047;,
    -0.982689; 1.616482; -0.980037;,
    -1.112031; 1.455067; -1.043925;,
    -1.212840; 1.398510; -0.024020;,
    -1.352911; 1.013678; -0.024048;,
    -1.319394; 0.371657; -0.025247;,
    -1.223253; 0.651927; -1.114745;,
    -0.828527; 0.179554; -0.990406;,
    -1.071930; 0.000000; -0.024867;,
    -0.828527; 0.179554; -0.990406;,
    -0.044052; 0.000000; -1.207888;,
    -1.071930; 0.000000; -0.024867;,
    1.106372; 0.038611; -0.676594;,
    1.375276; 0.389511; -0.352010;,
    1.194145; 0.038611; -0.422986;,
    1.239228; 0.399063; -0.852570;,
    0.747385; 1.265196; -0.838859;,
    1.178996; 0.965249; -0.023897;,
    1.013781; 0.963457; -0.896602;,
    -0.793208; 1.702131; -0.873900;,
    -0.856391; 1.802957; -0.491973;,
    -0.322455; 1.700276; -0.901654;,
    -0.200489; 1.820006; -0.662743;,
    0.484270; 1.922231; 0.391598;,
    0.186638; 2.009201; 0.358564;,
    0.369606; 1.914821; 0.661440;,
    0.456289; 1.736794; -0.219790;,
    0.632252; 1.607919; -0.602258;,
    -0.044987; 1.465995; -1.299264;,
    0.518692; 1.362813; -0.951166;,
    -0.052891; 1.146024; -1.450239;,
    0.450322; 1.056002; -1.046760;,
    -0.053933; 0.488724; -1.478817;,
    0.426523; 0.507038; -1.091931;,
    0.413503; 0.000000; -0.821145;,
    -0.044052; 0.000000; -1.207888;,
    0.413503; 0.000000; -0.821145;,
    0.720754; 0.095521; 1.021134;,
    0.962502; 0.579013; 1.231300;,
    0.529826; 1.728021; 0.805990;,
    0.620461; 1.385984; 1.043578;,
    0.196793; 1.096287; 1.472891;,
    -0.600872; 0.932731; 1.505886;,
    -0.579190; 0.777956; 1.478771;,
    -1.004640; 0.770089; 0.468211;,
    -0.916064; 0.700907; 1.064936;,
    -1.213958; 1.088736; -1.092273;,
    -1.302522; 0.842574; -0.058598;,
    -0.053443; 0.797649; -1.380009;,
    1.259676; 0.696375; -0.727443;,
    1.331764; 0.697120; -0.456687;,
    1.283136; 0.879231; 0.434481;,
    1.192696; 0.909808; 0.937726;,
    0.549323; 1.060520; 1.210455;,
    0.195923; 0.730041; 1.568514;,
    0.933376; 1.021554; 1.190167;,
    -0.472214; 1.346069; 1.322315;,
    -0.807817; 1.336404; 1.021992;,
    -0.947546; 0.916166; 1.083400;,
    -0.916064; 0.700907; 1.064936;,
    -0.969819; 0.435519; 1.118605;,
    -0.735261; 0.093153; 0.914689;,
    0.933376; 1.021554; 1.190167;,
    0.962502; 0.579013; 1.231300;,
    1.194297; 0.514093; 0.039303;,
    -1.022928; 0.671622; -1.426911;,
    -0.891689; 1.423882; -1.330839;,
    -0.785668; 1.539432; -1.246174;,
    -0.036206; 1.767560; -0.992744;,
    -0.662710; 0.867151; -1.259357;,
    -0.828527; 0.179554; -0.990406;,
    -0.734006; 0.666139; -1.390118;,
    -0.642989; 1.572997; -1.090546;,
    -0.625130; 0.594452; 1.564016;,
    0.823180; 0.000000; -0.817402;,
    0.908973; 0.523820; -0.983637;,
    -0.018487; 1.844170; -0.306233;,
    -0.513481; 1.964214; 0.293833;,
    -0.544333; 1.685161; 0.699544;,
    -0.251773; 1.685161; 0.817649;,
    -0.300637; 1.972733; 0.012744;,
    -0.021921; 1.966440; -0.032049;,
    -0.497514; 1.817371; -0.229247;,
    0.573933; 1.839263; 0.180593;,
    0.254322; 1.908110; 0.018246;,
    -0.627710; 1.887395; 0.134237;,
    -0.934399; 1.788908; -0.020437;,
    -0.758991; 1.792066; 0.303329;,
    -0.030611; 1.685161; 0.790703;,
    -0.341978; 1.286456; 1.222733;,
    -0.908030; 1.141963; -1.366539;,
    -0.908030; 1.141963; -1.366539;,
    0.818844; 1.228062; 1.123438;,
    1.038023; 1.255992; 0.687128;,
    1.139276; 1.053520; 0.707116;,
    0.620461; 1.385984; 1.043578;,
    0.818844; 1.228062; 1.123438;,
    0.747385; 1.265196; -0.838859;,
    1.013781; 0.963457; -0.896602;,
    0.908973; 0.523820; -0.983637;,
    0.823180; 0.000000; -0.817402;,
    -0.906849; 0.813022; -1.430048;,
    -0.912766; 0.674024; -1.462728;,
    -1.004751; 0.842697; -1.409078;,
    -0.906849; 0.813022; -1.430048;,
    -0.912766; 0.674024; -1.462728;;
    220;
    3;0, 1, 2;,
    3;3, 4, 5;,
    3;3, 5, 6;,
    3;7, 8, 9;,
    3;8, 10, 9;,
    3;11, 12, 13;,
    3;11, 13, 14;,
    3;15, 16, 17;,
    3;17, 16, 18;,
    3;19, 20, 21;,
    3;19, 21, 22;,
    3;23, 24, 25;,
    3;23, 26, 24;,
    3;27, 28, 29;,
    3;30, 27, 29;,
    3;31, 32, 33;,
    3;34, 35, 36;,
    3;36, 35, 37;,
    3;38, 39, 40;,
    3;38, 40, 41;,
    3;42, 43, 44;,
    3;45, 46, 47;,
    3;48, 46, 45;,
    3;49, 50, 51;,
    3;49, 29, 50;,
    3;52, 53, 54;,
    3;53, 55, 54;,
    3;56, 57, 58;,
    3;57, 6, 58;,
    3;59, 30, 60;,
    3;61, 62, 63;,
    3;63, 62, 64;,
    3;65, 66, 67;,
    3;68, 65, 67;,
    3;43, 69, 9;,
    3;14, 13, 9;,
    3;13, 7, 9;,
    3;70, 0, 2;,
    3;71, 0, 70;,
    3;72, 32, 73;,
    3;73, 32, 31;,
    3;74, 75, 76;,
    3;21, 77, 78;,
    3;22, 21, 78;,
    3;37, 79, 80;,
    3;81, 64, 66;,
    3;63, 64, 81;,
    3;82, 83, 46;,
    3;48, 82, 46;,
    3;84, 85, 12;,
    3;11, 84, 12;,
    3;86, 87, 71;,
    3;88, 86, 71;,
    3;89, 90, 91;,
    3;75, 89, 91;,
    3;75, 91, 76;,
    3;76, 91, 92;,
    3;1, 93, 94;,
    3;85, 95, 96;,
    3;85, 96, 12;,
    3;12, 96, 13;,
    3;97, 11, 14;,
    3;97, 84, 11;,
    3;50, 84, 97;,
    3;39, 98, 40;,
    3;35, 34, 99;,
    3;34, 100, 99;,
    3;55, 101, 54;,
    3;24, 61, 63;,
    3;24, 63, 25;,
    3;25, 63, 81;,
    3;102, 25, 81;,
    3;103, 65, 68;,
    3;104, 65, 103;,
    3;52, 54, 105;,
    3;80, 79, 39;,
    3;80, 39, 38;,
    3;78, 77, 16;,
    3;15, 78, 16;,
    3;1, 106, 93;,
    3;0, 106, 1;,
    3;87, 106, 0;,
    3;47, 46, 14;,
    3;46, 97, 14;,
    3;45, 47, 14;,
    3;107, 45, 14;,
    3;108, 48, 45;,
    3;108, 45, 107;,
    3;108, 82, 48;,
    3;51, 82, 108;,
    3;51, 83, 82;,
    3;51, 50, 83;,
    3;83, 97, 46;,
    3;83, 50, 97;,
    3;109, 59, 60;,
    3;101, 109, 60;,
    3;57, 3, 6;,
    3;4, 110, 5;,
    3;5, 111, 112;,
    3;113, 114, 109;,
    3;113, 109, 115;,
    3;58, 6, 32;,
    3;72, 58, 32;,
    3;30, 116, 27;,
    3;117, 116, 59;,
    3;59, 116, 30;,
    3;114, 117, 109;,
    3;109, 117, 59;,
    3;118, 113, 115;,
    3;118, 115, 119;,
    3;5, 110, 111;,
    3;110, 120, 111;,
    3;32, 121, 33;,
    3;33, 121, 122;,
    3;6, 5, 121;,
    3;121, 5, 112;,
    3;121, 112, 122;,
    3;112, 89, 122;,
    3;123, 23, 25;,
    3;99, 124, 79;,
    3;35, 99, 79;,
    3;35, 79, 37;,
    3;112, 111, 89;,
    3;89, 111, 90;,
    3;111, 20, 19;,
    3;53, 52, 34;,
    3;53, 34, 36;,
    3;34, 105, 100;,
    3;34, 52, 105;,
    3;26, 105, 24;,
    3;105, 54, 24;,
    3;54, 101, 24;,
    3;101, 61, 24;,
    3;101, 60, 62;,
    3;61, 101, 62;,
    3;60, 29, 49;,
    3;60, 30, 29;,
    3;122, 89, 75;,
    3;33, 122, 75;,
    3;31, 33, 74;,
    3;74, 33, 75;,
    3;125, 86, 88;,
    3;126, 127, 50;,
    3;6, 121, 32;,
    3;127, 85, 84;,
    3;50, 127, 84;,
    3;56, 58, 27;,
    3;27, 58, 72;,
    3;28, 72, 128;,
    3;27, 72, 28;,
    3;127, 129, 95;,
    3;126, 129, 127;,
    3;127, 95, 85;,
    3;62, 60, 130;,
    3;62, 130, 64;,
    3;64, 130, 131;,
    3;64, 131, 132;,
    3;64, 132, 66;,
    3;66, 132, 133;,
    3;67, 66, 133;,
    3;69, 107, 14;,
    3;69, 14, 9;,
    3;119, 53, 36;,
    3;109, 55, 115;,
    3;115, 55, 53;,
    3;115, 53, 119;,
    3;55, 109, 101;,
    3;111, 120, 20;,
    3;120, 36, 20;,
    3;20, 36, 37;,
    3;20, 37, 21;,
    3;37, 80, 77;,
    3;21, 37, 77;,
    3;77, 80, 38;,
    3;16, 77, 38;,
    3;16, 38, 18;,
    3;18, 38, 41;,
    3;10, 44, 9;,
    3;31, 74, 86;,
    3;73, 31, 86;,
    3;86, 74, 87;,
    3;87, 76, 106;,
    3;74, 76, 87;,
    3;106, 76, 93;,
    3;76, 92, 93;,
    3;71, 87, 0;,
    3;44, 43, 9;,
    3;81, 66, 65;,
    3;102, 81, 65;,
    3;104, 102, 65;,
    3;134, 102, 104;,
    3;135, 134, 104;,
    3;136, 98, 39;,
    3;79, 136, 39;,
    3;135, 104, 103;,
    3;79, 124, 136;,
    3;123, 25, 102;,
    3;123, 102, 134;,
    3;136, 137, 98;,
    3;137, 138, 98;,
    3;98, 138, 40;,
    3;136, 124, 137;,
    3;1, 94, 2;,
    3;116, 56, 27;,
    3;117, 56, 116;,
    3;57, 56, 117;,
    3;3, 57, 117;,
    3;114, 3, 117;,
    3;113, 4, 114;,
    3;4, 3, 114;,
    3;4, 113, 118;,
    3;110, 4, 118;,
    3;110, 118, 120;,
    3;120, 119, 36;,
    3;120, 118, 119;,
    3;29, 126, 50;,
    3;29, 28, 126;,
    3;28, 128, 129;,
    3;126, 28, 129;,
    3;125, 73, 86;;

   MeshTextureCoords {
    139;
    0.101567; 0.431984;,
    0.110609; 0.305022;,
    0.010039; 0.437910;,
    0.430256; 0.400216;,
    0.440823; 0.355194;,
    0.394302; 0.351623;,
    0.373827; 0.412704;,
    0.378132; 0.847617;,
    0.430846; 0.966714;,
    0.541980; 0.860490;,
    0.497602; 0.967310;,
    0.456450; 0.677168;,
    0.405573; 0.692360;,
    0.394407; 0.776703;,
    0.529794; 0.735178;,
    0.300043; 0.076907;,
    0.400394; 0.072556;,
    0.326741; 0.011602;,
    0.402588; 0.006128;,
    0.310031; 0.224883;,
    0.399949; 0.224596;,
    0.393157; 0.159087;,
    0.303805; 0.153693;,
    0.681172; 0.259413;,
    0.658515; 0.326264;,
    0.713735; 0.323508;,
    0.655155; 0.272313;,
    0.412181; 0.508771;,
    0.393169; 0.555002;,
    0.490123; 0.557460;,
    0.479131; 0.507261;,
    0.244631; 0.435285;,
    0.320229; 0.432634;,
    0.240267; 0.367914;,
    0.602284; 0.251998;,
    0.610220; 0.224549;,
    0.477230; 0.211213;,
    0.477715; 0.159812;,
    0.477828; 0.076061;,
    0.621064; 0.115878;,
    0.618901; 0.029950;,
    0.478672; 0.015473;,
    0.684999; 0.946623;,
    0.694654; 0.837660;,
    0.561056; 0.993588;,
    0.594792; 0.707707;,
    0.551822; 0.670250;,
    0.566410; 0.706500;,
    0.602995; 0.663928;,
    0.600904; 0.532948;,
    0.499130; 0.611818;,
    0.613665; 0.589172;,
    0.588776; 0.280282;,
    0.535314; 0.281414;,
    0.598030; 0.346565;,
    0.560329; 0.365819;,
    0.421622; 0.460065;,
    0.423486; 0.420013;,
    0.383333; 0.450182;,
    0.506835; 0.458475;,
    0.561594; 0.487281;,
    0.654882; 0.390529;,
    0.624716; 0.476135;,
    0.696320; 0.396865;,
    0.674157; 0.481668;,
    0.781227; 0.421536;,
    0.756960; 0.504932;,
    0.835978; 0.542942;,
    0.852570; 0.455395;,
    0.635670; 0.784516;,
    0.020146; 0.537977;,
    0.119510; 0.567769;,
    0.354780; 0.487223;,
    0.279347; 0.511447;,
    0.201872; 0.432235;,
    0.180269; 0.313984;,
    0.157972; 0.313964;,
    0.396661; 0.128811;,
    0.306047; 0.119121;,
    0.617205; 0.173841;,
    0.481029; 0.137295;,
    0.739752; 0.411774;,
    0.587444; 0.632447;,
    0.556869; 0.638544;,
    0.444976; 0.636911;,
    0.383920; 0.646662;,
    0.210550; 0.502745;,
    0.145465; 0.430980;,
    0.200908; 0.569687;,
    0.245059; 0.322938;,
    0.268163; 0.256549;,
    0.188736; 0.229439;,
    0.145404; 0.227958;,
    0.092268; 0.233491;,
    0.010252; 0.264302;,
    0.333529; 0.638866;,
    0.348148; 0.705414;,
    0.502842; 0.670678;,
    0.671380; 0.114556;,
    0.661208; 0.237804;,
    0.649488; 0.266415;,
    0.601416; 0.386759;,
    0.753702; 0.323140;,
    0.887924; 0.336491;,
    0.792375; 0.321269;,
    0.631934; 0.296296;,
    0.130332; 0.312203;,
    0.624899; 0.731433;,
    0.645510; 0.651654;,
    0.513365; 0.392020;,
    0.430362; 0.328474;,
    0.357391; 0.302179;,
    0.338608; 0.353068;,
    0.466102; 0.355994;,
    0.473352; 0.391716;,
    0.501893; 0.328137;,
    0.451046; 0.471877;,
    0.469552; 0.428761;,
    0.452050; 0.311187;,
    0.475181; 0.272051;,
    0.428508; 0.287215;,
    0.340947; 0.387191;,
    0.249045; 0.347740;,
    0.726140; 0.270938;,
    0.675238; 0.192239;,
    0.244463; 0.550979;,
    0.399336; 0.589168;,
    0.404675; 0.618500;,
    0.322772; 0.554334;,
    0.328755; 0.598790;,
    0.620170; 0.517064;,
    0.655800; 0.571037;,
    0.728136; 0.576245;,
    0.810325; 0.599675;,
    0.775953; 0.286155;,
    0.795979; 0.291614;,
    0.672797; 0.139854;,
    0.689436; 0.136096;,
    0.686164; 0.107394;;
   }

   MeshMaterialList {
    1;
    220;
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

    Material lambert18SG_Smoothing {
     0.000000; 0.000000; 0.000000; 1.000000;;
     128.000000;
     0.050000; 0.050000; 0.050000;;
     0.000000; 0.000000; 0.000000;;

     TextureFilename {
      "rock_010_c.tga";
     }
    }

   }
  }
}
