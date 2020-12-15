using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextDecrypter
{
    public static class Dictionaries
    {
        //Coprimos para calculos con matrices
        public static Dictionary<int, int> CoprimosDe27 = new Dictionary<int, int>()
        {
            {1,1 },
            {2,14 },
            {4,7 },
            {5,11 },
            {7,4 },
            {8,17 },
            {10,19 },
            {11,5 },
            {13,25 },
            {14,2 },
            {16,22 },
            {17,8 },
            {19,10 },
            {20,23 },
            {22,16 },
            {23,20 },
            {25,13 },
            {26,26 },
        };



        public static Dictionary<char, int> LetrasNormalesANumerosClave = new Dictionary<char, int>()
        {//Texto original E ---> 19
            {'E' ,19},
            {'A',27},
            {'S' ,15},
            {'O' ,24},
            {'R' ,16},
            {'N' ,14},
            {'I' ,25},
            {'D' ,1},
            {'L' ,12},
            {'T' ,5},
            {'J' ,6},
            //Ronda 1
            {'M',22},
            {'C',11},
            //Ronda 2
            {'Y',13},
            {'G',8},
            {'H',18},
            //Ronda 3
            {'F',23},
            {'Q',20},
            {'U',3},
            {'V',2},
            {'P',4},
            {'B',10},
            //Ronda 4
            {'Ñ',9},
        };
        public static Dictionary<char, char> LetrasCodificadasALetrasNormales = new Dictionary<char, char>()
        {//Texto Codificado R --> E ---> 19
            {'R','E' },//E = 19
            {'Z','A' }, //27},
            {'Ñ','S' },//15},
            {'W','O' },//24},
            {'O','R' },//16},
            {'N','N' },//14},
            {'X','I' },//25},
            {'A','D' }, //1},
            {'L','L' },//12},
            {'E','T' },//5},
            {'F','J' },//6},
            //Ronda 1
            {'T' ,'M'},//22},
            {'K','C' },//11},
            //Ronda 2
            {'M','Y' },//13},
            {'H','G' },//8},
            {'Q','H' },//18},
            //Ronda 3
            {'V','F'},//23},
            {'S','Q'},//20},
            {'C','U'},//3},
            {'B','V'},//2},
            {'D','P'},//4},
            {'J','B'},//10},
            //Ronda 4
            {'I','Ñ'},//9},
        }; //Sin las letras que desconozco
        public static Dictionary<char, int> AbecedarioNormal = new Dictionary<char, int>()
            {
                {'A',1 },
                {'B',2 },
                {'C',3},
                {'D',4},
                {'E',5},
                {'F',6},
                {'G',7},
                {'H',8},
                {'I',9},
                {'J',10},
                {'K',11},
                {'L',12},
                {'M',13},
                {'N',14},
                {'Ñ',15},
                {'O',16 },
                {'P',17 },
                {'Q',18 },
                {'R',19 },
                {'S',20 },
                {'T',21 },
                {'U',22 },
                {'V',23 },
                {'W',24 },
                {'X',25 },
                {'Y',26 },
                {'Z',27 }
            };
        public static Dictionary<char, int> AbecedarioNormalFromZero = new Dictionary<char, int>()
            {
                {'A',0 },
                {'B',1 },
                {'C',2},
                {'D',3},
                {'E',4},
                {'F',5},
                {'G',6},
                {'H',7},
                {'I',8},
                {'J',9},
                {'K',10},
                {'L',11},
                {'M',12},
                {'N',13},
                {'Ñ',14},
                {'O',15 },
                {'P',16 },
                {'Q',17 },
                {'R',18 },
                {'S',19 },
                {'T',20 },
                {'U',21 },
                {'V',22 },
                {'W',23 },
                {'X',24 },
                {'Y',25 },
                {'Z',26 }
            };
    }
}
