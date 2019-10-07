using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ACE3Calc
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RBC : ContentPage
    {
        double temp = 20.0; //Значение температуры
        int range = 350; //Значение расстояния

        double aTemp, bTemp, cTemp; //коэффициенты для расчета коэффициента поправки на ветер
        double Kweapon = 0; //Коэффициет оружия
        double a, b, c, d; //Коэффициенты кубической апроксимации для расчета значения поправки

        double popravka; //Расчетное значение поправки

        Bullet[] bullets; //Создаем массив пуль
        Weapon[] weaponsList;

        public RBC()
        {
            InitializeComponent();

            //Options(); //Метод применения настроек для графических элементов

            //***********************************************************************************************************************************************************
            bullets = new Bullet[44]; //Добавление списка пуль, оружия и их коэффициентов

            bullets[0] = new Bullet(0, "12.7mm 5Rnd Mag", 0.0, 0.0, 0.0, 0.0, 0, 0, 0);
            bullets[1] = new Bullet(1, "Магазин, 5 патр. APDS 12,7mm", 0.0, 0.0, 0.0, 0.0, 0, 0, 0);
            bullets[2] = new Bullet(2, "Магазин из 5-ти 12,7x99 мм", 0.0, 0.0, 0.0, 0.0, 0, 0, 0);
            bullets[3] = new Bullet(3, "Магазин из 5-ти 12,7x99 мм (бронебойно-зажигательные)", 0.0, 0.0, 0.0, 0.0, 0, 0, 0);
            bullets[4] = new Bullet(4, "Магазин из 5-ти 12,7x99 мм (A-MAX)", 0.0, 0.0, 0.0, 0.0, 0, 0, 0);
            bullets[5] = new Bullet(5, "Магазин, 10 патронов .338 LM", 0.0000000024, -0.0000000400, 0.0076751806, -1.4023219815, 0, 0, 0);
            bullets[6] = new Bullet(6, "Магазин из 10-ти .338 (300 гран Lapua Scenar)", 0.0000000018, 0.0000016486, 0.0077578689, -1.2044117649, 0, 0, 0);
            bullets[7] = new Bullet(7, "Магазин из 10-ти .338 (API526)", 0.0000000036, -0.0000012098, 0.0082604539, -1.3898864808, 0, 0, 0);
            bullets[8] = new Bullet(8, "20rnd SR-25 M993 AP", 0.0, 0.0, 0.0, 0.0, 0, 0, 0);
            bullets[9] = new Bullet(9, "20rnd SR-25 M118", 0.0, 0.0, 0.0, 0.0, 0, 0, 0);
            bullets[10] = new Bullet(10, "20rnd SR-25 Mk316 Mod 0", 0.0, 0.0, 0.0, 0.0, 0, 0, 0);
            bullets[11] = new Bullet(11, "20rnd SR-25 M62 (Tracer)", 0.0, 0.0, 0.0, 0.0, 0, 0, 0);
            bullets[12] = new Bullet(12, ".408 7Rnd Mag", 0, 0, 0, 0, 0, 0, 0);
            bullets[13] = new Bullet(13, "Магазин из 7-ти .408 (305gr)", 0, 0, 0, 0, 0, 0, 0);
            bullets[14] = new Bullet(14, "7.62mm 20rnd Mag (NATO)", 0.0000000087, -0.0000008012, 0.0090613505, -1.2261463921, 0, 0, 0);
            bullets[15] = new Bullet(15, "Магазин из 20-ти 7.62 мм трассирующих", 0.0000000087, -0.0000008012, 0.0090613505, -1.2261463921, 0, 0, 0);
            bullets[16] = new Bullet(16, "Магазин из 20-ти 7.62 мм ИК-трассирующих", 0.0000000088, -0.0000008013, 0.0090613506, -1.2261463922, 0, 0, 0);
            bullets[17] = new Bullet(17, "Магазин из 20-ти 7.62 мм дозвуковых ", 0, 0.0000266272, 0.0433609468, -4.7150887436, 0, 0, 0);
            bullets[18] = new Bullet(18, "Магазин из 20-ти 7.62 мм (M118LR)", 0, 0, 0, 0, 0, 0, 0);
            bullets[19] = new Bullet(19, "Магазин из 20-ти 7.62 мм (M993 бронебоайные)", 0, 0, 0, 0, 0, 0, 0);
            bullets[20] = new Bullet(20, "Магазин из 20-ти 7.62 мм (MK316 Mod 0)", 0, 0, 0, 0, 0, 0, 0);
            bullets[21] = new Bullet(21, "Магазин из 20-ти 7.62 мм (MK319 Mod 0)", 0, 0, 0, 0, 0, 0, 0);
            bullets[22] = new Bullet(22, "20Rnd M14 m118 (RHS)", 0, 0, 0, 0, 0, 0, 0);
            bullets[23] = new Bullet(23, "20Rnd M14 m62 (Tracer) (RHS)", 0, 0, 0, 0, 0, 0, 0);
            bullets[24] = new Bullet(24, "20Rnd M14 m993 AP (RHS)", 0, 0, 0, 0, 0, 0, 0);
            bullets[25] = new Bullet(25, "Магазин из 10-ти 7.62 мм (M118LR)", 0, 0, 0, 0, 0, 0, 0);
            bullets[26] = new Bullet(26, "Магазин из 10-ти 7.62 мм (M993 бронебоайные)", 0, 0, 0, 0, 0, 0, 0);
            bullets[27] = new Bullet(27, "Магазин из 10-ти 7.62 мм (MK316 Mod 0)", 0, 0, 0, 0, 0, 0, 0);
            bullets[28] = new Bullet(28, "Магазин из 10-ти 7.62 мм (MK319 Mod 0)", 0, 0, 0, 0, 0, 0, 0);
            bullets[29] = new Bullet(29, "10Rnd AICS M118 (RHS)", 0, 0, 0, 0, 0, 0, 0);
            bullets[30] = new Bullet(30, "10Rnd AICS M62 (Tracer) (RHS)", 0, 0, 0, 0, 0, 0, 0);
            bullets[31] = new Bullet(31, "10Rnd AICS M993 AP (RHS)", 0, 0, 0, 0, 0, 0, 0);
            bullets[32] = new Bullet(32, "5Rnd AICS M118 (RHS)", 0, 0, 0, 0, 0, 0, 0);
            bullets[33] = new Bullet(33, "5Rnd AICS M62 (Tracer) (RHS)", 0, 0, 0, 0, 0, 0, 0);
            bullets[34] = new Bullet(34, "5Rnd AICS M993 AP (RHS)", 0, 0, 0, 0, 0, 0, 0);
            bullets[35] = new Bullet(35, "5Rnd M118 (RHS)", 0, 0, 0, 0, 0, 0, 0);
            bullets[36] = new Bullet(36, "5Rnd M62 (Tracer) (RHS)", 0, 0, 0, 0, 0, 0, 0);
            bullets[37] = new Bullet(37, "5Rnd M993 AP (RHS)", 0, 0, 0, 0, 0, 0, 0);
            bullets[38] = new Bullet(38, "6,5mm 30Rnd Mag (NATO)", 0, 0, 0, 0, 0, 0, 0);
            bullets[39] = new Bullet(39, "6,5 mm 30Rnd Mag (CSAT)", 0, 0, 0, 0, 0, 0, 0);
            bullets[40] = new Bullet(40, "10Птр. СВД 7Н1", 0, 0, 0, 0, 0, 0, 0);
            bullets[41] = new Bullet(41, "10Птр. СВД 7Н14", 0, 0, 0, 0, 0, 0, 0);
            bullets[42] = new Bullet(42, "Магазин, 10 патр. 9,3 мм", 0, 0, 0, 0, 0, 0, 0);
            bullets[43] = new Bullet(43, "Магазин, 10 патр. 7,62 мм", 0, 0, 0, 0, 0, 0, 0);


            //bullets[0] = new Bullet(0, "12.7mm 5Rnd Mag", -0.0000000004, 0.0000093195, 0.0018938974, -0.1816334947, -0.0000349298, -0.0044442614, 1.0745286151); //Добавление массива пуль
            //bullets[1] = new Bullet(1, "Магазин, 5 патр. APDS 12,7mm", -0.0000000004, 0.0000093195, 0.0018938974, -0.1816334947, -0.0000349298, -0.0044442614, 1.0745286151);
            //bullets[2] = new Bullet(2, "Магазин из 5-ти 12,7x99 мм", 0.0000000001, 0.0000062624, 0.0019210244, -0.2180889965, -0.0000493914, -0.0037035309, 1.0666712038);
            //bullets[3] = new Bullet(3, "Магазин из 5-ти 12,7x99 мм (бронебойно-зажигательные)", 0.0000000001, 0.0000062624, 0.0019210244, -0.2180889965, -0.0000493914, -0.0037035309, 1.0666712038);
            //bullets[4] = new Bullet(4, "Магазин из 5-ти 12,7x99 мм (A-MAX)", 0.0000000004, 0.0000028484, 0.0043822318, -0.4606140654, -0.0000456697, -0.0031961948, 1.0582231736);
            /////
            //bullets[5] = new Bullet(5, "Магазин, 10 патронов .338 LM", 0.0000000024, -0.0000000400, 0.0076751806, -1.4023219815, 0, 0, 0);
            //bullets[6] = new Bullet(6, "Магазин из 10-ти .338 (300 гран Lapua Scenar)", 0.0000000018, 0.0000016486, 0.0077578689, -1.2044117649, 0, 0, 0);
            //bullets[7] = new Bullet(7, "Магазин из 10-ти .338 (API526)", 0.0000000036, -0.0000012098, 0.0082604539, -1.3898864808, 0, 0, 0);
            /////
            //bullets[8] = new Bullet(8, "7.62mm 20rnd Mag (NATO)", 0.0000000127, -0.0000097972, 0.0058772425, -2.5239693553, 0, 0, 0);
            //bullets[9] = new Bullet(9, "Магазин из 20-ти 7.62 мм трассирующих (NATO)", 0.0000000127, -0.0000097972, 0.0058772425, -2.5239693553, 0, 0, 0);
            //bullets[10] = new Bullet(10, "Магазин из 20-ти 7.62 мм ИК-трассирующих (NATO)", 0.0000000127, -0.0000097972, 0.0058772425, -2.5239693553, 0, 0, 0);
            //bullets[11] = new Bullet(11, "Магазин из 20-ти 7.62 мм дозвуковых (NATO)", -0.0000000703, 0.0001227709, 0.0041550567, -0.1754806239, 0, 0, 0);


            //bullets[6] = new Bullet(6, "20rnd SR-25 M118", 0, 0.0000124800, 0.0019151580, -0.1550342679, -0.0000416668, -0.0041666649, 1.0718750474);
            //bullets[7] = new Bullet(7, "20rnd SR-25 Mk316 Mod 0", 0, 0.0000124800, 0.0019151580, -0.1550342679, -0.0000416668, -0.0041666649, 1.0718750474);
            //bullets[8] = new Bullet(8, "20rnd SR-25 M993 AP", 0, 0.0000122902, -0.0001834624, -0.0679626168, -0.0000666676, -0.0033333156, 1.0650004666);
            //bullets[9] = new Bullet(9, "20rnd SR-25 M62 (Tracer)", 0, 0.000014270, 0.0006383678, -0.0979544438, -0.0000854702, -0.0034188014, 1.0705128731);
            /////
            //bullets[10] = new Bullet(10, "6,5mm 30Rnd Mag (NATO)", 0, 0.0000117292, 0.0025112503, -0.1501122711, -0.0000406592, -0.0040648645, 1.0701265756);
            //bullets[11] = new Bullet(11, "6,5mm 30Rnd Mag (CSAT)", 0, 0.0000116474, 0.0025185907, -0.1600307561, -0.0000813009, -0.0032520306, 1.0670732206);

            //***********************************************************************************************************************************************************

            weaponsList = new Weapon[32]; //Массив с оружием и его коэффициентами

            weaponsList[0] = new Weapon(0, "GM6 Lynx", 1.0, bullets, new List<int>() { 0, 1, 2, 3, 4 });
            weaponsList[1] = new Weapon(1, "M107", 1.003357, bullets, new List<int>() { 2, 3, 4 });
            weaponsList[2] = new Weapon(2, "Mk18 ABR 7.62", 1.0, bullets, new List<int>() { 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28 });
            weaponsList[3] = new Weapon(3, "MK-1 EMR 7.62 mm", 0.96825397, bullets, new List<int>() { 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28 });
            weaponsList[4] = new Weapon(4, "Mk14 7.62 mm", 0.95502646, bullets, new List<int>() { 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28 });
            weaponsList[5] = new Weapon(5, "SPAR-17 7.62mm", 0.97089947, bullets, new List<int>() { 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28 });
            weaponsList[6] = new Weapon(6, "MAR-10 .338", 1.0, bullets, new List<int>() { 5, 6, 7 });
            weaponsList[7] = new Weapon(7, "Mk 11 Mod 0 (RHS)", 1.0, bullets, new List<int>() { 8, 9, 10, 11 });
            weaponsList[8] = new Weapon(8, "Type 115 6,5 mm", 1.0, bullets, new List<int>() { 39 });
            weaponsList[9] = new Weapon(9, "MXM 6,5 mm", 1.0, bullets, new List<int>() { 38 });
            weaponsList[10] = new Weapon(10, "СВДМ (НПЗ) (RHS)", 1.0, bullets, new List<int>() { 40, 41 });
            weaponsList[11] = new Weapon(11, "СВДС (НПЗ) (RHS)", 1.04123711, bullets, new List<int>() { 40, 41 });
            weaponsList[12] = new Weapon(12, "Cyrus 9,3 мм", 1.0, bullets, new List<int>() { 42 });
            weaponsList[13] = new Weapon(13, "Rahim 7,62 мм", 1.0, bullets, new List<int>() { 43 });
            weaponsList[14] = new Weapon(14, "M320 LRR .408", 1.0, bullets, new List<int>() { 12, 13 });
            weaponsList[15] = new Weapon(15, "ASP-1 Kir 12,7 мм", 1.0, bullets, new List<int>() { });
            weaponsList[16] = new Weapon(16, "CMR-76 6,5 мм", 0.5, bullets, new List<int>() { });
            weaponsList[17] = new Weapon(17, "T-5000", 1.0, bullets, new List<int>() { });
            weaponsList[18] = new Weapon(18, "M82A1 (RHS)", 0.5, bullets, new List<int>() { });
            weaponsList[19] = new Weapon(19, "M14 EBR-RI (RHS)", 0.5, bullets, new List<int>() { });
            weaponsList[20] = new Weapon(20, "M24 SWS (RHS)", 0.5, bullets, new List<int>() { });
            weaponsList[21] = new Weapon(21, "M40A5 (RHS)", 0.5, bullets, new List<int>() { });
            weaponsList[22] = new Weapon(22, "M2010 ESR", 0.5, bullets, new List<int>() { });
            weaponsList[23] = new Weapon(23, "H&K PSG1A1 (RIS)", 0.5, bullets, new List<int>() { });
            weaponsList[24] = new Weapon(24, "KSK HK417 7.62 mm", 0.5, bullets, new List<int>() { 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28 });
            weaponsList[25] = new Weapon(25, "KSK Sig 556 DMR 7.62 mm", 0.5, bullets, new List<int>() { });
            weaponsList[26] = new Weapon(26, "L115A3", 0.5, bullets, new List<int>() { });
            weaponsList[27] = new Weapon(27, "L118A1 AWC", 0.5, bullets, new List<int>() { });
            weaponsList[28] = new Weapon(28, "L135A1 LRPAS", 1, bullets, new List<int>() { });
            weaponsList[29] = new Weapon(29, "M14 (HLC)", 0.5, bullets, new List<int>() { });
            weaponsList[30] = new Weapon(30, "M14 DMR (HLC)", 0.5, bullets, new List<int>() { });
            weaponsList[31] = new Weapon(31, "M21 (HLC)", 0.5, bullets, new List<int>() { });



            //weaponsList[0] = new Weapon(0, "GM6 Lynx", 1.0, bullets, new List<int>() { 0, 1, 2, 3, 4 });
            //weaponsList[1] = new Weapon(1, "M107", 1.003357, bullets, new List<int>() { 2, 3, 4 });
            //weaponsList[2] = new Weapon(2, "Mk18 ABR 7.62", 1.0, bullets, new List<int>() { 8, 9, 10, 11 });
            //weaponsList[3] = new Weapon(3, "MK-1 EMR 7.62 mm", 0.96825397, bullets, new List<int>() { 8, 9, 10, 11 });
            //weaponsList[4] = new Weapon(4, "Mk14 7.62 mm", 0.95502646, bullets, new List<int>() { 8, 9, 10, 11 });
            //weaponsList[5] = new Weapon(5, "SPAR-17 7.62mm", 0.97089947, bullets, new List<int>() { 8, 9, 10, 11 });
            //weaponsList[6] = new Weapon(6, "MAR-10 .338", 1.0, bullets, new List<int>() { 5, 6, 7 });
            ////weaponsList[7] = new Weapon(, "", 1.0, bullets, new List<int>() {  });
            //weaponsList[8] = new Weapon(, "", 1.0, bullets, new List<int>() {  });
            //weaponsList[9] = new Weapon(, "", 1.0, bullets, new List<int>() {  });
            //weaponsList[10] = new Weapon(, "", 1.0, bullets, new List<int>() {  });
            //weaponsList[11] = new Weapon(, "", 1.0, bullets, new List<int>() {  });
            //weaponsList[12] = new Weapon(, "", 1.0, bullets, new List<int>() {  });
            //weaponsList[13] = new Weapon(, "", 1.0, bullets, new List<int>() {  });
            //weaponsList[14] = new Weapon(, "", 1.0, bullets, new List<int>() {  });


            //labelx.Text = bullets[0].arrayWeapons[0].namew + Convert.ToString(bullets[0].arrayWeapons[0].Kweapon); //проверочная строка


            for (int i = 0; i < weaponsList.Length; i++) //Цикл добавления списка оружия  // Первое
            {
                pickerWeapon.Items.Add(weaponsList[i].namew);
            }

            //labelTemp.Text = Convert.ToString(Math.Round(temp, 1)); //Округление температуры и обновление текста строки   ///Закоменчено, так как не используется температура
            labelRange.Text = Convert.ToString(range); //Обновление текста строки расстояния

            PopravkaRaschet(); //Метод расчета поправки
        }



        //////Пиккеры - контейнеры с массивами пуль и оружий
        private void PickerWeapon_SelectedIndexChanged(object sender, EventArgs e) //Выбор оружия
        {
            int index;
            index = pickerWeapon.SelectedIndex;

            pickerBullet.Items.Clear(); //Очищаем список пуль

            for (int i = 0; i < weaponsList[pickerWeapon.SelectedIndex].arrayBullets.Length; i++) //Цикл добавления списка пуль подходящего для оружия  // Второе
            {
                pickerBullet.Items.Add(weaponsList[pickerWeapon.SelectedIndex].arrayBullets[i].nameB);
            }

            Kweapon = weaponsList[pickerWeapon.SelectedIndex].Kweapon;
            popravka = 0; //Метод расчета поправки
            labelRezult.Text = Convert.ToString(Math.Round(popravka, 1)); //Выводим в лейбл значение поправки
        }

        private void PickerBullet_SelectedIndexChanged(object senders, EventArgs e) //Выбор пули
        {
            int index;
            index = pickerBullet.SelectedIndex;

            if (index >= 0)
            {
                a = weaponsList[pickerWeapon.SelectedIndex].arrayBullets[index].a;
                b = weaponsList[pickerWeapon.SelectedIndex].arrayBullets[index].b;
                c = weaponsList[pickerWeapon.SelectedIndex].arrayBullets[index].c;
                d = weaponsList[pickerWeapon.SelectedIndex].arrayBullets[index].d;
                aTemp = weaponsList[pickerWeapon.SelectedIndex].arrayBullets[index].aTemp;
                bTemp = weaponsList[pickerWeapon.SelectedIndex].arrayBullets[index].bTemp;
                cTemp = weaponsList[pickerWeapon.SelectedIndex].arrayBullets[index].cTemp;
            }

            PopravkaRaschet(); //Метод расчета поправки
        }



        //////Кнопки изменения значения температуры   ///Закоменчено, так как не используется температура
        //private void buttonTempAdd_clicked(object senders, EventArgs e)
        //{
        //    ChangeTempINT('+'); //Метод изменения целой части значения температуры
        //    PopravkaRaschet(); //Метод расчета поправки

        //    //if (temp >= 99)
        //    //{
        //    //    buttonTempAdd.IsEnabled = false;
        //    //    buttonTempSub.IsEnabled = true;
        //    //}
        //    //else if (temp<=-15)
        //    //{
        //    //    buttonTempAdd.IsEnabled = true;
        //    //    buttonTempSub.IsEnabled = false;
        //    //}
        //    //else
        //    //{
        //    //    buttonTempAdd.IsEnabled = true;
        //    //    buttonTempSub.IsEnabled = true;
        //    //}
        //}
        //private void buttonTempSub_clicked(object senders, EventArgs e)
        //{
        //    ChangeTempINT('-'); //Метод изменения целой части значения температуры
        //    PopravkaRaschet(); //Метод расчета поправки
        //}
        //private void buttonTempAddFl_clicked(object sender, EventArgs e)
        //{
        //    ChangeTempFl('+'); //Метод изменения дробной части значения температуры
        //    PopravkaRaschet(); //Метод расчета поправки
        //}
        //private void buttonTempSubFl_clicked(object sender, EventArgs e)
        //{
        //    ChangeTempFl('-'); //Метод изменения дробной части значения температуры
        //    PopravkaRaschet(); //Метод расчета поправки
        //}



        //////Кнопки на цифровой клаве
        private void button0_clicked(object senders, EventArgs e)
        {
            ChangeRange(0); //Метод изменения значения расстояния с помощью кнопок цифровой клавиатуры
            PopravkaRaschet(); //Метод расчета поправки
        }
        private void button1_clicked(object senders, EventArgs e)
        {
            ChangeRange(1); //Метод изменения значения расстояния с помощью кнопок цифровой клавиатуры
            PopravkaRaschet(); //Метод расчета поправки
        }
        private void button2_clicked(object senders, EventArgs e)
        {
            ChangeRange(2); //Метод изменения значения расстояния с помощью кнопок цифровой клавиатуры
            PopravkaRaschet(); //Метод расчета поправки
        }
        private void button3_clicked(object senders, EventArgs e)
        {
            ChangeRange(3); //Метод изменения значения расстояния с помощью кнопок цифровой клавиатуры
            PopravkaRaschet(); //Метод расчета поправки
        }
        private void button4_clicked(object senders, EventArgs e)
        {
            ChangeRange(4); //Метод изменения значения расстояния с помощью кнопок цифровой клавиатуры
            PopravkaRaschet(); //Метод расчета поправки
        }
        private void button5_clicked(object senders, EventArgs e)
        {
            ChangeRange(5); //Метод изменения значения расстояния с помощью кнопок цифровой клавиатуры
            PopravkaRaschet(); //Метод расчета поправки
        }
        private void button6_clicked(object senders, EventArgs e)
        {
            ChangeRange(6); //Метод изменения значения расстояния с помощью кнопок цифровой клавиатуры
            PopravkaRaschet(); //Метод расчета поправки
        }
        private void button7_clicked(object senders, EventArgs e)
        {
            ChangeRange(7); //Метод изменения значения расстояния с помощью кнопок цифровой клавиатуры
            PopravkaRaschet(); //Метод расчета поправки
        }
        private void button8_clicked(object senders, EventArgs e)
        {
            ChangeRange(8); //Метод изменения значения расстояния с помощью кнопок цифровой клавиатуры
            PopravkaRaschet(); //Метод расчета поправки
        }
        private void button9_clicked(object senders, EventArgs e)
        {
            ChangeRange(9); //Метод изменения значения расстояния с помощью кнопок цифровой клавиатуры
            PopravkaRaschet(); //Метод расчета поправки
        }
        private void buttonC_clicked(object senders, EventArgs e)
        {
            ChangeRange(99999); //Метод изменения значения расстояния с помощью кнопок цифровой клавиатуры
            PopravkaRaschet(); //Метод расчета поправки
        }
        private void buttonRangeAdd_clicked(object senders, EventArgs e)
        {
            ChangeRange(10); //Метод изменения значения расстояния с помощью кнопок цифровой клавиатуры
            PopravkaRaschet(); //Метод расчета поправки
        }
        private void buttonRangeSub_clicked(object senders, EventArgs e)
        {
            ChangeRange(-10); //Метод изменения значения расстояния с помощью кнопок цифровой клавиатуры
            PopravkaRaschet(); //Метод расчета поправки
        }



        //////Кнопки пресеты
        private void but200_clicked(object senders, EventArgs e)
        {
            ReplaceRange(200); //Метод изменения расстояния пресетами
            PopravkaRaschet(); //Метод расчета поправки
        }
        private void but250_clicked(object senders, EventArgs e)
        {
            ReplaceRange(250); //Метод изменения расстояния пресетами
            PopravkaRaschet(); //Метод расчета поправки
        }
        private void but300_clicked(object senders, EventArgs e)
        {
            ReplaceRange(300); //Метод изменения расстояния пресетами
            PopravkaRaschet(); //Метод расчета поправки
        }
        private void but350_clicked(object senders, EventArgs e)
        {
            ReplaceRange(350); //Метод изменения расстояния пресетами
            PopravkaRaschet(); //Метод расчета поправки
        }
        private void but400_clicked(object senders, EventArgs e)
        {
            ReplaceRange(400); //Метод изменения расстояния пресетами
            PopravkaRaschet(); //Метод расчета поправки
        }
        private void but450_clicked(object senders, EventArgs e)
        {
            ReplaceRange(450); //Метод изменения расстояния пресетами
            PopravkaRaschet(); //Метод расчета поправки
        }
        private void but500_clicked(object senders, EventArgs e)
        {
            ReplaceRange(500); //Метод изменения расстояния пресетами
            PopravkaRaschet(); //Метод расчета поправки
        }
        private void but550_clicked(object senders, EventArgs e)
        {
            ReplaceRange(550); //Метод изменения расстояния пресетами
            PopravkaRaschet(); //Метод расчета поправки
        }
        private void but600_clicked(object senders, EventArgs e)
        {
            ReplaceRange(600); //Метод изменения расстояния пресетами
            PopravkaRaschet(); //Метод расчета поправки
        }
        private void but650_clicked(object senders, EventArgs e)
        {
            ReplaceRange(650); //Метод изменения расстояния пресетами
            PopravkaRaschet(); //Метод расчета поправки
        }
        private void but700_clicked(object senders, EventArgs e)
        {
            ReplaceRange(700); //Метод изменения расстояния пресетами
            PopravkaRaschet(); //Метод расчета поправки
        }
        private void but750_clicked(object senders, EventArgs e)
        {
            ReplaceRange(750); //Метод изменения расстояния пресетами
            PopravkaRaschet(); //Метод расчета поправки
        }
        private void but800_clicked(object senders, EventArgs e)
        {
            ReplaceRange(800); //Метод изменения расстояния пресетами
            PopravkaRaschet(); //Метод расчета поправки
        }
        private void but850_clicked(object senders, EventArgs e)
        {
            ReplaceRange(850); //Метод изменения расстояния пресетами
            PopravkaRaschet(); //Метод расчета поправки
        }
        private void but900_clicked(object senders, EventArgs e)
        {
            ReplaceRange(900); //Метод изменения расстояния пресетами
            PopravkaRaschet(); //Метод расчета поправки
        }
        private void but950_clicked(object senders, EventArgs e)
        {
            ReplaceRange(950); //Метод изменения расстояния пресетами
            PopravkaRaschet(); //Метод расчета поправки
        }
        private void but1000_clicked(object senders, EventArgs e)
        {
            ReplaceRange(1000); //Метод изменения расстояния пресетами
            PopravkaRaschet(); //Метод расчета поправки
        }



        /////Функции

        //private void ChangeTempINT(char znak) //Функция изменения значения температуры   ///Закоменчено, так как не используется температура
        //{
        //    if (znak == '-')
        //    {
        //        if (temp <= -15)
        //        {
        //            temp = -15;
        //        }
        //        else
        //        {
        //            temp = temp - 1.0;
        //        }
        //        labelTemp.Text = Convert.ToString(Math.Round(temp, 1)); //Округление температуры и обновление текста строки
        //    }
        //    else if (znak == '+')
        //    {
        //        if (temp >= 50)
        //        {
        //            temp = 50;
        //        }
        //        else
        //        {
        //            temp = temp + 1.0;
        //        }
        //        labelTemp.Text = Convert.ToString(Math.Round(temp, 1)); //Округление температуры и обновление текста строки
        //    }
        //    else
        //    {
        //        //Ошибка                
        //        labelTemp.Text = "Err";
        //    }
        //}

        //private void ChangeTempFl(char znak) //Функция изменения дробной части значения температуры   ///Закоменчено, так как не используется температура
        //{
        //    if (znak == '-')
        //    {
        //        if (temp <= -15)
        //        {
        //            temp = -15;
        //        }
        //        else
        //        {
        //            temp = temp - 0.1;
        //        }
        //        labelTemp.Text = Convert.ToString(Math.Round(temp, 1)); //Округление температуры и обновление текста строки
        //    }
        //    else if (znak == '+')
        //    {
        //        if (temp >= 50)
        //        {
        //            temp = 50;
        //        }
        //        else
        //        {
        //            temp = temp + 0.1;
        //        }
        //        labelTemp.Text = Convert.ToString(Math.Round(temp, 1)); //Округление температуры и обновление текста строки
        //    }
        //    else
        //    {
        //        //Ошибка                
        //        labelTemp.Text = "Err";
        //    }
        //}

        private void ChangeRange(int Knopka) //Для изменения значения расстония цифровой клавиатурой
        {
            switch (Knopka)
            {
                case 0:
                    if (range < 1000)
                    {
                        range = range * 10 + 0;
                    }
                    else
                    {
                        range = 0;
                        range = range * 10 + 0;
                    }
                    break;
                case 1:
                    if (range < 1000)
                    {
                        range = range * 10 + 1;
                    }
                    else
                    {
                        range = 0;
                        range = range * 10 + 1;
                    }
                    break;
                case 2:
                    if (range < 1000)
                    {
                        range = range * 10 + 2;
                    }
                    else
                    {
                        range = 0;
                        range = range * 10 + 2;
                    }
                    break;
                case 3:
                    if (range < 1000)
                    {
                        range = range * 10 + 3;
                    }
                    else
                    {
                        range = 0;
                        range = range * 10 + 3;
                    }
                    break;
                case 4:
                    if (range < 1000)
                    {
                        range = range * 10 + 4;
                    }
                    else
                    {
                        range = 0;
                        range = range * 10 + 4;
                    }
                    break;
                case 5:
                    if (range < 1000)
                    {
                        range = range * 10 + 5;
                    }
                    else
                    {
                        range = 0;
                        range = range * 10 + 5;
                    }
                    break;
                case 6:
                    if (range < 1000)
                    {
                        range = range * 10 + 6;
                    }
                    else
                    {
                        range = 0;
                        range = range * 10 + 6;
                    }
                    break;
                case 7:
                    if (range < 1000)
                    {
                        range = range * 10 + 7;
                    }
                    else
                    {
                        range = 0;
                        range = range * 10 + 7;
                    }
                    break;
                case 8:
                    if (range < 1000)
                    {
                        range = range * 10 + 8;
                    }
                    else
                    {
                        range = 0;
                        range = range * 10 + 8;
                    }
                    break;
                case 9:
                    if (range < 1000)
                    {
                        range = range * 10 + 9;
                    }
                    else
                    {
                        range = 0;
                        range = range * 10 + 9;
                    }
                    break;
                case 99999: // Кнопка стереть
                    range = 0;
                    break;
                case 10:
                    range = range + 10;
                    break;
                case -10:
                    range = range - 10;
                    break;

                default: break;
            }


            if (range >= 9999) //Что бы расстояние не было больше четырех знаков 
            {
                range = 9999;
            }
            else if (range <= 0)
            {
                range = 0;
            }

            //PopravkaRaschet();

            labelRange.Text = Convert.ToString(range);
        }

        private void ReplaceRange(int Range) //Для изменения значения расстояния с помощью пресетов
        {
            range = Range;
            labelRange.Text = Convert.ToString(range);
            //PopravkaRaschet();
        }

        //private void PopravkaRaschet() //Расчет значения поправки по имеющимся значениям.    С WOG
        //{
        //    popravka = (a * Math.Pow(range, 3) + b * Math.Pow(range, 2) + c * range + d) * Kweapon * (aTemp * temp * temp + bTemp * temp + cTemp);

        //    if (popravka < 0) { popravka = 0; }

        //    labelRezult.Text = Convert.ToString(Math.Round(popravka, 1)); //Выводим в лейбл
        //}

        private void PopravkaRaschet() //Расчет значения поправки по имеющимся значениям.  для RBC
        {
            popravka = (a * range * range * range + b * range * range + c * range + d) * Kweapon;

            if (popravka < 0) { popravka = 0; }

            labelRezult.Text = Convert.ToString(Math.Round(popravka, 1)); //Выводим в лейбл
        }

        private void Options() //Метод с настройками страницы
        {
            int butPresetsHeigth = 25; //Высота кнопок пресетов

            //buttonTempAdd.HeightRequest = 20; //Переопределение высоты кнопки
            //buttonTempAddFl.HeightRequest = 20; //Переопределение высоты кнопки
            //buttonTempSub.HeightRequest = 20; //Переопределение высоты кнопки
            //buttonTempSubFl.HeightRequest = 20; //Переопределение высоты кнопки

            but200.HeightRequest = butPresetsHeigth;
            but250.HeightRequest = butPresetsHeigth;
            but300.HeightRequest = butPresetsHeigth;
            but350.HeightRequest = butPresetsHeigth;
            but400.HeightRequest = butPresetsHeigth;
            but450.HeightRequest = butPresetsHeigth;
            but500.HeightRequest = butPresetsHeigth;
            but550.HeightRequest = butPresetsHeigth;
            but600.HeightRequest = butPresetsHeigth;
            but650.HeightRequest = butPresetsHeigth;
            but700.HeightRequest = butPresetsHeigth;
            but750.HeightRequest = butPresetsHeigth;
            but800.HeightRequest = butPresetsHeigth;
            but850.HeightRequest = butPresetsHeigth;
            but900.HeightRequest = butPresetsHeigth;
            but950.HeightRequest = butPresetsHeigth;
            but1000.HeightRequest = butPresetsHeigth;
        }
    }
}