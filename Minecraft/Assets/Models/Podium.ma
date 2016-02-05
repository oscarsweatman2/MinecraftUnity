//Maya ASCII 2016 scene
//Name: Podium.ma
//Last modified: Fri, Feb 05, 2016 11:30:29 AM
//Codeset: 1252
requires maya "2016";
requires "stereoCamera" "10.0";
currentUnit -l centimeter -a degree -t film;
fileInfo "application" "maya";
fileInfo "product" "Maya 2016";
fileInfo "version" "2016";
fileInfo "cutIdentifier" "201502261600-953408";
fileInfo "osv" "Microsoft Windows 7 Business Edition, 64-bit Windows 7 Service Pack 1 (Build 7601)\n";
createNode transform -n "pCube2";
	rename -uid "18047E47-42CC-018F-7EB0-79990746501A";
	setAttr ".t" -type "double3" 0 2.7395038303399604 0 ;
	setAttr ".rp" -type "double3" 0 1.8929321765899658 -3.8387211561203003 ;
	setAttr ".sp" -type "double3" 0 1.8929321765899658 -3.8387211561203003 ;
createNode mesh -n "pCube2Shape" -p "pCube2";
	rename -uid "5D0B9A1C-48A1-0E14-0300-ADADBB61566C";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.79286873340606689 0.62041094899177551 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
