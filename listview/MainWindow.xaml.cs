using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.DirectoryServices.ActiveDirectory;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace listview;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    
    public MainWindow()
    {
        InitializeComponent();
        
        digitus.groups.Add("Discord");
        digitus.groups.Add("TeamSpeak");
        digitus.groups.Add("Skype");
        
        digitus.items.Add(new Contact
            { Name = "Michał", Number = "420690000", Mail = "lachim05@gmail.com", GroupName = digitus.groups[1]});
        digitus.items.Add(new Contact
            { Name = "Gosia", Number = "997999998", Mail = "kenaj6969@gmail.com", GroupName = digitus.groups[1]});
        digitus.items.Add(new Contact
            { Name = "Franciszek", Number = "444666090", Mail = "keszicnarf420@gmail.com", GroupName = digitus.groups[1]});
        lvUsers.ItemsSource = digitus.items;
        
        CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvUsers.ItemsSource);
        PropertyGroupDescription groupDescription = new PropertyGroupDescription("GroupName");
        view.GroupDescriptions.Add(groupDescription);

        lvUsers.Items.Refresh();
    }

    
    private void NewContact_OnClick(object sender, RoutedEventArgs e)
    {
      
        var contact = new Contact();


        contact.Name = TextBoxName.Text;
        contact.Number = TextBoxNumber.Text;
        contact.Mail = TextBoxMail.Text;
        contact.GroupName = Odtwarzacz.SelectedItem.ToString();
        

        digitus.items.Add(contact);
        
        Refresh();
        
        TabControl.SelectedIndex = 1;
    }

    void Refresh()
    {
        lvUsers.Items.Refresh();
        ICollectionView view = CollectionViewSource.GetDefaultView(lvUsers.ItemsSource);
        view.Refresh();
    }
    
    
    public class Contact
    {
        public string Name { get; set; }

        public string Number { get; set; }

        public string Mail { get; set; }
        
        public string GroupName { get; set; }
    }

    private void MenuItem_OnClick(object sender, RoutedEventArgs e)
    {
        Contact contact = (Contact)lvUsers.SelectedItems[0];
        digitus.items.Remove(contact);
        Refresh();
    }


    private void Edit_OnClick(object sender, RoutedEventArgs e)
    {
        //TabControl.SelectedIndex = 2;
        Contact contact = (Contact)lvUsers.SelectedItems[0];
        secondwindow ue = new secondwindow(ref contact);
        ue.ShowDialog();
    }

    

    private void Refresh_OnClick(object sender, RoutedEventArgs e)
    {
        Refresh();
        TabControl.SelectedIndex = 1;
    }
}
//TODO: USUNIECIE SEXTYPA I ZROBIENIE FAJNYCH GRUP

