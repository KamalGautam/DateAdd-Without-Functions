using System;
using System.Windows.Forms;

namespace DevTest
{
    public partial class Form1 : Form
    {
        
        string year = "";
        Double totalDays = 0;
        string dt = "";
        string dtDays = "";
        string dtMonth = "";
        bool leapYear = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                lblNewDate.Text = "";
                totalDays = 0;
                dt = "";
                dtDays = "";
                dtMonth = "";
                year = "";

                dt = dtpStartDate.Value.ToString("dd/MM/yyyy");
                dtDays = dt.Substring(0, 2);
                dtMonth = dt.Substring(3, 2);
                year = dt.Substring(6, 4);

                totalDays = Convert.ToDouble(txtDays.Text);

                int currentDay = currentDayofYear(Convert.ToInt16(dtMonth), Convert.ToInt16(dtDays), Convert.ToInt16(year));

              
                    totalDays = totalDays + currentDay;
                    Double d = 0;
                    if ((Convert.ToDouble(year) % 4) == 0)
                    {
                        if (totalDays > 366)
                        {
                            d = daysFind();
                            lblNewDate.Text = addDays(dt, totalDays, Convert.ToInt16(year));

                        }
                        else
                        {
                            lblNewDate.Text = addDays(dt, totalDays, Convert.ToInt16(year));
                        }
                    }
                    else
                    {

                        if (totalDays > 365)
                        {
                            d = daysFind();
                            lblNewDate.Text = addDays(dt, totalDays, Convert.ToInt16(year));
                        }
                        else
                        {
                            lblNewDate.Text = addDays(dt, totalDays, Convert.ToInt16(year));
                        }

                    }
               
