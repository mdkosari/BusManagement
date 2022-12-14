using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
namespace AP_Project_1
{
    public partial class Main : Form
    {
        static int id = 0, ib = 0, it = 0, ip = 0, ibi = 0;
       
        public Main()
        {
            InitializeComponent();
            if(id==0)
            drivecol.Enabled = false;
            if(it==0)
            travelcol.Enabled = false;
            if(ibi==0)
            blitcol.Enabled = false;
            if(ib==0)
            tabgozaresh.Enabled = false;
            
            busshowdelet.CurrentCell = null;
            drivershowdelet.CurrentCell = null;
            showdelettravel.CurrentCell = null;
            showdeletblit.CurrentCell = null;

        }

        private void Main_Load(object sender, EventArgs e)
        {

            string line;
            StreamReader readerbus = new StreamReader(@"Files\Buses.txt");
            while (!readerbus.EndOfStream)
            {
                line = readerbus.ReadLine();
                if (line != "")
                {
                    string[] busp = line.Split(' ');
                    busshowadd.Rows.Add(ib + 1, busp[0], busp[1], busp[2]);
                    busshowdelet.Rows.Add(ib + 1, busp[0], busp[1], busp[2]);
                    Bus loadbus = new Bus(Convert.ToInt32(busp[0]), Convert.ToInt32(busp[1]), Convert.ToInt32(busp[2]));
                    abus.Add(loadbus);
                    ib++;
                }
            }
            readerbus.Close();
            StreamReader readerdriver = new StreamReader(@"Files\Drivers.txt");
            while (!readerdriver.EndOfStream)
            {
                line = readerdriver.ReadLine();
                if (line != "")
                {
                    drivecol.Enabled = true;
                    tabgozaresh.Enabled = true;
                    string[] drivep = line.Split(' ');
                    drivershowadd.Rows.Add(id + 1, drivep[0], drivep[1], drivep[2], drivep[3], drivep[4], drivep[5]);
                    drivershowdelet.Rows.Add(id + 1, drivep[0], drivep[1], drivep[2], drivep[3], drivep[4], drivep[5]);
                    string[] birthday = drivep[4].Split('/');
                    string[] employee = drivep[5].Split('/');
                    Driver loaddriver = new Driver(drivep[0], drivep[1], Convert.ToInt64(drivep[2]), Convert.ToInt32(drivep[3]), Convert.ToInt32(birthday[0]), Convert.ToInt32(birthday[1]), Convert.ToInt32(birthday[2]), Convert.ToInt32(employee[0]), Convert.ToInt32(employee[1]), Convert.ToInt32(employee[2]));
                   
                    adriver.Add(loaddriver);
                    id++;
                }
            }
            readerdriver.Close();
            StreamReader readertravel = new StreamReader(@"Files\Travels.txt");
            while (!readertravel.EndOfStream)
            {
                line = readertravel.ReadLine();
                if (line != "")
                {
                    travelcol.Enabled = true;
                    tabgozaresh.Enabled = true;
                    string[] travelp = line.Split(' ');
                    string[] traveldate = travelp[2].Split('/');
                    teravelshowadd.Rows.Add(it + 1, travelp[0], travelp[1], travelp[4], travelp[5], travelp[2], travelp[3]);
                    showdelettravel.Rows.Add(it + 1, travelp[0], travelp[1], travelp[4], travelp[5], travelp[2], travelp[3]);
                    Teravel loadtravel = new Teravel(Convert.ToInt32(travelp[0]), Convert.ToInt32(travelp[1]), Convert.ToInt32(traveldate[0]), Convert.ToInt32(traveldate[1]), Convert.ToInt32(traveldate[2]),travelp[3],travelp[4],travelp[5]);
                    ateravel.Add(loadtravel);
                    it++;
                }
            }
            readertravel.Close();
            StreamReader readerpasenger = new StreamReader(@"Files\Passengers.txt");
            while (!readerpasenger.EndOfStream)
            {
                line = readerpasenger.ReadLine();
                if (line != "")
                {
                    string[] pasengerp = line.Split(' ');
                    string[] birthpl = pasengerp[4].Split('/');
                    Pasenger loadpasenger = new Pasenger(pasengerp[0], pasengerp[1], pasengerp[2], Convert.ToInt64(pasengerp[3]), Convert.ToInt32(birthpl[0]), Convert.ToInt32(birthpl[1]), Convert.ToInt32(birthpl[2]));
                    apasenger.Add(loadpasenger);
                    ip++;
                }
            }
            readerpasenger.Close();
            StreamReader readerblit = new StreamReader(@"Files\Tickets.txt");
            while (!readerblit.EndOfStream)
            {
                line = readerblit.ReadLine();
                if (line != "")
                {
                    blitcol.Enabled = true;
                    tabgozaresh.Enabled = true;
                    string[] blitp = line.Split(' ');
                    string[] blitnt = blitp[1].Split('/');
                    showblitadd.Rows.Add(ibi + 1, blitp[5], blitp[6], blitp[7], blitp[3], blitp[4], blitp[1], blitp[2]);
                    showdeletblit.Rows.Add(ibi + 1, blitp[5], blitp[6], blitp[7], blitp[3], blitp[4], blitp[1], blitp[2]);
                    Blit loadblit = new Blit(blitp[5], blitp[6], Convert.ToInt64(blitp[7]), Convert.ToInt32(blitp[8]), Convert.ToInt32(blitp[9]), Convert.ToInt32(blitp[0]), blitp[3], blitp[4], Convert.ToInt32(blitnt[0]), Convert.ToInt32(blitnt[1]), Convert.ToInt32(blitnt[2]), blitp[2], Convert.ToDouble(blitp[10]));
                    ablit.Add(loadblit);
                    ablit[ibi].Personaldriver = Convert.ToInt32(blitp[9]);
                    ibi++;
                }
            }
            readerblit.Close();
        }


