using System;
using System.Collections;
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

namespace InfoG2WpfControls
{
    public class MyDataGrid : DataGrid
    {
        static MyDataGrid()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyDataGrid), new FrameworkPropertyMetadata(typeof(MyDataGrid)));
        }

        public MyDataGrid()
        {
            this.SelectionChanged += MyDataGrid_SelectionChanged;
        }

        void MyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.SelectedItemsList = this.SelectedItems;
        }

        /// <summary>
        /// Propriedade para uso com MVVM em caso de seleção de multiplas linhas
        /// </summary>
        public IList SelectedItemsList
        {
            get { return (IList)GetValue(SelectedItemsListProperty); }
            set { SetValue(SelectedItemsListProperty, value); }
        }

        public static readonly DependencyProperty SelectedItemsListProperty =
                DependencyProperty.Register("SelectedItemsList", typeof(IList), typeof(MyDataGrid), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
    }
}
