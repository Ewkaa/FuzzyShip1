using System;
using UnityEngine;

namespace Assets
{
    public class Fuzzy : MonoBehaviour {

        private static float[,] _left = new float[4,201];
        private static float[,] _right = new float[4, 201];
        public static float[,] forward = new float[4, 201];
        public static float[,] side = new float[8,91];
        public static float[,] result = new float[8,91];
        public static float[,] addcja = new float[2,91]; //agregacja

        public static float[,] Left
        {
            get
            {
                return _left;
            }

            set
            {
                _left = value;
            }
        }

        /*
     ****************************************
     *              ODLEGŁOŚĆ               *
     ****************************************

     blisko  srednio     daleko
     ____            _________________
     |   \    /\    /                |
     |    \  /  \  /                 |
     |     \/    \/		             |
     |     /\    /\                  |
     |    /  \  /  \                 |
     |   /    \/    \                |
     0  a     b     cd              100

    B - blisko 
    S-srednio 
    D - daleko

    a - B=1 â†‘S=0
    b - B=0  S=1 D=0
    c - S=0 
    d - D=1 

    

    */

        public static void angleFuzzySet()
        {
            for (int i = 0; i < side.Length; i++)
            {
                float x = i;
                side[0,i] = x;

                if (i >= 0 & i <= 5)
                    side[1,i] = 1;
                if (i >= 5 & i <= 15)
                    side[1,i] = (15 - x) / (15 - 5);

                if (i >= 5 & i <= 15)
                    side[2,i] = (x - 5) / (15 - 5);
                if (i >= 15 & i <= 30)
                    side[2,i] = (30 - x) / (30 - 15);

                if (i >= 15 & i <= 30)
                    side[3,i] = (x - 15) / (30 - 15);
                if (i >= 30 & i <= 45)
                    side[3,i] = (45 - x) / (45 - 30);

                if (i >= 30 & i <= 45)
                    side[4,i] = (x - 30) / (45 - 30);
                if (i >= 45 & i <= 60)
                    side[4,i] = (60 - x) / (60 - 45);

                if (i >= 45 & i <= 60)
                    side[5,i] = (x - 45) / (60 - 45);
                if (i >= 60 & i <= 75)
                    side[5,i] = (75 - x) / (75 - 60);

                if (i >= 60 & i <= 75)
                    side[6,i] = (x - 60) / (75 - 60);
                if (i >= 75 & i <= 85)
                    side[6,i] = (85 - x) / (85 - 75);

                if (i >= 75 & i <= 85)
                    side[7,i] = (x - 75) / (85 - 75);
                if (i >= 85 & i <= 91)
                    side[7,i] = 1;
            }
        }

        public static void distanceFuzzySets(int min, int a, int b, int c, int d, int max)
        {
            float x = 0;
            for (int i = 0; i < Left.Length; i++)
            {
                x = i;
                Left[0,i] = x;
                _right[0,i] = x;
                forward[0,i] = x;

                // LEWO

                if (i >= min & i <= a)
                    Left[1,i] = 1;
                else if (i >= a & i <= b)
                    Left[1,i] = (b - x) / (b - a);

                if (i >= a & i <= b)
                    Left[2,i] = (x - a) / (b - a);
                else if (i >= b & i <= c)
                    Left[2,i] = (c - x) / (c - b);

                if (i >= b & i <= d)
                    Left[3,i] = (x - b) / (d - b);
                else if (i >= d & i <= max)
                    Left[3,i] = 1;

                // PRAWO

                if (i >= min & i <= a)
                    _right[1,i] = 1;
                else if (i >= a & i <= b)
                    _right[1,i] = (b - x) / (b - a);

                if (i >= a & i <= b)
                    _right[2,i] = (x - a) / (b - a);
                else if (i >= b & i <= c)
                    _right[2,i] = (c - x) / (c - b);

                if (i >= b & i <= d)
                    _right[3,i] = (x - b) / (d - b);
                else if (i >= d & i <= max)
                    _right[3,i] = 1;

                // PRZOD

                if (i >= min & i <= a)
                    forward[1,i] = 1;
                else if (i >= a & i <= b)
                    forward[1,i] = (b - x) / (b - a);

                if (i >= a & i <= b)
                    forward[2,i] = (x - a) / (b - a);
                else if (i >= b & i <= c)
                    Left[2,i] = (c - x) / (c - b);

                if (i >= b & i <= d)
                    forward[3,i] = (x - b) / (d - b);
                else if (i >= d & i <= max)
                    forward[3,i] = 1;
            }
        }

        public static float MaxFuzzy(params float[] number)
        {
            // minimalna wartosc to 0 tylko logika rozmyta

            float max = 0;
            foreach (var f in number)
            {
                max = Math.Max(max, f);
            }
            return max;
        }

        public static float MinFuzzy(params float[] number)
        {
            
            // maksymalna wartosc to 1
            float min = 1;
            foreach (var f in number)
            {
                min = Math.Min(min, f);
            }
            return min;
        }