        private List<Driver> adriver = new List<Driver>();
        private List<Bus> abus = new List<Bus>();
        private List<Teravel> ateravel = new List<Teravel>();
        private List<Pasenger> apasenger = new List<Pasenger>();
        private List<Blit> ablit = new List<Blit>();

        private void addbus_Click(object sender, EventArgs e)
        {

            try
            {
                if (testb.stest(Convert.ToInt32(serialbusadd.Text)) && testb.ctest(Convert.ToInt32(capacitybus.Text)))
                {
                    Bus bus = new Bus(Convert.ToInt32(serialbusadd.Text), Convert.ToInt32(capacitybus.Text), Convert.ToInt32(yearsbus.Text));
                    abus.Add(bus);

                    busshowadd.Rows.Add(ib + 1, abus[ib].Serial, abus[ib].Capacity, abus[ib].Years);
                    busshowdelet.Rows.Add(ib + 1, abus[ib].Serial, abus[ib].Capacity, abus[ib].Years);
                    ib++;
                    MessageBox.Show("اتوبوس با موفقیت ثبت شد", "عملیات موفق ", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                    drivecol.Enabled = true;
                    tabgozaresh.Enabled = true;

                }
                StreamWriter writetravel = new StreamWriter(@"Files\Buses.txt");   
                for(int i=0;i< ib;i++)
                {
                    writetravel.Write(abus[i].Serial);
                    writetravel.Write(" ");
                    writetravel.Write(abus[i].Capacity);
                    writetravel.Write(" ");
                    writetravel.WriteLine(abus[i].Years);
                }
                writetravel.Close();
            }
            catch
            {
                MessageBox.Show("ورودی نا معتبر", "خطا ورود اطلاعات", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            serialbusadd.Clear(); capacitybus.Clear(); yearsbus.Clear();

        }
        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
        private void tabmain_selecting(object sender, TabControlCancelEventArgs e)
        {
            
        }
        private void tabmain_Enter(object sender, EventArgs e)
        {
        }
        
        private void buscol_Enter(object sender, EventArgs e)
        {
        }
        private void tabremovebus_Enter(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            tabmain.SelectTab(1);
        }

        private void removedriver_Enter(object sender, EventArgs e)
        {



        }

        private void travelcol_Enter(object sender, EventArgs e)
        {

        }
        private void blit_selecting(object sender, TabControlCancelEventArgs e)
        {

        }
        private void blit_Enter(object sender, EventArgs e)
        {

        }
        private void drivecol_selecting(object sender, TabControlCancelEventArgs e)
        {

        }
        private void drivecol_Enter(object sender, EventArgs e)
        {

        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (ib > 0)
            {
                tabmain.SelectTab(2);
                drivecol.SelectTab(0);
            }
            else
            {
                MessageBox.Show("اتوبوس ثبت نشده!", "! ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            }
        }
        private void buttravel_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                tabmain.SelectTab(3);
                travelcol.SelectTab(0);
            }
            else
            {
                MessageBox.Show("راننده ثبت نشده!", "! ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            }
        }
        private void addbusm_Click(object sender, EventArgs e)
        {
            tabmain.SelectTab(1);
        }

        private void اتوبوسToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tabmain.SelectTab(1);
            buscol.SelectTab(1);
        }

        private void ثبتToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void adddriverm_Click(object sender, EventArgs e)
        {
            tabmain.SelectTab(2);
        }

        private void رانندهToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tabmain.SelectTab(2);
            drivecol.SelectTab(1);
        }

        private void addteravelm_Click(object sender, EventArgs e)
        {
            tabmain.SelectTab(3);
        }

        private void سفرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabmain.SelectTab(3);
            travelcol.SelectTab(1);
        }

        private void butpasenger_Click(object sender, EventArgs e)
        {
            if(it>0)
            tabmain.SelectTab(4);
            else
            {
                MessageBox.Show("صفر ثبت نشده ثبت نشده!", "! ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            }
        }

        private void addblitm_Click(object sender, EventArgs e)
        {
            tabmain.SelectTab(4);
        }

        private void بلیطToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            tabmain.SelectTab(4);
            blitcol.SelectTab(1);
        }
        private void gozaresh_selecting(object sender, TabControlCancelEventArgs e)
        {

        }
        private void gozaresh_Enter(object sender, EventArgs e)
        {

        }

        private void butinfo_Click(object sender, EventArgs e)
        {
            if(ib>0)
            tabmain.SelectTab(5);
            else
            {
                MessageBox.Show("اتوبوس ثبت نشده!", "! ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            }
        }

        private void سفرToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tabmain.SelectTab(5);
            tabgozaresh.SelectTab(0);
        }

        private void رانندهToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            tabmain.SelectTab(5);
            tabgozaresh.SelectTab(1);
        }

        private void gtravel_Click(object sender, EventArgs e)
        {

        }

        private void مسافرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabmain.SelectTab(5);
            tabgozaresh.SelectTab(2);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void deletbus_Click(object sender, EventArgs e)
        {
            if (ib == 0)
            {
                MessageBox.Show("اتوبوس ثبت نشده", "خطا ", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            try {
                int rprb = 0;
                bool t = true;
                DialogResult result;
                result = MessageBox.Show("؟آیا از حذف اتوبوس مطمین هستید", "هشدار ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (serialbusdelet.Text == "")
                        serialbusdelet.Text = "-1";
                    else { t = false; rprb = Convert.ToInt32(serialbusdelet.Text); }
                    for (int i = 0; i < ib; i++)
                    {
                        if (abus[i].Serial == Convert.ToInt32(serialbusdelet.Text))
                        {
                            abus.Remove(abus[i]);
                            ib--;
                            busshowadd.Rows.Clear();
                            busshowdelet.Rows.Clear();
                            MessageBox.Show("اتوبوس با موفقیت حذف شد", "عملیات موفق ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            break;
                        }

                    }




                    if (t && ib > 0)
                    {
                        rprb = abus[busshowdelet.CurrentRow.Index].Serial;
                        abus.Remove(abus[busshowdelet.CurrentRow.Index]);
                        ib--;
                        busshowadd.Rows.Clear();
                        busshowdelet.Rows.Clear();
                        MessageBox.Show("اتوبوس با موفقیت حذف شد", "عملیات موفق ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }


                    for (int j = 0; j < ib; j++)
                    {

                        busshowadd.Rows.Add(j + 1, abus[j].Serial, abus[j].Capacity, abus[j].Years);
                        busshowdelet.Rows.Add(j + 1, abus[j].Serial, abus[j].Capacity, abus[j].Years);
                    }
                    StreamWriter writebusd = new StreamWriter(@"Files\Buses.txt");
                    for (int i = 0; i < ib; i++)
                    {
                        writebusd.Write(abus[i].Serial);
                        writebusd.Write(" ");
                        writebusd.Write(abus[i].Capacity);
                        writebusd.Write(" ");
                        writebusd.WriteLine(abus[i].Years);
                    }
                    writebusd.Close();

                }
                else MessageBox.Show("حذف اتوبوس لغو شد!", "! ", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);

                if (ib==0)
                {
                    
                    drivecol.Enabled = false;
                    travelcol.Enabled = false;
                    blitcol.Enabled = false;
                    ablit.Clear();
                    ateravel.Clear();
                }
            }
            catch
            {
                MessageBox.Show("اتوبوس با این مشخصات موجود نمی باشد!", "خطا وروداطلاعات ", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            serialbusdelet.Clear();
        }

        private void button1_Click_4(object sender, EventArgs e)
        {
            tabmain.SelectTab(0);
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        
        private void button2_Click_2(object sender, EventArgs e)
        {
            tabmain.SelectTab(0);
        }

        private void adddriv_Click(object sender, EventArgs e)
        {

        }
        
        

        private void adddriver_Click_1(object sender, EventArgs e)
        {
            try
            {
                bool t;
                DialogResult a;
                if (personalcodedriver.Text != "")
                {
                    t = Testd.ptest(Convert.ToInt32(personalcodedriver.Text));
                }
                else {
                    personalcodedriver.Text="0";
                    t = false;
                }
                if(!t)
                {
                    a=MessageBox.Show("کد پرسنلی نامعتبر است.آیا میخواهید کد پرسنلی پیشفرض قرار بگیرد؟", "هشدار!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if ((a == DialogResult.Yes))
                        t = true;
                }
                Date tbdate = new Date(Convert.ToInt32(yearsbirthdriver.Text), Convert.ToInt32(monthbirthdriver.Text), Convert.ToInt32(daybirthdriver.Text));
                Date tedat = new Date(Convert.ToInt32(yearsbirthdriver.Text), Convert.ToInt32(monthbirthdriver.Text), Convert.ToInt32(daybirthdriver.Text));
                if (tbdate.Test() && tedat.Test()&&t && Testd.ntest(Convert.ToInt64(ncodedriver.Text)))
                {
                    Driver driver = new Driver(enternamedriver.Text, enterfamilydriver.Text, Convert.ToInt64(ncodedriver.Text),Convert.ToInt32(personalcodedriver.Text), Convert.ToInt32(yearsbirthdriver.Text), Convert.ToInt32(monthbirthdriver.Text), Convert.ToInt32(daybirthdriver.Text), Convert.ToInt32(this.eyd.Text), Convert.ToInt32(this.emd.Text), Convert.ToInt32(this.edd.Text));
                    adriver.Add(driver);
                    id++;
                    Date bdate = new Date(adriver[id - 1].Byd, adriver[id - 1].Bmd, adriver[id - 1].Bdd);
                    Date edate = new Date(adriver[id - 1].Eyd, adriver[id - 1].Emd, adriver[id - 1].Edd);
                    drivershowadd.Rows.Add(id, adriver[id - 1].Name, adriver[id - 1].Family, adriver[id - 1].Codnational, adriver[id - 1].Codpersonal, edate.Get(), bdate.Get());
                    drivershowdelet.Rows.Add(id, adriver[id - 1].Name, adriver[id - 1].Family, adriver[id - 1].Codnational, adriver[id - 1].Codpersonal, edate.Get(), bdate.Get());
                    MessageBox.Show("راننده با موفقیت ثبت شد", "عملیات موفق ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    travelcol.Enabled = true;
                    drivecol.Enabled= true;
                    
                    
                 }
                StreamWriter writead = new StreamWriter(@"Files\Drivers.txt");
                for (int i = 0; i < id; i++)
                {
                    writead.Write(adriver[i].Name);
                   writead.Write(" ");
                   writead.Write(adriver[i].Family);
                    writead.Write(" ");
                    writead.Write(adriver[i].Codnational);
                    writead.Write(" ");
                    writead.Write(adriver[i].Codpersonal);
                    writead.Write(" ");
                    Date bfd = new Date(adriver[i].Byd, adriver[i].Bmd, adriver[i].Bdd);
                    writead.Write(bfd.Get());
                    writead.Write(" ");
                    Date efd = new Date(adriver[id - 1].Eyd, adriver[id - 1].Emd, adriver[id - 1].Edd);
                    writead.WriteLine(efd.Get());
                }
                writead.Close();
            }

            catch
            {
                MessageBox.Show("ورودی نا معتبر", "هشدار", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            yearsbirthdriver.Clear(); monthbirthdriver.Clear(); daybirthdriver.Clear(); emd.Clear(); eyd.Clear(); edd.Clear(); enterfamilydriver.Clear(); enternamedriver.Clear(); ncodedriver.Clear(); personalcodedriver.Clear();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabmain.SelectTab(0);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            tabmain.SelectTab(0);
        }

        private void teraveldelet_Click(object sender, EventArgs e)
        {
            if (it == 0)
            {
                MessageBox.Show("سفری ثبت نشده!", "خطا ", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            try {
                bool t = true;
                int rbrt=0;
                DialogResult result;
                result = MessageBox.Show("؟آیامیخواهید سفر را حذف کنید", "هشدار ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (numbertraveldelet.Text == "")
                        numbertraveldelet.Text = "-1";
                    else
                    {
                        t = false; rbrt = Convert.ToInt32(numbertraveldelet.Text);
                    }
                    for (int i = 0; i < it; i++)
                    {
                        if (ateravel[i].Teravelnumber == Convert.ToInt32(numbertraveldelet.Text))
                        {
                            
                           
                            ateravel.RemoveAt(i);
                            it--;
                            showdelettravel.Rows.Clear();
                            teravelshowadd.Rows.Clear();
                            MessageBox.Show("سفر با موفقیت حذف شد", "عملیات موفق ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            break;
                        }
                    }
                    if (t)
                    {
                        rbrt = ateravel[showdelettravel.CurrentRow.Index].Serialbus;
                        ateravel.RemoveAt(showdelettravel.CurrentRow.Index);
                        it--;
                        showdelettravel.Rows.Clear();
                        teravelshowadd.Rows.Clear();
                        MessageBox.Show("سفر با موفقیت حذف شد", "عملیات موفق ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    for(int i=0;i< ibi;i++)
                    {
                        if (ablit[i].Teravelnumber == rbrt)
                        {
                            ablit.RemoveAt(i);
                            for(int j=0;j< ip;j++)
                            {
                                if (apasenger[j].Nationalcode == ablit[i].Nationalcode)
                                    apasenger.RemoveAt(j);
                            }
                        }
                       
                    }
                    showdeletblit.Rows.Clear();
                    showblitadd.Rows.Clear();
                    for (int j = 0; j < ibi; j++)
                    {
                        Date t1 = new Date(ablit[j].Yb, ablit[j].Mb, ablit[j].Db);
                        showblitadd.Rows.Add(j + 1, ablit[j].Name, ablit[j].Family, ablit[j].Nationalcode, ablit[j].Start, ablit[j].End, t1.Get(), ablit[j].Time);
                        showdeletblit.Rows.Add(j + 1, ablit[j].Name, ablit[j].Family, ablit[j].Nationalcode, ablit[j].Start, ablit[j].End, t1.Get(), ablit[j].Time);
                    }
                }
                for (int j=0;j<it;j++)
                {
                    Date ltdate = new Date(ateravel[j].Yt, ateravel[j].Mt, ateravel[j].Dt);
                    teravelshowadd.Rows.Add(j+1,ateravel[j].Teravelnumber, ateravel[j].Serialbus, ateravel[j].Start, ateravel[j].End, ltdate.Get(),ateravel[j].Time);
                    showdelettravel.Rows.Add(j+1, ateravel[j].Teravelnumber, ateravel[j].Serialbus, ateravel[j].Start, ateravel[j].End, ltdate.Get(),ateravel[j].Time);
                }
                if (it == 0)
                {
                    blitcol.Enabled = false; }
                StreamWriter writert = new StreamWriter(@"Files\Travels.txt");
                for (int i = 0; i < it; i++)
                {
                    writert.Write(ateravel[i].Teravelnumber);
                    writert.Write(" ");
                    writert.Write(ateravel[i].Serialbus);
                    writert.Write(" ");
                    Date rts = new Date(ateravel[i].Yt, ateravel[i].Mt, ateravel[i].Dt);
                    writert.Write(rts.Get());
                    writert.Write(" ");
                    writert.Write(ateravel[i].Time);
                    writert.Write(" ");
                    writert.Write(ateravel[i].Start);
                    writert.Write(" ");
                    writert.WriteLine(ateravel[i].End);
                }
                writert.Close();
            }
            catch
            {
                MessageBox.Show("سفر وجود ندارد !", "خطا", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            numbertraveldelet.Clear();
        }

        private void numbertraveldelet_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void rfamilydriver_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void rnamedriver_TextChanged(object sender, EventArgs e)
        {

        }

        private void rpersonaldriver_TextChanged(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void drivershowdelet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabmain.SelectTab(0);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabmain_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void deletblit_Click(object sender, EventArgs e)
        {
        }

        private void deletblit_Click_1(object sender, EventArgs e)
        {
            if (ibi == 0)
            {
                MessageBox.Show("بلیط وجود ندارد", "خطا ", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
                try
            {
                bool t = true;
                DialogResult result;
                result = MessageBox.Show("؟آیا از حذف بلیط مطمین هستید", "هشدار ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (ndeletblit.Text == "")
                        ndeletblit.Text = "-1";
                    if (namedeletblit.Text == "")
                        namedeletblit.Text = "no value";
                    if (familydeletblit.Text == "")
                        familydeletblit.Text = "no value";
                    for (int i = 0; i < id; i++)
                    {
                        if (adriver[i] == null)
                            continue;
                        if (t && namedeletblit.Text == ablit[i].Name ||
                            Convert.ToInt64(ndeletblit.Text) == ablit[i].Nationalcode ||
                            familydeletblit.Text == ablit[i].Family)
                        {
                            t = false;
                            ablit.RemoveAt(i);
                            ibi--;
                            showblitadd.Rows.Clear();
                            showdeletblit.Rows.Clear();
                            MessageBox.Show("بلیط با موفقیت حذف شد", "عملیات موفق ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            break;
                        }

                    }
                    if (t && ibi > 0)
                    {

                        ablit.RemoveAt(showdeletblit.CurrentRow.Index);
                        showblitadd.Rows.Clear();
                        showdeletblit.Rows.Clear();
                        ibi--;
                        MessageBox.Show("بلیط با موفقیت حذف شد", "عملیات موفق ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    showdeletblit.Rows.Clear();
                    showblitadd.Rows.Clear();
                    for (int j = 0; j < ibi; j++)
                    {
                        Date t1 = new Date(ablit[j].Yb, ablit[j].Mb, ablit[j].Db);
                        showblitadd.Rows.Add(j + 1, ablit[j].Name, ablit[j].Family, ablit[j].Nationalcode, ablit[j].Start, ablit[j].End, t1.Get(), ablit[j].Time);
                        showdeletblit.Rows.Add(j + 1, ablit[j].Name, ablit[j].Family, ablit[j].Nationalcode, ablit[j].Start, ablit[j].End, t1.Get(), ablit[j].Time);
                    }
                    if (ibi == 0)
                        deletblit.Enabled = false;
                }

                else { MessageBox.Show("حذف راننده لغو شد!", "خطا وروداطلاعات ", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk); return; }
                StreamWriter writerp = new StreamWriter(@"Files\Passengers.txt");
                for (int i = 0; i < ip; i++)
                {
                    writerp.Write(apasenger[i].Name);
                    writerp.Write(" ");
                    writerp.Write(apasenger[i].Family);
                    writerp.Write(" ");
                    writerp.Write(apasenger[i].Fathername);
                    writerp.Write(" ");
                    writerp.Write(apasenger[i].Nationalcode);
                    writerp.Write(" ");
                    Date rp = new Date(apasenger[i].Y, apasenger[i].M, apasenger[i].D);
                    writerp.WriteLine(rp.Get());
                }
                writerp.Close();
                StreamWriter writerb = new StreamWriter(@"Files\Tickets.txt");
                for (int i = 0; i < ibi; i++)
                {
                    writerb.Write(ablit[i].Teravelnumber);
                    writerb.Write(" ");
                    Date rb = new Date(ablit[i].Yb, ablit[i].Mb, ablit[i].Db);
                    writerb.Write(rb.Get());
                    writerb.Write(" ");
                    writerb.Write(ablit[i].Time);
                    writerb.Write(" ");
                    writerb.Write(ablit[i].Start);
                    writerb.Write(" ");
                    writerb.Write(ablit[i].End);
                    writerb.Write(" ");
                    writerb.Write(ablit[i].Name);
                    writerb.Write(" ");
                    writerb.Write(ablit[i].Family);
                    writerb.Write(" ");
                    writerb.Write(ablit[i].Nationalcode);
                    writerb.Write(" ");
                    writerb.Write(ablit[i].Serialbus);
                    writerb.Write(" ");
                    writerb.Write(ablit[i].Personaldriver);
                    writerb.Write(" ");
                    writerb.WriteLine(ablit[i].Money);
                }
                writerb.Close();
            
            }

            catch
            {
                MessageBox.Show("ورودی نا معتبر", "خطا ورود اطلاعات", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            ndeletblit.Clear();namedeletblit.Clear();familydeletblit.Clear();
        }

        private void swrchtravel_Click(object sender, EventArgs e)
        {
           
        }

        private void serch2_Click(object sender, EventArgs e)
        {

        }

        private void serchtravel2_Click(object sender, EventArgs e)
        {
            try {
                Date t = new Date(Convert.ToInt32(yts.Text), Convert.ToInt32(mts.Text), Convert.ToInt32(dts.Text));
                for (int i = 0; i < it; i++)
                {

                    Date t1 = new Date(ateravel[i].Yt, ateravel[i].Mt, ateravel[i].Dt);
                    if (t.Test() && ateravel[i].Start == starttravelserch.Text && ateravel[i].End == endtravelserch.Text && t.Get() == t1.Get())
                    {
                        showserchtravel2.Rows.Add(i + 1, ateravel[i].Teravelnumber, ateravel[i].Serialbus, ateravel[i].Time);
                    }
                }
            }
            catch
            {
                MessageBox.Show("ورودی نا معتبر", "خطا ورود اطلاعات", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            dts.Clear();mts.Clear();yts.Clear();starttravelserch.Clear();endtravelserch.Clear();
        }

        private void showserchtravel2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void swrchtravel_Click_1(object sender, EventArgs e)
        {
            showserchtravel.Rows.Clear();
            try {
                uint c = 1;
                if (it > 0 && ibi > 0)
                {
                    for (int i = 0; i < ibi; i++)
                    {
                        if (ablit[i].Serialbus == Convert.ToInt32(ssh.Text))
                        {
                            Date t = new Date(ablit[i].Yb, ablit[i].Mb, ablit[i].Db);
                            showserchtravel.Rows.Add(c, ablit[i].Name, ablit[i].Family, ablit[i].Nationalcode, ablit[i].Start, ablit[i].End, t.Get(), ablit[i].Time);
                            c++;
                        }
                    }
                }
                else {
                    MessageBox.Show("بلیط ثبت نشده!", "خطا!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                     }
                }
                
            
            catch
            {
                MessageBox.Show("ورودی نا معتبر", "خطا ورود اطلاعات", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            ssh.Clear();
        }


        private void pds_TextChanged(object sender, EventArgs e)
        {
            nds.Enabled = false;
        }

        
        private void serchds1_Click_1(object sender, EventArgs e)
        {
            showserchs1.Rows.Clear();
            try {
                uint cd = 1;
                if (nds.Enabled != false)
                {
                    for (int i = 0; i < id; i++)
                    {
                        if (adriver[i].Codnational == Convert.ToInt64(nds.Text))
                        {
                            for (int j = 0; j < ibi; j++)
                            {
                                if (adriver[i].Codpersonal == ablit[j].Personaldriver)
                                {
                                    for (int k = 0; k < it; k++)
                                    {
                                        if (ablit[j].Teravelnumber == ateravel[k].Teravelnumber && ablit[j].Yb >= Convert.ToInt32(ysds.Text) && ablit[j].Yb <= Convert.ToInt32(yeds.Text))
                                        {
                                            Date s = new Date(ateravel[k].Yt, ateravel[k].Mt, ateravel[k].Dt);
                                            showserchs1.Rows.Add(cd,ateravel[k].Teravelnumber, ateravel[k].Start, ateravel[k].End, s.Get(), ateravel[k].Time);
                                            cd++;
                                        }
                                    }

                                }
                            }
                        }
                    }
                }
                else {
                    for (int i = 0; i < ibi; i++)
                    {
                        if (ablit[i].Personaldriver == Convert.ToInt32(pds.Text))
                        {
                            for (int j = 0; j < it; j++)
                            {
                                if (ablit[i].Teravelnumber == ateravel[j].Teravelnumber)
                                {
                                    Date s = new Date(ateravel[j].Yt, ateravel[j].Mt, ateravel[j].Dt);
                                    showserchs1.Rows.Add(cd,ateravel[j].Teravelnumber, ateravel[j].Start, ateravel[j].End, s.Get(), ateravel[j].Time);
                                    cd++;
                                    break;
                                }
                            }
                        }
                    }
                } }
            catch
            {
                MessageBox.Show("ورودی نا معتبر", "خطا ورود اطلاعات", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

            nds.Enabled= true;
            pds.Enabled= true;
            nds.Clear();pds.Clear();ysds.Clear();yeds.Clear();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try {
                bool tsd2 = false;
                if (Convert.ToInt32(sdb.Text) <= 30)
                    tsd2 = true;
                else
                {
                    MessageBox.Show("لطفا سال را از 1تا30 وارد کنید", "خطا ورود اطلاعات", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                uint cd1 = 1;
                for (int i = 0; i < id&&tsd2; i++)
                {
                    if ((1395 - adriver[i].Byd) == (60 - Convert.ToInt32(sdb.Text)) && (1395 - adriver[i].Eyd) <= (30 - Convert.ToInt32(sdb.Text)) || (1395 - adriver[i].Byd) <= (60 - Convert.ToInt32(sdb.Text)) && (1395 - adriver[i].Eyd) == (30 - Convert.ToInt32(sdb.Text)))
                    {
                        for (int j = 0; j < it; j++)
                        {
                            if (adriver[i].Codpersonal == ablit[j].Personaldriver)
                            {
                                for (int k = 0; k < it; k++)
                                {
                                    if (ablit[j].Teravelnumber == ateravel[k].Teravelnumber)
                                    {
                                        Date s = new Date(ateravel[k].Yt, ateravel[k].Mt, ateravel[k].Dt);
                                        showserchs2.Rows.Add(cd1, ateravel[k].Teravelnumber, ateravel[k].Start, ateravel[k].End, s.Get(), ateravel[k].Time);
                                        cd1++;

                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("ورودی نا معتبر", "خطا ورود اطلاعات", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            sdb.Clear();
        }
            
        private void serchblit_Click_1(object sender, EventArgs e)
        {
            try {
                uint cb = 1;
                if (ncodeserchblit.Text == "")
                    ncodeserchblit.Text = "-1";
                if (nameserchblit.Text == "")
                    nameserchblit.Text = "no value";
                if (familyserchblit.Text == "")
                    familyserchblit.Text = "no value";
                for (int i = 0; i < ibi; i++)
                {
                    if (ablit[i].Nationalcode == Convert.ToInt64(ncodeserchblit.Text) || ablit[i].Name == nameserchblit.Text || familyblit.Text == ablit[i].Family)
                    {
                        Date d = new Date(ablit[i].Yb, ablit[i].Mb, ablit[i].Db);
                        showserchblit.Rows.Add(cb, ablit[i].Name, ablit[i].Family,ablit[i].Nationalcode ,ablit[i].Start, ablit[i].End, d.Get(), ablit[i].Time);
                        cb++;
                    }
                }
            }
            catch
            {
                MessageBox.Show("ورودی نا معتبر", "خطا ورود اطلاعات", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            ncodeserchblit.Clear();nameserchblit.Clear();familyserchblit.Clear();
        }

        private void nds_cahngedtext(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void nds_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void nds_TextChanged(object sender, EventArgs e)
        {
            pds.Enabled = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sdb_TextChanged(object sender, EventArgs e)
        {

        }

        private void backbus_Click(object sender, EventArgs e)
        {
            tabmain.SelectTab(0);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabmain.SelectTab(0);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            tabmain.SelectTab(0);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            tabmain.SelectTab(0);
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            tabmain.SelectTab(0);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            tabmain.SelectTab(0);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            tabmain.SelectTab(0);
        }

        private void دربارهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("برنامه مدیریت اتوبوس نوشته شده توسط محمد کوثری نسخه ناکامل برنامه");
        }

       
        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void addblit_Click(object sender, EventArgs e)
        {
            
            try
            {
                Date bdate = new Date(Convert.ToInt32(byb.Text), Convert.ToInt32(bmb.Text), Convert.ToInt32(bdb.Text));
                Date tdate = new Date(Convert.ToInt32(tyb.Text), Convert.ToInt32(tmb.Text), Convert.ToInt32(tdb.Text));

                bool ttdate = false, tpd = false, teraveltest = false; ;
                for (int i = 0; i < it; i++)
                {
                    Date ltdate = new Date(ateravel[i].Yt, ateravel[i].Mt, ateravel[i].Dt);
                    if (ltdate.Get() == tdate.Get())
                        ttdate = true;
                }
                for (int i = 0; i < id; i++)
                {
                    if (adriver[i].Codpersonal == Convert.ToInt32(personaldriverblit.Text))
                    { tpd = true; break; }

                }
                 if(!tpd) {
                    MessageBox.Show("کد پرسنلی وجود ندارد", "خطا!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                for (int i = 0; i < it; i++)
                {
                    if (ateravel[i].Start == startblit.Text && ateravel[i].End == endblit.Text && ateravel[i].Teravelnumber == Convert.ToInt32(numbertravelblit.Text))
                        teraveltest = true;
                }
                if (tdate.Test() && tdate.Test() && ttdate && tpd && teraveltest)
                {
                    Blit blit = new Blit(nameblit.Text, familyblit.Text, Convert.ToInt64(nationalblit.Text), Convert.ToInt32(serialbusblit.Text), Convert.ToInt32(personaldriverblit.Text), Convert.ToInt32(numbertravelblit.Text), startblit.Text, endblit.Text, Convert.ToInt32(tyb.Text), Convert.ToInt32(tmb.Text), Convert.ToInt32(tdb.Text), timeblit.Text, Convert.ToDouble(costblit.Text));
                    Pasenger pasenger = new Pasenger(nameblit.Text, familyblit.Text, fatherblit.Text, Convert.ToInt64(nationalblit.Text), Convert.ToInt32(byb.Text), Convert.ToInt32(bmb.Text), Convert.ToInt32(bdb.Text));
                    apasenger.Add(pasenger);
                    ablit.Add(blit);
                    ibi++;
                    ip++;
                    Date t = new Date(ablit[ibi - 1].Yb, ablit[ibi - 1].Mb, ablit[ibi - 1].Db);
                    showblitadd.Rows.Add(ibi, ablit[ibi - 1].Name, ablit[ibi - 1].Family, ablit[ibi - 1].Nationalcode, ablit[ibi - 1].Start, ablit[ibi - 1].End, t.Get(), ablit[ibi - 1].Time);
                    MessageBox.Show("بلیط با موفقیت ثبت شد", "عملیات موفق ", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                    showdeletblit.Rows.Add(ibi, ablit[ibi - 1].Name, ablit[ibi - 1].Family, ablit[ibi - 1].Nationalcode, ablit[ibi - 1].Start, ablit[ibi - 1].End, t.Get(), ablit[ibi - 1].Time);

                    StreamWriter writeap = new StreamWriter(@"Files\Passengers.txt");
                    for (int i = 0; i < ip; i++)
                    {
                        writeap.Write(apasenger[i].Name);
                        writeap.Write(" ");
                        writeap.Write(apasenger[i].Family);
                        writeap.Write(" ");
                        writeap.Write(apasenger[i].Fathername);
                        writeap.Write(" ");
                        writeap.Write(apasenger[i].Nationalcode);
                        writeap.Write(" ");
                        Date ap = new Date(apasenger[i].Y, apasenger[i].M, apasenger[i].D);
                        writeap.Write(ap.Get());
                    }
                    writeap.Close();
                    StreamWriter writeab = new StreamWriter(@"Files\Tickets.txt");
                    for (int i = 0; i < ibi; i++)
                    {
                        writeab.Write(ablit[i].Teravelnumber);
                        writeab.Write(" ");
                        Date ab = new Date(ablit[i].Yb, ablit[i].Mb, ablit[i].Db);
                        writeab.Write(ab.Get());
                        writeab.Write(ablit[i].Time);
                        writeab.Write(" ");
                        writeab.Write(ablit[i].Start);
                        writeab.Write(" ");
                        writeab.Write(ablit[i].End);
                        writeab.Write(" ");
                        writeab.Write(ablit[i].Name);
                        writeab.Write(" ");
                        writeab.Write(ablit[i].Family);
                        writeab.Write(" ");
                        writeab.Write(ablit[i].Nationalcode);
                        writeab.Write(" ");
                        writeab.Write(ablit[i].Serialbus);
                        writeab.Write(" ");
                        writeab.Write(ablit[i].Personaldriver);
                        writeab.Write(" ");
                        writeab.Write(ablit[i].Money);
                    }
                    writeab.Close();
                }
                else
                {
                    MessageBox.Show("ورودی نا معتبر", "خطا!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("ورودی نا معتبر", "خطا!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }
            nameblit.Clear();familyblit.Clear();fatherblit.Clear();bdb.Clear();bmb.Clear();byb.Clear();tdb.Clear();tmb.Clear();tyb.Clear();nationalblit.Clear();numbertravelblit.Clear();serialbusblit.Clear();personalcodedriver.Clear();startblit.Clear();endblit.Clear();timeblit.Clear();costblit.Clear();
        }

        private void adtravel_Click(object sender, EventArgs e)
        {
            try
            {

                bool st=false;
                for(int i=0;i< ib;i++)
                {
                    if (abus[i].Serial == Convert.ToInt32(serialbus.Text))
                        st = true;
                }
                if (!st)
                {
                    MessageBox.Show(" اتوبوس با این شماره سریال وجود ندارد", "خطا ورود اطلاعات", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return;
                }

                Date tdate = new Date(Convert.ToInt32(teravelyears.Text), Convert.ToInt32(teravelmonth.Text), Convert.ToInt32(teravelday.Text));
                if (st&&tdate.Test())
                {
                    Teravel teravel = new Teravel(Convert.ToInt32(teravelnumber.Text), Convert.ToInt32(serialbus.Text), Convert.ToInt32(teravelyears.Text), Convert.ToInt32(teravelmonth.Text), Convert.ToInt32(teravelday.Text), timetravel.Text, startteravel.Text, endtravel.Text);
                    ateravel.Add(teravel);
                    it++;
                    Date ltdate = new Date(ateravel[it - 1].Yt, ateravel[it - 1].Mt, ateravel[it - 1].Dt);
                    teravelshowadd.Rows.Add(it, ateravel[it - 1].Teravelnumber, ateravel[it - 1].Serialbus, ateravel[it - 1].Start, ateravel[it - 1].End, ltdate.Get(),ateravel[it-1].Time);
                    showdelettravel.Rows.Add(it, ateravel[it - 1].Teravelnumber, ateravel[it - 1].Serialbus, ateravel[it - 1].Start, ateravel[it - 1].End, ltdate.Get(), ateravel[it - 1].Time);
                    blitcol.Enabled = true;
                    deletblit.Enabled = false;
                    MessageBox.Show("سفر با موفقیت ثبت شد", "عملیات موفق", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                    StreamWriter writeat = new StreamWriter(@"Files\Travels.txt");
                    for (int i = 0; i < it; i++)
                    {
                        writeat.Write(ateravel[i].Teravelnumber);
                        writeat.Write(" ");
                        writeat.Write(ateravel[i].Serialbus);
                        writeat.Write(" ");
                        Date ats = new Date(ateravel[i].Yt, ateravel[i].Mt, ateravel[i].Dt);
                        writeat.Write(ats.Get());
                        writeat.Write(" ");
                        writeat.Write(ateravel[i].Time);
                        writeat.Write(" ");
                        writeat.Write(ateravel[i].Start);
                        writeat.Write(" ");
                        writeat.WriteLine(ateravel[i].End);
                    }
                    writeat.Close();
                }
                
            }
            catch
            {
                MessageBox.Show("!ورودی نا معتبر", "خطا ورود اطلاعات", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            teravelday.Clear(); teravelmonth.Clear(); teravelyears.Clear(); teravelnumber.Clear(); timetravel.Clear(); serialbus.Clear(); startteravel.Clear(); endtravel.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("راننده ثبت نشده!", "خطا ", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            try
            {
                bool t = true;
                DialogResult result;
                result = MessageBox.Show("؟آیا از حذف راننده مطمین هستید", "هشدار ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (rpersonaldriver.Text == "")
                        rpersonaldriver.Text = "-1";
                    if (rnamedriver.Text == "")
                        rnamedriver.Text = "no value";
                    if (rfamilydriver.Text == "")
                        rfamilydriver.Text = "no value";
                    for (int i = 0; i < id; i++)
                    {
                        if (adriver[i] == null)
                            continue;
                        if (t && Convert.ToInt32(rpersonaldriver.Text) == adriver[i].Codpersonal||
                            rnamedriver.Text == adriver[i].Name ||
                            rfamilydriver.Text == adriver[i].Family)
                        {
                            t = false;
                            adriver.RemoveAt(i);
                            id--;
                            drivershowdelet.Rows.Clear();
                            drivershowadd.Rows.Clear();
                            MessageBox.Show("راننده با موفقیت حذف شد", "عملیات موفق ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            break;
                        }
                    }
                    if (t && id > 0)
                    {

                        adriver.RemoveAt(Convert.ToInt32(drivershowdelet.Rows[drivershowdelet.CurrentRow.Index].Cells[0].Value.ToString()) - 1);
                        drivershowdelet.Rows.Clear();
                        drivershowadd.Rows.Clear();
                        id--;
                        MessageBox.Show("راننده با موفقیت حذف شد", "عملیات موفق ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    }
                    drivershowdelet.Rows.Clear();
                    drivershowadd.Rows.Clear();
                    for (int j = 0; j < id; j++)
                    {
                        Date bdate = new Date(adriver[j].Byd, adriver[j].Bmd, adriver[j].Bdd);
                        Date edate = new Date(adriver[j].Eyd, adriver[j].Emd, adriver[j].Edd);
                        drivershowdelet.Rows.Add(j + 1, adriver[j].Name, adriver[j].Family, adriver[j].Codnational, adriver[j].Codpersonal, edate.Get(), bdate.Get());
                        drivershowadd.Rows.Add(j + 1, adriver[j].Name, adriver[j].Family, adriver[j].Codnational, adriver[j].Codpersonal, edate.Get(), bdate.Get());
                    }
                }
               else MessageBox.Show("حذف راننده لغو شد!", "خطا وروداطلاعات ", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                if (id==0)
                {
                    travelcol.Enabled = false;
                    blitcol.Enabled = false;
                    
                }
                else
                {
                    StreamWriter writerd = new StreamWriter(@"Files\Drivers.txt");
                    for (int i = 0; i < id; i++)
                    {
                        writerd.Write(adriver[i].Name);
                        writerd.Write(" ");
                        writerd.Write(adriver[i].Family);
                        writerd.Write(" ");
                        writerd.Write(adriver[i].Codnational);
                        writerd.Write(" ");
                        writerd.Write(adriver[i].Codpersonal);
                        writerd.Write(" ");
                        Date bfd = new Date(adriver[i].Byd, adriver[i].Bmd, adriver[i].Bdd);
                        writerd.Write(bfd.Get());
                        writerd.Write(" ");
                        Date efd = new Date(adriver[id - 1].Eyd, adriver[id - 1].Emd, adriver[id - 1].Edd);
                        writerd.WriteLine(efd.Get());
                    }
                    writerd.Close();
                }
            }

            catch
            {
                MessageBox.Show("ورودی نا معتبر", "خطا ورود اطلاعات", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            rpersonaldriver.Clear();rfamilydriver.Clear();rnamedriver.Clear();
        }
}
    }


            
        
        

        
    
    
    
