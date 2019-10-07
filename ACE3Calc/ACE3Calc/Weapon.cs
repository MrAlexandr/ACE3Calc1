using System;
using System.Collections.Generic;
using System.Text;

namespace ACE3Calc
{
    class Weapon
    {
        public int idweapon;
        public string namew;
        public double Kweapon;

        public Bullet[] arrayBullets;



        public Weapon(int Id, string N, double K, Bullet[] BulletsArray, List<int> ListIDBullets)
        {
            idweapon = Id;
            namew = N;
            Kweapon = K;

            arrayBullets = new Bullet[ListIDBullets.Count];

            for (int i = 0; i < arrayBullets.Length; i++)
            {
                for (int j = 0; j < BulletsArray.Length; j++)
                {
                    if (ListIDBullets[i] == BulletsArray[j].id)
                    {
                        arrayBullets[i] = BulletsArray[j];
                    }
                }
            }
        }


        //public Weapon(int Id, string N, double K)
        //{
        //    idweapon = Id;
        //    namew = N;
        //    Kweapon = K;
        //}
    }
}
