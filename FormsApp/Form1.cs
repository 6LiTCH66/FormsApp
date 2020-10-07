using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsApp
{
    public partial class Form1 : Form
    {
        TreeView tree;
        Button btn;
        Label lbl;
        CheckBox box_lbl, box_btn;
        RadioButton r1, r2;
        TextBox txt_box;
        public Form1()
        {
            this.Height = 500;
            this.Width = 600;
            this.Text = "Vorm elementidega";
            tree = new TreeView();
            tree.Dock = DockStyle.Left;
            tree.AfterSelect += Tree_AfterSelect;

            TreeNode tn = new TreeNode("Elemendid");
            tn.Nodes.Add(new TreeNode("Nupp-Button"));
            btn = new Button();
            btn.Text = "Vajta siia";
            btn.Location = new Point(200, 100);
            btn.Height = 40;
            btn.Width = 120;
            btn.Click += Btn_Click;


            tn.Nodes.Add(new TreeNode("Silt-Label"));
            lbl = new Label();
            lbl.Text = "Tarkvara arendajad";
            lbl.Size = new Size(150, 30);
            lbl.Location = new Point(150, 200);
            tn.Nodes.Add(new TreeNode("Märkeruut-CheckBox"));

            tn.Nodes.Add(new TreeNode("RadioNupp-RadioButton"));
            tn.Nodes.Add(new TreeNode("TekstKast-TextBox"));
            tree.Nodes.Add(tn);
            this.Controls.Add(tree);

        }
       
        private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Nupp-Button")
            {
                this.Controls.Add(btn);
            }
            else if (e.Node.Text == "Silt-Label")
            {                
                this.Controls.Add(lbl);
            }
            else if (e.Node.Text == "Märkeruut-CheckBox")
            {
                box_btn = new CheckBox();
                box_btn.Text = "Näita nupp";
                box_btn.Location = new Point(200, 30);
                this.Controls.Add(box_btn);
                box_btn.CheckedChanged += Box_btn_CheckedChanged;


                box_lbl = new CheckBox();
                box_lbl.Text = "Näita silt";
                box_lbl.Location = new Point(200, 70);
                this.Controls.Add(box_lbl);
                box_lbl.CheckedChanged += Box_lbl_CheckedChanged;

            }
            else if(e.Node.Text == "RadioNupp-RadioButton")
            {
                r1 = new RadioButton();
                r1.Text = "nupp vasakul";
                r1.Location = new Point(300, 30);
                r1.CheckedChanged += new EventHandler(Radionbuttons_Changed);


                r2 = new RadioButton();
                r2.Text = "nupp paremale";
                r2.Location = new Point(300, 70);
                r2.CheckedChanged += new EventHandler(Radionbuttons_Changed);

                this.Controls.Add(r1);
                this.Controls.Add(r2);
            }
            else if(e.Node.Text == "TekstKast-TextBox")
            {
                string text_file;
                try
                {
                    StreamReader from_file = new StreamReader(@"C:\Users\Game\RiderProjects\FormsApp\FormsApp\bin\Debug\file.txt");
                    text_file = from_file.ReadToEnd();
                }
                catch (FileNotFoundException exception DirectoryNotFoundException)
                {
                    text_file = "Tetst puudub";
                }
                txt_box = new TextBox();
                txt_box.Multiline = true;
                txt_box.Text = text_file;
                txt_box.Location = new Point(300, 300);
                txt_box.Width = 200;
                txt_box.Height = 200;
                Controls.Add(txt_box);
            }
        }

        private void Radionbuttons_Changed(object sender, EventArgs e)
        {
            if (r1.Checked)
            {
                btn.Location = new Point(150, 100);

            }
            else if (r2.Checked)
            {
                btn.Location = new Point(400, 100);
            }
        }

        private void Box_lbl_CheckedChanged(object sender, EventArgs e)
        {
            if (box_lbl.Checked)
            {
                Controls.Add(lbl);
            }
            else
            {
                Controls.Remove(lbl);
            }
        }

        private void Box_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (box_btn.Checked)
            {
                Controls.Add(btn);
            }
            else 
            {
                Controls.Remove(btn);
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            if (btn.BackColor == Color.Red)
            {
                btn.BackColor = Color.Blue;
                lbl.BackColor = Color.Green;
                lbl.ForeColor = Color.White;
            }
            else
            {
                btn.BackColor = Color.Red;
                lbl.BackColor = Color.White;
                lbl.ForeColor = Color.Green;
            }
            
        }
    }
}
