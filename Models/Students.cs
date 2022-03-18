using System;
using System.ComponentModel;
using System.Text;
using System.Windows;
using PropertyChanged;

namespace Caliburn.Micro.Hello
{
    [AddINotifyPropertyChangedInterface]
    public class Students : PropertyChangedBase
    {
        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
            }
        }
        public string Name { get; set; }

        private int age;
        public int Age 
        {
            get { return age; }
            set
            {
                age = value;
                if(age < 16 || age > 21 )
                {
                    AgeValidate = true;
                }
                else
                {
                    AgeValidate = false;
                }
            }
        }

        public bool AgeValidate { get; set; }
        public override string ToString()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine($"[Id]  = [{Id}]");
            report.AppendLine($"[Name]  = [{Name}]");
            report.AppendLine($"[Age]  = [{Age}]");
            report.AppendLine($"[AgeValidate]  = [{AgeValidate}]");
            return report.ToString();
        }
    }
    //public class Students : INotifyPropertyChanged
    //{
    //    private int id;
    //    public int Id
    //    {
    //        get { return id; }
    //        set
    //        {
    //            id = value;
    //            OnPropertyChanged("Id");
    //        }
    //    }
    //    private string name;
    //    public string Name
    //    {
    //        get { return name; }
    //        set
    //        {
    //            name = value;
    //            OnPropertyChanged("Name");
    //        }
    //    }

    //    private int age;
    //    public int Age
    //    {
    //        get { return age; }
    //        set
    //        {
    //            age = value;
    //            OnPropertyChanged("Age");
    //        }
    //    }

    //    public event PropertyChangedEventHandler PropertyChanged;
    //    private void OnPropertyChanged(string propertyName)
    //    {
    //        PropertyChangedEventHandler handler = this.PropertyChanged;
    //        if (handler != null)
    //        {
    //            handler(this, new PropertyChangedEventArgs(propertyName));
    //        }
    //    }
    //}

}