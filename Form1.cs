using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool c_switch = true; // true = black, false = white... somewhat
        bool black_mill = false;
        bool white_mill = false;
        bool dev = false;
        int turns_combined = 18;
        int turns = 0;
        int black_turns = 0;
        int white_turns = 0;
        int counter = 2;
        string name_btn;
        Point move;

        private void b_rowEnabledDisabled() //Enables the visibility of the small buttons
        {
            if (turns_combined <= 0)
            {
                foreach (Control c1 in Controls)
                {
                    if (c1 is Button && c1.Height == c1.Width)
                    {
                        Button bButton = (Button)c1;
                        foreach (Control c2 in Controls)
                        {
                            if (c2 is Button && c2.Height != c2.Width)
                            {
                                Button sButton = (Button)c2;                             
                                if (c_switch)
                                {
                                    if (sButton.Bounds.IntersectsWith(bButton.Bounds) && bButton.BackColor == Color.White) sButton.Visible = true;
                                    else if (sButton.Bounds.IntersectsWith(bButton.Bounds) && bButton.BackColor != Color.White) sButton.Visible = false;
                                }
                                else
                                {
                                    if (sButton.Bounds.IntersectsWith(bButton.Bounds) && bButton.BackColor == Color.Black) sButton.Visible = true;
                                    else if (sButton.Bounds.IntersectsWith(bButton.Bounds) && bButton.BackColor != Color.Black) sButton.Visible = false;
                                }                                
                           }
                        }
                    }
                }
            }
        }

        private void b_rowEnabledDisabled2()
        {
            if (turns_combined <= 0)
            {
                foreach (Control c1 in Controls)
                {
                    if (c1 is Button && c1.Height == c1.Width)
                    {
                        Button bButton = (Button)c1;
                        foreach (Control c2 in Controls)
                        {
                            if (c2 is Button && c2.Height != c2.Width)
                            {
                                Button sButton = (Button)c2;
                                string b_row1 = sButton.Tag.ToString();
                                string b_row2 = bButton.Tag.ToString();
                                if (b_row2.Contains(b_row1) && bButton.BackColor != Color.Transparent) sButton.Visible = false;                               
                            }
                        }
                    }
                }
            }
        }

        private void b_rowClick(object sender, EventArgs e) //Makes a turn (stage 2)
        {
            turns_combined--;
            turns++;
            if (turns_combined <= 0)
            {
                Button sButton = (Button)sender;
                name_btn = sButton.Name;
                counter--;
                string b_row1 = sButton.Tag.ToString();
                foreach (Control c in Controls)
                {
                    try
                    {
                        Button bButton = (Button)c;
                        if (bButton.Width == bButton.Height)
                        {
                            string b_row2 = bButton.Tag.ToString();
                            if (sButton.Bounds.IntersectsWith(bButton.Bounds) && counter == 1) { bButton.BackColor = Color.Transparent; timer.Start();}
                            else if (b_row2.Contains(b_row1) && counter == 0)
                            {
                                c_switch = !c_switch;
                                if (c_switch) bButton.BackColor = Color.Black;
                                else bButton.BackColor = Color.White;
                                counter = 2;
                            }
                        }
                    }
                    catch { }
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
            {
                if (c is Button && c.Height != c.Width)
                {
                    Button b = (Button)c;
                    if (name_btn == b.Name) { b.Visible = true; b.PerformClick(); b.Visible = false;}
                }
                timer.Stop();
            }
        }

        private void enableDisableMill()
        {
            foreach (Control c in Controls)
            {
                if (c is Button)
                {
                    Button b = (Button)c;
                    if (black_mill)
                    {
                        if (b.BackColor == Color.White) b.Enabled = true;
                        if (b.BackColor == Color.Transparent) b.Enabled = false;
                        MillDisabledBlack();
                        MillDisabledWhite();
                        if (!a_tl.Enabled && !a_tc.Enabled && !a_tr.Enabled && !a_ml.Enabled && !a_mr.Enabled && !a_bl.Enabled && !a_bc.Enabled && !a_br.Enabled &&
                            !b_tl.Enabled && !b_tc.Enabled && !b_tr.Enabled && !b_ml.Enabled && !b_mr.Enabled && !b_bl.Enabled && !b_bc.Enabled && !b_br.Enabled &&
                            !c_tl.Enabled && !c_tc.Enabled && !c_tr.Enabled && !c_ml.Enabled && !c_mr.Enabled && !c_bl.Enabled && !c_bc.Enabled && !c_br.Enabled)
                        {
                            if (a_tl.BackColor == Color.White) a_tl.Enabled = true;
                            if (a_tc.BackColor == Color.White) a_tc.Enabled = true;
                            if (a_tr.BackColor == Color.White) a_tr.Enabled = true;
                            if (a_ml.BackColor == Color.White) a_ml.Enabled = true;
                            if (a_mr.BackColor == Color.White) a_mr.Enabled = true;
                            if (a_bl.BackColor == Color.White) a_bl.Enabled = true;
                            if (a_bc.BackColor == Color.White) a_bc.Enabled = true;
                            if (a_br.BackColor == Color.White) a_br.Enabled = true;
                            if (b_tl.BackColor == Color.White) b_tl.Enabled = true;
                            if (b_tc.BackColor == Color.White) b_tc.Enabled = true;
                            if (b_tr.BackColor == Color.White) b_tr.Enabled = true;
                            if (b_ml.BackColor == Color.White) b_ml.Enabled = true;
                            if (b_mr.BackColor == Color.White) b_mr.Enabled = true;
                            if (b_bl.BackColor == Color.White) b_bl.Enabled = true;
                            if (b_bc.BackColor == Color.White) b_bc.Enabled = true;
                            if (b_br.BackColor == Color.White) b_br.Enabled = true;
                            if (c_tl.BackColor == Color.White) c_tl.Enabled = true;
                            if (c_tc.BackColor == Color.White) c_tc.Enabled = true;
                            if (c_tr.BackColor == Color.White) c_tr.Enabled = true;
                            if (c_ml.BackColor == Color.White) c_ml.Enabled = true;
                            if (c_mr.BackColor == Color.White) c_mr.Enabled = true;
                            if (c_bl.BackColor == Color.White) c_bl.Enabled = true;
                            if (c_bc.BackColor == Color.White) c_bc.Enabled = true;
                            if (c_br.BackColor == Color.White) c_br.Enabled = true;
                        }
                    }
                    else if (white_mill)
                    {
                        if (b.BackColor == Color.Black) b.Enabled = true;
                        if (b.BackColor == Color.Transparent) b.Enabled = false;
                        MillDisabledBlack();
                        MillDisabledWhite();
                        if (!a_tl.Enabled && !a_tc.Enabled && !a_tr.Enabled && !a_ml.Enabled && !a_mr.Enabled && !a_bl.Enabled && !a_bc.Enabled && !a_br.Enabled &&
                            !b_tl.Enabled && !b_tc.Enabled && !b_tr.Enabled && !b_ml.Enabled && !b_mr.Enabled && !b_bl.Enabled && !b_bc.Enabled && !b_br.Enabled &&
                            !c_tl.Enabled && !c_tc.Enabled && !c_tr.Enabled && !c_ml.Enabled && !c_mr.Enabled && !c_bl.Enabled && !c_bc.Enabled && !c_br.Enabled)
                        {
                            if (a_tl.BackColor == Color.Black) a_tl.Enabled = true;
                            if (a_tc.BackColor == Color.Black) a_tc.Enabled = true;
                            if (a_tr.BackColor == Color.Black) a_tr.Enabled = true;
                            if (a_ml.BackColor == Color.Black) a_ml.Enabled = true;
                            if (a_mr.BackColor == Color.Black) a_mr.Enabled = true;
                            if (a_bl.BackColor == Color.Black) a_bl.Enabled = true;
                            if (a_bc.BackColor == Color.Black) a_bc.Enabled = true;
                            if (a_br.BackColor == Color.Black) a_br.Enabled = true;
                            if (b_tl.BackColor == Color.Black) b_tl.Enabled = true;
                            if (b_tc.BackColor == Color.Black) b_tc.Enabled = true;
                            if (b_tr.BackColor == Color.Black) b_tr.Enabled = true;
                            if (b_ml.BackColor == Color.Black) b_ml.Enabled = true;
                            if (b_mr.BackColor == Color.Black) b_mr.Enabled = true;
                            if (b_bl.BackColor == Color.Black) b_bl.Enabled = true;
                            if (b_bc.BackColor == Color.Black) b_bc.Enabled = true;
                            if (b_br.BackColor == Color.Black) b_br.Enabled = true;
                            if (c_tl.BackColor == Color.Black) c_tl.Enabled = true;
                            if (c_tc.BackColor == Color.Black) c_tc.Enabled = true;
                            if (c_tr.BackColor == Color.Black) c_tr.Enabled = true;
                            if (c_ml.BackColor == Color.Black) c_ml.Enabled = true;
                            if (c_mr.BackColor == Color.Black) c_mr.Enabled = true;
                            if (c_bl.BackColor == Color.Black) c_bl.Enabled = true;
                            if (c_bc.BackColor == Color.Black) c_bc.Enabled = true;
                            if (c_br.BackColor == Color.Black) c_br.Enabled = true;
                        }
                    }
                    else
                    {
                        if (turns_combined >= 0)
                        {
                            if (b.BackColor != Color.Transparent) b.Enabled = false;
                            else if (b.BackColor == Color.Transparent) b.Enabled = true;
                            MillDisabledBlack();
                            MillDisabledWhite();
                        }
                        else
                        {
                            if (black_turns < 4)
                            {
                                if (b.BackColor == Color.Transparent) b.Enabled = true;
                                if (c_switch)
                                {
                                    if (b.BackColor == Color.Black) b.Enabled = false;
                                    MillDisabledBlack();
                                }
                                else
                                {
                                    if (b.BackColor == Color.Black) b.Enabled = true;
                                    MillDisabledWhite();
                                }
                            }
                            if (white_turns < 4)
                            {
                                if (b.BackColor == Color.Transparent) b.Enabled = true;
                                if (c_switch)
                                {
                                    if (b.BackColor == Color.White) b.Enabled = true;
                                    MillDisabledBlack();
                                }
                                else
                                {
                                    if (b.BackColor == Color.White) b.Enabled = false;
                                    MillDisabledWhite();
                                }
                            }
                            if (black_turns > 3)
                            {
                                if (b.BackColor == Color.Black) b.Enabled = false;
                                else if (b.BackColor == Color.Transparent) b.Enabled = true;
                                if (c_switch) MillDisabledBlack();
                                else MillDisabledWhite();
                            }
                            if (white_turns > 3)
                            {
                                if (b.BackColor == Color.White) b.Enabled = false;
                                else if (b.BackColor == Color.Transparent) b.Enabled = true;
                                if (c_switch) MillDisabledBlack();
                                else MillDisabledWhite();
                            }
                        }
                    }
                }
            }
        }

        private void MillDisabledBlack()
        {

            if (a_tl.BackColor == a_tc.BackColor && a_tc.BackColor == a_tr.BackColor && a_tc.BackColor != Color.Transparent && a_tc.BackColor == Color.Black) { a_tl.Enabled = false; a_tc.Enabled = false; a_tr.Enabled = false; }
            if (b_tl.BackColor == b_tc.BackColor && b_tc.BackColor == b_tr.BackColor && b_tc.BackColor != Color.Transparent && b_tc.BackColor == Color.Black) { b_tl.Enabled = false; b_tc.Enabled = false; b_tr.Enabled = false; }
            if (c_tl.BackColor == c_tc.BackColor && c_tc.BackColor == c_tr.BackColor && c_tc.BackColor != Color.Transparent && c_tc.BackColor == Color.Black) { c_tl.Enabled = false; c_tc.Enabled = false; c_tr.Enabled = false; }
            if (a_ml.BackColor == b_ml.BackColor && b_ml.BackColor == c_ml.BackColor && b_ml.BackColor != Color.Transparent && b_ml.BackColor == Color.Black) { a_ml.Enabled = false; b_ml.Enabled = false; c_ml.Enabled = false; }
            if (a_mr.BackColor == b_mr.BackColor && b_mr.BackColor == c_mr.BackColor && b_mr.BackColor != Color.Transparent && b_mr.BackColor == Color.Black) { a_mr.Enabled = false; b_mr.Enabled = false; c_mr.Enabled = false; }
            if (a_bl.BackColor == a_bc.BackColor && a_bc.BackColor == a_br.BackColor && a_bc.BackColor != Color.Transparent && a_bc.BackColor == Color.Black) { a_bl.Enabled = false; a_bc.Enabled = false; a_br.Enabled = false; }
            if (b_bl.BackColor == b_bc.BackColor && b_bc.BackColor == b_br.BackColor && b_bc.BackColor != Color.Transparent && b_bc.BackColor == Color.Black) { b_bl.Enabled = false; b_bc.Enabled = false; b_br.Enabled = false; }
            if (c_bl.BackColor == c_bc.BackColor && c_bc.BackColor == c_br.BackColor && c_bc.BackColor != Color.Transparent && c_bc.BackColor == Color.Black) { c_bl.Enabled = false; c_bc.Enabled = false; c_br.Enabled = false; }
            if (a_tl.BackColor == a_ml.BackColor && a_ml.BackColor == a_bl.BackColor && a_ml.BackColor != Color.Transparent && a_ml.BackColor == Color.Black) { a_tl.Enabled = false; a_ml.Enabled = false; a_bl.Enabled = false; }
            if (b_tl.BackColor == b_ml.BackColor && b_ml.BackColor == b_bl.BackColor && b_ml.BackColor != Color.Transparent && b_ml.BackColor == Color.Black) { b_tl.Enabled = false; b_ml.Enabled = false; b_bl.Enabled = false; }
            if (c_tl.BackColor == c_ml.BackColor && c_ml.BackColor == c_bl.BackColor && c_ml.BackColor != Color.Transparent && c_ml.BackColor == Color.Black) { c_tl.Enabled = false; c_ml.Enabled = false; c_bl.Enabled = false; }
            if (a_tc.BackColor == b_tc.BackColor && b_tc.BackColor == c_tc.BackColor && b_tc.BackColor != Color.Transparent && b_tc.BackColor == Color.Black) { a_tc.Enabled = false; b_tc.Enabled = false; c_tc.Enabled = false; }
            if (a_bc.BackColor == b_bc.BackColor && b_bc.BackColor == c_bc.BackColor && b_bc.BackColor != Color.Transparent && b_bc.BackColor == Color.Black) { a_bc.Enabled = false; b_bc.Enabled = false; c_bc.Enabled = false; }
            if (a_tr.BackColor == a_mr.BackColor && a_mr.BackColor == a_br.BackColor && a_mr.BackColor != Color.Transparent && a_mr.BackColor == Color.Black) { a_tr.Enabled = false; a_mr.Enabled = false; a_br.Enabled = false; }
            if (b_tr.BackColor == b_mr.BackColor && b_mr.BackColor == b_br.BackColor && b_mr.BackColor != Color.Transparent && b_mr.BackColor == Color.Black) { b_tr.Enabled = false; b_mr.Enabled = false; b_br.Enabled = false; }
            if (c_tr.BackColor == c_mr.BackColor && c_mr.BackColor == c_br.BackColor && c_mr.BackColor != Color.Transparent && c_mr.BackColor == Color.Black) { c_tr.Enabled = false; c_mr.Enabled = false; c_br.Enabled = false; }
        }

        private void MillDisabledWhite()
        {
            if (a_tl.BackColor == a_tc.BackColor && a_tc.BackColor == a_tr.BackColor && a_tc.BackColor != Color.Transparent && a_tc.BackColor == Color.White) { a_tl.Enabled = false; a_tc.Enabled = false; a_tr.Enabled = false; }
            if (b_tl.BackColor == b_tc.BackColor && b_tc.BackColor == b_tr.BackColor && b_tc.BackColor != Color.Transparent && b_tc.BackColor == Color.White) { b_tl.Enabled = false; b_tc.Enabled = false; b_tr.Enabled = false; }
            if (c_tl.BackColor == c_tc.BackColor && c_tc.BackColor == c_tr.BackColor && c_tc.BackColor != Color.Transparent && c_tc.BackColor == Color.White) { c_tl.Enabled = false; c_tc.Enabled = false; c_tr.Enabled = false; }
            if (a_ml.BackColor == b_ml.BackColor && b_ml.BackColor == c_ml.BackColor && b_ml.BackColor != Color.Transparent && b_ml.BackColor == Color.White) { a_ml.Enabled = false; b_ml.Enabled = false; c_ml.Enabled = false; }
            if (a_mr.BackColor == b_mr.BackColor && b_mr.BackColor == c_mr.BackColor && b_mr.BackColor != Color.Transparent && b_mr.BackColor == Color.White) { a_mr.Enabled = false; b_mr.Enabled = false; c_mr.Enabled = false; }
            if (a_bl.BackColor == a_bc.BackColor && a_bc.BackColor == a_br.BackColor && a_bc.BackColor != Color.Transparent && a_bc.BackColor == Color.White) { a_bl.Enabled = false; a_bc.Enabled = false; a_br.Enabled = false; }
            if (b_bl.BackColor == b_bc.BackColor && b_bc.BackColor == b_br.BackColor && b_bc.BackColor != Color.Transparent && b_bc.BackColor == Color.White) { b_bl.Enabled = false; b_bc.Enabled = false; b_br.Enabled = false; }
            if (c_bl.BackColor == c_bc.BackColor && c_bc.BackColor == c_br.BackColor && c_bc.BackColor != Color.Transparent && c_bc.BackColor == Color.White) { c_bl.Enabled = false; c_bc.Enabled = false; c_br.Enabled = false; }
            if (a_tl.BackColor == a_ml.BackColor && a_ml.BackColor == a_bl.BackColor && a_ml.BackColor != Color.Transparent && a_ml.BackColor == Color.White) { a_tl.Enabled = false; a_ml.Enabled = false; a_bl.Enabled = false; }
            if (b_tl.BackColor == b_ml.BackColor && b_ml.BackColor == b_bl.BackColor && b_ml.BackColor != Color.Transparent && b_ml.BackColor == Color.White) { b_tl.Enabled = false; b_ml.Enabled = false; b_bl.Enabled = false; }
            if (c_tl.BackColor == c_ml.BackColor && c_ml.BackColor == c_bl.BackColor && c_ml.BackColor != Color.Transparent && c_ml.BackColor == Color.White) { c_tl.Enabled = false; c_ml.Enabled = false; c_bl.Enabled = false; }
            if (a_tc.BackColor == b_tc.BackColor && b_tc.BackColor == c_tc.BackColor && b_tc.BackColor != Color.Transparent && b_tc.BackColor == Color.White) { a_tc.Enabled = false; b_tc.Enabled = false; c_tc.Enabled = false; }
            if (a_bc.BackColor == b_bc.BackColor && b_bc.BackColor == c_bc.BackColor && b_bc.BackColor != Color.Transparent && b_bc.BackColor == Color.White) { a_bc.Enabled = false; b_bc.Enabled = false; c_bc.Enabled = false; }
            if (a_tr.BackColor == a_mr.BackColor && a_mr.BackColor == a_br.BackColor && a_mr.BackColor != Color.Transparent && a_mr.BackColor == Color.White) { a_tr.Enabled = false; a_mr.Enabled = false; a_br.Enabled = false; }
            if (b_tr.BackColor == b_mr.BackColor && b_mr.BackColor == b_br.BackColor && b_mr.BackColor != Color.Transparent && b_mr.BackColor == Color.White) { b_tr.Enabled = false; b_mr.Enabled = false; b_br.Enabled = false; }
            if (c_tr.BackColor == c_mr.BackColor && c_mr.BackColor == c_br.BackColor && c_mr.BackColor != Color.Transparent && c_mr.BackColor == Color.White) { c_tr.Enabled = false; c_mr.Enabled = false; c_br.Enabled = false; }
        }

        private void black_or_while_mill()
        {
            if (c_switch) black_mill = true;
            else if (c_switch == false) white_mill = true;
        }

        private void buttons_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            label1.Focus();
            if (black_mill == false && white_mill == false)
            {
                turns_combined--;
                turns++;
                l_remaining.Text = turns_combined.ToString();
                if (turns_combined == 0) { label1.Visible = false; l_remaining.Visible = false; }
                if (turns_combined >= 0)
                {
                    if (c_switch) { b.BackColor = Color.Black; black_turns++; l_black.Text = black_turns.ToString() + "/9"; }
                    else { b.BackColor = Color.White; white_turns++; l_white.Text = white_turns.ToString() + "/9"; }
                    if (turns_combined > 0) c_switch = !c_switch;
                }
                else return;
            }
            else
            {
                b.BackColor = Color.Transparent;
                if (turns_combined <= 0)
                {
                    if (c_switch) { white_turns--; l_white.Text = white_turns.ToString() + "/9"; }
                    else { black_turns--; l_black.Text = black_turns.ToString() + "/9"; }
                    black_mill = false; white_mill = false; enableDisableMill();
                    DEV_info();
                }
                else if (turns_combined > 0)
                {
                    if (c_switch) { black_turns--; l_black.Text = black_turns.ToString() + "/9"; }
                    else { white_turns--; l_white.Text = white_turns.ToString() + "/9"; }
                }
            }
            if (b.BackColor != Color.Transparent) b.Enabled = false;
        }

        private void buttons_BackColorChanged(object sender, EventArgs e)
        {
            if (turns_combined >= 0) { black_mill = false; white_mill = false; }
            Button b = (Button)sender;
            switch ((sender as Button).Name)//horizontal         
            {
                case "a_tl":
                case "a_tc":
                case "a_tr": if (a_tl.BackColor == a_tc.BackColor && a_tc.BackColor == a_tr.BackColor && a_tc.BackColor != Color.Transparent) black_or_while_mill(); break;
                case "b_tl":
                case "b_tc":
                case "b_tr": if (b_tl.BackColor == b_tc.BackColor && b_tc.BackColor == b_tr.BackColor && b_tc.BackColor != Color.Transparent) black_or_while_mill(); break;
                case "c_tl":
                case "c_tc":
                case "c_tr": if (c_tl.BackColor == c_tc.BackColor && c_tc.BackColor == c_tr.BackColor && c_tc.BackColor != Color.Transparent) black_or_while_mill(); break;
                case "a_ml":
                case "b_ml":
                case "c_ml": if (a_ml.BackColor == b_ml.BackColor && b_ml.BackColor == c_ml.BackColor && b_ml.BackColor != Color.Transparent) black_or_while_mill(); break;
                case "a_mr":
                case "b_mr":
                case "c_mr": if (a_mr.BackColor == b_mr.BackColor && b_mr.BackColor == c_mr.BackColor && b_mr.BackColor != Color.Transparent) black_or_while_mill(); break;
                case "a_bl":
                case "a_bc":
                case "a_br": if (a_bl.BackColor == a_bc.BackColor && a_bc.BackColor == a_br.BackColor && a_bc.BackColor != Color.Transparent) black_or_while_mill(); break;
                case "b_bl":
                case "b_bc":
                case "b_br": if (b_bl.BackColor == b_bc.BackColor && b_bc.BackColor == b_br.BackColor && b_bc.BackColor != Color.Transparent) black_or_while_mill(); break;
                case "c_bl":
                case "c_bc":
                case "c_br": if (c_bl.BackColor == c_bc.BackColor && c_bc.BackColor == c_br.BackColor && c_bc.BackColor != Color.Transparent) black_or_while_mill(); break;
            }
            switch ((sender as Button).Name)//vertical
            {
                case "a_tl":
                case "a_ml":
                case "a_bl": if (a_tl.BackColor == a_ml.BackColor && a_ml.BackColor == a_bl.BackColor && a_ml.BackColor != Color.Transparent) black_or_while_mill(); break;
                case "b_tl":
                case "b_ml":
                case "b_bl": if (b_tl.BackColor == b_ml.BackColor && b_ml.BackColor == b_bl.BackColor && b_ml.BackColor != Color.Transparent) black_or_while_mill(); break;
                case "c_tl":
                case "c_ml":
                case "c_bl": if (c_tl.BackColor == c_ml.BackColor && c_ml.BackColor == c_bl.BackColor && c_ml.BackColor != Color.Transparent) black_or_while_mill(); break;
                case "a_tc":
                case "b_tc":
                case "c_tc": if (a_tc.BackColor == b_tc.BackColor && b_tc.BackColor == c_tc.BackColor && b_tc.BackColor != Color.Transparent) black_or_while_mill(); break;
                case "a_bc":
                case "b_bc":
                case "c_bc": if (a_bc.BackColor == b_bc.BackColor && b_bc.BackColor == c_bc.BackColor && b_bc.BackColor != Color.Transparent) black_or_while_mill(); break;
                case "a_tr":
                case "a_mr":
                case "a_br": if (a_tr.BackColor == a_mr.BackColor && a_mr.BackColor == a_br.BackColor && a_mr.BackColor != Color.Transparent) black_or_while_mill(); break;
                case "b_tr":
                case "b_mr":
                case "b_br": if (b_tr.BackColor == b_mr.BackColor && b_mr.BackColor == b_br.BackColor && b_mr.BackColor != Color.Transparent) black_or_while_mill(); break;
                case "c_tr":
                case "c_mr":
                case "c_br": if (c_tr.BackColor == c_mr.BackColor && c_mr.BackColor == c_br.BackColor && c_mr.BackColor != Color.Transparent) black_or_while_mill(); break;
            }
            enableDisableMill();
            b_rowEnabledDisabled();
            b_rowEnabledDisabled2();
            DEV_info();
            if (turns_combined < 0 && black_turns == 3 && white_mill) { MessageBox.Show("Белите печелят", "Game Over"); новаИграToolStripMenuItem.PerformClick(); }
            else if (turns_combined < 0 && white_turns == 3 && black_mill) { MessageBox.Show("Черните печелят", "Game Over"); новаИграToolStripMenuItem.PerformClick(); }
        }

        private void buttons_MouseEnter(object sender, EventArgs e)
        {
            if (turns_combined < 0)
            {
                if ((black_turns < 4 && c_switch == false) || (white_turns < 4 && c_switch == true))
                {
                    Button b = (Button)sender;
                    Button mButton = new Button();
                    mButton.Visible = false;
                    if (b.BackColor != Color.Transparent)
                    {
                        mButton.Tag = b.Tag;
                        mButton.Visible = true;
                        mButton.Location = b.Location;
                        mButton.Size = b.Size;
                        mButton.BackColor = b.BackColor;
                        this.Controls.Add(mButton);
                        mButton.BringToFront();
                        mButton.MouseMove += new MouseEventHandler(mButton_MouseMove);
                        mButton.MouseDown += new MouseEventHandler(mButton_MouseDown);
                        mButton.MouseUp += new MouseEventHandler(mButton_MouseUp);
                        mButton.MouseLeave += new EventHandler(mButton_MouseLeave);
                    }
                    else return;
                }
            }
        }

        public void mButton_MouseMove(object sender, MouseEventArgs e)
        {
            Button b = (Button)sender;
            if (e.Button == MouseButtons.Left)
            {
                b.Left += e.X - move.X;
                b.Top += e.Y - move.Y;
            }
        }
        public void mButton_MouseDown(object sender, MouseEventArgs e)
        {
            move = e.Location;
        }
        public void mButton_MouseLeave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            this.Controls.Remove(b);
        }
        public void mButton_MouseUp(object sender, MouseEventArgs e)
        {
            Button b = (Button)sender;
            this.Controls.Remove(b);
            foreach (Control c in Controls)
            {
                if (c.Tag == b.Tag)
                {
                    foreach (Control c1 in Controls)
                    {
                        if (c1 is Button && c is Button)
                        {
                            if (c1.Bounds.IntersectsWith(b.Bounds) && b.BackColor != c1.BackColor && c1.Enabled == true && c1.Height == c1.Width)
                            {
                                c_switch = !c_switch;
                                c.BackColor = Color.Transparent;
                                c1.BackColor = b.BackColor;
                            }
                        }
                    }
                }
            }
        }

        private void DEV_info()
        {
            if (dev)
            {
                if (c_switch) label6.Text = "switch: Off";
                if (c_switch == false) label6.Text = "switch: On";
                if (black_mill) label4.Text = "black_mill: On";
                if (black_mill == false) label4.Text = "black_mill: Off";
                if (white_mill) label5.Text = "white_mill: On";
                if (white_mill == false) label5.Text = "white_mill: Off";
                label7.Text = "stage1_turns: " + turns_combined.ToString();
                label8.Text = "all_p_turns: " + turns.ToString();
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                if(turns_combined>=0) label7.Visible = true;
                else label7.Visible = false;
                label8.Visible = true;
                label9.Visible = true;

            }
            else
            {
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
            }
        }

        private void новаИграToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Искате да започнете Нова игра?", "New Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (Control c in Controls)
                {
                    if (c is Button)
                    {
                        Button b = (Button)c;
                        b.BackColor = Color.Transparent;
                        c_switch = true;
                        turns_combined = 18;
                        black_turns = 0;
                        white_turns = 0;
                        black_mill = false;
                        white_mill = false;
                        label1.Visible = true;
                        l_remaining.Visible = true;
                        l_remaining.Text = turns_combined.ToString();
                        l_black.Text = black_turns.ToString() + "/9";
                        l_white.Text = white_turns.ToString() + "/9";
                    }
                    if (c is Button && c.Width != c.Height)
                    {
                        c.Visible = false;
                    }
                }
            }
        }

        private void относноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Дама (Корам) - Версия 3.5", "About");
        }

        private void какСеИграеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //wip
        }

        private void developerInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (developerInformationToolStripMenuItem.Checked) dev = true;
            else dev = false;
            DEV_info();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }//end of public partial class
}//end of namespace