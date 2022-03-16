using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class Student : INotifyPropertyChanged
    {
        private Guid idValue = Guid.NewGuid();
        private string studentGradeValue = String.Empty;
        private string studentCclassValue = String.Empty;
        private string studentNoValue = String.Empty;
        private string studentNameValue = String.Empty;
        private string studentScoreValue = String.Empty;

        public Student(string grade, string cclass, string no, string name, string score)
        {
            Grade = grade;
            Cclass = cclass;
            No = no;
            Name = name;
            Score = score;
        }

        public Student()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            Console.WriteLine("바뀜");
            Console.WriteLine(propertyName.ToString());
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Guid ID
        {
            get
            {
                return this.idValue;
            }
        }


        public string Grade
        {
            get
            {
                return this.studentGradeValue;
            }

            set
            {
                if (value != this.studentGradeValue)
                {
                    this.studentGradeValue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Cclass
        {
            get
            {
                return this.studentCclassValue;
            }

            set
            {
                if (value != this.studentCclassValue)
                {
                    this.studentCclassValue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string No
        {
            get
            {
                return this.studentNoValue;
            }

            set
            {
                if (value != this.studentNoValue)
                {
                    this.studentNoValue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Name
        {
            get
            {
                return this.studentNameValue;
            }

            set
            {
                if (value != this.studentNameValue)
                {
                    this.studentNameValue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Score
        {
            get
            {
                return this.studentScoreValue;
            }

            set
            {
                if (value != this.studentScoreValue)
                {
                    this.studentScoreValue = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}