createNode mesh -n "polySurfaceShape1" -p "pCube2";
	rename -uid "5782C85A-4B3A-CD20-6E1E-7495F1F57F2E";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr -s 4 ".iog[0].og";
	setAttr ".iog[0].og[0].gcl" -type "componentList" 1 "f[0:15]";
	setAttr ".iog[0].og[1].gcl" -type "componentList" 1 "f[16:31]";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 105 ".uvst[0].uvsp[0:104]" -type "float2" 0.375 0.14708167
		 0.625 0.14708167 0.625 0.25 0.375 0.25 0.125 0.14708167 0.125 0.25 0.375 0 0.625
		 0 0.875 0.14708167 0.875 0.25 0.375 0.25 0.375 0.25 0.375 0.25 0.375 0.5 0.625 0.5
		 0.625 0.60291833 0.375 0.60291833 0.125 0 0.375 0.5 0.375 0.75 0.625 0.75 0.625 1
		 0.375 1 0.875 0 0.625 0.5 0.625 0.25 0.53868282 0.33631715 0.54073203 0.32963169
		 0.50659215 0.2884405 0.50448859 0.28737772 0.50238502 0.2884405 0.46824515 0.32963169
		 0.48633873 0.38866124 0.48073071 0.39426932 0.46974114 0.35465986 0.43388483 0.34158874
		 0.4305931 0.34175271 0.42887199 0.34448501 0.42409599 0.38023639 0.46157297 0.413427
		 0.625 0.5 0.625 0.5 0.48264915 0.43209264 0.48949295 0.43499732 0.49014911 0.4282158
		 0.50015849 0.43374741 0.50448859 0.43943244 0.5198471 0.43586832 0.52650625 0.43272835
		 0.58289421 0.37906438 0.57757199 0.34372312 0.57584375 0.34108734 0.57262516 0.34105128
		 0.53773487 0.35539728 0.51908261 0.42913467 0.50881875 0.43374741 0.47730452 0.14824013
		 0.52950358 0.11459007 0.50578994 0.026741369 0.66768909 0.76988852 0.65546417 0.72997129
		 0.706442 0.77007043 0.47730452 0.14824013 0.49195167 0.96100336 0.50578994 0.97766674
		 0.33192834 0.76831269 0.706442 0.77007043 0.55974847 0.41743824 0.66768909 0.76988858
		 0.51699543 0.96607333 0.706442 0.77007043 0.33192834 0.76831269 0.49195167 0.96100336
		 0.46841526 0.18615536 0.53703666 0.14249688 0.50578994 0.026741369 0.64730763 0.76979291
		 0.55097514 0.45550755 0.706442 0.77007043 0.46789229 0.18838608 0.48010102 0.94673359
		 0.50578994 0.97766674 0.33192834 0.76831269 0.706442 0.77007043 0.52979755 0.39765036
		 0.63987565 0.76975799 0.52677178 0.9559586 0.706442 0.77007043 0.33192834 0.76831269
		 0.47971034 0.94626307 0.46780646 0.18875213 0.53713262 0.14285238 0.50578994 0.026741369
		 0.64021611 0.76975965 0.706442 0.77007043 0.46829125 0.18668441 0.47981322 0.94638699
		 0.50578994 0.97766674 0.33192834 0.76831269 0.64709336 0.7697919 0.706442 0.77007043
		 0.52669847 0.95603448 0.706442 0.77007043 0.33192834 0.76831269 0.48017365 0.94682097;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 65 ".vt[0:64]"  -3.34437203 -0.53265536 3.34437203 3.34437203 -0.53265536 3.34437203
		 3.34437203 6.43169308 3.34437203 -3.34437203 6.43169308 3.34437203 -3.34437203 -0.53265536 -3.34437203
		 -3.34437203 4.042915344 -3.34437203 -3.34437203 -2.64582872 3.34437203 3.34437203 -2.64582872 3.34437203
		 3.34437203 -0.53265536 -3.34437203 3.34437203 4.042915344 -3.34437203 3.34437203 6.43169308 3.34437203
		 -3.34437203 6.43169308 3.34437203 -3.34437203 -2.64582872 -11.021814346 -3.34437203 4.042915344 -3.34437203
		 3.34437203 -2.64582872 -11.021814346 3.34437203 4.042915344 -3.34437203 1.034958482 5.6069231 1.034958482
		 1.089785218 5.67080355 1.21382797 0.17637345 6.064389706 2.31589723 0.12009239 6.074544907 2.34433246
		 0.063811339 6.064389706 2.31589723 -0.84960037 5.67080355 1.21382821 -0.36550611 5.10676956 -0.36550611
		 -0.5155496 5.053184032 -0.5155496 -0.80957562 5.43165636 0.54420018 -1.76890981 5.55655289 0.89391792
		 -1.8569802 5.55498552 0.88953012 -1.90302718 5.52887821 0.81642771 -2.030810833 5.18727016 -0.1400993
		 -1.028113842 4.87012959 -1.028113842 -0.46422157 4.69177771 -1.5275116 -0.2811164 4.6640234 -1.60522652
		 -0.26356032 4.72882128 -1.42378759 0.0042403108 4.67596579 -1.57178617 0.12009239 4.62164497 -1.72388899
		 0.5310086 4.65570068 -1.62853074 0.70917416 4.68570328 -1.54452085 2.21783257 5.19846869 -0.10874253
		 2.075437307 5.53615808 0.83681202 2.029198408 5.56134367 0.9073332 1.94308507 5.56168795 0.90829766
		 1.0095950365 5.42461061 0.52447033 0.51055461 4.72004128 -1.44837177 0.23594448 4.67596579 -1.57178617
		 0.12009239 4.36467028 -2.074146271 1.12009239 5.60226011 1.23942828 0.12009239 6.047070026 2.43038106
		 0.82719898 4.93984699 1.48683333 -0.87990761 5.60226011 1.23942852 0.12009239 4.66546726 1.58931208
		 -0.5870142 4.93984747 1.48683357 -0.070670128 4.43124962 -1.89588451 -0.77987671 5.35968304 0.58994269
		 -1.90777016 5.51165676 0.99684405 -0.96796799 4.82555008 0.66998434 -2.064242363 5.09233284 -0.12587261
		 -1.42206001 4.52600002 0.4934814 -1.87615108 4.63650513 0.16382682 0.33026123 4.42012882 -1.92565894
		 2.25073719 5.10453415 -0.093203783 2.077330589 5.51866579 1.015609264 2.064658165 4.64578152 0.18866432
		 0.98010731 5.3519125 0.56913757 1.61542225 4.52821541 0.49941349 1.16618633 4.82070446 0.65701067;
	setAttr -s 145 ".ed[0:144]"  0 1 0 1 2 0 2 3 0 3 0 0 4 0 1 3 5 0 5 4 0
		 6 7 0 7 1 0 0 6 0 1 8 1 8 9 0 9 2 0 2 10 0 10 11 0 11 3 0 5 9 0 8 4 0 12 6 0 4 12 0
		 11 13 0 13 5 0 12 14 0 14 7 0 14 8 0 9 15 0 15 10 0 10 16 1 16 17 0 17 18 0 18 19 0
		 19 20 0 20 21 0 21 22 0 22 23 1 23 24 0 24 25 0 25 26 0 26 27 0 27 28 0 28 29 0 29 13 1
		 13 15 0 29 30 0 30 31 0 31 32 0 32 23 0 22 33 0 33 34 0 34 35 1 35 36 0 36 37 0 37 38 0
		 38 39 0 39 16 1 39 40 0 40 41 0 41 42 0 42 35 0 34 43 0 43 16 0 34 44 0 44 43 0 44 45 0
		 45 17 0 33 44 0 45 46 0 46 18 0 44 47 0 47 45 0 48 44 0 21 48 0 46 19 0 47 46 0 44 49 0
		 49 47 0 50 44 0 48 50 0 20 46 0 46 48 0 49 46 0 50 49 0 46 50 0 32 31 0 31 51 0 51 32 0
		 24 23 0 23 32 0 51 52 0 52 24 0 31 30 0 30 51 0 25 24 0 52 53 0 53 25 0 51 54 0 54 52 0
		 55 51 0 30 29 0 29 28 0 28 55 0 26 25 0 53 26 0 54 53 0 51 56 0 56 54 0 57 51 0 55 57 0
		 28 27 0 27 53 0 53 55 0 27 26 0 56 53 0 57 56 0 53 57 0 36 35 0 35 58 0 58 36 0 37 36 0
		 58 59 0 59 37 0 35 42 0 42 58 0 38 37 0 59 60 0 60 38 0 58 61 0 61 59 0 42 41 0 41 62 0
		 62 58 0 39 38 0 60 39 0 61 60 0 58 63 0 63 61 0 64 58 0 62 64 0 41 40 0 40 60 0 60 62 0
		 40 39 0 63 60 0 64 63 0 60 64 0;
	setAttr -s 64 -ch 254 ".fc[0:63]" -type "polyFaces" 
		f 4 0 1 2 3
		mu 0 4 0 1 2 3
		f 4 4 -4 5 6
		mu 0 4 4 0 3 5
		f 4 7 8 -1 9
		mu 0 4 6 7 1 0
		f 4 10 11 12 -2
		mu 0 4 1 8 9 2
		f 4 -3 13 14 15
		mu 0 4 3 10 11 12
		f 4 16 -12 17 -7
		mu 0 4 13 14 15 16
		f 4 18 -10 -5 19
		mu 0 4 17 6 0 4
		f 4 -6 -16 20 21
		mu 0 4 13 3 12 18
		f 4 22 23 -8 -19
		mu 0 4 19 20 21 22
		f 4 -24 24 -11 -9
		mu 0 4 7 23 8 1
		f 4 -13 25 26 -14
		mu 0 4 2 14 24 25
		f 17 -15 27 28 29 30 31 32 33 34 35 36 37 38 39 40 41 -21
		mu 0 17 12 25 26 27 28 29 30 31 32 33 34 35 36 37 38 39 18
		f 4 -17 -22 42 -26
		mu 0 4 14 40 41 24
		f 4 -18 -25 -23 -20
		mu 0 4 16 15 20 19
		f 17 -42 43 44 45 46 -35 47 48 49 50 51 52 53 54 -28 -27 -43
		mu 0 17 18 39 42 43 44 33 32 45 46 47 48 49 50 51 26 25 24
		f 8 55 56 57 58 -50 59 60 -55
		mu 0 8 51 52 53 54 47 46 55 26
		f 3 -60 61 62
		mu 0 3 56 57 58
		f 5 -29 -61 -63 63 64
		mu 0 5 59 60 56 58 61
		f 3 -49 65 -62
		mu 0 3 57 62 58
		f 4 -30 -65 66 67
		mu 0 4 63 59 61 64
		f 3 -64 68 69
		mu 0 3 61 58 65
		f 5 70 -66 -48 -34 71
		mu 0 5 66 58 62 67 68
		f 3 -31 -68 72
		mu 0 3 69 63 64
		f 3 73 -67 -70
		mu 0 3 65 64 61
		f 3 -69 74 75
		mu 0 3 65 58 70
		f 3 76 -71 77
		mu 0 3 71 58 66
		f 4 -33 78 79 -72
		mu 0 4 68 72 64 66
		f 3 -32 -73 -79
		mu 0 3 72 69 64
		f 3 80 -74 -76
		mu 0 3 70 64 65
		f 3 -75 -77 81
		mu 0 3 70 58 71
		f 3 -80 82 -78
		mu 0 3 66 64 71
		f 3 -83 -81 -82
		mu 0 3 71 64 70
		f 3 83 84 85
		mu 0 3 73 74 75
		f 5 86 87 -86 88 89
		mu 0 5 76 77 73 75 78
		f 3 90 91 -85
		mu 0 3 74 79 75
		f 4 92 -90 93 94
		mu 0 4 80 76 78 81
		f 3 -89 95 96
		mu 0 3 78 75 82
		f 5 97 -92 98 99 100
		mu 0 5 83 75 79 84 85
		f 3 101 -95 102
		mu 0 3 86 80 81
		f 3 103 -94 -97
		mu 0 3 82 81 78
		f 3 -96 104 105
		mu 0 3 82 75 87
		f 3 106 -98 107
		mu 0 3 88 75 83
		f 4 108 109 110 -101
		mu 0 4 85 89 81 83
		f 3 111 -103 -110
		mu 0 3 89 86 81
		f 3 112 -104 -106
		mu 0 3 87 81 82
		f 3 -105 -107 113
		mu 0 3 87 75 88
		f 3 -111 114 -108
		mu 0 3 83 81 88
		f 3 -115 -113 -114
		mu 0 3 88 81 87
		f 3 115 116 117
		mu 0 3 90 91 92
		f 4 118 -118 119 120
		mu 0 4 93 90 92 94
		f 3 121 122 -117
		mu 0 3 91 95 92
		f 4 123 -121 124 125
		mu 0 4 96 93 94 97
		f 3 -120 126 127
		mu 0 3 94 92 98
		f 4 128 129 130 -123
		mu 0 4 95 99 100 92
		f 3 131 -126 132
		mu 0 3 101 96 97
		f 3 133 -125 -128
		mu 0 3 98 97 94
		f 3 -127 134 135
		mu 0 3 98 92 102
		f 3 136 -131 137
		mu 0 3 103 92 100
		f 4 138 139 140 -130
		mu 0 4 99 104 97 100
		f 3 141 -133 -140
		mu 0 3 104 101 97
		f 3 142 -134 -136
		mu 0 3 102 97 98
		f 3 -135 -137 143
		mu 0 3 102 92 103
		f 3 -141 144 -138
		mu 0 3 100 97 103
		f 3 -145 -143 -144
		mu 0 3 103 97 102;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
