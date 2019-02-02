
// -------------------------------------- UTWORZENIE TABLICY ----------------------------
// ZMIENNE
XXmin=0;
XXmax=90;
XXdys=1;
XXtermy=7;
// PROGRAM
XXilosc=(XXmax-XXmin)/XXdys+1;
XX=zeros(XXtermy+1,XXilosc);
for i = 1:XXilosc
XX(1,i)=XXmin-XXdys*(1-i);
end

// ----------------------------------------------- AA ----------------------------------
// ---------------------------------------- KSZTALT TRAPEZU ----------------------------
// ZMIENNE
AAa=0;        
AAx1=0;
AAx2=5;
AAb=15;
// PROGRAM
for i = 1:XXilosc
if XX(1,i)>=AAa & XX(1,i)<=AAx1 & AAa<>AAx1
AA=(XX(1,i)-AAa)/(AAx1-AAa);
elseif XX(1,i)>=AAx1 & XX(1,i)<=AAx2
AA=1;
elseif XX(1,i)>=AAx2 & XX(1,i)<=AAb & AAb<>AAx2
AA=(AAb-XX(1,i))/(AAb-AAx2);
else AA=0;
end
XX(2,i) = AA;
end

// ----------------------------------------------- BB ----------------------------------
// --------------------------------------- KSZTALT TROJKATA ----------------------------
// ZMIENNE
BBa=5;        
BBx0=15;
BBb=30;
// PROGRAM
for i = 1:XXilosc
if XX(1,i)>=BBa & XX(1,i)<=BBx0 & BBa<>BBx0
BB=(XX(1,i)-BBa)/(BBx0-BBa);
elseif XX(1,i)>=BBx0 & XX(1,i)<=BBb & BBb<>BBx0
BB=(BBb-XX(1,i))/(BBb-BBx0);
else BB=0;
end
XX(3,i) = BB;
end
// ----------------------------------------------- CC ----------------------------------
// --------------------------------------- KSZTALT TROJKATA ----------------------------
// ZMIENNE
CCa=15;        
CCx0=30;
CCb=45;
// PROGRAM
for i = 1:XXilosc
if XX(1,i)>=CCa & XX(1,i)<=CCx0 & CCa<>CCx0
CC=(XX(1,i)-CCa)/(CCx0-CCa);
elseif XX(1,i)>=CCx0 & XX(1,i)<=CCb & CCb<>CCx0
CC=(CCb-XX(1,i))/(CCb-CCx0);
else CC=0;
end
XX(4,i) = CC;
end
// ----------------------------------------------- DD ----------------------------------
// --------------------------------------- KSZTALT TROJKATA ----------------------------
// ZMIENNE
DDa=30;        
DDx0=45;
DDb=60;
// PROGRAM
for i = 1:XXilosc
if XX(1,i)>=DDa & XX(1,i)<=DDx0 & DDa<>DDx0
DD=(XX(1,i)-DDa)/(DDx0-DDa);
elseif XX(1,i)>=DDx0 & XX(1,i)<=DDb & DDb<>DDx0
DD=(DDb-XX(1,i))/(DDb-DDx0);
else DD=0;
end
XX(5,i) = DD;
end
// ----------------------------------------------- EE ----------------------------------
// --------------------------------------- KSZTALT TROJKATA ----------------------------
// ZMIENNE
EEa=45;        
EEx0=60;
EEb=75;
// PROGRAM
for i = 1:XXilosc
if XX(1,i)>=EEa & XX(1,i)<=EEx0 & EEa<>EEx0
EE=(XX(1,i)-EEa)/(EEx0-EEa);
elseif XX(1,i)>=EEx0 & XX(1,i)<=EEb & EEb<>EEx0
EE=(EEb-XX(1,i))/(EEb-EEx0);
else EE=0;
end
XX(6,i) = EE;
end
// ----------------------------------------------- FF ----------------------------------
// --------------------------------------- KSZTALT TROJKATA ----------------------------
// ZMIENNE
FFa=60;        
FFx0=75;
FFb=85;
// PROGRAM
for i = 1:XXilosc
if XX(1,i)>=FFa & XX(1,i)<=FFx0 & FFa<>FFx0
FF=(XX(1,i)-FFa)/(FFx0-FFa);
elseif XX(1,i)>=FFx0 & XX(1,i)<=FFb & FFb<>FFx0
FF=(FFb-XX(1,i))/(FFb-FFx0);
else FF=0;
end
XX(7,i) = FF;
end

// ----------------------------------------------- GG ----------------------------------
// ---------------------------------------- KSZTALT TRAPEZU ----------------------------
// ZMIENNE
GGa=75;        
GGx1=85;
GGx2=100;
GGb=100;
// PROGRAM
for i = 1:XXilosc
if XX(1,i)>=GGa & XX(1,i)<=GGx1 & GGa<>GGx1
GG=(XX(1,i)-GGa)/(GGx1-GGa);
elseif XX(1,i)>=GGx1 & XX(1,i)<=GGx2
GG=1;
elseif XX(1,i)>=GGx2 & XX(1,i)<=GGb & GGb<>GGx2
GG=(GGb-XX(1,i))/(GGb-GGx2);
else GG=0;
end
XX(8,i) = GG;
end


// ---------------------------------------- WYKRESY------------------------------------
subplot(1,1,1);
plot(XX(1,:),XX(2,:),'r');
mtlb_axis([XXmin XXmax 0 1.2]);

plot(XX(1,:),XX(3,:),'b');
mtlb_axis([XXmin XXmax 0 1.2]);

plot(XX(1,:),XX(4,:),'g');
mtlb_axis([XXmin XXmax 0 1.2]);

plot(XX(1,:),XX(5,:),'r');
mtlb_axis([XXmin XXmax 0 1.2]);

plot(XX(1,:),XX(6,:),'g');
mtlb_axis([XXmin XXmax 0 1.2]);

plot(XX(1,:),XX(7,:),'b');
mtlb_axis([XXmin XXmax 0 1.2]);

plot(XX(1,:),XX(8,:),'r');
mtlb_axis([XXmin XXmax 0 1.2]);

