using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.Objects;
using System.Collections;
using System.ComponentModel;

namespace new_ticket_master
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TicketMastersEntities infoContext;
        private User objecttoshow;
        IQueryable<User> getdata;
        public MainWindow()
        {
            InitializeComponent();
            infoContext = new TicketMastersEntities();   
        }

        private void adduserbtn_Click(object sender, RoutedEventArgs e)
        {
          
            addUser(infoContext);
        }

        private void editUserbtn_Click(object sender, RoutedEventArgs e)
        {
           
            editUser(infoContext);
        }

        private void deleteUserbtn_Click(object sender, RoutedEventArgs e)
        {
            deleteUser(infoContext);
        }

        private void viewUserDetailbtn_Click(object sender, RoutedEventArgs e)
        {
            ShowUserDetail show = new ShowUserDetail();
            show.uId.Text = useridLbl.Text;

            show.ShowDialog();

        }

      

        private void addUser(TicketMastersEntities context)
        {
            AddUserWindow p = new AddUserWindow();
            if (p.ShowDialog().Value)
            {
                User addNewUser = new User
                {

                    FirstName = p.firstNameTxt.Text,
                    LastName = p.lastNameTxt.Text,
                    StreetAddress = p.streetAddressTxt.Text,
                    City = p.cityTxt.Text,
                    State = p.stateTxt.Text,
                    ZipCode = p.zipCodeTxt.Text,
                    PhoneNumber = p.phoneNumTxt.Text

                };
                context.Users.AddObject(addNewUser);
                saveUser();

                //fix still shows when data not saving
                
                useridLbl.Text = addNewUser.UserID.ToString();
                firstLbl.Text = addNewUser.FirstName;
                lastLbl.Text = addNewUser.LastName;
                streetLbl.Text = addNewUser.StreetAddress;
                cityLbl.Text = addNewUser.City;
                stateLbl.Text = addNewUser.State;
                zipLbl.Text = addNewUser.ZipCode;
                phoneLbl.Text = addNewUser.PhoneNumber;
               
            }

        }
        private void editUser(TicketMastersEntities context)
        {
            int idInfo = int.Parse(useridLbl.Text);
            User u = context.Users.First(userIdInEntity => userIdInEntity.UserID == idInfo);
           
            AddUserWindow p = new AddUserWindow();
            p.firstNameTxt.Text = u.FirstName;
            p.lastNameTxt.Text = u.LastName;
            p.stateTxt.Text = u.State;
            p.streetAddressTxt.Text = u.StreetAddress;
            p.cityTxt.Text = u.City;
            p.zipCodeTxt.Text = u.ZipCode;
            p.phoneNumTxt.Text = u.PhoneNumber;
            if (p.ShowDialog().Value)
            {
                //change this so it binds directly
                u.FirstName = firstLbl.Text = p.firstNameTxt.Text;
                u.LastName = lastLbl.Text = p.lastNameTxt.Text;
                u.State = stateLbl.Text = p.stateTxt.Text;
                u.StreetAddress = streetLbl.Text = p.streetAddressTxt.Text;
                u.City = cityLbl.Text = p.cityTxt.Text;
                u.ZipCode = zipLbl.Text = p.zipCodeTxt.Text;
                u.PhoneNumber = phoneLbl.Text = p.phoneNumTxt.Text;
                
            }
           saveUser();
        }
      

        private void deleteUser(TicketMastersEntities context)
        {
          //add code to delete other tables later
            int idInfo = int.Parse(useridLbl.Text);

            var deleteDerUser = from user in context.Users
                                where user.UserID == idInfo
                                select user;

            foreach (var userIns in deleteDerUser)
            {
                context.Users.DeleteObject(userIns);
            }
            saveUser();
        }

        private void saveUser()
        {
            try
            {

                this.infoContext.SaveChanges();
            }
            catch (OptimisticConcurrencyException)
            {
                this.infoContext.Refresh(RefreshMode.ClientWins, infoContext.Users);
                this.infoContext.SaveChanges();
            }
            catch (UpdateException uEx)
            {
                this.infoContext.Refresh(RefreshMode.StoreWins, infoContext.Users);
                MessageBox.Show(uEx.InnerException.Message, "Error Saving changes");
            }
            catch (Exception ex)
            {
                this.infoContext.Refresh(RefreshMode.StoreWins, infoContext.Users);
                MessageBox.Show(ex.Message);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            About getinfo = new About();

            getinfo.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            //listBox1.Visibility = Visibility.Visible;
            string id = textBox1.Text;
            getdata = from user_Id in infoContext.Users
                      where user_Id.FirstName.StartsWith(id) 
                      select user_Id;
                       
            //doing it this way will pass data as null because the user object expects all of its data not part of it
            //select new { user_Id.FirstName, user_Id.LastName, user_Id.UserID };

            listBox1.ItemsSource = getdata;
           
            
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // in order to pass data, it must be all data coming from a iqueryable<object/parameter>. if i just do it from a var ... = query, it wont work since that is 
            // considered as read only. once it gets it/displays it, it dumps it from memory 
            objecttoshow = listBox1.SelectedItem as User;

            viewUserDetailbtn.IsEnabled = true;

            displayData(objecttoshow);
        }

        private void displayData(User objecttoshow)
        {
            try
            {

                useridLbl.Text = objecttoshow.UserID.ToString();
                firstLbl.Text = objecttoshow.FirstName;
                lastLbl.Text = objecttoshow.LastName;
                streetLbl.Text = objecttoshow.StreetAddress;
                phoneLbl.Text = objecttoshow.PhoneNumber;
                cityLbl.Text = objecttoshow.City;
                zipLbl.Text = objecttoshow.ZipCode;
                stateLbl.Text = objecttoshow.State;
            }
            catch (NullReferenceException)
            {
                // switch this to
                MessageBox.Show("no such user exists/n Search by first name only");
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Form1 dr = new Form1();
            dr.ShowDialog();
        }
      
        //-------------------------------------old depreciated code--------------------------------------------

        /* private void findUserbtn_Click(object sender, RoutedEventArgs e)
           {
               fetchUserData(infoContext);
               viewUserDetailbtn.IsEnabled = true;
           }
           * 
           *   private void fetchUserData(TicketMastersEntities context)
           {
               int idInfo = int.Parse(useridLbl.Text);

               var getSpecificUser = from user in context.Users
                                   where user.UserID == idInfo
                                   select user;

               foreach (var userIns in getSpecificUser)
               {
                    useridLbl.Text = userIns.UserID.ToString();
                   firstLbl.Text = userIns.FirstName;
                   lastLbl.Text = userIns.LastName;
                   streetLbl.Text = userIns.StreetAddress;
                   stateLbl.Text = userIns.State;
                   cityLbl.Text = userIns.City;
                   zipLbl.Text = userIns.ZipCode;
                   phoneLbl.Text = userIns.PhoneNumber;
               }
           }*/

        
    }
}
