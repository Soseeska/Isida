﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using SQLite;

namespace isida
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Polzovatel : ContentPage
    {
        public Polzovatel()
        {
            InitializeComponent();
            Soglasie.Text = "Я, являясь дееспособным гражданином РФ, своей волей и в своем интересе в соответствии с нормативными правовыми актами Российской Федерации, регулирующими вопросы защиты персональных данных, подтверждаю свое согласие на обработку ООО «ИСИДА» (далее – Оператор), находящимся по адресу: г.Армавир, ул.Советской Армии, д.94, моих персональных данных, включающих фамилию, имя, отчество, контактные телефоны, адрес. Предоставляю Оператору право осуществлять все действия(операции) с персональными данными, включая сбор, систематизацию, накопление, хранение, обновление, изменение, использование, обезличивание, блокирование, уничтожение. Оператор вправе обрабатывать персональные данные посредством внесения их в электронную базу данных, включения в списки(реестры) и отчетные формы. Передача персональных данных иным лицам или иное их разглашение может осуществляться только с моего письменного согласия, а также без моего согласия в порядке и в случаях, предусмотренных законодательством РФ. Я оставляю за собой право отозвать свое согласие посредством составления соответствующего письменного документа, который может быть направлен мной в адрес Оператора по почте заказным письмом с уведомлением о вручении либо вручен лично под расписку представителю Оператора. В случае получения моего письменного заявления об отзыве настоящего согласия на обработку персональных данных Оператор обязан: а) прекратить их обработку в течение периода времени, необходимого для завершения взаиморасчетов по оплате оказанной мне до этого медицинской помощи; б) по истечении срока хранения моих персональных данных, предусмотренных законодательством РФ, уничтожить(стереть) все мои персональные данные из баз данных автоматизированной информационной системы Оператора, включая все копии на машинных носителях информации, без уведомления меня об этом. Настоящим даю свое согласие Оператору использовать мои персональные данные(номер телефона) с целью направления мне рассылок, уведомлений информационного рекламного характера. Настоящее согласие дано мной сроком на 25 лет.";
        }
        protected override void OnAppearing()
        {
            string info = Preferences.Get("info", "Введите данные!");
            user_info.Text = info;

            base.OnAppearing();
        }

        public void SendInfo(string user_label)
        {
            TovKorzina Tkorz = new TovKorzina();
            (this.Parent as TabbedPage).CurrentPage = (Parent as TabbedPage).Children[1];
            Tkorz.GetInfo(user_label);
        }


        private async void OnClick(object sender, EventArgs e)
        {
            if (((user_name.Text != null) && (user_name.Text !="") && (user_name.Text.Length > 10)) && ((user_phone.Text != null) && (user_phone.Text !="") && (user_phone.Text.Length > 4)))
            {
                string name = user_name.Text;
                string phone = user_phone.Text;
                user_name.Text = null;
                user_phone.Text = null;
                string user_label = name +" "+ phone;
                string value = "ФИО:\n" + name + "\n\nТелефон:\n" + phone;
                user_info.Text = value;

                
                Preferences.Set("info", value);

                SendInfo(user_label);
            }
            else
            {
                await DisplayAlert("Уведомление", "ВВЕДИТЕ ДАННЫЕ ПОЛЬЗОВАТЕЛЯ!", "OK");
            }

        }
    }

}