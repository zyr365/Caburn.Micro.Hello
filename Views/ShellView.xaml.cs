using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Caliburn.Micro.Hello
{
    /// <summary>
    /// ShellView.xaml 的交互逻辑
    /// </summary>
    public partial class ShellView : UserControl
    {
        public ShellView()
        {
            InitializeComponent();
        }

        private void DG_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            int colindex = -1;
            int rowindex = -1;

            //方法1
            //DataGridCellInfo info = new DataGridCellInfo(dg.Items[0], dg.Columns[2]);
            //方法2
            //foreach (DataGridCellInfo info in this.dgSourceData.SelectedCells)
            //{
            //    string str = ((TextBlock)info.Column.GetCellContent(info.Item)).Text;
            //    Console.WriteLine(str);
            //}
            //方案1
            //var info = this.dgSourceData.SelectedCells.FirstOrDefault();
            //var str = ((TextBlock)info.Column.GetCellContent(info.Item)).Text;
            //((TextBlock)info.Column.GetCellContent(info.Item)).Foreground = new SolidColorBrush(Colors.Red);
            //Console.WriteLine(str);

            //方案2
            colindex = this.dgSourceData.CurrentCell.Column.DisplayIndex;//获取选中单元格列号
            //rowindex = this.dgSourceData.SelectedIndex;//获取选中单元格行号
            for (int i = 0; i < ShellViewModel.StudentList.Count(); i++)
            {
                if (ShellViewModel.StudentList[i] == this.dgSourceData.CurrentItem)
                {
                    //MessageBox.Show("当前选择的行是：" + i.ToString());
                    rowindex = i;
                }
            }
            DataGridRow row = (DataGridRow)dgSourceData.ItemContainerGenerator.ContainerFromIndex(rowindex);//获取选中单元格所在行
            DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(row);//函数调用，获取行中所有单元格的集合
            DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(colindex);//锁定选中单元格（重点）
            if (cell != null)
            {
                TextBlock tb = cell.Content as TextBlock;
                Console.WriteLine(tb.Text);
                dgSourceData.ScrollIntoView(row, dgSourceData.Columns[colindex]);
                //cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(colindex);
                cell.Focus();
                cell.Background = new SolidColorBrush(Colors.Red);//OK!问题解决，选中单元格变色
                cell.Foreground = new SolidColorBrush(Colors.Yellow);
                cell.FontSize = 20;
            }
        }
        private void dgSourceData_BeginningEdit(object sender, DataGridCellEditEndingEventArgs e)
        {
           

        }
        /// <summary>
        /// 获取父可视对象中第一个指定类型的子可视对象
        /// </summary>
        /// <typeparam name="T">可视对象类型</typeparam>
        /// <param name="parent">父可视对象</param>
        /// <returns>第一个指定类型的子可视对象</returns>
        public static T GetVisualChild<T>(Visual parent) where T : Visual
        {
            T childContent = default(T);
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                childContent = v as T;
                if (childContent == null)
                {
                    childContent = GetVisualChild<T>(v);
                }
                if (childContent != null)
                { break; }
            }
            return childContent;
        }

        public void dgSourceData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show(1111.ToString());//SelectionMode="Extended" SelectionUnit="Cell" 模式下触发不了
        }
    }
}