                lblDateFunction.Text = (Convert.ToDateTime(dtpStartDate.Text).AddDays(Convert.ToDouble(txtDays.Text))).ToString("dd/MM/yyyy");
            }
            catch(Exception ex)
            { }           
            

        }

        Double daysFind()
        {
            try
            {
                Double tDays = totalDays;
                if ((Convert.ToDouble(year) % 4) == 0)
                {
                    leapYear = true;
                    if ((Convert.ToDouble(year) % 100) == 0)
                    {
                        if ((Convert.ToDouble(year) % 400) == 0)
                        {
                            //leap year
                            if (tDays > 366)
                            {
                                tDays = tDays - 366;
                                totalDays = tDays;
                                year = (Convert.ToDouble(year) + 1).ToString();
                                dt = "01/01/" + year;
                                dtDays = "01";
                                dtMonth = "01";
                                return daysFind();
                            }
                            else
                            {
                                return tDays;
                            }
                        }
                        else
                        {
                            //Not leap Year
                            leapYear = false;
                            if (tDays > 365)
                            {
                                tDays = tDays - 365;
                                totalDays = tDays;
                                year = (Convert.ToDouble(year) + 1).ToString();
                                dt = "01/01/" + year;
                                dtDays = "01";
                                dtMonth = "01";
                                return daysFind();
                            }
                            else
                            {
                                return tDays;
                            }
                        }

                    }
                    else
                    {
                        //Leap Year
                        leapYear = true;
                        if (tDays > 366)
                        {
                            tDays = tDays - 366;
                            totalDays = tDays;
                            year = (Convert.ToDouble(year) + 1).ToString();
                            dt = "01/01/" + year;
                            dtDays = "01";
                            dtMonth = "01";
                            return daysFind();
                        }
                        else
                        {
                            return tDays;
                        }

                    }

                }
                else
                {
                    //Not Leap Year
                    leapYear = false;
                    if (tDays > 365)
                    {
                        tDays = tDays - 365;
                        totalDays = tDays;
                        year = (Convert.ToDouble(year) + 1).ToString();
                        dt = "01/01/" + year;
                        dtDays = "01";
                        dtMonth = "01";
                        return daysFind();
                    }
                    else
                    {
                        return tDays;
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        private int currentDayofYear(int mnth,int days, int year)
        {
            int i = 1;
            int currentDay = 0;
            
            for (i=1;i<=mnth;i++)
            {
                if(i==mnth)
                {
                    currentDay = currentDay + days;
                }
                else if(i==1)
                {
                    currentDay = currentDay + 31;
                }
                else if(i==2)
                {
                    if((year%4)==0)
                    {
                        currentDay = currentDay + 29;
                    }
                    else
                    {
                        currentDay = currentDay + 28;
                    }
                }
                else if (i == 3)
                {
                       currentDay = currentDay + 31;

                }
                else if (i == 4)
                {
                    currentDay = currentDay + 30;

                }
                else if (i == 5)
                {
                    currentDay = currentDay + 31;

                }
                else if (i == 6)
                {
                    currentDay = currentDay + 30;

                }
                else if (i == 7)
                {
                    currentDay = currentDay + 31;

                }
                else if (i == 8)
                {
                    currentDay = currentDay + 31;

                }
                else if (i == 9)
                {
                    currentDay = currentDay + 30;

                }
                else if (i == 10)
                {
                    currentDay = currentDay + 31;

                }
                else if (i ==11)
                {
                    currentDay = currentDay + 30;

                }
                else if (i == 12)
                {
                    currentDay = currentDay + 31;

                }
            }
            return currentDay;
        }
        private string addDays(string startDate, Double days, int year)
        {

            string ansDate = "";
            try
            {

                if (leapYear==true)
                {
                    if (days <= 31) //Jan
                    {
                        ansDate = days.ToString("00") + "/01/" + year.ToString();
                    }
                    else if (days > 31 && days <= 60) //Feb
                    {
                        ansDate = (days - 31).ToString("00") + "/02/" + year.ToString();
                    }
                    else if (days > 60 && days <= 91) //March
                    {
                        ansDate = (days - 60).ToString("00") + "/03/" + year.ToString();
                    }
                    else if (days > 91 && days <= 121) //April
                    {
                        ansDate = (days - 91).ToString("00") + "/04/" + year.ToString();
                    }
                    else if (days > 121 && days <= 152) //May
                    {
                        ansDate = (days - 121).ToString("00") + "/05/" + year.ToString();
                    }
                    else if (days > 152 && days <= 182) //June
                    {
                        ansDate = (days - 152).ToString("00") + "/06/" + year.ToString();
                    }
                    else if (days > 182 && days <= 213) //July
                    {
                        ansDate = (days - 182).ToString("00") + "/07/" + year.ToString();
                    }
                    else if (days > 213 && days <= 244) //Aug
                    {
                        ansDate = (days - 213).ToString("00") + "/08/" + year.ToString();
                    }
                    else if (days > 244 && days <= 274) //Sep
                    {
                        ansDate = (days - 244).ToString("00") + "/09/" + year.ToString();
                    }
                    else if (days > 274 && days <= 305) //Oct
                    {
                        ansDate = (days - 274).ToString("00") + "/10/" + year.ToString();
                    }
                    else if (days > 305 && days <= 335) //Nov
                    {
                        ansDate = (days - 305).ToString("00") + "/11/" + year.ToString();
                    }
                    else if (days > 335 && days <= 366) //Dec
                    {
                        ansDate = (days - 335).ToString("00") + "/12/" + year.ToString();
                    }

                }
                else
                {
                    if (days <= 31) //Jan
                    {
                        ansDate = days.ToString("00") + "/01/" + year.ToString();
                    }
                    else if (days > 31 && days <= 59) //Feb
                    {
                        ansDate = (days - 31).ToString("00") + "/02/" + year.ToString();
                    }
                    else if (days > 59 && days <= 90) //March
                    {
                        ansDate = (days - 59).ToString("00") + "/03/" + year.ToString();
                    }
                    else if (days > 90 && days <= 120) //April
                    {
                        ansDate = (days - 90).ToString("00") + "/04/" + year.ToString();
                    }
                    else if (days > 120 && days <= 151) //May
                    {
                        ansDate = (days - 120).ToString("00") + "/05/" + year.ToString();
                    }
                    else if (days > 151 && days <= 181) //June
                    {
                        ansDate = (days - 151).ToString("00") + "/06/" + year.ToString();
                    }
                    else if (days > 181 && days <= 212) //July
                    {
                        ansDate = (days - 181).ToString("00") + "/07/" + year.ToString();
                    }
                    else if (days > 212 && days <= 243) //Aug
                    {
                        ansDate = (days - 212).ToString("00") + "/08/" + year.ToString();
                    }
                    else if (days > 243 && days <= 273) //Sep
                    {
                        ansDate = (days - 243).ToString("00") + "/09/" + year.ToString();
                    }
                    else if (days > 273 && days <= 304) //Oct
                    {
                        ansDate = (days - 273).ToString("00") + "/10/" + year.ToString();
                    }
                    else if (days > 304 && days <= 334) //Nov
                    {
                        ansDate = (days - 304).ToString("00") + "/11/" + year.ToString();
                    }
                    else if (days > 334 && days <= 365) //Dec
                    {
                        ansDate = (days - 334).ToString("00") + "/12/" + year.ToString();
                    }

                }
                return ansDate;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void txtDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

            }
            catch (Exception ex)
            { }
        }
    }
}