createNode polyTweakUV -n "polyTweakUV5";
	rename -uid "C3C955AC-498F-3FFA-AC05-EEA453AF94EC";
	setAttr ".uopa" yes;
	setAttr -s 85 ".uvtk[0:84]" -type "float2" -0.29090428 0.0042092726
		 -0.080939218 0.0042092726 -0.17869674 -0.033519171 -0.080939218 -0.033519171 0.24270672
		 0.33894032 0.21402371 0.2351914 0.25734627 0.32427233 0.21012115 0.16965142 -0.29090428
		 0.0042092726 -0.17869674 -0.033519171 -0.080939218 0.0042092726 -0.080939218 -0.033519171
		 0.12042729 0.20085886 -0.76332378 0.53267193 -1.41591287 0.53267193 -0.76332378 0.45327449
		 -1.41591287 0.45327449 0.2934162 0.44237018 0.26728874 0.42785609 0.26557529 0.44561124
		 0.30471891 0.45726907 0.4909904 0.19996634 0.48258883 0.19986239 0.39398777 0.1873658
		 0.39151144 0.2373237 0.31602252 0.44239575 0.34481025 0.44798183 0.34281534 0.4303478
		 0.30465788 0.49834955 0.40225947 0.17137006 0.39933759 0.16986623 0.31022447 0.061907172
		 0.30470741 0.053698178 0.37334388 0.18584183 0.20712906 0.17114881 0.30473334 0.059118092
		 0.3042143 0.19177106 0.23536587 0.18568519 0.29924226 0.061894536 0.28604805 0.48073167
		 0.21688157 0.23527217 0.24771076 0.43798524 0.10684285 0.19498113 0.19827563 0.25643703
		 0.091564216 0.30578953 0.19269633 0.38904732 0.09487126 0.3020277 0.1118348 0.20127848
		 0.15386426 0.28585786 0.10966299 0.30630034 0.10734198 0.20842797 0.36219341 0.4397797
		 0.32516468 0.4837153 0.50939095 0.29942912 0.51255631 0.30304229 0.49550152 0.2068733
		 0.49565005 0.19356993 0.49414897 0.30428463 0.38859451 0.23752064 0.45021671 0.28560859
		 0.4064945 0.25795397 -0.005910344 0.58963943 -0.65933931 -0.1268785 -0.96999776 -0.12687853
		 -0.65933931 0.38063323 -0.96999788 0.38063318 -0.76332378 0.29948127 -0.033425309
		 0.62995583 -0.033425607 -0.021892823 -0.00064900657 -0.0082797743 -1.41591287 0.29948127
		 0.59190464 0.59031749 0.61916316 0.63109004 -0.080939218 -0.14686507 -0.17869674
		 -0.10694447 -0.080939218 -0.14686507 -0.17869674 -0.10694447 -0.18172111 1.032098055
		 -0.11769809 1.032098055 -0.18172111 1.095558167 -0.11769809 1.095558167 -0.18172111
		 1.11668169 -0.11769809 1.11668169 0.58668691 -0.0076138731 0.6191628 -0.021152534;
