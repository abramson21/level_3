using eMailSender.Library.Users;
using System;
using System.Net;
using System.Net.Mail;
using System.Windows;
using System.Windows.Controls;

namespace eMailSender
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ComboSmtp.Items.Add("25").ToString();
            ComboSmtp.Items.Add("465").ToString();
            ComboSmtp.Items.Add("2525").ToString();
            ComboSmtp.Items.Add("587").ToString();
            BSendEmail.IsEnabled = false;
            

        }

        private void activeButton()
        {
            if (LoginName.Text != "" && ToName.Text != "" && Password != null)
            {
                BSendEmail.IsEnabled = true;
            }
            else BSendEmail.IsEnabled = false;
        }
        

        private void ButtonSendEmail(object sender, RoutedEventArgs e)
        {
            
                
                Library.StaticName.GetFromEmail = LoginName.Text;
                Library.StaticName.GeToEmail = ToName.Text;

                object newSmtp = ComboSmtp.SelectedItem;
                Library.StaticName.Smtp = Convert.ToInt32(newSmtp.ToString());
                //Пользователь, кому ДОСТАВЛЕНО сообщение

                var fromUser = new BaseUser(/*"abramson21@yandex.ru"*//*Library.StaticName.GeToEmail*/Library.StaticName.GetFromEmail, "Andrey Nikolaev"); //new MailAddress(StaticName.GeToEmail, "Andrey Nikolaev");

                //Пользователь, который отправляет
                var toUser = new BaseUser(/*"abramson21@mail.ru"*/Library.StaticName.GeToEmail, "Andrey Nikolaev");

                MailAddress to = toUser.GetInfoUser();
                MailAddress from = fromUser.GetInfoUser();

                //Создаем переменную, хранящую данные о пользователях.
                var message = new MailMessage(from, to);

                //Добавляем заголовок письма
                message.Subject = "Тема письма... " + DateTime.Now;

                //Добавляем тело сообщения
                message.Body = "Ещё отправляем электронный чек — вместе с другими чеками он также хранится в разделе «Мои заказы» в вашем личном кабинете.";

                //Smtp клиент ОТПРАВИТЕЛЯ
                var client = new SmtpClient("smtp.yandex.ru", Library.StaticName.Smtp);

                //????? 
                client.EnableSsl = true;

                client.Credentials = new NetworkCredential
                {
                    UserName = Library.StaticName.GetFromEmail,
                    SecurePassword = Password.SecurePassword
                };

                client.Send(message);
          
                //new Exception("Ошибка в данных!");
                //BSendEmail.IsEnabled = true;
            

        }

        private void bAddNewUser_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem itemsUsers = new ListBoxItem();
            itemsUsers.Content = NewUserItem.Text;
            usersItems.Items.Add(itemsUsers);

        }

        private void usersItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            //LoginName.Text = ListBoxItem.IsMouseOverProperty()
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newItem = ((ListBoxItem)usersItems.SelectedItem).Content.ToString();
                if (newItem != null)
                {
                    Library.StaticName.GeToEmail = newItem;
                    ToName.Text = newItem;
                }

            }
            catch
            {
                Exception newError = new Exception("Вы ничего не выбрали!");
                newError.exError();
                newError.Show();
            }
            // numberListBox.GetItemText(numberListBox.SelectedItem);
            //(usersItems.SelectedItem);
        }

        private void LoginName_TextChanged(object sender, TextChangedEventArgs e)
        {
            activeButton();
        }

        private void ToName_TextChanged(object sender, TextChangedEventArgs e)
        {
            activeButton();
        }
    }
}
