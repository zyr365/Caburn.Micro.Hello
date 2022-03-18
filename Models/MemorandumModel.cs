using DevExpress.Xpo;
using System;

namespace Caliburn.Micro.Hello
{
    public class MemorandumModel 
    {
        public string Title { get; set; }
        public EvenType EvenType { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsComplete { get; set; }
    }

}