createNode polyPlanarProj -n "polyPlanarProj7";
	rename -uid "D6A69B3B-4CE0-F7C6-D26A-DDA74C13C5D6";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 4 "f[8:10]" "f[13:90]" "f[97:117]" "f[120:121]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 2.7395038303399604 0 1;
	setAttr ".ws" yes;
	setAttr ".pc" -type "double3" 0.00014501810073852539 7.6438064575195312 0.016518354415893555 ;
	setAttr ".ro" -type "double3" 122.98655365642507 -0.092952560672130119 -179.73384092889555 ;
	setAttr ".ps" -type "double2" 6.6886672275947419 6.8896304731443472 ;
	setAttr ".cam" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
createNode polyTweakUV -n "polyTweakUV4";
	rename -uid "1A38D1B1-4843-12BE-04D4-F19DAEC8D799";
	setAttr ".uopa" yes;
	setAttr -s 62 ".uvtk";
	setAttr ".uvtk[4]" -type "float2" 1.3824871 -0.37602025 ;
	setAttr ".uvtk[5]" -type "float2" 1.3824871 -0.37305912 ;
	setAttr ".uvtk[6]" -type "float2" 1.3824871 -0.37560099 ;
	setAttr ".uvtk[7]" -type "float2" 1.3824871 -0.37118813 ;
	setAttr ".uvtk[12]" -type "float2" 1.3824871 -0.37208202 ;
	setAttr ".uvtk[13]" -type "float2" 1.3824871 -0.3761178 ;
	setAttr ".uvtk[14]" -type "float2" 1.3824871 -0.3761178 ;
	setAttr ".uvtk[15]" -type "float2" 1.3824871 -0.3761178 ;
	setAttr ".uvtk[16]" -type "float2" 1.3824871 -0.3761178 ;
	setAttr ".uvtk[17]" -type "float2" 1.3824871 -0.37897158 ;
	setAttr ".uvtk[18]" -type "float2" 1.3824871 -0.37855804 ;
	setAttr ".uvtk[19]" -type "float2" 1.3824871 -0.37906501 ;
	setAttr ".uvtk[20]" -type "float2" 1.3824871 -0.37939659 ;
	setAttr ".uvtk[21]" -type "float2" 1.3824869 -0.37204447 ;
	setAttr ".uvtk[22]" -type "float2" 1.3824872 -0.37204179 ;
	setAttr ".uvtk[23]" -type "float2" 1.3824872 -0.37168786 ;
	setAttr ".uvtk[24]" -type "float2" 1.3824869 -0.37311426 ;
	setAttr ".uvtk[25]" -type "float2" 1.3824871 -0.37897158 ;
	setAttr ".uvtk[26]" -type "float2" 1.3824871 -0.37913015 ;
	setAttr ".uvtk[27]" -type "float2" 1.3824871 -0.37862673 ;
	setAttr ".uvtk[28]" -type "float2" 1.3824871 -0.38140714 ;
	setAttr ".uvtk[29]" -type "float2" 1.3824871 -0.3717244 ;
	setAttr ".uvtk[30]" -type "float2" 1.3824872 -0.37118813 ;
	setAttr ".uvtk[31]" -type "float2" 1.3824871 -0.36810872 ;
	setAttr ".uvtk[32]" -type "float2" 1.3824871 -0.3682442 ;
	setAttr ".uvtk[33]" -type "float2" 1.3824869 -0.37690699 ;
	setAttr ".uvtk[34]" -type "float2" 1.3824871 -0.3717244 ;
	setAttr ".uvtk[35]" -type "float2" 1.3824871 -0.36802921 ;
	setAttr ".uvtk[36]" -type "float2" 1.3824871 -0.37905374 ;
	setAttr ".uvtk[37]" -type "float2" 1.3824871 -0.37690699 ;
	setAttr ".uvtk[38]" -type "float2" 1.3824871 -0.36810872 ;
	setAttr ".uvtk[39]" -type "float2" 1.3824871 -0.38088623 ;
	setAttr ".uvtk[40]" -type "float2" 1.3824871 -0.37362221 ;
	setAttr ".uvtk[41]" -type "float2" 1.3824871 -0.3788479 ;
	setAttr ".uvtk[42]" -type "float2" 1.3824871 -0.37243327 ;
	setAttr ".uvtk[43]" -type "float2" 1.3824871 -0.37780124 ;
	setAttr ".uvtk[44]" -type "float2" 1.3824871 -0.37571397 ;
	setAttr ".uvtk[45]" -type "float2" 1.3824871 -0.37745246 ;
	setAttr ".uvtk[46]" -type "float2" 1.3824871 -0.37497115 ;
	setAttr ".uvtk[47]" -type "float2" 1.3824871 -0.37209424 ;
	setAttr ".uvtk[48]" -type "float2" 1.3824871 -0.38014492 ;
	setAttr ".uvtk[49]" -type "float2" 1.3824871 -0.37928033 ;
	setAttr ".uvtk[50]" -type "float2" 1.3824871 -0.37229845 ;
	setAttr ".uvtk[51]" -type "float2" 1.3824871 -0.3788954 ;
	setAttr ".uvtk[52]" -type "float2" 1.3824871 -0.38097322 ;
	setAttr ".uvtk[53]" -type "float2" 1.3824871 -0.37488356 ;
	setAttr ".uvtk[54]" -type "float2" 1.3824871 -0.37561849 ;
	setAttr ".uvtk[55]" -type "float2" 1.3824872 -0.37224153 ;
	setAttr ".uvtk[56]" -type "float2" 1.3824869 -0.37237844 ;
	setAttr ".uvtk[57]" -type "float2" 1.3824869 -0.37920773 ;
	setAttr ".uvtk[58]" -type "float2" 1.3824871 -0.37368307 ;
	setAttr ".uvtk[59]" -type "float2" 1.3824869 -0.38012758 ;
	setAttr ".uvtk[60]" -type "float2" 1.3824871 -0.37783915 ;
	setAttr ".uvtk[61]" -type "float2" 1.3824871 -0.38318589 ;
	setAttr ".uvtk[66]" -type "float2" 1.3824871 -0.38612074 ;
	setAttr ".uvtk[67]" -type "float2" 1.3824871 -0.36785123 ;
	setAttr ".uvtk[68]" -type "float2" 1.3824871 -0.36611494 ;
	setAttr ".uvtk[69]" -type "float2" 1.3824871 -0.38318589 ;
	setAttr ".uvtk[70]" -type "float2" 1.3824871 -0.38612074 ;
	setAttr ".uvtk[71]" -type "float2" 1.3824869 -0.36611494 ;
	setAttr ".uvtk[72]" -type "float2" 1.3824871 -0.36785123 ;
