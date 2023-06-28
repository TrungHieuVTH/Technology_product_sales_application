﻿using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp122.Controllers.UserController;
using WindowsFormsApp122.FormFunction;
using WindowsFormsApp122.UserForm;
//using WindowsFormsApp122.Controllers.Draw.DrawProductController;
using WinFormsApp2;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace WindowsFormsApp122
{
    public partial class MainForm : Form
    {
        Form login;
        Panel Dashboard = new Panel(), Cart = new Panel(), Orders = new Panel(), Invoices = new Panel(), Account = new Panel(), AboutUs = new Panel();
        Panel[] allPanels;

        private static int user_id;
        
        public static int getUserID()
        {
            return user_id;
        }
        private static void turnOn(PictureBox pic, Label lb, Panel pn, Panel Content)
        {
            lb.ForeColor = Color.Black;
            pn.BackColor = Color.White;
            Content.Visible = true;
            //pic.Image = invertPicture(new Bitmap(pic.Image));
        }
        private static void panelUnClick(PictureBox pic, Label lb, Panel pn, Panel Content)
        {
            lb.ForeColor = Color.White; 
            pn.BackColor = Color.Black;
            Content.Visible = false;

            //pic.Image = invertPicture(new Bitmap(pic.Image));
        }
        public void panelClick(object sender, EventArgs e, int num)
        {
            panelUnClick(picDashboard, lbDashboard, pnDashboard, Dashboard);
            panelUnClick(picShoppingCart, lbShoppingCart, pnShoppingCart, Cart);
            panelUnClick(picMyOrders, lbMyOrders, pnMyOrders, Orders);
            panelUnClick(picInvoice, lbInvoice, pnInvoice, Invoices);
            panelUnClick(picAccount, lbAccount, pnAccount, Account);
            panelUnClick(picAboutUs, lbAboutUs, pnAboutUs, AboutUs);
            panelUnClick(picSignOut, lbSignOut, pnSignOut, AboutUs);
            this.picDashboard.Image = global::WindowsFormsApp122.Properties.Resources.iconDashboardOff;
            this.picShoppingCart.Image = global::WindowsFormsApp122.Properties.Resources.iconShoppingCartOff;
            this.picMyOrders.Image = global::WindowsFormsApp122.Properties.Resources.IconMyOrdersOff;
            this.picInvoice.Image = global::WindowsFormsApp122.Properties.Resources.iconInvoiceOff;
            this.picAccount.Image = global::WindowsFormsApp122.Properties.Resources.iconAccountOff;
            this.picAboutUs.Image = global::WindowsFormsApp122.Properties.Resources.iconAboutUsOff;
            switch (num)
            {
                case 1:
                    turnOn(picDashboard, lbDashboard, pnDashboard, Dashboard);
                    this.picDashboard.Image = global::WindowsFormsApp122.Properties.Resources.iconDashboardOn;
                    break;
                case 2:
                    new Controllers.UserController.CartController(Cart, pnHeader, pnContent, user_id, this);
                    turnOn(picShoppingCart, lbShoppingCart, pnShoppingCart, Cart);
                    this.picShoppingCart.Image = global::WindowsFormsApp122.Properties.Resources.iconShoppingCartOn;
                    break; 
                case 3:
                    turnOn(picMyOrders, lbMyOrders, pnMyOrders, Orders);
                    var test2 = new Controllers.UserController.MyOrderController(Orders, pnHeader, pnContent);
                    this.picMyOrders.Image = global::WindowsFormsApp122.Properties.Resources.IconMyOrdersOn;
                    break;                    
                case 4:
                    turnOn(picInvoice, lbInvoice, pnInvoice, Invoices);
                    var test3 = new Controllers.UserController.InvoiceController(Invoices, pnHeader, pnContent);
                    this.picInvoice.Image = global::WindowsFormsApp122.Properties.Resources.iconInvoiceOn;
                    break;                     
                case 5:
                    turnOn(picAccount, lbAccount, pnAccount, Account);
                    var test4 = new Controllers.UserController.AcountController(Account, pnHeader, pnContent, this);
                    this.picAccount.Image = global::WindowsFormsApp122.Properties.Resources.iconAccountOn;
                    break;                    
                case 6:
                    turnOn(picAboutUs, lbAboutUs, pnAboutUs, AboutUs);
                    var test5 = new Controllers.UserController.AboutUsController(AboutUs, pnHeader, pnContent);
                    this.picAboutUs.Image = global::WindowsFormsApp122.Properties.Resources.iconAboutUsOn;
                    break;                  
                default: break;
            }
        }
        public MainForm(Form login, int user_idd)
        {
            this.login=login;
            user_id = user_idd;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panelClick(sender, e, 1);
        }

        public void pnDashboard_Click(object sender, EventArgs e)
        {
            panelClick(sender,e,1);
        }

        private void pnShoppingCart_Click(object sender, EventArgs e)
        {
            panelClick(sender, e, 2);
        }

        private void pnMyOrders_Click(object sender, EventArgs e)
        {
            panelClick(sender, e, 3);
        }

        private void pnInvoice_Click(object sender, EventArgs e)
        {
            panelClick(sender, e, 4);
        }

        private void pnAccount_Click(object sender, EventArgs e)
        {
            panelClick(sender, e, 5);
        }

        private void pnAboutUs_Click(object sender, EventArgs e)
        {
            panelClick(sender, e, 6);
        }

        private void pnSignOut_Click(object sender, EventArgs e)
        {
            this.Close();
            login.Show();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            this.Controls.Add(pictureBox2);
            pictureBox2.BringToFront();
            pictureBox2.Location = new Point(300, 35);
            pictureBox2.BackColor = Color.DimGray;
            this.picAboutUs.Image = global::WindowsFormsApp122.Properties.Resources.Apple_logo_white;


            SessionFunction.createSession(user_id);
            allPanels = new Panel[]
            {
                Dashboard, Cart, Orders, Invoices, Account, AboutUs
            };
            foreach(var pn in allPanels)
            {
                this.Controls.Add(pn);
                pn.Location = pnDesign.Location;
                pn.Size = pnDesign.Size;
                pn.Visible = false;
            }
          
            var test = new DashboardController(Dashboard, pnHeader, pnContent, user_id, this);
            panelClick(sender, e, 1);

            //Panel panel1 = new Panel();
            //Panel panel2 = new Panel();
            //Panel panel3 = new Panel();
            //Panel panel4 = new Panel();
            //Panel panel5 = new Panel();
            //Panel panel6 = new Panel();
            //Panel panel7 = new Panel();
            //Panel panel8 = new Panel();
            //panel = new Panel[]
            //{
            //    panel1,panel2, panel3, panel4, panel5, panel6, panel7, panel8,
            //};

            //for (int i = 0; i < 8; i++)
            //{
            //    this.Controls.Add(panel[i]);
            //    panel[i].Size = new Size(866, 582);
            //    panel[i].Location = new Point(288, 87);
            //    panel[i].BackColor = Color.Transparent;
            //    panel[i].AutoScroll = true;

            //    var count = 1;
            //    var product = ProductFunction.listProduct(i + 1, 0);
            //    foreach (var p in product)
            //    {
            //        PictureBox productPic = new PictureBox();
            //        productPic.LoadAsync(p.image_url);
            //        UserFormController.Dashboard.products products = new UserFormController.Dashboard.products(productPic, p.name_product.ToString(), p.price.ToString(), p.desc_product.ToString(), p.id);

            //        products.DrawProducts(panel[i], count++);

            //    }
            //    panel[i].Visible = false;
            //}
            //panel[0].Visible = true;
        }

        private void lbDashboard_Click(object sender, EventArgs e)
        {
            panelClick(sender, e, 1);
        }

        private void lbShoppingCart_Click(object sender, EventArgs e)
        {
            panelClick(sender, e, 2);
        }

        private void lbMyOrders_Click(object sender, EventArgs e)
        {
            panelClick(sender, e, 3);
        }

        private void lbInvoice_Click(object sender, EventArgs e)
        {
            panelClick(sender, e, 4);
        }

        private void lbAccount_Click(object sender, EventArgs e)
        {
            panelClick(sender, e, 5);
        }

        private void lbAboutUs_Click(object sender, EventArgs e)
        {
            panelClick(sender, e, 6);
        }

        private void lbSignOut_Click(object sender, EventArgs e)
        {
            this.Close();
            login.Show();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void pnDashboard_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {
        }

        private void label8_Click(object sender, EventArgs e)
        {
        }

        private void label9_Click(object sender, EventArgs e)
        {
        }

        private void picShoppingCart_Click(object sender, EventArgs e)
        {
            panelClick(sender, e, 2);

        }

        private void picMyOrders_Click(object sender, EventArgs e)
        {
            panelClick(sender, e, 3);

        }

        private void picInvoice_Click(object sender, EventArgs e)
        {
            panelClick(sender, e, 4);

        }

        private void picAccount_Click(object sender, EventArgs e)
        {
            panelClick(sender, e, 5);

        }

        private void picAboutUs_Click(object sender, EventArgs e)
        {
            panelClick(sender, e, 6);

        }

        private void picSignOut_Click(object sender, EventArgs e)
        {
            this.Close();
            login.Show();
        }
    }
}
