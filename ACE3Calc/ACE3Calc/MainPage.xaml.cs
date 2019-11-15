using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Sockets;
using System.Net;

namespace ACE3Calc
{
    public partial class MainPage : MasterDetailPage
    {
        NavigationPage wogpage; //Переменная, хранящая страницу
        NavigationPage rbcpage; //Переменная, хранящая страницу
        NavigationPage aboutpage; //Переменная, хранящая страницу

        public MainPage()
        {
            InitializeComponent();
            NewVersionMessage(); //Функция уведомления о новой версии

            img1.Source = ImageSource.FromResource("ACE3Calc.img.acelogobig.png"); //Картинка для меню

            wogpage = new NavigationPage(new WOG3()) //Создаем страницу и записываем ее в переменную при инициализации
            {
                BarBackgroundColor = Color.DarkCyan,
                BarTextColor = Color.White
            };

            rbcpage = new NavigationPage(new RBC()) //Создаем страницу и записываем ее в переменную при инициализации
            {
                BarBackgroundColor = Color.DarkRed,
                BarTextColor = Color.White
            };

            aboutpage = new NavigationPage(new About()) //Создаем страницу и записываем ее в переменную при инициализации
            {
                BarBackgroundColor = Color.FromHex("333333"),
                BarTextColor = Color.White
            };

            Detail = aboutpage;
            IsPresented = false;
        }

        //Кнопки в мастер-меню
        private void ButWOGPage_cliked(object senders, EventArgs e) //Открываем нужную страницу
        {
            Detail = wogpage;
            IsPresented = false;
        }
        private void ButWRBCPage_cliked(object senders, EventArgs e) //Открываем нужную страницу
        {
            Detail = rbcpage;
            IsPresented = false;
        }
        private void ButAboutPage_cliked(object senders, EventArgs e) //Открываем нужную страницу
        {
            Detail = aboutpage;
            IsPresented = false;
        }


        public void NewVersionMessage() //Функция уведомления о новой версии
        {
            if (AppSettings.CheckNewVersion() == true)
            {
                DisplayAlert("Вышла новая версия!", $"Текущая версия: {AppSettings.currrentversion}. Доступная версия для установки: {AppSettings.lastverison}", "ОK");
            }
        }


    }
}