createNode polyPlanarProj -n "polyPlanarProj6";
	rename -uid "8273F44F-40E8-EBFC-3B8E-0FBE5879503E";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 3 "f[8:90]" "f[96:117]" "f[119:121]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 2.7395038303399604 0 1;
	setAttr ".ws" yes;
	setAttr ".pc" -type "double3" -1.1920928955078125e-007 4.5293636322021484 -3.8387211561203003 ;
	setAttr ".ps" -type "double2" 6.6887443065643311 9.0587272644042969 ;
	setAttr ".cam" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
createNode polyPlanarProj -n "polyPlanarProj5";
	rename -uid "514C2690-4181-7C3F-4B2E-968780DA49BA";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 3 "f[8:90]" "f[96:117]" "f[119:121]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 2.7395038303399604 0 1;
	setAttr ".ws" yes;
	setAttr ".pc" -type "double3" -1.1920928955078125e-007 4.5293636322021484 -3.8387211561203003 ;
	setAttr ".ro" -type "double3" -90 0 0 ;
	setAttr ".ps" -type "double2" 6.6887443065643311 14.366186380386353 ;
	setAttr ".cam" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
createNode polyTweakUV -n "polyTweakUV3";
	rename -uid "49C0D97E-4B37-A639-C59E-1B8E7F6EE90C";
	setAttr ".uopa" yes;
	setAttr -s 22 ".uvtk";
	setAttr ".uvtk[0]" -type "float2" 0.29797524 0.0050826725 ;
	setAttr ".uvtk[1]" -type "float2" 0.067977205 0.0050826725 ;
	setAttr ".uvtk[2]" -type "float2" 0.17506185 0.0050826799 ;
	setAttr ".uvtk[3]" -type "float2" 0.067977205 0.0050826799 ;
	setAttr ".uvtk[8]" -type "float2" 0.29797524 0.0050826725 ;
	setAttr ".uvtk[9]" -type "float2" 0.17506185 0.0050826799 ;
	setAttr ".uvtk[10]" -type "float2" 0.067977205 0.0050826725 ;
	setAttr ".uvtk[11]" -type "float2" 0.067977205 0.0050826799 ;
	setAttr ".uvtk[62]" -type "float2" 0.78527558 -0.3304081 ;
	setAttr ".uvtk[63]" -type "float2" 0.017786738 -0.3304081 ;
	setAttr ".uvtk[64]" -type "float2" 0.78527558 0.28974688 ;
	setAttr ".uvtk[65]" -type "float2" 0.017786738 0.28974688 ;
	setAttr ".uvtk[140]" -type "float2" -1.6862969 -1.180367 ;
	setAttr ".uvtk[141]" -type "float2" -1.5767791 -1.180367 ;
	setAttr ".uvtk[142]" -type "float2" -1.6862969 -1.1442332 ;
	setAttr ".uvtk[143]" -type "float2" -1.5767791 -1.1442332 ;
	setAttr ".uvtk[144]" -type "float2" -1.6862969 -1.0356783 ;
	setAttr ".uvtk[145]" -type "float2" -1.5767791 -1.0356783 ;
	setAttr ".uvtk[166]" -type "float2" 0.17506185 0.005082665 ;
	setAttr ".uvtk[167]" -type "float2" 0.067977205 0.005082665 ;
	setAttr ".uvtk[168]" -type "float2" 0.17506185 0.005082665 ;
	setAttr ".uvtk[169]" -type "float2" 0.067977205 0.005082665 ;
