﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tip.V2
{
    public partial class tip : Form
    {
        // Please modify card tax persent. If servers can take 95% of the card tip, TaxPercent needs to be 5.
        public int TaxPercent = 5;

        // Please modify the ratio servers and kitchen tip.
        // If servers can take 60& of total tips and kitchen workers take 40%, ServerTipPercent and KitchenTipPercent need to be 60, 40 each.
        public int ServerTipPercent = 60;
        public int KitchenTipPercent = 40;





        public double cash1Total = 0, card1Total = 0, cash2Total = 0, card2Total = 0, cash3Total = 0, card3Total = 0, cash4Total = 0, card4Total = 0, p1Total = 0, p2Total = 0, p3Total = 0, p4Total = 0, KitchenTotal = 0, sum = 0;
        public double c1hrs = 11, c2hrs = 0, c3hrs = 0, c4hrs = 0, c5hrs = 0, c6hrs = 0, dwTip = 0, totalHours = 0;


        public tip()
        {
            InitializeComponent();
        }

        private void p1cash_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (p1cash.Text != "" && p1cash.Text != null)
                {
                    cash1Total = Convert.ToDouble(p1cash.Text);
                    card1Total = Convert.ToDouble(p1card.Text) * (100-TaxPercent)/100;
                    p1tip.Text = String.Format("{0:0.00}", RoundNumber(Math.Round((cash1Total + card1Total) * ServerTipPercent/100 / Convert.ToDouble(p1nos.Text), 2)));

                    p1Total = cash1Total + card1Total;
                    KitchenTotal = (p1Total + p2Total + p3Total + p4Total) * KitchenTipPercent/100;
                    calculateKitchen();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter only number.");
            }
        }

        private void p1card_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (p1card.Text != "" && p1card.Text != null)
                {
                    cash1Total = Convert.ToDouble(p1cash.Text);
                    card1Total = Convert.ToDouble(p1card.Text) * (100-TaxPercent)/100;
                    p1tip.Text = String.Format("{0:0.00}", RoundNumber(Math.Round((cash1Total + card1Total) * ServerTipPercent/100 / Convert.ToDouble(p1nos.Text), 2)));

                    p1Total = cash1Total + card1Total;

                    if(p2Total != 0)
                    {
                        cash2Total = Convert.ToDouble(p2cash.Text);
                        card2Total = (Convert.ToDouble(p2card.Text) - Convert.ToDouble(p1card.Text)) * (100-TaxPercent)/100;
                        p2tip.Text = String.Format("{0:0.00}", RoundNumber(Math.Round((cash2Total + card2Total) * ServerTipPercent/100 / Convert.ToDouble(p2nos.Text), 2)));

                        p2Total = cash2Total + card2Total;
                    }

                    if(p3Total != 0)
                    {
                        cash3Total = Convert.ToDouble(p3cash.Text);
                        card3Total = (Convert.ToDouble(p3card.Text) - Convert.ToDouble(p2card.Text)) * (100-TaxPercent)/100;
                        p3tip.Text = String.Format("{0:0.00}", RoundNumber(Math.Round((cash3Total + card3Total) * ServerTipPercent/100 / Convert.ToDouble(p3nos.Text), 2)));

                        p3Total = cash3Total + card3Total;
                    }

                    if (p4Total != 0)
                    {
                        cash4Total = Convert.ToDouble(p4cash.Text);
                        card4Total = (Convert.ToDouble(p4card.Text) - Convert.ToDouble(p3card.Text)) * (100-TaxPercent)/100;
                        p4tip.Text = String.Format("{0:0.00}", RoundNumber(Math.Round((cash4Total + card4Total) * ServerTipPercent/100 / Convert.ToDouble(p4nos.Text), 2)));

                        p4Total = cash4Total + card4Total;
                    }

                    KitchenTotal = (p1Total + p2Total + p3Total + p4Total) * KitchenTipPercent/100;
                    calculateKitchen();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter only number.");
            }
        }

        private void p1nos_TextChanged(object sender, EventArgs e)
        {
            try
            {
                p1Total = cash1Total + card1Total;

                if (p1nos.Text == "" || p1nos.Text == null)
                    p1tip.Text = String.Format("{0:0.00}", RoundNumber(Math.Round(p1Total * ServerTipPercent/100, 2)));
                else
                    p1tip.Text = String.Format("{0:0.00}", RoundNumber(Math.Round(p1Total * ServerTipPercent/100 / Convert.ToDouble(p1nos.Text), 2)));

                KitchenTotal = (p1Total + p2Total + p3Total + p4Total) * KitchenTipPercent/100;
                calculateKitchen();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter only number.");
            }
        }

        private void p2cash_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (p2cash.Text != "" && p2cash.Text != null)
                {
                    cash2Total = Convert.ToDouble(p2cash.Text);
                    card2Total = (Convert.ToDouble(p2card.Text) - Convert.ToDouble(p1card.Text)) * (100-TaxPercent)/100;
                    p2tip.Text = String.Format("{0:0.00}", RoundNumber(Math.Round((cash2Total + card2Total) * ServerTipPercent/100 / Convert.ToDouble(p2nos.Text), 2)));

                    p2Total = cash2Total + card2Total;
                    KitchenTotal = (p1Total + p2Total + p3Total + p4Total) * KitchenTipPercent/100;
                    calculateKitchen();
                }
            }
            catch (Exception ex) { MessageBox.Show("Please enter only number."); }
        }

        private void p2card_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (p2card.Text != "" && p2card.Text != null)
                {
                    cash2Total = Convert.ToDouble(p2cash.Text);
                    card2Total = (Convert.ToDouble(p2card.Text) - Convert.ToDouble(p1card.Text)) * (100-TaxPercent)/100;
                    p2tip.Text = String.Format("{0:0.00}", RoundNumber(Math.Round((cash2Total + card2Total) * ServerTipPercent/100 / Convert.ToDouble(p2nos.Text), 2)));

                    p2Total = cash2Total + card2Total;

                    if(p3Total != 0)
                    {
                        cash3Total = Convert.ToDouble(p3cash.Text);
                        card3Total = (Convert.ToDouble(p3card.Text) - Convert.ToDouble(p2card.Text)) * (100-TaxPercent)/100;
                        p3tip.Text = String.Format("{0:0.00}", RoundNumber(Math.Round((cash3Total + card3Total) * ServerTipPercent/100 / Convert.ToDouble(p3nos.Text), 2)));

                        p3Total = cash3Total + card3Total;
                    }

                    if (p4Total != 0)
                    {
                        cash4Total = Convert.ToDouble(p4cash.Text);
                        card4Total = (Convert.ToDouble(p4card.Text) - Convert.ToDouble(p3card.Text)) * (100-TaxPercent)/100;
                        p4tip.Text = String.Format("{0:0.00}", RoundNumber(Math.Round((cash4Total + card4Total) * ServerTipPercent/100 / Convert.ToDouble(p4nos.Text), 2)));

                        p4Total = cash4Total + card4Total;
                    }

                    KitchenTotal = (p1Total + p2Total + p3Total + p4Total) * KitchenTipPercent/100;
                    calculateKitchen();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter only number.");
            }
        }

        private void p2nos_TextChanged(object sender, EventArgs e)
        {
            try
            {
                p2Total = cash2Total + card2Total;

                if (p2nos.Text == "" || p2nos.Text == null)
                    p2tip.Text = String.Format("{0:0.00}", RoundNumber(Math.Round(p2Total * ServerTipPercent/100, 2)));
                else
                    p2tip.Text = String.Format("{0:0.00}", RoundNumber(Math.Round(p2Total * ServerTipPercent/100 / Convert.ToDouble(p2nos.Text), 2)));

                KitchenTotal = (p1Total + p2Total + p3Total + p4Total) * KitchenTipPercent/100;
                calculateKitchen();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter only number.");
            }
        }

        private void p3cash_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (p3cash.Text != "" && p3cash.Text != null)
                {
                    cash3Total = Convert.ToDouble(p3cash.Text);
                    card3Total = (Convert.ToDouble(p3card.Text) - Convert.ToDouble(p2card.Text)) * (100-TaxPercent)/100;
                    p3tip.Text = String.Format("{0:0.00}", RoundNumber(Math.Round((cash3Total + card3Total) * ServerTipPercent/100 / Convert.ToDouble(p3nos.Text), 2)));

                    p3Total = cash3Total + card3Total;
                    KitchenTotal = (p1Total + p2Total + p3Total + p4Total) * KitchenTipPercent/100;
                    calculateKitchen();
                }
            }
            catch (Exception ex) { MessageBox.Show("Please enter only number."); }
        }

        private void p3card_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (p3card.Text != "" && p3card.Text != null)
                {
                    cash3Total = Convert.ToDouble(p3cash.Text);
                    card3Total = (Convert.ToDouble(p3card.Text) - Convert.ToDouble(p2card.Text)) * (100-TaxPercent)/100;
                    p3tip.Text = String.Format("{0:0.00}", RoundNumber(Math.Round((cash3Total + card3Total) * ServerTipPercent/100 / Convert.ToDouble(p3nos.Text), 2)));

                    p3Total = cash3Total + card3Total;

                    if (p4Total != 0)
                    {
                        cash4Total = Convert.ToDouble(p4cash.Text);
                        card4Total = (Convert.ToDouble(p4card.Text) - Convert.ToDouble(p3card.Text)) * (100-TaxPercent)/100;
                        p4tip.Text = String.Format("{0:0.00}", RoundNumber(Math.Round((cash4Total + card4Total) * ServerTipPercent/100 / Convert.ToDouble(p4nos.Text), 2)));

                        p4Total = cash4Total + card4Total;
                    }

                    KitchenTotal = (p1Total + p2Total + p3Total + p4Total) * KitchenTipPercent/100;
                    calculateKitchen();
                }
            }
            catch (Exception ex) { MessageBox.Show("Please enter only number."); }
        }

        private void p3nos_TextChanged(object sender, EventArgs e)
        {
            try
            {
                p3Total = cash3Total + card3Total;

                if (p3nos.Text == "" || p3nos.Text == null)
                    p3tip.Text = String.Format("{0:0.00}", RoundNumber(Math.Round(p3Total * ServerTipPercent/100, 2)));
                else
                    p3tip.Text = String.Format("{0:0.00}", RoundNumber(Math.Round(p3Total * ServerTipPercent/100 / Convert.ToDouble(p3nos.Text), 2)));

                KitchenTotal = (p1Total + p2Total + p3Total + p4Total) * KitchenTipPercent/100;
                calculateKitchen();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter only number.");
            }
        }

        private void p4cash_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (p4card.Text != "" && p4card.Text != null)
                {
                    cash4Total = Convert.ToDouble(p4cash.Text);
                    card4Total = (Convert.ToDouble(p4card.Text) - Convert.ToDouble(p3card.Text)) * (100-TaxPercent)/100;
                    p4tip.Text = String.Format("{0:0.00}", RoundNumber(Math.Round((cash4Total + card4Total) * ServerTipPercent/100 / Convert.ToDouble(p4nos.Text), 2)));

                    p4Total = cash4Total + card4Total;
                    KitchenTotal = (p1Total + p2Total + p3Total + p4Total) * KitchenTipPercent/100;
                    calculateKitchen();
                }
            }
            catch (Exception ex) { MessageBox.Show("Please enter only number."); }
        }

        private void p4card_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (p4card.Text != "" && p4card.Text != null)
                {
                    cash4Total = Convert.ToDouble(p4cash.Text);
                    card4Total = (Convert.ToDouble(p4card.Text) - Convert.ToDouble(p3card.Text)) * (100-TaxPercent)/100;
                    p4tip.Text = String.Format("{0:0.00}", RoundNumber(Math.Round((cash4Total + card4Total) * ServerTipPercent/100 / Convert.ToDouble(p4nos.Text), 2)));

                    p4Total = cash4Total + card4Total;
                    KitchenTotal = (p1Total + p2Total + p3Total + p4Total) * KitchenTipPercent/100;
                    calculateKitchen();
                }
            }
            catch (Exception ex) { MessageBox.Show("Please enter only number."); }
        }

        private void p4nos_TextChanged(object sender, EventArgs e)
        {
            try
            {
                p4Total = cash4Total + card4Total;

                if (p4nos.Text == "" || p4nos.Text == null)
                    p4tip.Text = String.Format("{0:0.00}", RoundNumber(Math.Round(p4Total * ServerTipPercent/100, 2)));
                else
                    p4tip.Text = String.Format("{0:0.00}", RoundNumber(Math.Round(p4Total * ServerTipPercent/100 / Convert.ToDouble(p4nos.Text), 2)));

                KitchenTotal = (p1Total + p2Total + p3Total + p4Total) * KitchenTipPercent/100;
                calculateKitchen();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter only number.");
            }
        }

        private void dwh_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dwh.Text != "" && dwh.Text != null)
                {
                    calculateKitchen();
                }
            }
            catch (Exception ex) { MessageBox.Show("Please enter only number."); }
                
        }

        private void c1h_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (c1h.Text != "" && c1h.Text != null)
                {
                    c1hrs = Convert.ToDouble(c1h.Text);

                    calculateKitchen();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter only number.");
            }
        }

        private void c2h_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (c2h.Text != "" && c2h.Text != null)
                {
                    c2hrs = Convert.ToDouble(c2h.Text);

                    calculateKitchen();
                }
            }
            catch (Exception ex) { MessageBox.Show("Please enter only number."); }
                
        }

        private void c3h_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (c3h.Text != "" && c3h.Text != null)
                {
                    c3hrs = Convert.ToDouble(c3h.Text);

                    calculateKitchen();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter only number.");
            }
                
        }

        private void c4h_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (c4h.Text != "" && c4h.Text != null)
                {
                    c4hrs = Convert.ToDouble(c4h.Text);

                    calculateKitchen();
                }
            }
            catch (Exception ex) { MessageBox.Show("Please enter only number."); }
                
        }

        private void c5h_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (c5h.Text != "" && c5h.Text != null)
                {
                    c5hrs = Convert.ToDouble(c5h.Text);

                    calculateKitchen();
                }
            }
            catch (Exception ex) { MessageBox.Show("Please enter only number."); }
                
        }

        private void c6h_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (c6h.Text != "" && c6h.Text != null)
                {
                    c6hrs = Convert.ToDouble(c6h.Text);

                    calculateKitchen();
                }
            }
            catch (Exception ex) { MessageBox.Show("Please enter only number."); }
                
        }

        public void calculateKitchen()
        {
            double totalHour = c1hrs + c2hrs + c3hrs + c4hrs + c5hrs + c5hrs + Convert.ToDouble(dwh.Text);

            if (KitchenTotal / totalHour >= 2)
            {
                dwTip = 2 * Convert.ToDouble(dwh.Text);
                dwtip.Text = (dwTip).ToString();
                
            }
            else
            {

                dwTip = Math.Round(KitchenTotal / totalHour * Convert.ToDouble(dwh.Text), 2);
                dwtip.Text = String.Format("{0:0.00}", RoundNumber(dwTip));
            }

            totalHours = c1hrs + c2hrs + c3hrs + c4hrs + c5hrs + c6hrs;
            c1tip.Text = String.Format("{0:0.00}", RoundNumber(Math.Round(((KitchenTotal - dwTip) / totalHours * c1hrs), 2)));
            c2tip.Text = String.Format("{0:0.00}", RoundNumber(Math.Round(((KitchenTotal - dwTip) / totalHours * c2hrs), 2)));
            c3tip.Text = String.Format("{0:0.00}", RoundNumber(Math.Round(((KitchenTotal - dwTip) / totalHours * c3hrs), 2)));
            c4tip.Text = String.Format("{0:0.00}", RoundNumber(Math.Round(((KitchenTotal - dwTip) / totalHours * c4hrs), 2)));
            c5tip.Text = String.Format("{0:0.00}", RoundNumber(Math.Round(((KitchenTotal - dwTip) / totalHours * c5hrs), 2)));
            c6tip.Text = String.Format("{0:0.00}", RoundNumber(Math.Round(((KitchenTotal - dwTip) / totalHours * c6hrs), 2)));
        }

        public double RoundNumber(double Tip)
        {
            int tip = Convert.ToInt32(Tip * 100);

            if (tip % 10 == 1 || tip % 10 == 6)
                tip -= 1;
            else if (tip % 10 == 2 || tip % 10 == 7)
                tip -= 2;
            else if (tip % 10 == 3 || tip % 10 == 8)
                tip += 2;
            else if (tip % 10 == 4 || tip % 10 == 9)
                tip += 1;

            return Convert.ToDouble(tip) /100;
        }

        private void btnP1_Click(object sender, EventArgs e)
        {
            double part1 = Convert.ToDouble(p1tip.Text);
            sum += part1;
            txtSum.Text = String.Format("{0:0.00}", sum);
        }

        private void btnP2_Click(object sender, EventArgs e)
        {
            double part2 = Convert.ToDouble(p2tip.Text);
            sum += part2;
            txtSum.Text = String.Format("{0:0.00}", sum);
        }

        private void btnP3_Click(object sender, EventArgs e)
        {
            double part3 = Convert.ToDouble(p3tip.Text);
            sum += part3;
            txtSum.Text = String.Format("{0:0.00}", sum);
        }

        private void btnP4_Click(object sender, EventArgs e)
        {
            double part4 = Convert.ToDouble(p4tip.Text);
            sum += part4;
            txtSum.Text = String.Format("{0:0.00}", sum);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            sum = 0;
            txtSum.Text = "0";
        }
    }
}
