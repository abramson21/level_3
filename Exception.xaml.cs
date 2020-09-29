using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace eMailSender
{
    /// <summary>
    /// Логика взаимодействия для Exception.xaml
    /// </summary>
    public partial class Exception : Window
    {
        private string newError;

        public string NewError
        {
            get
            {
                return newError;
            }
            set
            {
                newError = value;
            }
        }

        public Exception(string newError)
        {
            this.newError = newError;
            InitializeComponent();
        }

        

        public void exError()
        {
            exception_value.Content = newError;
        }
    }
}