        /**
     * Funkcja zwracajaca wyjscie systemu rozmytego
     * @param inForward - Odleglosc z przodu
     * @param inLeft - Odleglosc z lewej
     * @param inRight - Odleglosc z prawej
     * @return Kat skretu w przedziale <-45;45> stopni.
     */
        public static float getOutput(int inLeft, int inRight, int inForward)
        {
            // ROZMYWANIE
            var bliskoLewo = Left[1,inLeft];
            var srednioLewo = Left[2,inLeft];
            var dalekoLewo = Left[3,inLeft];

            var bliskoPrawo = _right[1,inRight];
            var srednioPrawo = _right[2,inRight];
            var dalekoPrawo = _right[3,inRight];

            var bliskoPrzod = forward[1,inForward];
            var srednioPrzod = forward[2,inForward];
            var dalekoPrzod = forward[3,inForward];

            // REGULY
            var r1 = MinFuzzy(bliskoLewo, bliskoPrawo, bliskoPrzod);
            var r2 = MinFuzzy(bliskoLewo, bliskoPrawo, srednioPrzod);
            var r3 = MinFuzzy(bliskoLewo, bliskoPrawo, dalekoPrzod);

            var r4 = MinFuzzy(bliskoLewo, srednioPrawo, bliskoPrzod);
            var r5 = MinFuzzy(bliskoLewo, srednioPrawo, srednioPrzod);
            var r6 = MinFuzzy(bliskoLewo, srednioPrawo, dalekoPrzod);

            var r7 = MinFuzzy(bliskoLewo, dalekoPrawo, bliskoPrzod);
            var r8 = MinFuzzy(bliskoLewo, dalekoPrawo, srednioPrzod);
            var r9 = MinFuzzy(bliskoLewo, dalekoPrawo, dalekoPrzod);

            var r10 = MinFuzzy(srednioLewo, bliskoPrawo, bliskoPrzod);
            var r11 = MinFuzzy(srednioLewo, bliskoPrawo, srednioPrzod);
            var r12 = MinFuzzy(srednioLewo, bliskoPrawo, dalekoPrzod);

            var r13 = MinFuzzy(srednioLewo, srednioPrawo, bliskoPrzod);
            var r14 = MinFuzzy(srednioLewo, srednioPrawo, srednioPrzod);
            var r15 = MinFuzzy(srednioLewo, srednioPrawo, dalekoPrzod);

            var r16 = MinFuzzy(srednioLewo, dalekoPrawo, bliskoPrzod);
            var r17 = MinFuzzy(srednioLewo, dalekoPrawo, srednioPrzod);
            var r18 = MinFuzzy(srednioLewo, dalekoPrawo, dalekoPrzod);

            var r19 = MinFuzzy(dalekoLewo, bliskoPrawo, bliskoPrzod);
            var r20 = MinFuzzy(dalekoLewo, bliskoPrawo, srednioPrzod);
            var r21 = MinFuzzy(dalekoLewo, bliskoPrawo, dalekoPrzod);

            var r22 = MinFuzzy(dalekoLewo, srednioPrawo, bliskoPrzod);
            var r23 = MinFuzzy(dalekoLewo, srednioPrawo, srednioPrzod);
            var r24 = MinFuzzy(dalekoLewo, srednioPrawo, dalekoPrzod);

            var r25 = MinFuzzy(dalekoLewo, dalekoPrawo, bliskoPrzod);
            var r26 = MinFuzzy(dalekoLewo, dalekoPrawo, srednioPrzod);
            var r27 = MinFuzzy(dalekoLewo, dalekoPrawo, dalekoPrzod);

            // WNIOSKOWANIE
            var mocnoWLewo = MaxFuzzy(r1, r13, r19, r25);
            var srednioWLewo = MaxFuzzy(r10, r20, r22, r26);
            var lekkoWLewo = MaxFuzzy(r11, r12, r21, r23);
            var prosto = MaxFuzzy(r2, r3, r14, r15, r18, r24, r27);
            var lekkoWPrawo = MaxFuzzy(r5, r6, r9, r17);
            var srednioWPrawo = MaxFuzzy(r4, r8, r16);
            var mocnoWPrawo = MaxFuzzy(r7);

            for (int i = 0; i < side.Length; i++)
            {
                float x = i;
                result[0,i] = x;

                if (i >= 0 & i <= 15)
                    result[1,i] = MinFuzzy(mocnoWLewo, side[1,i]);
                if (i >= 5 & i <= 30)
                    result[2,i] = MinFuzzy(srednioWLewo, side[2,i]);
                if (i >= 15 & i <= 45)
                    result[3,i] = MinFuzzy(lekkoWLewo, side[3,i]);
                if (i >= 30 & i <= 60)
                    result[4,i] = MinFuzzy(prosto, side[4,i]);
                if (i >= 45 & i <= 75)
                    result[5,i] = MinFuzzy(lekkoWPrawo, side[5,i]);
                if (i >= 60 & i <= 85)
                    result[6,i] = MinFuzzy(srednioWPrawo, side[6,i]);
                if (i >= 75 & i <= 90)
                    result[7,i] = MinFuzzy(mocnoWPrawo, side[7,i]);
            }

            // AGREGACJA
            for (int i = 0; i < side.Length; i++)
            {
                addcja[0,i] = result[0,i];
                addcja[1,i] = MaxFuzzy( result[2,i], result[3,i], result[4,i],
                    result[5,i], result[6,i], result[7,i], result[8, i]);
            }

            // WYOSTRZANIE (Metoda srodka ciezkosci)
            float g = 0;
            float d = 0;
            for (int j = 0; j < side.Length; j++)
            {
                g = addcja[0,j] * addcja[1,j] + g;
                d = addcja[1,j] + d;
            }

            float y = g / d;
            return (y - 45);
        }

    }
}