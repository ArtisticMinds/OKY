xof 0303txt 0032

// DirectX 9.0 file
// Creator: Ultimate Unwrap3D Pro v3.22
// Website: http://www.unwrap3d.com
// Time: Fri Mar 12 16:39:53 2010

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

Frame rock_006 {
   FrameTransformMatrix {
    1.000000, 0.000000, 0.000000, 0.000000,
    0.000000, 1.000000, 0.000000, 0.000000,
    0.000000, 0.000000, 1.000000, 0.000000,
    0.000000, 0.000000, 0.000000, 1.000000;;
   }

   Mesh rock_006 {
    315;
    -1.304733; 0.759923; -0.115810;,
    -1.321864; 0.000000; -0.309784;,
    -1.124837; 0.746483; -0.499893;,
    -1.214321; 0.000000; -0.603896;,
    -1.585923; 0.847143; -0.941231;,
    -1.846497; 0.834481; -0.150061;,
    -1.218424; 0.970672; -0.555356;,
    -1.348545; 0.918920; -0.159844;,
    -2.145251; 0.000000; -0.503570;,
    -2.470949; 0.619535; -0.429979;,
    -2.318623; 0.000000; -0.956162;,
    -2.627526; 0.579399; -0.946092;,
    -0.784645; 0.772835; -1.546640;,
    -0.928284; 0.000000; -1.439600;,
    -1.192762; 0.746142; -1.983801;,
    -1.165361; 0.000000; -1.776422;,
    -1.818735; 0.720711; -0.085169;,
    -1.683569; 0.000000; -0.246247;,
    -1.304733; 0.759923; -0.115810;,
    -1.321864; 0.000000; -0.309784;,
    -2.393170; 0.786229; -0.434587;,
    -2.570001; 0.755185; -0.904350;,
    -0.902550; 0.992988; -1.506354;,
    -1.280346; 0.914280; -1.889781;,
    -2.470949; 0.619535; -0.429979;,
    -2.145251; 0.000000; -0.503570;,
    -1.937653; 0.592399; -2.026834;,
    -1.799667; 0.000000; -1.704233;,
    -1.839092; 0.853498; -1.930157;,
    -0.813212; 0.959008; -0.941737;,
    -2.388730; 0.804996; -1.514978;,
    -2.426000; 0.620117; -1.603069;,
    -1.937653; 0.592399; -2.026834;,
    -1.799667; 0.000000; -1.704233;,
    -2.251832; 0.000000; -1.417460;,
    -0.784645; 0.772835; -1.546640;,
    -0.707465; 0.736837; -0.934149;,
    -0.928284; 0.000000; -1.439600;,
    -0.824028; 0.000000; -0.932631;,
    -0.707465; 0.736837; -0.934149;,
    -0.824028; 0.000000; -0.932631;,
    -0.502438; 0.719541; -1.478169;,
    -0.446460; 0.000000; -1.538819;,
    -0.088530; 0.680294; -1.249704;,
    -0.102042; 0.000000; -1.467345;,
    -0.289933; 0.791816; -2.182997;,
    -0.559007; 0.812674; -1.924446;,
    -0.090710; 0.907090; -1.342209;,
    -0.489766; 0.879602; -1.524642;,
    -0.554100; 0.557214; -3.075273;,
    -0.626298; 0.000000; -2.838016;,
    -0.832112; 0.607568; -2.600492;,
    -0.737203; 0.000000; -2.483142;,
    0.623208; 0.652133; -2.319723;,
    0.656392; 0.673562; -1.712479;,
    0.477394; 0.000000; -2.262542;,
    0.486763; 0.000000; -1.870477;,
    -0.446460; 0.000000; -1.538819;,
    -0.502438; 0.719541; -1.478169;,
    -0.556757; 0.000000; -2.029384;,
    -0.589883; 0.699180; -1.876167;,
    -0.781186; 0.772957; -2.507035;,
    -0.540690; 0.733635; -2.974519;,
    0.584357; 0.899674; -1.775912;,
    0.531554; 0.826519; -2.330777;,
    -0.832112; 0.607568; -2.600492;,
    -0.737203; 0.000000; -2.483142;,
    0.318692; 0.526788; -2.985518;,
    0.250060; 0.000000; -2.706955;,
    0.324471; 0.789418; -2.804031;,
    0.365704; 0.887411; -1.458157;,
    -0.108655; 0.765654; -3.002391;,
    0.318692; 0.526788; -2.985518;,
    -0.084549; 0.578202; -3.110443;,
    -0.028605; 0.000000; -2.925172;,
    0.250060; 0.000000; -2.706955;,
    0.402811; 0.660957; -1.380189;,
    0.311381; 0.000000; -1.567427;,
    0.402811; 0.660957; -1.380189;,
    0.311381; 0.000000; -1.567427;,
    -0.554100; 0.557214; -3.075273;,
    -0.626298; 0.000000; -2.838016;,
    -0.112673; 0.617956; 0.675841;,
    -0.715625; 0.685862; 0.508850;,
    -0.045120; 0.000000; 0.440436;,
    -0.549708; 0.000000; 0.291514;,
    -0.861059; 0.892810; 0.081770;,
    -0.695979; 0.876336; 0.497351;,
    -0.124078; 0.908903; 0.050500;,
    -0.100577; 0.893139; 0.636178;,
    -0.505706; 0.824703; -0.776752;,
    -0.387274; 0.000000; -0.687318;,
    -0.818423; 0.809824; -0.539246;,
    -0.642334; 0.000000; -0.452975;,
    0.865020; 0.787723; 0.021700;,
    0.697676; 0.677571; 0.542408;,
    0.714183; 0.000000; -0.049553;,
    0.574353; 0.000000; 0.316781;,
    -0.903865; 0.754778; 0.097377;,
    -0.716163; 0.000000; 0.005366;,
    -0.715625; 0.685862; 0.508850;,
    -0.549708; 0.000000; 0.291514;,
    -0.792817; 0.978679; -0.439445;,
    -0.525038; 1.004699; -0.676820;,
    0.622923; 0.946399; 0.511726;,
    0.756406; 0.987666; 0.019666;,
    0.578138; 0.800316; -0.672242;,
    0.454769; 0.000000; -0.564032;,
    0.524923; 1.062091; -0.502653;,
    0.297661; 0.919769; 0.474831;,
    -0.148923; 1.030719; -0.571744;,
    -0.084654; 0.839583; -0.671808;,
    0.578138; 0.800316; -0.672242;,
    -0.039849; 0.000000; -0.616903;,
    0.454769; 0.000000; -0.564032;,
    0.328989; 0.647763; 0.510003;,
    0.301104; 0.000000; 0.279488;,
    0.697676; 0.677571; 0.542408;,
    0.574353; 0.000000; 0.316781;,
    -0.505706; 0.824703; -0.776752;,
    -0.387274; 0.000000; -0.687318;,
    0.754861; 0.712719; -0.868113;,
    0.965565; 0.000000; -1.024543;,
    1.243508; 0.614271; -0.483951;,
    1.373169; 0.000000; -0.692906;,
    0.793709; 0.931558; -1.311934;,
    0.784832; 0.902175; -0.865518;,
    1.485680; 0.913092; -1.056568;,
    1.280692; 0.889039; -0.507732;,
    1.449919; 0.857240; -1.969079;,
    1.493049; 0.000000; -1.864923;,
    1.069445; 0.854279; -1.870828;,
    1.167517; 0.000000; -1.746952;,
    2.403723; 0.745541; -0.705923;,
    2.044228; 0.637055; -0.293289;,
    2.262125; 0.000000; -0.852565;,
    1.991861; 0.000000; -0.568476;,
    0.742850; 0.795527; -1.318105;,
    0.922578; 0.000000; -1.352583;,
    0.754861; 0.712719; -0.868113;,
    0.965565; 0.000000; -1.024543;,
    1.061111; 1.020493; -1.763910;,
    1.400549; 1.036708; -1.879011;,
    1.997648; 0.909479; -0.342410;,
    2.312193; 0.950417; -0.743696;,
    2.407614; 0.780238; -1.456120;,
    2.221579; 0.000000; -1.427015;,
    2.303319; 1.042138; -1.312421;,
    1.711055; 0.898748; -0.502457;,
    1.707676; 1.043583; -1.636511;,
    1.798081; 0.850860; -1.709730;,
    2.407614; 0.780238; -1.456120;,
    1.786094; 0.000000; -1.666212;,
    2.221579; 0.000000; -1.427015;,
    1.715753; 0.625152; -0.466006;,
    1.754400; 0.000000; -0.708077;,
    2.044228; 0.637055; -0.293289;,
    1.991861; 0.000000; -0.568476;,
    1.449919; 0.857240; -1.969079;,
    1.493049; 0.000000; -1.864923;,
    1.367301; 0.830146; 1.088692;,
    1.519708; 0.000000; 0.889928;,
    1.666743; 0.712933; 1.412005;,
    1.702071; 0.000000; 1.177791;,
    1.666743; 0.712933; 1.412005;,
    1.702071; 0.000000; 1.177791;,
    2.332660; 0.453739; 1.432353;,
    2.246623; 0.000000; 1.180201;,
    2.857268; 0.369422; 1.705032;,
    2.642160; 0.000000; 1.411579;,
    1.741051; 0.893614; 1.359096;,
    1.978606; 1.007246; 0.927007;,
    1.493601; 0.955974; 1.048703;,
    1.693517; 0.991106; 0.611330;,
    2.485163; 0.937642; 1.095249;,
    2.368525; 0.830194; 1.384036;,
    3.108876; 0.780503; 1.211176;,
    2.836616; 0.753642; 1.637945;,
    2.164285; 0.984574; 0.299713;,
    1.710262; 1.019712; 0.368178;,
    2.655216; 0.922122; 0.422493;,
    3.019695; 0.852022; 0.704634;,
    2.138313; 0.717790; 0.171462;,
    2.040140; -0.000000; 0.266359;,
    1.627773; 0.760694; 0.221156;,
    1.666813; 0.000000; 0.357354;,
    2.138313; 0.717790; 0.171462;,
    2.685762; 0.647572; 0.313013;,
    2.040140; -0.000000; 0.266359;,
    2.454433; 0.000000; 0.366609;,
    3.111366; 0.617626; 0.619881;,
    2.749910; 0.000000; 0.626220;,
    3.111366; 0.617626; 0.619881;,
    3.171500; 0.538426; 1.210697;,
    2.749910; 0.000000; 0.626220;,
    2.872918; 0.000000; 1.058786;,
    2.857268; 0.369422; 1.705032;,
    2.642160; 0.000000; 1.411579;,
    1.591736; 0.825872; 0.561193;,
    1.627773; 0.760694; 0.221156;,
    1.679799; 0.000000; 0.526531;,
    1.666813; 0.000000; 0.357354;,
    1.367301; 0.830146; 1.088692;,
    1.519708; 0.000000; 0.889928;,
    0.691091; 0.834236; 2.133414;,
    0.176102; 0.717388; 2.475732;,
    0.726105; 0.000000; 1.861384;,
    0.312157; 0.000000; 2.132064;,
    -0.284963; 0.818394; 2.322131;,
    0.127251; 0.902888; 2.474349;,
    0.144176; 1.023717; 1.758164;,
    0.593487; 1.094795; 2.128148;,
    -0.676931; 0.729828; 1.481601;,
    -0.305176; 0.000000; 1.361103;,
    -0.692015; 0.665622; 1.868993;,
    -0.288082; 0.000000; 1.704133;,
    0.769205; 1.164734; 0.994435;,
    1.078592; 1.086514; 1.452076;,
    0.827003; 0.000000; 0.978487;,
    1.010256; 0.000000; 1.324958;,
    0.176102; 0.717388; 2.475732;,
    -0.261916; 0.677429; 2.349091;,
    0.312157; 0.000000; 2.132064;,
    0.002335; 0.000000; 2.063502;,
    -0.649415; 0.847239; 1.934785;,
    -0.665149; 0.910259; 1.581924;,
    0.935539; 1.319341; 1.516302;,
    0.645239; 1.326767; 1.095214;,
    0.294064; 0.000000; 0.825996;,
    0.078045; 1.006441; 0.746936;,
    0.097454; 1.265544; 0.927512;,
    0.714275; 1.203155; 1.729396;,
    -0.362109; 1.048569; 1.376455;,
    -0.343074; 0.869325; 1.241601;,
    0.078045; 1.006441; 0.746936;,
    0.294064; 0.000000; 0.825996;,
    -0.043642; 0.000000; 1.153338;,
    1.078592; 1.086514; 1.452076;,
    0.834604; 0.956462; 1.699916;,
    1.010256; 0.000000; 1.324958;,
    0.817782; 0.000000; 1.500412;,
    -0.676931; 0.729828; 1.481601;,
    -0.305176; 0.000000; 1.361103;,
    -1.458268; 0.000000; 1.484929;,
    -1.243109; 0.000000; 1.091705;,
    -1.202218; 0.680964; 1.624774;,
    -0.957193; 0.598530; 1.153909;,
    -1.788592; 0.911664; 1.163527;,
    -1.834925; 0.905071; 1.636574;,
    -1.018184; 0.875708; 1.148020;,
    -1.223050; 0.872117; 1.611978;,
    -2.800495; 0.860679; 1.445271;,
    -2.737085; 0.000000; 1.352982;,
    -2.521875; 0.842223; 1.916758;,
    -2.374686; 0.000000; 1.768861;,
    -1.913079; 0.776861; 0.378618;,
    -1.259117; 0.651177; 0.451240;,
    -1.986183; 0.000000; 0.485478;,
    -1.537589; 0.000000; 0.537314;,
    -1.811391; 0.766711; 1.668193;,
    -1.899698; 0.000000; 1.511050;,
    -1.202218; 0.680964; 1.624774;,
    -1.458268; 0.000000; 1.484929;,
    -2.395607; 1.007842; 1.899594;,
    -2.676183; 1.038114; 1.463349;,
    -1.311479; 0.922926; 0.513125;,
    -1.926797; 0.979038; 0.466152;,
    -2.521875; 0.842223; 1.916758;,
    -2.374686; 0.000000; 1.768861;,
    -2.706472; 0.817087; 0.609949;,
    -2.542454; 0.000000; 0.696125;,
    -2.494815; 1.074680; 0.655967;,
    -1.215434; 0.902144; 0.836582;,
    -2.756135; 1.055247; 0.911975;,
    -2.878490; 0.865995; 0.858654;,
    -2.776576; 0.000000; 0.812698;,
    -1.259117; 0.651177; 0.451240;,
    -1.158758; 0.627681; 0.808584;,
    -1.537589; 0.000000; 0.537314;,
    -1.440952; 0.000000; 0.820519;,
    -2.878490; 0.865995; 0.858654;,
    -2.776576; 0.000000; 0.812698;,
    -4.337379; 0.287080; -0.344673;,
    -4.034452; 0.000000; -0.460513;,
    -4.069090; 0.291100; 0.182151;,
    -3.840636; 0.000000; 0.047064;,
    -3.646398; 0.378837; 0.483721;,
    -3.357010; 0.000000; 0.171906;,
    -4.338830; 0.612413; -0.294999;,
    -4.127734; 0.606873; 0.176011;,
    -3.762234; 0.685052; 0.421768;,
    -4.075643; 0.769600; -0.772997;,
    -3.820663; 0.717946; -0.233177;,
    -3.382365; 0.844652; 0.168571;,
    -3.279148; 0.948707; -0.561115;,
    -3.596093; 0.943013; -0.910429;,
    -3.166603; 0.948732; -0.127928;,
    -3.481181; 0.669353; -1.061709;,
    -3.107044; 0.684606; -0.656582;,
    -2.937306; 0.694190; -0.167581;,
    -2.922921; 0.000000; -0.673901;,
    -3.190065; 0.000000; -0.974615;,
    -2.860177; 0.000000; -0.289314;,
    -2.937306; 0.694190; -0.167581;,
    -3.209798; 0.564274; 0.179721;,
    -2.860177; 0.000000; -0.289314;,
    -3.026540; 0.000000; -0.037054;,
    -3.646398; 0.378837; 0.483721;,
    -3.357010; 0.000000; 0.171906;,
    -3.481181; 0.669353; -1.061709;,
    -3.190065; 0.000000; -0.974615;,
    -4.017459; 0.470103; -0.873474;,
    -3.620215; 0.000000; -0.881420;,
    -4.337379; 0.287080; -0.344673;,
    -4.034452; 0.000000; -0.460513;;
    392;
    3;0, 1, 2;,
    3;1, 3, 2;,
    3;4, 5, 6;,
    3;7, 6, 5;,
    3;8, 9, 10;,
    3;9, 11, 10;,
    3;12, 13, 14;,
    3;13, 15, 14;,
    3;16, 17, 18;,
    3;17, 19, 18;,
    3;18, 7, 16;,
    3;5, 16, 7;,
    3;9, 20, 11;,
    3;20, 21, 11;,
    3;12, 14, 22;,
    3;14, 23, 22;,
    3;6, 7, 2;,
    3;0, 2, 7;,
    3;16, 24, 17;,
    3;25, 17, 24;,
    3;14, 15, 26;,
    3;15, 27, 26;,
    3;26, 28, 14;,
    3;23, 14, 28;,
    3;21, 20, 4;,
    3;5, 4, 20;,
    3;24, 16, 20;,
    3;16, 5, 20;,
    3;29, 22, 23;,
    3;30, 4, 28;,
    3;4, 23, 28;,
    3;30, 28, 31;,
    3;31, 28, 32;,
    3;32, 33, 31;,
    3;34, 31, 33;,
    3;35, 36, 37;,
    3;36, 38, 37;,
    3;35, 22, 36;,
    3;29, 36, 22;,
    3;4, 29, 23;,
    3;2, 39, 6;,
    3;6, 39, 29;,
    3;39, 2, 40;,
    3;2, 3, 40;,
    3;21, 4, 30;,
    3;11, 21, 31;,
    3;21, 30, 31;,
    3;31, 34, 11;,
    3;10, 11, 34;,
    3;6, 29, 4;,
    3;41, 42, 43;,
    3;42, 44, 43;,
    3;45, 46, 47;,
    3;48, 47, 46;,
    3;49, 50, 51;,
    3;51, 50, 52;,
    3;53, 54, 55;,
    3;56, 55, 54;,
    3;57, 58, 59;,
    3;59, 58, 60;,
    3;58, 48, 60;,
    3;46, 60, 48;,
    3;51, 61, 49;,
    3;61, 62, 49;,
    3;54, 53, 63;,
    3;53, 64, 63;,
    3;47, 48, 43;,
    3;41, 43, 48;,
    3;65, 66, 60;,
    3;66, 59, 60;,
    3;67, 53, 68;,
    3;53, 55, 68;,
    3;67, 69, 53;,
    3;64, 53, 69;,
    3;45, 62, 46;,
    3;46, 62, 61;,
    3;65, 60, 61;,
    3;60, 46, 61;,
    3;70, 63, 64;,
    3;64, 69, 45;,
    3;71, 45, 69;,
    3;72, 73, 69;,
    3;73, 71, 69;,
    3;73, 72, 74;,
    3;74, 72, 75;,
    3;54, 76, 56;,
    3;76, 77, 56;,
    3;54, 63, 76;,
    3;70, 76, 63;,
    3;45, 70, 64;,
    3;43, 78, 47;,
    3;47, 78, 70;,
    3;43, 44, 78;,
    3;44, 79, 78;,
    3;62, 45, 71;,
    3;73, 80, 71;,
    3;80, 62, 71;,
    3;74, 81, 73;,
    3;81, 80, 73;,
    3;47, 70, 45;,
    3;82, 83, 84;,
    3;85, 84, 83;,
    3;86, 87, 88;,
    3;87, 89, 88;,
    3;90, 91, 92;,
    3;92, 91, 93;,
    3;94, 95, 96;,
    3;97, 96, 95;,
    3;98, 99, 100;,
    3;99, 101, 100;,
    3;100, 87, 98;,
    3;86, 98, 87;,
    3;92, 102, 90;,
    3;102, 103, 90;,
    3;95, 94, 104;,
    3;94, 105, 104;,
    3;89, 87, 82;,
    3;83, 82, 87;,
    3;92, 93, 98;,
    3;93, 99, 98;,
    3;94, 96, 106;,
    3;96, 107, 106;,
    3;106, 108, 94;,
    3;105, 94, 108;,
    3;103, 102, 88;,
    3;86, 88, 102;,
    3;92, 98, 102;,
    3;98, 86, 102;,
    3;109, 104, 105;,
    3;88, 105, 110;,
    3;110, 105, 108;,
    3;110, 108, 111;,
    3;111, 108, 112;,
    3;111, 112, 113;,
    3;113, 112, 114;,
    3;115, 116, 117;,
    3;116, 118, 117;,
    3;117, 104, 115;,
    3;109, 115, 104;,
    3;88, 109, 105;,
    3;82, 115, 89;,
    3;89, 115, 109;,
    3;115, 82, 116;,
    3;82, 84, 116;,
    3;103, 88, 110;,
    3;111, 119, 110;,
    3;119, 103, 110;,
    3;111, 113, 119;,
    3;120, 119, 113;,
    3;89, 109, 88;,
    3;121, 122, 123;,
    3;122, 124, 123;,
    3;125, 126, 127;,
    3;126, 128, 127;,
    3;129, 130, 131;,
    3;131, 130, 132;,
    3;133, 134, 135;,
    3;136, 135, 134;,
    3;137, 138, 139;,
    3;138, 140, 139;,
    3;139, 126, 137;,
    3;125, 137, 126;,
    3;131, 141, 129;,
    3;141, 142, 129;,
    3;134, 133, 143;,
    3;133, 144, 143;,
    3;128, 126, 123;,
    3;121, 123, 126;,
    3;131, 132, 137;,
    3;132, 138, 137;,
    3;133, 135, 145;,
    3;135, 146, 145;,
    3;145, 147, 133;,
    3;144, 133, 147;,
    3;142, 141, 127;,
    3;125, 127, 141;,
    3;131, 137, 141;,
    3;137, 125, 141;,
    3;148, 143, 144;,
    3;127, 144, 149;,
    3;149, 144, 147;,
    3;149, 147, 150;,
    3;150, 147, 151;,
    3;150, 151, 152;,
    3;152, 151, 153;,
    3;154, 155, 156;,
    3;155, 157, 156;,
    3;156, 143, 154;,
    3;148, 154, 143;,
    3;127, 148, 144;,
    3;123, 154, 128;,
    3;128, 154, 148;,
    3;154, 123, 155;,
    3;123, 124, 155;,
    3;142, 127, 149;,
    3;150, 158, 149;,
    3;158, 142, 149;,
    3;150, 152, 158;,
    3;159, 158, 152;,
    3;128, 148, 127;,
    3;160, 161, 162;,
    3;161, 163, 162;,
    3;164, 165, 166;,
    3;165, 167, 166;,
    3;166, 167, 168;,
    3;167, 169, 168;,
    3;170, 171, 172;,
    3;172, 171, 173;,
    3;171, 170, 174;,
    3;170, 175, 174;,
    3;176, 174, 177;,
    3;175, 177, 174;,
    3;171, 178, 173;,
    3;173, 178, 179;,
    3;174, 180, 171;,
    3;171, 180, 178;,
    3;174, 176, 180;,
    3;176, 181, 180;,
    3;182, 183, 184;,
    3;184, 183, 185;,
    3;186, 187, 188;,
    3;187, 189, 188;,
    3;187, 190, 189;,
    3;190, 191, 189;,
    3;192, 193, 194;,
    3;195, 194, 193;,
    3;193, 196, 195;,
    3;197, 195, 196;,
    3;198, 199, 200;,
    3;201, 200, 199;,
    3;198, 200, 202;,
    3;200, 203, 202;,
    3;168, 177, 166;,
    3;166, 177, 175;,
    3;166, 175, 164;,
    3;164, 175, 170;,
    3;162, 170, 160;,
    3;160, 170, 172;,
    3;198, 202, 173;,
    3;202, 172, 173;,
    3;199, 198, 179;,
    3;198, 173, 179;,
    3;184, 179, 182;,
    3;179, 178, 182;,
    3;187, 186, 180;,
    3;178, 180, 186;,
    3;190, 187, 181;,
    3;180, 181, 187;,
    3;192, 181, 193;,
    3;193, 181, 176;,
    3;196, 193, 177;,
    3;193, 176, 177;,
    3;204, 205, 206;,
    3;207, 206, 205;,
    3;208, 209, 210;,
    3;209, 211, 210;,
    3;212, 213, 214;,
    3;214, 213, 215;,
    3;216, 217, 218;,
    3;219, 218, 217;,
    3;220, 221, 222;,
    3;223, 222, 221;,
    3;220, 209, 221;,
    3;208, 221, 209;,
    3;214, 224, 212;,
    3;224, 225, 212;,
    3;217, 216, 226;,
    3;216, 227, 226;,
    3;211, 209, 204;,
    3;205, 204, 209;,
    3;214, 215, 221;,
    3;215, 223, 221;,
    3;218, 228, 216;,
    3;216, 228, 229;,
    3;229, 230, 216;,
    3;227, 216, 230;,
    3;225, 224, 210;,
    3;208, 210, 224;,
    3;214, 221, 224;,
    3;221, 208, 224;,
    3;231, 226, 227;,
    3;210, 227, 232;,
    3;232, 227, 230;,
    3;232, 230, 233;,
    3;233, 230, 234;,
    3;234, 235, 233;,
    3;236, 233, 235;,
    3;237, 238, 239;,
    3;238, 240, 239;,
    3;237, 226, 238;,
    3;231, 238, 226;,
    3;210, 231, 227;,
    3;204, 238, 211;,
    3;211, 238, 231;,
    3;238, 204, 240;,
    3;204, 206, 240;,
    3;225, 210, 232;,
    3;233, 241, 232;,
    3;241, 225, 232;,
    3;233, 236, 241;,
    3;242, 241, 236;,
    3;211, 231, 210;,
    3;243, 244, 245;,
    3;244, 246, 245;,
    3;247, 248, 249;,
    3;250, 249, 248;,
    3;251, 252, 253;,
    3;253, 252, 254;,
    3;255, 256, 257;,
    3;258, 257, 256;,
    3;259, 260, 261;,
    3;260, 262, 261;,
    3;261, 250, 259;,
    3;248, 259, 250;,
    3;253, 263, 251;,
    3;263, 264, 251;,
    3;256, 255, 265;,
    3;255, 266, 265;,
    3;249, 250, 246;,
    3;245, 246, 250;,
    3;267, 268, 259;,
    3;268, 260, 259;,
    3;269, 255, 270;,
    3;255, 257, 270;,
    3;269, 271, 255;,
    3;266, 255, 271;,
    3;264, 263, 247;,
    3;248, 247, 263;,
    3;259, 248, 267;,
    3;267, 248, 263;,
    3;272, 265, 266;,
    3;273, 247, 271;,
    3;247, 266, 271;,
    3;269, 274, 271;,
    3;274, 273, 271;,
    3;274, 269, 275;,
    3;275, 269, 270;,
    3;276, 277, 278;,
    3;277, 279, 278;,
    3;276, 265, 277;,
    3;272, 277, 265;,
    3;247, 272, 266;,
    3;246, 277, 249;,
    3;249, 277, 272;,
    3;277, 246, 279;,
    3;246, 244, 279;,
    3;264, 247, 273;,
    3;251, 264, 280;,
    3;264, 273, 280;,
    3;251, 280, 252;,
    3;252, 280, 281;,
    3;249, 272, 247;,
    3;282, 283, 284;,
    3;283, 285, 284;,
    3;286, 284, 287;,
    3;285, 287, 284;,
    3;282, 284, 288;,
    3;284, 289, 288;,
    3;286, 290, 284;,
    3;284, 290, 289;,
    3;291, 288, 292;,
    3;288, 289, 292;,
    3;293, 292, 290;,
    3;289, 290, 292;,
    3;294, 295, 292;,
    3;291, 292, 295;,
    3;292, 293, 294;,
    3;293, 296, 294;,
    3;297, 295, 298;,
    3;295, 294, 298;,
    3;299, 298, 296;,
    3;294, 296, 298;,
    3;298, 300, 297;,
    3;297, 300, 301;,
    3;298, 299, 300;,
    3;299, 302, 300;,
    3;303, 304, 305;,
    3;306, 305, 304;,
    3;304, 307, 306;,
    3;308, 306, 307;,
    3;303, 296, 304;,
    3;304, 296, 293;,
    3;307, 304, 290;,
    3;304, 293, 290;,
    3;309, 310, 311;,
    3;310, 312, 311;,
    3;311, 312, 313;,
    3;312, 314, 313;,
    3;309, 311, 295;,
    3;311, 291, 295;,
    3;313, 288, 311;,
    3;311, 288, 291;;

   MeshTextureCoords {
    315;
    0.668059; 0.770242;,
    0.587447; 0.834840;,
    0.694163; 0.822091;,
    0.605074; 0.871736;,
    0.795154; 0.790190;,
    0.737156; 0.703545;,
    0.725218; 0.806230;,
    0.687910; 0.761146;,
    0.909015; 0.611851;,
    0.838569; 0.655565;,
    0.936014; 0.661887;,
    0.878402; 0.696553;,
    0.828577; 0.920026;,
    0.893313; 0.977476;,
    0.877015; 0.883716;,
    0.923778; 0.944713;,
    0.723873; 0.691219;,
    0.659636; 0.576661;,
    0.657956; 0.746425;,
    0.586590; 0.592852;,
    0.818482; 0.670687;,
    0.862966; 0.703226;,
    0.814213; 0.891981;,
    0.868134; 0.868763;,
    0.822615; 0.639404;,
    0.745388; 0.547303;,
    0.937923; 0.837468;,
    0.976950; 0.900656;,
    0.906632; 0.824157;,
    0.752011; 0.872745;,
    0.893816; 0.754909;,
    0.910989; 0.750977;,
    0.940508; 0.809463;,
    1.000000; 0.758156;,
    0.963900; 0.708937;,
    0.806571; 0.919497;,
    0.739729; 0.897706;,
    0.764389; 0.998629;,
    0.709889; 0.976499;,
    0.728489; 0.893792;,
    0.637613; 0.929774;,
    0.307959; 0.185489;,
    0.382025; 0.165645;,
    0.306548; 0.138776;,
    0.375494; 0.129262;,
    0.202562; 0.183491;,
    0.238604; 0.214440;,
    0.287577; 0.143255;,
    0.287896; 0.188057;,
    0.079638; 0.225851;,
    0.064502; 0.299365;,
    0.139218; 0.259461;,
    0.101444; 0.326751;,
    0.180895; 0.080036;,
    0.235866; 0.071136;,
    0.171362; 0.014029;,
    0.212860; 0.007037;,
    0.341470; 0.332653;,
    0.308325; 0.203190;,
    0.257448; 0.347228;,
    0.249410; 0.230163;,
    0.158021; 0.244044;,
    0.100939; 0.212385;,
    0.234229; 0.088898;,
    0.182120; 0.098177;,
    0.146047; 0.271371;,
    0.183621; 0.359625;,
    0.104850; 0.087259;,
    0.117306; 0.023159;,
    0.129537; 0.112976;,
    0.269842; 0.099561;,
    0.106428; 0.161830;,
    0.089944; 0.109130;,
    0.084540; 0.156733;,
    0.018090; 0.136246;,
    0.018879; 0.093691;,
    0.275757; 0.068915;,
    0.249685; 0.000000;,
    0.296640; 0.090222;,
    0.369505; 0.085206;,
    0.074724; 0.209875;,
    0.002261; 0.205896;,
    0.106929; 0.568527;,
    0.070579; 0.519608;,
    0.063821; 0.615718;,
    0.025853; 0.578821;,
    0.112429; 0.465815;,
    0.086946; 0.507441;,
    0.163586; 0.514984;,
    0.124984; 0.553822;,
    0.189783; 0.403635;,
    0.133407; 0.321268;,
    0.153256; 0.421116;,
    0.099722; 0.345038;,
    0.234230; 0.586316;,
    0.203131; 0.625264;,
    0.289797; 0.632185;,
    0.263959; 0.659656;,
    0.101603; 0.457325;,
    0.050979; 0.374569;,
    0.061029; 0.495120;,
    0.008169; 0.393924;,
    0.154923; 0.437671;,
    0.189685; 0.432760;,
    0.184831; 0.601497;,
    0.222648; 0.573063;,
    0.279620; 0.535673;,
    0.330055; 0.594861;,
    0.249162; 0.525873;,
    0.160217; 0.576031;,
    0.209993; 0.469254;,
    0.232040; 0.459342;,
    0.277167; 0.510862;,
    0.305576; 0.411548;,
    0.336515; 0.451926;,
    0.140169; 0.599956;,
    0.086893; 0.646711;,
    0.169320; 0.625579;,
    0.107176; 0.666362;,
    0.206965; 0.421318;,
    0.283945; 0.382308;,
    0.388539; 0.175582;,
    0.319414; 0.205189;,
    0.395432; 0.234448;,
    0.336387; 0.254136;,
    0.449860; 0.150218;,
    0.408290; 0.173123;,
    0.469465; 0.216034;,
    0.417934; 0.230574;,
    0.545420; 0.133927;,
    0.536454; 0.034500;,
    0.505990; 0.131704;,
    0.496390; 0.038006;,
    0.494898; 0.310071;,
    0.449704; 0.328233;,
    0.519130; 0.372580;,
    0.483908; 0.383808;,
    0.444762; 0.137976;,
    0.441074; 0.040484;,
    0.392528; 0.150296;,
    0.396194; 0.038403;,
    0.499437; 0.146496;,
    0.531302; 0.158723;,
    0.445705; 0.299430;,
    0.491480; 0.293316;,
    0.557826; 0.288629;,
    0.571750; 0.361635;,
    0.536738; 0.265888;,
    0.437108; 0.266171;,
    0.530888; 0.199300;,
    0.554366; 0.201368;,
    0.567721; 0.266467;,
    0.640745; 0.195784;,
    0.645074; 0.244914;,
    0.408537; 0.276964;,
    0.342349; 0.291223;,
    0.421003; 0.312539;,
    0.351405; 0.317080;,
    0.551472; 0.157234;,
    0.638259; 0.160604;,
    0.720470; 0.345112;,
    0.624008; 0.347471;,
    0.711600; 0.394648;,
    0.628598; 0.384793;,
    0.714879; 0.400709;,
    0.655097; 0.445988;,
    0.735641; 0.472027;,
    0.685009; 0.490717;,
    0.764995; 0.524555;,
    0.714096; 0.524739;,
    0.734118; 0.394674;,
    0.788364; 0.384616;,
    0.739999; 0.350725;,
    0.802702; 0.336573;,
    0.803412; 0.437503;,
    0.771255; 0.450171;,
    0.831365; 0.486471;,
    0.791839; 0.499889;,
    0.856097; 0.369599;,
    0.831027; 0.327866;,
    0.865279; 0.416644;,
    0.864363; 0.457681;,
    0.883980; 0.354833;,
    0.948901; 0.312432;,
    0.856839; 0.307670;,
    0.932428; 0.275330;,
    0.884938; 0.363880;,
    0.890336; 0.415598;,
    0.953671; 0.361512;,
    0.951391; 0.401175;,
    0.889803; 0.462567;,
    0.951577; 0.437540;,
    0.880999; 0.476188;,
    0.839408; 0.501589;,
    0.904648; 0.532782;,
    0.867624; 0.543544;,
    0.802882; 0.533982;,
    0.836888; 0.564083;,
    0.797284; 0.308960;,
    0.842567; 0.287739;,
    0.773720; 0.187793;,
    0.798360; 0.182477;,
    0.719541; 0.334196;,
    0.716926; 0.202855;,
    0.555890; 0.772901;,
    0.577843; 0.828776;,
    0.630694; 0.734853;,
    0.642613; 0.782066;,
    0.523090; 0.868666;,
    0.558966; 0.836145;,
    0.488109; 0.808649;,
    0.534986; 0.782114;,
    0.432889; 0.907232;,
    0.464131; 1.000000;,
    0.472304; 0.900164;,
    0.501062; 0.983428;,
    0.441411; 0.723954;,
    0.479240; 0.694413;,
    0.382355; 0.642831;,
    0.411316; 0.622349;,
    0.580505; 0.855197;,
    0.530918; 0.879541;,
    0.603343; 0.974918;,
    0.557775; 0.972932;,
    0.475219; 0.884010;,
    0.440952; 0.879375;,
    0.490996; 0.721492;,
    0.448458; 0.738853;,
    0.343413; 0.674371;,
    0.385157; 0.757518;,
    0.410668; 0.775479;,
    0.507567; 0.751900;,
    0.431866; 0.839327;,
    0.408351; 0.842732;,
    0.380173; 0.781920;,
    0.290565; 0.835086;,
    0.318873; 0.873005;,
    0.512105; 0.702933;,
    0.532763; 0.734337;,
    0.617688; 0.673848;,
    0.623900; 0.698885;,
    0.421480; 0.885386;,
    0.338936; 0.900014;,
    0.438064; 0.338424;,
    0.403258; 0.359183;,
    0.472647; 0.395472;,
    0.429396; 0.406471;,
    0.466114; 0.486374;,
    0.517594; 0.477033;,
    0.435432; 0.421976;,
    0.479278; 0.414051;,
    0.510092; 0.589962;,
    0.540567; 0.668185;,
    0.558029; 0.565492;,
    0.591821; 0.646013;,
    0.387651; 0.520968;,
    0.359028; 0.467100;,
    0.324453; 0.553038;,
    0.309060; 0.513072;,
    0.533108; 0.465032;,
    0.632465; 0.413843;,
    0.491964; 0.394106;,
    0.602814; 0.360356;,
    0.551209; 0.543923;,
    0.506877; 0.571023;,
    0.387659; 0.462665;,
    0.405731; 0.517051;,
    0.576474; 0.548223;,
    0.662033; 0.477557;,
    0.417755; 0.584634;,
    0.345384; 0.604448;,
    0.431523; 0.562040;,
    0.415327; 0.444525;,
    0.454779; 0.586646;,
    0.436024; 0.605456;,
    0.355500; 0.627230;,
    0.370689; 0.437890;,
    0.401371; 0.421254;,
    0.347432; 0.375944;,
    0.373749; 0.366531;,
    0.456571; 0.610878;,
    0.491060; 0.691582;,
    0.123241; 0.693545;,
    0.080089; 0.668062;,
    0.083583; 0.744616;,
    0.047524; 0.721524;,
    0.051403; 0.792088;,
    0.000000; 0.752168;,
    0.149949; 0.721637;,
    0.110019; 0.761807;,
    0.089231; 0.804997;,
    0.209715; 0.747761;,
    0.159482; 0.783319;,
    0.129623; 0.841097;,
    0.211511; 0.836242;,
    0.245843; 0.794042;,
    0.167406; 0.861161;,
    0.278661; 0.817147;,
    0.235147; 0.862784;,
    0.187338; 0.897165;,
    0.283195; 0.927529;,
    0.315730; 0.893929;,
    0.246713; 0.954704;,
    0.154250; 0.900628;,
    0.111505; 0.870508;,
    0.098654; 0.961152;,
    0.077782; 0.933241;,
    0.060782; 0.832048;,
    0.051421; 0.896765;,
    0.284282; 0.770208;,
    0.346018; 0.695497;,
    0.230367; 0.722880;,
    0.293176; 0.677106;,
    0.163242; 0.678756;,
    0.221018; 0.648173;;
   }

   MeshMaterialList {
    1;
    392;
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
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

    Material lambert14SG {
     0.000000; 0.000000; 0.000000; 1.000000;;
     128.000000;
     1.000000; 1.000000; 1.000000;;
     0.000000; 0.000000; 0.000000;;

     TextureFilename {
      "rock_006_c.tga";
     }
    }

   }
  }
}
