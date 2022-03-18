using PropertyChanged;
using System;
using System.Collections.Specialized;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace Caliburn.Micro.Hello
{
    [AddINotifyPropertyChangedInterface]
    public class ShellViewModel : Screen, IViewModel
    {
        public static int RowIndex = -1;
        string name;
        private int age = 20;
        public System.Windows.Controls.DataGrid dGrid { get; set; }
        public System.Windows.Controls.ContextMenu menu1 { get; set; }
        public string BrowseDataSavePath { get; set; } = @"D:\Temporary";
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyOfPropertyChange(() => Name);
                NotifyOfPropertyChange(() => CanSayHello);
            }
        }
        public Students SelectedItems { get; set; }
        private static ItemsChangeObservableCollection<Students> studentList;
        public static ItemsChangeObservableCollection<Students> StudentList
        {
            get
            {
                return studentList;
            }
            set
            {
                if (studentList != value)
                {
                    studentList = value;
                    //OnPropertyChanged("StudentList");
                    //NotifyOfPropertyChange(() => StudentList);
                }
                //MessageBox.Show(value.ToString());
            }
        }
        public bool CanSayHello
        {
            get { return !string.IsNullOrWhiteSpace(Name); }
        }

        public void SayHello()
        {
            //IoC.BuildUp(new SimpleContainerViewModel());
            //从ioc中获取实例方法1
            //object simpleContainer = IoC.Get<SimpleContainerViewModel>();//没有key
            object simpleContainer = IoC.Get<IViewModel>("SimpleContainerViewModel");//有key
            SimpleContainerViewModel SimpleContainerViewModel = (SimpleContainerViewModel)simpleContainer;
            SimpleContainerViewModel.ClickCtr();

            //从ioc中获取实例方法2
            //var viewModel = IoC.GetAll<IViewModel>().FirstOrDefault(vm => vm.GetType() == typeof(SimpleContainerViewModel));
            //SimpleContainerViewModel SimpleContainerViewModel = (SimpleContainerViewModel)viewModel;
            //SimpleContainerViewModel.ClickCtr();

            //打开一个新窗体
            IWindowManager windowManager = IoC.Get<IWindowManager>();
            Execute.OnUIThreadAsync(() =>
            {
                Thread.Sleep(2500);
                windowManager.ShowDialog(SimpleContainerViewModel);
            });
          
            //获取窗体修改后的值
            //MessageBox.Show(SimpleContainerViewModel.TextContent);
            //ShowNewWindow();
        }
        public ShellViewModel()
        {
            DisplayName = "Shell";

            StudentList = new ItemsChangeObservableCollection<Students>();
            StudentList.CollectionChanged += new NotifyCollectionChangedEventHandler(StudentList_OnCollectionChanged);
            StudentList.Add(new Students() { Name = "zhangsan", Age = 15, Id = 1 });
            StudentList.Add(new Students() { Name = "wanger", Age = 16, Id = 2 });
            StudentList.Add(new Students() { Name = "xiaoli", Age = 17, Id = 3 });
            
            //this.StudentList.CollectionChanged += StudentList_OnCollectionChanged;
        }
        public void StudentList_OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            //var sss = sender as ItemsChangeObservableCollection<Students>;
            //foreach (var s in sss)
            //{
            //    MessageBox.Show(s.ToString());
            //}
          Console.WriteLine("当前触发的事件是："+ e.Action.ToString());
            //for (int i = 0; i < StudentList.Count(); i++)
            //{
            //    if (StudentList[i] == SelectedItems)
            //    {
            //        //MessageBox.Show("当前选择的行是：" + i.ToString());
            //        RowIndex = i;
            //        return;
            //    }
            //}
            //RowIndex = -1;
        }
        /// <summary>
        /// SelectedItemChanged事件，获取当前行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //public void GridControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    //GridControl gc = sender as GridControl;
        //    //var a = gc.GetSelectedRowHandles();
        //    //RowIndex = a[0];
        //    for (int i = 0; i < this.StudentList.Count(); i++)
        //    {
        //        if (this.StudentList[i] == SelectedItems)
        //        {
        //            RowIndex = i;
        //            return;
        //        }
        //    }
        //}
        public void RemoveData()
        {
            StudentList.RemoveAt(0);
        }
        public void AddData()
        {
            StudentList.Add(new Students() { Name = "xiaoli", Age = age++, Id = 3 });
        }
        /// <summary>
        /// 显示一个新窗体
        /// </summary>
        public void ShowNewWindow()
        {
            SimpleContainerViewModel simpleContainerViewModel = new SimpleContainerViewModel();
            IWindowManager windowManager = IoC.Get<IWindowManager>();
            windowManager.ShowDialog(simpleContainerViewModel);
        }

        #region
        /// <summary>
        /// 右键删除数据
        /// </summary>
        /// <param name="sender">对象</param>
        /// <param name="e">事件</param>
        public void datagrid_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            dGrid = (System.Windows.Controls.DataGrid)sender;
            menu1 = new System.Windows.Controls.ContextMenu();
            System.Windows.Controls.MenuItem menuitemFunc1 = new System.Windows.Controls.MenuItem();
            System.Windows.Controls.MenuItem menuitemFunc2 = new System.Windows.Controls.MenuItem();
            System.Windows.Controls.MenuItem menuitemFunc3 = new System.Windows.Controls.MenuItem();
            menuitemFunc1.Header = "移动到此位置";
            menuitemFunc2.Header = "删除此行信息";
            menuitemFunc3.Header = "导出数据";
            menuitemFunc1.Click += MoveToPostion_Click;
            menuitemFunc2.Click += DeleteRow_Click;
            menuitemFunc3.Click += ExportData_Click;
            menu1.Items.Add(menuitemFunc1);
            menu1.Items.Add(menuitemFunc2);
            menu1.Items.Add(menuitemFunc3);
            menu1.StaysOpen = true;
        }
        /// <summary>
        /// 点击删除后的事件
        /// </summary>
        /// <param name="sender">对象</param>
        /// <param name="e">事件</param>
        public void DeleteRow_Click(object sender, RoutedEventArgs e)
        {
            StudentList.RemoveAt(dGrid.SelectedIndex);
        }
        /// <summary>
        /// 移动到当前选定的位置
        /// </summary>
        /// <param name="sender">对象</param>
        /// <param name="e">事件</param>
        public void MoveToPostion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //此方法省略；
                System.Windows.MessageBox.Show("机台已成功移动到当前坐标");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        /// <summary>
        /// 导出datagrid表格中的数据
        /// </summary>
        /// <param name="sender">对象</param>
        /// <param name="e">事件</param>
        public void ExportData_Click(object sender, RoutedEventArgs e)
        {
            BrowseSavePath();
        }
        /// <summary>
        /// 导出地址浏览
        /// </summary>
        public void BrowseSavePath()
        {
            FolderBrowserDialog browserDialog = new FolderBrowserDialog();
            browserDialog.Description = "请选择路径";
            try
            {
                if (browserDialog.ShowDialog() == DialogResult.OK)
                {
                    if (string.IsNullOrEmpty(browserDialog.SelectedPath))
                    {
                        System.Windows.MessageBox.Show("文件夹路径不能为空");
                        return;
                    }
                    BrowseDataSavePath = browserDialog.SelectedPath;
                    DataExport(BrowseDataSavePath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void DataExport(string path)
        {
            //此方法省略；
            System.Windows.MessageBox.Show("数据已成功导出");
        }
        #endregion

    }
}