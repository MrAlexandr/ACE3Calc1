using System;
using System.Collections.Generic;
using System.Text;

namespace ACE3Calc
{
    class Bullet
    {
        public int id { get; set; }

        public double aTemp { get; set; } //коэффициенты для расчета коэффициента поправки на ветер
        public double bTemp { get; set; }
        public double cTemp { get; set; }

        public double a { get; set; }
        public double b { get; set; }
        public double c { get; set; }
        public double d { get; set; }

        public string nameB { get; set; }


        //public Weapon[] arrayWeapons;


        //public Bullet(double A, double B, double C, double D, double ATemp, double BTemp, double CTemp, string NameB, Weapon[] Weapons, int Id1)
        //{
        //    a = A;
        //    b = B;
        //    c = C;
        //    d = D;

        //    aTemp = ATemp;
        //    bTemp = BTemp;
        //    cTemp = CTemp;

        //    nameB = NameB;

        //    arrayWeapons = new Weapon[1];
        //    arrayWeapons[0] = Weapons[Id1];
        //}

        //public Bullet(double A, double B, double C, double D, double ATemp, double BTemp, double CTemp, string NameB, Weapon[] Weapons, int Id1, int Id2)
        //{
        //    a = A;
        //    b = B;
        //    c = C;
        //    d = D;

        //    aTemp = ATemp;
        //    bTemp = BTemp;
        //    cTemp = CTemp;

        //    nameB = NameB;

        //    arrayWeapons = new Weapon[2];
        //    arrayWeapons[0] = Weapons[Id1];
        //    arrayWeapons[1] = Weapons[Id2];
        //}

        //public Bullet(double A, double B, double C, double D, double ATemp, double BTemp, double CTemp, string NameB, Weapon[] Weapons, int Id1, int Id2, int Id3)
        //{
        //    a = A;
        //    b = B;
        //    c = C;
        //    d = D;

        //    aTemp = ATemp;
        //    bTemp = BTemp;
        //    cTemp = CTemp;

        //    nameB = NameB;

        //    arrayWeapons = new Weapon[3];
        //    arrayWeapons[0] = Weapons[Id1];
        //    arrayWeapons[1] = Weapons[Id2];
        //    arrayWeapons[2] = Weapons[Id3];
        //}

        //public Bullet(double A, double B, double C, double D, double ATemp, double BTemp, double CTemp, string NameB, Weapon[] Weapons, int Id1, int Id2, int Id3, int Id4)
        //{
        //    a = A;
        //    b = B;
        //    c = C;
        //    d = D;

        //    aTemp = ATemp;
        //    bTemp = BTemp;
        //    cTemp = CTemp;

        //    nameB = NameB;

        //    arrayWeapons = new Weapon[4];
        //    arrayWeapons[0] = Weapons[Id1];
        //    arrayWeapons[1] = Weapons[Id2];
        //    arrayWeapons[2] = Weapons[Id3];
        //    arrayWeapons[3] = Weapons[Id4];
        //}

        //public Bullet(double A, double B, double C, double D, double ATemp, double BTemp, double CTemp, string NameB, Weapon[] Weapons, int Id1, int Id2, int Id3, int Id4, int Id5)
        //{
        //    a = A;
        //    b = B;
        //    c = C;
        //    d = D;

        //    aTemp = ATemp;
        //    bTemp = BTemp;
        //    cTemp = CTemp;

        //    nameB = NameB;

        //    arrayWeapons = new Weapon[5];
        //    arrayWeapons[0] = Weapons[Id1];
        //    arrayWeapons[1] = Weapons[Id2];
        //    arrayWeapons[2] = Weapons[Id3];
        //    arrayWeapons[3] = Weapons[Id4];
        //    arrayWeapons[4] = Weapons[Id5];
        //}


        //public Bullet(double A, double B, double C, double D, double ATemp, double BTemp, double CTemp, string NameB)
        //{
        //    a = A;
        //    b = B;
        //    c = C;
        //    d = D;

        //    aTemp = ATemp;
        //    bTemp = BTemp;
        //    cTemp = CTemp;

        //    nameB = NameB;
        //}

        public Bullet(int ID, string NameB, double A, double B, double C, double D, double ATemp, double BTemp, double CTemp) //Конструктор
        {
            id = ID;
            a = A;
            b = B;
            c = C;
            d = D;

            aTemp = ATemp;
            bTemp = BTemp;
            cTemp = CTemp;

            nameB = NameB;
        }

        //public Bullet(int ID, double A, double B, double C, double D, double ATemp, double BTemp, double CTemp, string NameB, Weapon[] Weapons, int Id1)
        //{
        //    id = ID;
        //    a = A;
        //    b = B;
        //    c = C;
        //    d = D;

        //    aTemp = ATemp;
        //    bTemp = BTemp;
        //    cTemp = CTemp;

        //    nameB = NameB;

        //    arrayWeapons = new Weapon[1];
        //    arrayWeapons[0] = Weapons[Id1];
        //}

        //public Bullet(int ID, double A, double B, double C, double D, double ATemp, double BTemp, double CTemp, string NameB, Weapon[] Weapons, int Id1, int Id2)
        //{
        //    id = ID;
        //    a = A;
        //    b = B;
        //    c = C;
        //    d = D;

        //    aTemp = ATemp;
        //    bTemp = BTemp;
        //    cTemp = CTemp;

        //    nameB = NameB;

        //    arrayWeapons = new Weapon[2];
        //    arrayWeapons[0] = Weapons[Id1];
        //    arrayWeapons[1] = Weapons[Id2];
        //}
    }




    //public Weapon[] arrayWeapons;

    //public void AddWeapons(string name0, double Kw0)
    //{
    //    arrayWeapons = new Weapon[1];
    //    arrayWeapons[0] = new Weapon(name0, Kw0);
    //}

    //public void AddWeapons(string name0, double Kw0, string name1, double Kw1)
    //{
    //    arrayWeapons = new Weapon[2];
    //    arrayWeapons[0] = new Weapon(name0, Kw0);
    //    arrayWeapons[1] = new Weapon(name1, Kw1);
    //}
    //public void AddWeapons(string name0, double Kw0, string name1, double Kw1, string name2, double Kw2)
    //{
    //    arrayWeapons = new Weapon[3];
    //    arrayWeapons[0] = new Weapon(name0, Kw0);
    //    arrayWeapons[1] = new Weapon(name1, Kw1);
    //    arrayWeapons[2] = new Weapon(name2, Kw2);
    //}
    //public void AddWeapons(string name0, double Kw0, string name1, double Kw1, string name2, double Kw2, string name3, double Kw3)
    //{
    //    arrayWeapons = new Weapon[4];
    //    arrayWeapons[0] = new Weapon(name0, Kw0);
    //    arrayWeapons[1] = new Weapon(name1, Kw1);
    //    arrayWeapons[2] = new Weapon(name2, Kw2);
    //    arrayWeapons[3] = new Weapon(name3, Kw3);
    //}
    //public void AddWeapons(string name0, double Kw0, string name1, double Kw1, string name2, double Kw2, string name3, double Kw3, string name4, double Kw4)
    //{
    //    arrayWeapons = new Weapon[5];
    //    arrayWeapons[0] = new Weapon(name0, Kw0);
    //    arrayWeapons[1] = new Weapon(name1, Kw1);
    //    arrayWeapons[2] = new Weapon(name2, Kw2);
    //    arrayWeapons[3] = new Weapon(name3, Kw3);
    //    arrayWeapons[4] = new Weapon(name4, Kw4);
    //}
}

