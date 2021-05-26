using Microsoft.Win32;
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



        Service S1;
        private void BReg_Click(object sender, RoutedEventArgs e)
        {
            Button BEdit = (Button)sender;
            int ind = Int32.Parse(BEdit.Uid);
            S1 = ServiswList[ind];
            MSP.Visibility = Visibility.Collapsed;
            SPRed.Visibility = Visibility.Visible;

            TBlRId.Text = Convert.ToString(S1.ID);
            TBRTitle.Text = S1.Title;
            TBRCost.Text = Convert.ToString(S1.Cost);
            TBDurationInSeconds.Text = Convert.ToString(S1.DurationInSeconds);
            TBDiscount.Text = Convert.ToString(S1.Discount);
            TBDescription.Text = Convert.ToString(S1.Description);
            TBRImage.Text = Convert.ToString(S1.MainImagePath);

        }

        private void BABack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Admin());
            SPRed.Visibility = Visibility.Collapsed;
            MSP.Visibility = Visibility.Visible;
        }

        private void BRReg_Click(object sender, RoutedEventArgs e)
        {
            S1.Title = TBRTitle.Text;
            S1.Cost = Convert.ToDecimal(TBRCost.Text);
            S1.DurationInSeconds = Convert.ToInt32(TBDurationInSeconds.Text);
            S1.Discount = Convert.ToInt32(TBDiscount.Text);
            S1.Description = TBDescription.Text;
            S1.MainImagePath = TBRImage.Text;
            Base.mE.SaveChanges();
            MessageBox.Show("Запись добавлена");
        }

        private void RImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.ShowDialog();
            string path = OFD.FileName;
            TBRImage.Text = path;
        }

        private void BDel_Click(object sender, RoutedEventArgs e)
        {
            Button BtnDel = (Button)sender;
            int ind = Convert.ToInt32(BtnDel.Uid);
            Service S = ServiswList[ind];
            Base.mE.Service.Remove(S);
            MessageBox.Show("Удалена");
            Base.mE.SaveChanges();
            NavigationService.Navigate(new Admin());
        }

        private void BAdd_Click(object sender, RoutedEventArgs e)
        {
            Button BtnAdd = (Button)sender;
            int ind = Int32.Parse(BtnAdd.Uid);
            S1 = ServiswList[ind];
            BAdd.Visibility = Visibility.Collapsed;
            AddNote.Visibility = Visibility.Visible;

            S1.Title = TBATitle.Text;
            S1.Cost = Convert.ToInt32(TBACost.Text);
            // и тд
            Base.mE.Service.Add(S1);
            Base.mE.SaveChanges();
        }


    }
}
