// -------------------------------------- UTWORZENIE TABLICY ----------------------------
// ZMIENNE
XXmin=0;
XXmax=100;
XXdys=1;
XXtermy=3;
// PROGRAM
XXilosc=(XXmax-XXmin)/XXdys+1;
XX=zeros(XXtermy+1,XXilosc);
for i = 1:XXilosc
XX(1,i)=XXmin-XXdys*(1-i);
end

// ---------------------------------------- KSZTALT TRAPEZU ----------------------------
// ZMIENNE
AAa=0;        
AAx1=0;
AAx2=25;
AAb=50;
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

/
// --------------------------------------- KSZTALT TROJKATA ----------------------------
// ZMIENNE
BBa=25;        
BBx0=50;
BBb=75;
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


// ---------------------------------------- KSZTALT TRAPEZU ----------------------------
// ZMIENNE
CCa=50;        
CCx1=75;
CCx2=100;
CCb=100;
// PROGRAM
for i = 1:XXilosc
if XX(1,i)>=CCa & XX(1,i)<=CCx1 & CCa<>CCx1
CC=(XX(1,i)-CCa)/(CCx1-CCa);
elseif XX(1,i)>=CCx1 & XX(1,i)<=CCx2
CC=1;
elseif XX(1,i)>=CCx2 & XX(1,i)<=CCb & CCb<>CCx2
CC=(CCb-XX(1,i))/(CCb-CCx2);
else CC=0;
end
XX(4,i) = CC;
end


// ---------------------------------------- WYKRESY------------------------------------
subplot(1,1,1);
plot(XX(1,:),XX(2,:),'r');
mtlb_axis([XXmin XXmax 0 1.2]);

plot(XX(1,:),XX(3,:),'b');
mtlb_axis([XXmin XXmax 0 1.2]);

plot(XX(1,:),XX(4,:),'g');
mtlb_axis([XXmin XXmax 0 1.2]);