createNode polyPlanarProj -n "polyPlanarProj4";
	rename -uid "B3BAF00C-4310-CF5C-D1CD-049580A43C71";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "f[4:5]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 2.7395038303399604 0 1;
	setAttr ".ws" yes;
	setAttr ".pc" -type "double3" 0 0 -3.8387211561203003 ;
	setAttr ".ro" -type "double3" -90 0 0 ;
	setAttr ".ps" -type "double2" 6.688744068145752 14.366186380386353 ;
	setAttr ".cam" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
createNode polyPlanarProj -n "polyPlanarProj3";
	rename -uid "7FE78D6D-436F-AF90-2E31-719A6B20A48A";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "f[4:5]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 2.7395038303399604 0 1;
	setAttr ".ws" yes;
	setAttr ".pc" -type "double3" 0 0 -3.8387211561203003 ;
	setAttr ".ps" -type "double2" 6.688744068145752 0 ;
	setAttr ".cam" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
createNode polyTweakUV -n "polyTweakUV2";
	rename -uid "9A1ADD2A-4C07-69C1-B7AA-6D9DCEBACD18";
	setAttr ".uopa" yes;
	setAttr -s 12 ".uvtk";
	setAttr ".uvtk[0]" -type "float2" -0.35746855 0.037260085 ;
	setAttr ".uvtk[1]" -type "float2" 0.052508056 0.037260085 ;
	setAttr ".uvtk[2]" -type "float2" -0.1383727 -0.065125063 ;
	setAttr ".uvtk[3]" -type "float2" 0.052508056 -0.065125063 ;
	setAttr ".uvtk[8]" -type "float2" -0.35746855 0.037260085 ;
	setAttr ".uvtk[9]" -type "float2" -0.1383727 -0.065125063 ;
	setAttr ".uvtk[10]" -type "float2" 0.052508056 0.037260085 ;
	setAttr ".uvtk[11]" -type "float2" 0.052508056 -0.065125063 ;
	setAttr ".uvtk[166]" -type "float2" -0.1383727 -0.26438227 ;
	setAttr ".uvtk[167]" -type "float2" 0.052508056 -0.37271655 ;
	setAttr ".uvtk[168]" -type "float2" -0.1383727 -0.26438227 ;
	setAttr ".uvtk[169]" -type "float2" 0.052508056 -0.37271655 ;
createNode polyPlanarProj -n "polyPlanarProj2";
	rename -uid "8E8EC5EC-4431-269D-FEBF-148F10F77B72";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 3 "f[2:3]" "f[6:7]" "f[92:95]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 2.7395038303399604 0 1;
	setAttr ".ws" yes;
	setAttr ".pc" -type "double3" -1.1920928955078125e-007 4.4183969497680664 -3.8387211561203003 ;
	setAttr ".ro" -type "double3" 0 90 0 ;
	setAttr ".ps" -type "double2" 14.366186380386353 8.8367938995361328 ;
	setAttr ".cam" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
createNode polyPlanarProj -n "polyPlanarProj1";
	rename -uid "0CDF53AB-43B9-EE46-24CC-F9B0121755F9";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 3 "f[2:3]" "f[6:7]" "f[92:95]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 2.7395038303399604 0 1;
	setAttr ".ws" yes;
	setAttr ".pc" -type "double3" -1.1920928955078125e-007 4.4183969497680664 -3.8387211561203003 ;
	setAttr ".ro" -type "double3" -90 0 0 ;
	setAttr ".ps" -type "double2" 6.6887443065643311 14.366186380386353 ;
	setAttr ".cam" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
