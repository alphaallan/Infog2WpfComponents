using System.Collections;
using System.Windows;
using System.Windows.Controls;

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
