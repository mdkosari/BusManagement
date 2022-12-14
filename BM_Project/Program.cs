using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace AP_Project_1
{


    class Date
    {
        private int year, month, day;
        public Date() { }
        public Date(int theYear, int theMonth, int theDay)
        {
            Year = theYear;
            Month = theMonth;
            Day = theDay;
        }
        public int Year
        {
            get { return year; }
            set
            {
                if (value >= 1300&&value<1400)
                    year = value;
                else
                    MessageBox.Show("سال وارد شده معتبر نیست", "خطا وروداطلاعات ", MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
            }
        }
        public int Month
        {
            
            get { return month; }
            set
            {
                if (value >= 1 && value <= 12)
                    month = value;
                else {
                    MessageBox.Show("ماه باید از 1 تا 12 وارد شود", "خطا وروداطلاعات ", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    Test();
                     }
            }
        }
        public int Day
        {
            get { return day; }
            set
            {
                if ((value >= 1 && value <= 31 && month <= 6) ||
                (value >= 1 && value <= 30 && month > 6))
                    day = value;
                else {
                    MessageBox.Show("روز وارد شده معتبر نیست", "خطا وروداطلاعات ", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    Test();
                     }
                }
        }

         public bool Test()
        {       if ((year >= 1300 && year < 1400))
                if (month >= 1 && month <= 12)
                    if((day >= 1 && day <= 31 && month <= 6)||
                    (day >= 1 && day <= 30 && month > 6)||
                    (day >= 1 && day < 30 && month ==12))
                        return true;

                 return false;
        }
        
        public string Get()
        {   
            
            return year + "/" + month + "/" + day;

            
        }
    }
    class testb
    {
        public static bool stest(int serial)
        {
            if (serial > 0)
               return true;
            MessageBox.Show("سریال نا معتبر", "خطا وروداطلاعات ", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            return false;

        }
        public static bool ctest(int capacity)
        {
            if (capacity > 0 && capacity <= 60)
                return true;
                MessageBox.Show("ظرفیت میتواند مقادیر 1تا60 باشد", "خطا وروداطلاعات ", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            return false;
        }
    }
    class Bus
    {
        int capacity, serial, years;
        public Bus(int serial,int capacity,int year)
            {
            this.serial = serial;
            Capacity = capacity;
            Years = year;
            
            }
        public int Capacity
        { get { return capacity; }
        set { capacity = value; } } 
        public int Serial
        {
            get { return serial; }
            set { serial = value; }
        }
        
        public int Years
        { get { return years; }
            set { years = value; }
        }
    }
    class Testd
    {
       static public bool ntest(long n) {
            if (n > 1000000000 && n < 10000000000) return true;
            MessageBox.Show("کد ملی نا معتبر", "خطا وروداطلاعات ", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                         return false;
        }
        static public bool ptest(int p)
        {
            if (p > 10000000 && p < 100000000) return true;

            MessageBox.Show("کد پرسونلی نا معتبر", "خطا وروداطلاعات ", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
             return false;
        }
    }
    class Driver
    {
        string name="", family="";
         int codp,byd,bmd,bdd,eyd,emd,edd;
        long codnational;
       static int nextcodepersonal = 10000000;
        public Driver(string name,string family, long codnational,int codpersonals, int byd,int bmd,int bdd,int eyd,int emd,int edd)
        {
            this.name =name;
            this.family=family;
            Codnational = codnational;
            this.byd = byd;
            this.bmd = bmd;
            this.bdd = bdd;
            this.eyd = eyd;
            this.emd = emd;
            this.edd = edd;
            if (codpersonals > 10000000)
                nextcodepersonal = codpersonals;
            Codpersonal = nextcodepersonal;
            nextcodepersonal++;


        }
        public int Codpersonal
        {
            get { return codp; }
            set {if (value > nextcodepersonal) { codp = value; nextcodepersonal = value + 1; }
                else {
                    codp = nextcodepersonal;
                    nextcodepersonal++;
                } }
           
        }
        public string Name
        {
            get { return name; }
        }
        public string Family
        {
            get { return family; }
        }
       
        public long Codnational { get{ return codnational; }
            set { if (value > 1000 || value < 10000000) codnational = value;
                else MessageBox.Show("کد ملی غیر مجاز", "خطا وروداطلاعات ", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
        public int Byd
        {
            get { return byd; }
        }
        public int Bmd
        {
            get { return bmd; }
        }
        public int Bdd
        {
            get { return bdd; }
        }
        public int Eyd
        {
            get { return eyd; }
        }
        public int Emd
        {
            get { return bmd; }
        }
        public int Edd
        { get { return edd; } }
    }
    class Teravel
    {
        int teravelnumber, serialbus, yt, mt, dt;
        string time, start, end;
        public Teravel(int teravelnumber,int serialbus,int yt,int mt,int dt,string time,string start ,string end)
        {
            Teravelnumber = teravelnumber;
            Serialbus = serialbus;
            Yt = yt;
            Mt = mt;
            Dt = dt;
            Time = time;
            Start = start;
            End = end;
        }
       public int Yt
        {
            get { return yt; }
            set { yt = value; }
        }
        public int Mt
        {
            get { return mt; }
            set { mt = value; }
        }
        public int Dt
        {
            get { return dt; }
            set { dt = value; }
        }
        public int Teravelnumber
        {
            get { return teravelnumber; }
            set { teravelnumber = value; }
        }

        public int Serialbus
        {
            get { return serialbus; }
            set { serialbus = value; }
        }
        public string Time
        {
            get { return time; }
            set { time = value; }
        }
        public string Start
        {
            get { return start; }
            set { start = value; }
        }
        public string End
        {
            get { return end; }
            set { end = value; }
        }
    }
   class Pasenger
    {
        string name, family, fathername;
        int  yers, month, day;
        long nationalcode;
        public Pasenger(string name,string family,string fathername,long nationalcode,int years,int month,int day)
            {
            Name = name;
            Family = family;
            Fathername = fathername;
            Nationalcode = nationalcode;
            Y = years;
            M = month;
            D = day;
            }
        public string Name
        {
            get { return name; }
            set { name = value; }
        } 
        public string Family { get { return family; } set { family = value; } }
        public string Fathername
        { get { return fathername; } set { fathername = value; } }
        public long Nationalcode { get { return nationalcode; } set { nationalcode = value; } }
        public int Y { get { return yers; } set { yers = value; } }
        public int M { get { return month; } set { month = value; } }
        public int D { get { return day; } set { day = value; } }
    }

    class Blit
    {
        string name, family,start,end, time;
        long nationalcode;
        int serialbus, personaldriver, teravelnumber, yb, mb, db;
        double money;
        public Blit(string name,string family,long nationalcode,int serialbus,int personaldriver,int teravelnumber,string start,string end,int yb,int mb,int db,string time,double money)
        {
            Name = name;
            Family = family;
            Nationalcode = nationalcode;
            Serialbus = serialbus;
            Personaldriver = personaldriver;
            Teravelnumber = teravelnumber;
            Start = start;
            End = end;
            Yb = yb;
            Mb = mb;
            Db = db;
            Time = time;
            Money = money;
        }
        public string Name
        { get { return name; } set { name = value; } }
        public string Family
        { get { return family; } set { family = value; } }
        public string Start { get { return start; } set { start = value; } }
        public string End { get { return end; } set { end = value; } }
        public string Time { get { return time; } set { time = value; } }
        public long Nationalcode { get { return nationalcode; } set { nationalcode = value; } }
        public double Money { get { return money; } set { money -= value; } }
        public int Serialbus { get { return serialbus; }set { serialbus = value; } }
        public int Personaldriver { get { return personaldriver; } set { personaldriver = value; } }
        public int Teravelnumber { get { return teravelnumber; } set { teravelnumber = value; } }
        public int Yb { get { return yb; } set { yb = value; } }
        public int Mb { get { return mb; } set { mb = value; } }
        public int Db { get { return db; } set { db = value; } }
    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