createNode polyTweakUV -n "polyTweakUV1";
	rename -uid "7C540C0E-4DDB-E421-9D21-4C880EBFE851";
	setAttr ".uopa" yes;
	setAttr -s 166 ".uvtk[0:165]" -type "float2" 1.3012346 0 1.3012346 0 1.30123448
		 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123448 0 1.3012346
		 0 1.30123448 0 1.3012346 0 1.30123472 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123448
		 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123448 0 1.3012346 0 1.30123448 0 1.30123448
		 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123448 0 1.3012346 0 1.30123448 0 1.30123448
		 0 1.3012346 0 1.3012346 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123448
		 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123448
		 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123436 0 1.30123448 0 1.30123436 0 1.3012346
		 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123436 0 1.30123448 0 1.30123448
		 0 1.30123448 0 1.3012346 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123448
		 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123448
		 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123448
		 0 1.3012346 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123448
		 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123448
		 0 1.3012346 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123448
		 0 1.30123448 0 1.3012346 0 1.30123448 0 1.3012346 0 1.30123448 0 1.30123448 0 1.30123448
		 0 1.30123448 0 1.30123448 0 1.30123448 0 1.3012346 0 1.3012346 0 1.3012346 0 1.30123472
		 0 1.30123448 0 1.30123448 0 1.30123472 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123448
		 0 1.30123448 0 1.30123448 0 1.30123448 0 1.3012346 0 1.30123448 0 1.30123448 0 1.30123448
		 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123448
		 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123448
		 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123448 0 1.3012346 0 1.30123448 0 1.30123448
		 0 1.30123448 0 1.30123448 0 1.3012346 0 1.3012346 0 1.30123448 0 1.30123448 0 1.30123448
		 0 1.30123472 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123448 0 1.30123472
		 0 1.30123472 0 1.30123448 0;
createNode polyAutoProj -n "polyAutoProj1";
	rename -uid "06F35216-46B2-158F-5348-67A21DBD9524";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "f[0:121]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 2.7395038303399604 0 1;
	setAttr ".s" -type "double3" 14.366186380386353 14.366186380386353 14.366186380386353 ;
	setAttr ".ps" 0.20000000298023224;
	setAttr ".dl" yes;
createNode polyTweak -n "polyTweak1";
	rename -uid "266B88BA-4C09-1C95-78E8-A39D371A8BE2";
	setAttr ".uopa" yes;
	setAttr -s 6 ".tk";
	setAttr ".tk[3]" -type "float3" 0 -0.093675137 0 ;
	setAttr ".tk[4]" -type "float3" 0 -0.093675137 0 ;
	setAttr ".tk[6]" -type "float3" 0 -0.093675137 0 ;
	setAttr ".tk[7]" -type "float3" 0 -0.093675137 0 ;
createNode polyBevel3 -n "polyBevel2";
	rename -uid "0528429F-4D49-44FB-4D54-3F928EF4A1DD";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 3 "e[178]" "e[180]" "e[193:194]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
	setAttr ".ws" yes;
	setAttr ".oaf" yes;
	setAttr ".f" 0.099999999999999978;
	setAttr ".at" 180;
	setAttr ".fn" yes;
	setAttr ".mv" yes;
	setAttr ".mvt" 0.0001;
	setAttr ".sa" 30;
	setAttr ".ma" 180;
createNode polyBevel3 -n "polyBevel1";
	rename -uid "7A8D84A8-4925-06F3-74A8-2D8914E47529";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 4 "e[5]" "e[12]" "e[14]" "e[42]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
	setAttr ".ws" yes;
	setAttr ".oaf" yes;
	setAttr ".f" 0;
	setAttr ".sg" 3;
	setAttr ".at" 180;
	setAttr ".fn" yes;
	setAttr ".mv" yes;
	setAttr ".mvt" 0.0001;
	setAttr ".sa" 30;
	setAttr ".ma" 180;
createNode polyTriangulate -n "polyTriangulate1";
	rename -uid "16AED615-4AF9-A3A2-B369-D7A163EA0F02";
	setAttr ".ics" -type "componentList" 1 "f[*]";
createNode materialInfo -n "materialInfo1";
	rename -uid "7FF47D5D-4383-2892-6657-E78F99387C5D";
createNode shadingEngine -n "lambert2SG";
	rename -uid "9E1AAF05-4CE8-3C57-3496-778450D917D2";
	setAttr ".ihi" 0;
	setAttr ".ro" yes;
createNode lambert -n "lambert2";
	rename -uid "704BD771-4184-2E96-9DB2-8AB5B2BA4C59";
createNode file -n "file1";
	rename -uid "44EF7B41-4576-C486-8437-AEB6561ED9FA";
	setAttr ".ftn" -type "string" "C:/Users/coolweek/Desktop/project/Podium/PodiumColor.psd";
	setAttr ".cs" -type "string" "sRGB";
createNode place2dTexture -n "place2dTexture2";
	rename -uid "54035D3A-4538-76FB-2B4F-D7ADA09B05FF";
createNode lightLinker -s -n "lightLinker1";
	rename -uid "6AF86A04-4CF1-C003-E903-BBB3574960B7";
	setAttr -s 6 ".lnk";
	setAttr -s 6 ".slnk";
select -ne :time1;
	setAttr ".o" 1;
	setAttr ".unw" 1;
select -ne :hardwareRenderingGlobals;
	setAttr ".otfna" -type "stringArray" 22 "NURBS Curves" "NURBS Surfaces" "Polygons" "Subdiv Surface" "Particles" "Particle Instance" "Fluids" "Strokes" "Image Planes" "UI" "Lights" "Cameras" "Locators" "Joints" "IK Handles" "Deformers" "Motion Trails" "Components" "Hair Systems" "Follicles" "Misc. UI" "Ornaments"  ;
	setAttr ".otfva" -type "Int32Array" 22 0 1 1 1 1 1
		 1 1 1 0 0 0 0 0 0 0 0 0
		 0 0 0 0 ;
	setAttr ".fprt" yes;
