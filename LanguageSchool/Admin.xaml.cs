using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            CBPeople.ItemsSource = Base.mE.Client.ToList();
            CBPeople.SelectedValuePath = "ID";
            CBPeople.DisplayMemberPath = "People";

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

        private void TextBlock_Initialized_Cost_dop(object sender, EventArgs e)
        {
            if (i < ServiswList.Count)
            {
                TextBlock Price = (TextBlock)sender;
                Service S = ServiswList[i];
                Price.Text = Convert.ToInt32(S.Cost) + "";
                //  i++;
            }
        }
        private void TextBlock_Initialized_Cost(object sender, EventArgs e)
        {
            if (i < ServiswList.Count)
            {
                TextBlock Price = (TextBlock)sender;
                Service S = ServiswList[i];
                Price.Text = Convert.ToInt32(S.Cost)+"";
                //  i++;
            }
        }

        private void TextBlock_Initialized_Duration(object sender, EventArgs e)
        {
            if (i < ServiswList.Count)
            {
                TextBlock Duration = (TextBlock)sender;
                Service S = ServiswList[i];
                Duration.Text =Convert.ToString(S.DurationInSeconds/60 + " минут");

                //  i++;
            }
        }

        private void TextBlock_Initialized_Discount(object sender, EventArgs e)
        {
            if (i < ServiswList.Count)
            {
                TextBlock Disc = (TextBlock)sender;
                Service S = ServiswList[i];
                Disc.Text = Convert.ToString(S.Discount *100 + "%");
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
            TBRCost.Text = Convert.ToInt32(S1.Cost) + "";
            TBDurationInSeconds.Text = Convert.ToString(S1.DurationInSeconds / 60);
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
            MSP.Visibility = Visibility.Collapsed;
            BAdd.Visibility = Visibility.Collapsed;
            AddNote.Visibility = Visibility.Visible;
        }

        private void BAddNote_Click(object sender, RoutedEventArgs e)
        {
            Service S = new Service();
            S.Title = TBATitle.Text;
            S.Cost = Convert.ToInt32(TBACost.Text);
            S.DurationInSeconds = Convert.ToInt32(TBADurationInSeconds.Text);
            S.Discount = Convert.ToInt32(TBADiscount.Text);
            S.Description = TBADescription.Text;
            S.MainImagePath = TBARImage.Text;

            Base.mE.Service.Add(S);
            Base.mE.SaveChanges();
            MessageBox.Show("Запись добавлена");
        }

        private void BBackNote_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Admin());
            AddNote.Visibility = Visibility.Collapsed;
            MSP.Visibility = Visibility.Visible;
        }

        private void AddImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.ShowDialog();
            string path = OFD.FileName;
            TBARImage.Text = path;
        }

        private void BAddOrder_Click(object sender, RoutedEventArgs e)
        {
            MSP.Visibility = Visibility.Collapsed;
            AddOrder.Visibility = Visibility.Visible;

            Button BEdit = (Button)sender;
            int ind = Int32.Parse(BEdit.Uid);
            S1 = ServiswList[ind];
            TBAddOrderTitle.Text = Convert.ToString(S1.Title);
            TBAddOrderDuration.Text = Convert.ToString(S1.DurationInSeconds/60 + " минут");
        }
        private void BAddOrderBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Admin());
            AddOrder.Visibility = Visibility.Collapsed;
            MSP.Visibility = Visibility.Visible;
        }

        DateTime DT;
        private void TBTime_TextChanged(object sender, TextChangedEventArgs e)
        {
           
            {
                Regex r1 = new Regex("[0-1][0-9][0-5][0-9]");
                Regex r2 = new Regex("2[0-3]:[0-5][0-9]");
                /*string s = "";*/
                if ((r1.IsMatch(TBTime.Text) || r2.IsMatch(TBTime.Text)) && TBTime.Text.Length == 5)
                {
                    MessageBox.Show(TBTime.Text);
                    TimeSpan TS = TimeSpan.Parse(TBTime.Text);
                    DT = Convert.ToDateTime(DP.SelectedDate);
                    DT = DT.Add(TS);
                    if (DT > DateTime.Now)
                    {
                        MessageBox.Show(DT + "");
                    }
                    else
                    {
                        MessageBox.Show("Слишком поздно");
                        Zap.IsEnabled = false;
                    }
                }
                else
                {
                    if (TBTime.Text.Length >= 5)
                    {
                        MessageBox.Show("Время указано неверно");
                        Zap.IsEnabled = false;
                    }
                }
            }
        }

        private void Zap_Click(object sender, RoutedEventArgs e)
        {
            Service S = ServiswList[i];
            int indexCombo = (int)CBPeople.SelectedValue;

            ClientService obj = new ClientService()
            {
                ClientID = indexCombo,
                ServiceID = S.ID,
                StartTime = DT
            };
            Base.mE.ClientService.Add(obj);
            Base.mE.SaveChanges();
            MessageBox.Show("Запись добавлена");
        }
    }
}
