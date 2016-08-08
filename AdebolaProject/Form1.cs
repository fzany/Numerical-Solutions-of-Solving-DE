using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdebolaProject
{
    public partial class Form1 : Form
    {
        private double a = 0;
        private double b = 0;      
        private double h = 0;      
        private double n = 0;

        private double asi = 0;
        private double bsi = 0;
        private double hsi = 0;
        private double nsi = 0;

        private double ab = 0;
        private double bb = 0;
        private double hb = 0;
        private double nb = 0;


        private List<double> list1 = new List<double>();
        private List<double> list2 = new List<double>();
        private List<double> list3 = new List<double>();
        private List<int> list4 = new List<int>();
        private List<double> list5 = new List<double>();

        private List<double> list1s = new List<double>();
        private List<double> list2s = new List<double>();
        private List<double> list3s = new List<double>();
        private List<int> list4s = new List<int>();
        private List<double> list5s = new List<double>();

        private List<double> list1b = new List<double>();
        private List<double> list2b = new List<double>();
        private List<double> list3b = new List<double>();
        private List<int> list4b = new List<int>();
        private List<double> list5b = new List<double>();

        private int currentList = 1;
        private int currentListsi = 1;
        private int currentListb = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void CalculateTrapeziodal(int cu)
        {
            if (cu == 1)
            {
                a = double.Parse(atextBox.Text);
                b = double.Parse(btextBox.Text);
                h = double.Parse(htextBox.Text);
                n = (b - a) / h;
                nlabel.Text = "n =    " + n.ToString();
            }
            else if (cu == 2)
            {
                //setlIst1
                double cal = 1;
                int calint2 = int.Parse(n.ToString()) + 1;
                for (int z = 0; z < calint2; z++)
                {
                    if( z == 0)
                    {
                         cal = a;
                        list1.Add(cal);
                        xlistView.Items.Add(cal.ToString());
                    }
                    else 
                    {
                        int calint = z - 1;
                        double cal2 = list1.ElementAt(calint);
                        cal = cal2 + h;
                        list1.Add(cal);
                        xlistView.Items.Add(cal.ToString());
                    }
                   
                  //listBox1.Items.Add
                }
            }
            else if (cu == 3)
            {
                //setList2
                int calint2 = int.Parse(n.ToString()) + 1;
                for (int z = 0; z <calint2; z++)
                {
                    double cal = list1.ElementAt(z) * 2;
                    list2.Add(cal);
                    xX2listView1.Items.Add(cal.ToString());
                }
            }
            else if (cu == 4)
            {
                //setList3
                int calint2 = int.Parse(n.ToString()) + 1;
                for (int z = 0; z< calint2; z++)
                {
                    double cal2 = Math.Exp(list2.ElementAt(z));
                    list3.Add(cal2);
                    exXlistView.Items.Add(cal2.ToString());
                }
            }
            else if (cu == 5)
            {
                //setList4
                int calint2 = int.Parse(n.ToString()) + 1;
                int calint3 = int.Parse(n.ToString());
                for (int z = 0; z< calint2; z++)
                {
                    if (z ==0)
                    {
                        list4.Add(1);
                        factorslistView.Items.Add(1.ToString());
                    }
                    else if(z == calint3)
                    {
                        list4.Add(1);
                        factorslistView.Items.Add(1.ToString());
                    }
                    else
                    {
                        list4.Add(2);
                        factorslistView.Items.Add(2.ToString());
                    }
                }
            }
            else if (cu == 6)
            {
                //SetList5
                double total = 0;
                int calint2 = int.Parse(n.ToString()) + 1;
                for (int z = 0; z < calint2; z++)
                {
                    double cal = list3.ElementAt(z) * list4.ElementAt(z);
                    total = total + cal;
                    list3.Add(cal);
                    ProductslistView.Items.Add(cal.ToString());
                }
                productSumlabel.Text = "Total: " + total;
                totaladdlabel.Text = "" + h + " / 2 * " + total;
                double totaltostring = h / 2 * total;
                sumtotallabel.Text = totaltostring.ToString();
                calculateNbutton.Enabled = true;
                clearbutton.Enabled = true;
                timer1.Stop();
                currentList = 0;
            }
        }
        private void calculateNbutton_Click(object sender, EventArgs e)
        {
            if (atextBox.Text != string.Empty && btextBox.Text != string.Empty && htextBox.Text != string.Empty)
            {
                timer1.Start();
                calculateNbutton.Enabled = false;
                clearbutton.Enabled = false;
            }
            else
            {
                MessageBox.Show("Input Incorrect! Check the values for a,b,h for Trapezoidal Rule", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CalculateTrapeziodal(currentList);
            currentList++;
        }

        private void clearbutton_Click(object sender, EventArgs e)
        {
            list1.Clear();
            list2.Clear();
            list3.Clear();
            list4.Clear();
            xlistView.Clear();
            xX2listView1.Clear();
            exXlistView.Clear();
            factorslistView.Clear();
            ProductslistView.Clear();
            productSumlabel.Text = " ";
            sumtotallabel.Text = " ";
            totaladdlabel.Text = " ";
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void CalculatebuttonSimp_Click(object sender, EventArgs e)
        {
            if (atextBoxSimp.Text != string.Empty && btextBoxSimp.Text != string.Empty && htextBoxSimp.Text != string.Empty)
            {
                timer2.Start();
                CalculatebuttonSimp.Enabled = false;
                ClearbuttonSimp.Enabled = false;
            }
            else
            {
                MessageBox.Show("Input Incorrect! Check the values for a,b,h for Simpson's Rule", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ClearbuttonSimp_Click(object sender, EventArgs e)
        {
            list1s.Clear();
            list2s.Clear();
            list3s.Clear();
            list4s.Clear();
            listView1Simp.Clear();
            listView2Simp.Clear();
            listView3Simp.Clear();
            listView4Simp.Clear();
            listView5Simp.Clear();
            totallabelSimp.Text = " ";
            sumtotalLabelSimp.Text = " ";
            TotaladdlabelSimp.Text = " ";
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            CalculateSimpson(currentListsi);
            currentListsi++;
        }

        private void CalculateSimpson(int cusi)
        {
            if (cusi == 1)
            {
                asi = double.Parse(atextBoxSimp.Text);
                bsi = double.Parse(btextBoxSimp.Text);
                hsi = double.Parse(htextBoxSimp.Text);
                nsi = (bsi - asi) / hsi;
                nlabelSimp.Text = "n =    " + nsi.ToString();
            }
            else if (cusi == 2)
            {
                //setlIst1
                double cal = 1;
                int calint2 = int.Parse(nsi.ToString()) + 1;
                for (int z = 0; z < calint2; z++)
                {
                    if (z == 0)
                    {
                        cal = asi;
                        list1s.Add(cal);
                        listView1Simp.Items.Add(cal.ToString());
                    }
                    else
                    {
                        int calint = z - 1;
                        double cal2 = list1s.ElementAt(calint);
                        cal = cal2 + hsi;
                        list1s.Add(cal);
                        listView1Simp.Items.Add(cal.ToString());
                    }

                    //listBox1.Items.Add
                }
            }
            else if (cusi == 3)
            {
                //setList2
                int calint2 = int.Parse(nsi.ToString()) + 1;
                for (int z = 0; z < calint2; z++)
                {
                    double cal = list1s.ElementAt(z) * 2;
                    list2s.Add(cal);
                    listView2Simp.Items.Add(cal.ToString());
                }
            }
            else if (cusi == 4)
            {
                //setList3
                int calint2 = int.Parse(nsi.ToString()) + 1;
                for (int z = 0; z < calint2; z++)
                {
                    double cal2 = Math.Exp(list2s.ElementAt(z));
                    list3s.Add(cal2);
                    listView3Simp.Items.Add(cal2.ToString());
                }
            }
            else if (cusi == 5)
            {
                //setList4
                int calint2 = int.Parse(nsi.ToString()) + 1;
                int calint3 = int.Parse(nsi.ToString());
                int calinttloop = 3;
                bool calintloopbook = false;
                for (int z = 0; z < calint2; z++)
                {
                    if (z == 0)
                    {
                        list4s.Add(1);
                        listView4Simp.Items.Add(1.ToString());
                    }
                    else if (z == calint3)
                    {
                        list4s.Add(1);
                        listView4Simp.Items.Add(1.ToString());
                    }
                    else
                    {
                        if(calinttloop == 3 && calintloopbook == false)
                        {
                            list4s.Add(3);
                            listView4Simp.Items.Add(3.ToString());
                            calinttloop = 3;
                            calintloopbook = true;
                        }
                        else if (calinttloop == 3 && calintloopbook == true)
                        {
                            list4s.Add(3);
                            listView4Simp.Items.Add(3.ToString());
                            calinttloop = 2;
                            calintloopbook = false;
                        }
                        else if (calinttloop == 2)
                        {
                            list4s.Add(2);
                            listView4Simp.Items.Add(2.ToString());
                            calinttloop = 3;
                            calintloopbook = false;
                        }
                    }
                }
            }
            else if (cusi == 6)
            {
                //SetList5
                double total = 0;
                int calint2 = int.Parse(nsi.ToString()) + 1;
                for (int z = 0; z < calint2; z++)
                {
                    double cal = list3s.ElementAt(z) * list4s.ElementAt(z);
                    total = total + cal;
                    list5s.Add(cal);
                    listView5Simp.Items.Add(cal.ToString());
                }
                totallabelSimp.Text = "Total: " + total;
                TotaladdlabelSimp.Text = "" + " 3 ( " + hsi + " )" + " / 8 * " + total;
                double totaltostringSimp = 3 * (hsi / 8) * total;
                sumtotalLabelSimp.Text = totaltostringSimp.ToString();
                CalculatebuttonSimp.Enabled = true;
                ClearbuttonSimp.Enabled = true;
                timer2.Stop();
                currentListsi = 0;
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {
            
        }
        //third method(Bool's) starts from here

        private void timer3_Tick(object sender, EventArgs e)
        {
            CalculateBool(currentListb);
            currentListb++;
        }

        private void CalculateBool(int cubool)
        {
            if (cubool == 1)
            {
                ab = double.Parse(atextBoxbool.Text);
                bb = double.Parse(btextBoxbool.Text);
                hb = double.Parse(htextBoxbool.Text);
                nb = (bb - ab) / hb;
                nlabelbool.Text = "n =    " + nb.ToString();
            }
            else if (cubool == 2)
            {
                //setlIst1
                double cal = 1;
                int calint2 = int.Parse(nb.ToString()) + 1;
                for (int z = 0; z < calint2; z++)
                {
                    if (z == 0)
                    {
                        cal = ab;
                        list1b.Add(cal);
                        listView1bool.Items.Add(cal.ToString());
                    }
                    else
                    {
                        int calint = z - 1;
                        double cal2 = list1b.ElementAt(calint);
                        cal = cal2 + hb;
                        list1b.Add(cal);
                        listView1bool.Items.Add(cal.ToString());
                    }

                    //listBox1.Items.Add
                }
            }
            else if (cubool == 3)
            {
                //setList2
                int calint2 = int.Parse(nb.ToString()) + 1;
                for (int z = 0; z < calint2; z++)
                {
                    double cal = list1b.ElementAt(z) * 2;
                    list2b.Add(cal);
                    listView2bool.Items.Add(cal.ToString());
                }
            }
            else if (cubool == 4)
            {
                //setList3
                int calint2 = int.Parse(nb.ToString()) + 1;
                for (int z = 0; z < calint2; z++)
                {
                    double cal2 = Math.Exp(list2b.ElementAt(z));
                    list3b.Add(cal2);
                    listView3bool.Items.Add(cal2.ToString());
                }
            }
            else if (cubool == 5)
            {
                //setList4
                int calint2 = int.Parse(nb.ToString()) + 1;
                int calint3 = int.Parse(nb.ToString());
                int calinttloop = 32;
                for (int z = 0; z < calint2; z++)
                {
                    if (z == 0)
                    {
                        list4b.Add(7);
                        listView4bool.Items.Add(7.ToString());
                    }
                    else if (z == calint3)
                    {
                        list4b.Add(7);
                        listView4bool.Items.Add(7.ToString());
                    }
                    else
                    {
                        if (calinttloop == 32)
                        {
                            list4b.Add(32);
                            listView4bool.Items.Add(32.ToString());
                            calinttloop = 12;
                        }
                        else if (calinttloop == 12)
                        {
                            list4b.Add(12);
                            listView4bool.Items.Add(12.ToString());
                            calinttloop = 32;
                        }
                    }
                }
            }
            else if (cubool == 6)
            {
                //SetList5
                double total = 0;
                int calint2 = int.Parse(nb.ToString()) + 1;
                for (int z = 0; z < calint2; z++)
                {
                    double cal = list3b.ElementAt(z) * list4b.ElementAt(z);
                    total = total + cal;
                    list5b.Add(cal);
                    listView5bool.Items.Add(cal.ToString());
                }
                totallabelbool.Text = "Total: " + total;
                totallabel31booll.Text = "" + " 2 ( " + hb + " )" + " / 45 * " + total;
                double totaltostringbool = 2 * (hb / 45) * total;
                finaltotallabelbool.Text = totaltostringbool.ToString();
                Calculatbuttonbool.Enabled = true;
                Clearbuttonbool.Enabled = true;
                timer3.Stop();
                currentListb = 0;
            }
        }

        private void Calculatbuttonbool_Click(object sender, EventArgs e)
        {
            if (atextBoxbool.Text != string.Empty && btextBoxbool.Text != string.Empty && htextBox.Text != string.Empty)
            {
                timer3.Start();
                Calculatbuttonbool.Enabled = false;
                Clearbuttonbool.Enabled = false;
            }
            else
            {
                MessageBox.Show("Input Incorrect! Check the values for a,b,h for Bool's Rule", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Clearbuttonbool_Click(object sender, EventArgs e)
        {
            list1b.Clear();
            list2b.Clear();
            list3b.Clear();
            list4b.Clear();
            listView1bool.Clear();
            listView2bool.Clear();
            listView3bool.Clear();
            listView4bool.Clear();
            listView5bool.Clear();
            totallabelbool.Text = " ";
            totallabel31booll.Text = " ";
            finaltotallabelbool.Text = " ";
        }

        private void GotoSimpsonbutton_Click(object sender, EventArgs e)
        {

        }
    }
}