select -ne :renderPartition;
	setAttr -s 6 ".st";
select -ne :renderGlobalsList1;
select -ne :defaultShaderList1;
	setAttr -s 8 ".s";
select -ne :postProcessList1;
	setAttr -s 2 ".p";
select -ne :defaultRenderUtilityList1;
	setAttr -s 5 ".u";
select -ne :defaultRenderingList1;
select -ne :defaultTextureList1;
	setAttr -s 5 ".tx";
select -ne :initialShadingGroup;
	setAttr ".ro" yes;
select -ne :initialParticleSE;
	setAttr ".ro" yes;
select -ne :defaultResolution;
	setAttr ".pa" 1;
select -ne :hardwareRenderGlobals;
	setAttr ".ctrs" 256;
	setAttr ".btrs" 512;
select -ne :ikSystem;
	setAttr -s 4 ".sol";
connectAttr "polyTweakUV5.out" "pCube2Shape.i";
connectAttr "polyTweakUV5.uvtk[0]" "pCube2Shape.uvst[0].uvtw";
connectAttr "polyPlanarProj7.out" "polyTweakUV5.ip";
connectAttr "polyTweakUV4.out" "polyPlanarProj7.ip";
connectAttr "pCube2Shape.wm" "polyPlanarProj7.mp";
connectAttr "polyPlanarProj6.out" "polyTweakUV4.ip";
connectAttr "polyPlanarProj5.out" "polyPlanarProj6.ip";
connectAttr "pCube2Shape.wm" "polyPlanarProj6.mp";
connectAttr "polyTweakUV3.out" "polyPlanarProj5.ip";
connectAttr "pCube2Shape.wm" "polyPlanarProj5.mp";
connectAttr "polyPlanarProj4.out" "polyTweakUV3.ip";
connectAttr "polyPlanarProj3.out" "polyPlanarProj4.ip";
connectAttr "pCube2Shape.wm" "polyPlanarProj4.mp";
connectAttr "polyTweakUV2.out" "polyPlanarProj3.ip";
connectAttr "pCube2Shape.wm" "polyPlanarProj3.mp";
connectAttr "polyPlanarProj2.out" "polyTweakUV2.ip";
connectAttr "polyPlanarProj1.out" "polyPlanarProj2.ip";
connectAttr "pCube2Shape.wm" "polyPlanarProj2.mp";
connectAttr "polyTweakUV1.out" "polyPlanarProj1.ip";
connectAttr "pCube2Shape.wm" "polyPlanarProj1.mp";
connectAttr "polyAutoProj1.out" "polyTweakUV1.ip";
connectAttr "polyTweak1.out" "polyAutoProj1.ip";
connectAttr "pCube2Shape.wm" "polyAutoProj1.mp";
connectAttr "polyBevel2.out" "polyTweak1.ip";
connectAttr "polyBevel1.out" "polyBevel2.ip";
connectAttr "pCube2Shape.wm" "polyBevel2.mp";
connectAttr "polyTriangulate1.out" "polyBevel1.ip";
connectAttr "pCube2Shape.wm" "polyBevel1.mp";
connectAttr "polySurfaceShape1.o" "polyTriangulate1.ip";
connectAttr "lambert2SG.msg" "materialInfo1.sg";
connectAttr "lambert2.msg" "materialInfo1.m";
connectAttr "file1.msg" "materialInfo1.t" -na;
connectAttr "lambert2.oc" "lambert2SG.ss";
connectAttr "pCube2Shape.iog" "lambert2SG.dsm" -na;
connectAttr "file1.oc" "lambert2.c";
connectAttr ":defaultColorMgtGlobals.cme" "file1.cme";
connectAttr ":defaultColorMgtGlobals.cfe" "file1.cmcf";
connectAttr ":defaultColorMgtGlobals.cfp" "file1.cmcp";
connectAttr ":defaultColorMgtGlobals.wsn" "file1.ws";
connectAttr "place2dTexture2.c" "file1.c";
connectAttr "place2dTexture2.tf" "file1.tf";
connectAttr "place2dTexture2.rf" "file1.rf";
connectAttr "place2dTexture2.mu" "file1.mu";
connectAttr "place2dTexture2.mv" "file1.mv";
connectAttr "place2dTexture2.s" "file1.s";
connectAttr "place2dTexture2.wu" "file1.wu";
connectAttr "place2dTexture2.wv" "file1.wv";
connectAttr "place2dTexture2.re" "file1.re";
connectAttr "place2dTexture2.of" "file1.of";
connectAttr "place2dTexture2.r" "file1.ro";
connectAttr "place2dTexture2.n" "file1.n";
connectAttr "place2dTexture2.vt1" "file1.vt1";
connectAttr "place2dTexture2.vt2" "file1.vt2";
connectAttr "place2dTexture2.vt3" "file1.vt3";
connectAttr "place2dTexture2.vc1" "file1.vc1";
connectAttr "place2dTexture2.o" "file1.uv";
connectAttr "place2dTexture2.ofs" "file1.fs";
relationship "link" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "lambert2SG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "lambert2SG.message" ":defaultLightSet.message";
connectAttr "lambert2SG.pa" ":renderPartition.st" -na;
connectAttr "lambert2.msg" ":defaultShaderList1.s" -na;
connectAttr "place2dTexture2.msg" ":defaultRenderUtilityList1.u" -na;
connectAttr "file1.msg" ":defaultTextureList1.tx" -na;
// End of Podium.ma
