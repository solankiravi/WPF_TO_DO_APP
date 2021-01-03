using System;
using System.Windows;
using System.Windows.Controls;


namespace XamlDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string CustomText
        {
            get { return (string)GetValue(CustomTextProperty); }
            set { SetValue(CustomTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CustomText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CustomTextProperty =
            DependencyProperty.Register("CustomText", typeof(string), typeof(TextBlock), new PropertyMetadata("Item 1",new PropertyChangedCallback(changed_custom_text)),
                new ValidateValueCallback(validate_custom_text)
                
                );

        private static bool validate_custom_text(object value)
        {
            //TODO
            return true;
        }

        private static void changed_custom_text(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            string oldval = e.OldValue.ToString();
            string newval = e.NewValue.ToString();
            MessageBox.Show("Value changed");
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void addbtn_Click(object sender, RoutedEventArgs e)
        {
            if (itemlist.Items.Contains(itemnametxt.Text))
            {
                MessageBox.Show("Please choose a different Task name.","Duplicate Task",MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }
            itemlist.Items.Add(itemtxtbox.Text);
        }

        private void itemlist_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (completeditemlist.Items.Contains(itemlist.SelectedItem))
                return;

            
            completeditemlist.Items.Add(itemlist.SelectedItem +" - on"+ DateTime.Now.ToString());
            itemlist.Items.Remove(itemlist.SelectedItem);
        }
        private void ContextMenu_Click(object sender, RoutedEventArgs e)
        {
            MenuItem item = e.OriginalSource as MenuItem;
            string skinDictPath = item.Tag as string;
            Uri skinDictUri = new Uri(skinDictPath, UriKind.Relative);
            App app = Application.Current as App;

            app.ApplySkin(skinDictUri);
        }

       
    }
}