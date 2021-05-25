using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LanguageSchool
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        List<Service> ServiswList = Base.mE.Service.ToList();
        public Admin()
        {
            InitializeComponent();
            DGServises.ItemsSource = ServiswList;
        }

        int i = -1;

        private void MediaElement_Initialized(object sender, EventArgs e)
        {
            if (i < ServiswList.Count)
            {
                i++;
                MediaElement ME = (MediaElement)sender;
                Service S = ServiswList[i];
                Uri U = new Uri(S.MainImagePath, UriKind.RelativeOrAbsolute);
                ME.Source = U;
                //   i++;
            }
        }

        private void TextBlock_Initialized(object sender, EventArgs e)
        {
            if (i < ServiswList.Count)
            {
                TextBlock TB = (TextBlock)sender;
                Service S = ServiswList[i];
                TB.Text = S.Title;
                //  i++;
            }

        }

        

        private void StackPanel_Initialized(object sender, EventArgs e)
        {
            if (i < ServiswList.Count)
            {
                StackPanel SP = (StackPanel)sender;
                Service S = ServiswList[i];
                if (S.Discount != 0)
                {
                    SP.Background = new SolidColorBrush(Color.FromRgb(231, 250, 191));
                }
            }

        }

        //Инициализация кнопок
        private void Button_Initialized_Red(object sender, EventArgs e)
        {
            Button BtnRed = (Button)sender;
            if (BtnRed != null)
            {
                BtnRed.Uid = Convert.ToString(i);
            }

        }
        private void Button_Initialized_Del(object sender, EventArgs e)
        {
            Button BtnDel = (Button)sender;
            if (BtnDel != null)
            {
                BtnDel.Uid = Convert.ToString(i);
            }
        }
        private void Button_Initialized_Add(object sender, EventArgs e)
        {
            Button BtnAdd = (Button)sender;
            if (BtnAdd != null)
            {
                BtnAdd.Uid = Convert.ToString(i);
            }
        }


        //Проверка кнопок
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button BtnRed = (Button)sender;
            int ind = Convert.ToInt32(BtnRed.Uid);
            Service S = ServiswList[ind];
            MessageBox.Show(S.Title);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button BtnRed = (Button)sender;
            int ind = Convert.ToInt32(BtnRed.Uid);
            Service S = ServiswList[ind];
            MessageBox.Show(S.Title);
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Button BtnRed = (Button)sender;
            int ind = Convert.ToInt32(BtnRed.Uid);
            Service S = ServiswList[ind];
            MessageBox.Show(S.Title);
        }

        private void TextBlock_Initialized_Cost(object sender, EventArgs e)
        {
            if (i < ServiswList.Count)
            {
                TextBlock Price = (TextBlock)sender;
                Service S = ServiswList[i];
                Price.Text = Convert.ToString(S.Cost);
                //  i++;
            }
        }

        private void TextBlock_Initialized_Duration(object sender, EventArgs e)
        {
            if (i < ServiswList.Count)
            {
                TextBlock Duration = (TextBlock)sender;
                Service S = ServiswList[i];
                Duration.Text =Convert.ToString(S.DurationInSeconds);
                //  i++;
            }
        }

        private void TextBlock_Initialized_Discount(object sender, EventArgs e)
        {
            if (i < ServiswList.Count)
            {
                TextBlock Disc = (TextBlock)sender;
                Service S = ServiswList[i];
                Disc.Text = Convert.ToString(S.Discount);
                //  i++;
            }

        }
    }
}
