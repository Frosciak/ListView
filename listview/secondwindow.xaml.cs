using System.Windows;

namespace listview;

public partial class secondwindow : Window
{
    private MainWindow.Contact u;
    public secondwindow(ref MainWindow.Contact contact)
    {
        InitializeComponent();
        editername.Text = contact.Name;
        editermail.Text = contact.Mail;
        editernumber.Text = contact.Number;
        u = contact;
    }


    private void EditButton_OnClick(object sender, RoutedEventArgs e)
    {
        u.Name = editername.Text;
        u.Number = editernumber.Text;
        u.Mail = editermail.Text;
        Close();
    }
}