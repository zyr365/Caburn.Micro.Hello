using DevExpress.Xpf.Grid;
using PropertyChanged;
using SpeechLib;
using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using System.Xml;
using System.Xml.Linq;

namespace Caliburn.Micro.Hello
{
    [AddINotifyPropertyChangedInterface]
    public class MemorandumViewModel : Screen,IViewModel
    {
        public ObservableCollection<EvenType> EvenTypeList { get; set; } = new ObservableCollection<EvenType>();
        public ObservableCollection<MemorandumModel> MemorandumRealList { get; set; }
        public ObservableCollection<MemorandumModel> MemorandumShowList { get; set; }
        private string titleText;
        public string TitleText
        {
            get { return titleText; }
            set
            {
                titleText = value;
            }
        }
        public Color TitleColor { get; set; }
        public int SelectedIndex { get; set; }
        public bool IsCompleteStatus { get; set; }
        public bool SelectAll { get; set; }
        public string XmlDocPath { get; set; }

        public MemorandumModel SelectedItem { get; set; }
        public int SelectRow { get; set; }
        public string DataTimeContext { get; set; }
        private DispatcherTimer timer;
        //public System.Windows.Media.Brush RowColor { get; set; }
        public MemorandumViewModel()
        {
            DisplayName = "Memorandum";

            DataTimeContext = "2022/02/20 10:14";
            TitleText = "备忘录标题";
            TitleColor = Color.DimGray;

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMinutes(1);
            timer.Tick += timer1_Tick;
            timer.Start();

            foreach (EvenType evenType in Enum.GetValues(typeof(EvenType)))
            {
                EvenTypeList.Add(evenType);
            }
            MemorandumRealList = new ObservableCollection<MemorandumModel>();

            XmlDocPath = AppDomain.CurrentDomain.BaseDirectory + @"\RawData\Memorandum.xml";
            XmlDocReader();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (var memorandum in MemorandumRealList)
            {
                if(DateTime.Now >= memorandum.DateTime)
                {
                    SpeakAsync(memorandum.Title);
                }
            }
        }
            public void OnDeactivate()
        {
            SaveXmlDoc();
        }

        public void SaveXmlDoc()
        {
            //获取根节点对象
            XDocument document = new XDocument();
            XElement xmlRoot = new XElement("MemorandumModels");

            XElement memorandumModel;
            foreach (var memorandumReal in MemorandumRealList)
            {
                memorandumModel = new XElement($"MemorandumModel");
                memorandumModel.SetElementValue("Title", memorandumReal.Title);
                memorandumModel.SetElementValue("EvenType", memorandumReal.EvenType);
                memorandumModel.SetElementValue("DateTime", memorandumReal.DateTime);
                memorandumModel.SetElementValue("IsComplete", memorandumReal.IsComplete);
                xmlRoot.Add(memorandumModel);
            }
            xmlRoot.Save(XmlDocPath);
        }

        public void XmlDocReader()
        {
            //XmlDocument读取xml文件
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(XmlDocPath);
            //获取xml根节点
            XmlNode xmlRoot = xmlDoc.DocumentElement;
            if (xmlRoot == null)
                return;
         
            //读取所有的节点
            foreach (XmlNode node in xmlRoot.SelectNodes("MemorandumModel"))
            {
                MemorandumRealList.Add(new MemorandumModel()
                {
                    Title = node.SelectSingleNode("Title").InnerText,
                    EvenType = (EvenType)Enum.Parse(typeof(EvenType), node.SelectSingleNode("EvenType").InnerText),
                    DateTime = Convert.ToDateTime(node.SelectSingleNode("DateTime").InnerText),
                    IsComplete = Convert.ToBoolean(node.SelectSingleNode("IsComplete").InnerText)
                }); 
            }
            MemorandumShowList = new  ObservableCollection<MemorandumModel>(MemorandumRealList);
        }

        public void GridControl_SelectedItemChanged(object sender, SelectedItemChangedEventArgs e)
        {
            GridControl gd = sender as GridControl;
            SelectRow = gd.GetSelectedRowHandles()[0];//选中行的行号        
           //var a = gd.GetRow(SelectRow) as RowControl;
          // a.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 0, 0));
        }
        public void DeleteClick()
        {
            MemorandumRealList.Remove(SelectedItem);
            MemorandumShowList.Remove(SelectedItem);
        }

        public void Add()
        {
            MemorandumRealList.Add(new MemorandumModel()
            {
                Title = titleText,
                DateTime =DateTime.Parse(DataTimeContext),
                EvenType = EvenTypeList[SelectedIndex],
                IsComplete = IsCompleteStatus
            });
            MemorandumShowList.Add(new MemorandumModel()
            {
                Title = titleText,
                DateTime = DateTime.Parse(DataTimeContext),
                EvenType = EvenTypeList[SelectedIndex],
                IsComplete = IsCompleteStatus
            });
        }

        public void Modify()
        {
            MemorandumRealList[SelectRow] = new MemorandumModel()
            {
                Title = titleText,
                DateTime = DateTime.Parse(DataTimeContext),
                EvenType = EvenTypeList[SelectedIndex],
                IsComplete = IsCompleteStatus
            };
            MemorandumShowList[SelectRow] = new MemorandumModel()
            {
                Title = titleText,
                DateTime = DateTime.Parse(DataTimeContext),
                EvenType = EvenTypeList[SelectedIndex],
                IsComplete = IsCompleteStatus
            };
        }

        public void SearchClick()
        {
            SaveXmlDoc();
            if (SelectAll)
            {
                MemorandumShowList = new ObservableCollection<MemorandumModel>(MemorandumRealList);
                return;
            }
            MemorandumShowList = new ObservableCollection<MemorandumModel>(
                MemorandumRealList.Where(
                    t => t.EvenType == EvenTypeList[SelectedIndex]
                    ).Where(s => s.IsComplete == IsCompleteStatus
                    ).Where(p => p.Title == TitleText
                     ).Where(x => x.DateTime == DateTime.Parse(DataTimeContext)
                    ) .ToList() );
        }
        public void GotFocus()
        {
            TitleText = "";
            TitleColor = Color.Black;
        }
        public void LostFocus()
        {
            if (string.IsNullOrEmpty(TitleText))
            {
                TitleText = "备忘录标题";
                TitleColor = Color.DimGray;
            }
        }

        /// <summary>
        /// 微软语音识别
        /// </summary>
        /// <param name="content">提示内容</param>
        public static void SpeakAsync(string content)
        {
            try
            {
                Task.Run(() =>
                {
                    SpVoice voice = new SpVoice();
                    voice.Rate = 1;//速率[-10,10]
                    voice.Volume = 10;//音量[0,100]
                    voice.Voice = voice.GetVoices().Item(0);//语音库
                    voice.Speak(content);
                });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
