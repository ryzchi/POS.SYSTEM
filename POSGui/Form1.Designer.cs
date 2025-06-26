using System;
using System.Windows.Forms;

namespace POSGui
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ColumnHeader columnHeader1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            label2 = new Label();
            txtName = new TextBox();
            label3 = new Label();
            txtPrice = new TextBox();
            btnAdd = new Button();
            btnRemove = new Button();
            btnExit = new Button();
            btnCheckout = new Button();
            lstView = new ListView();
            columnHeader2 = new ColumnHeader();
            lblTotal = new Label();
            lblAmount = new Label();
            btnMinus = new Button();
            btnPlus = new Button();
            label4 = new Label();
            lblQty = new Label();
            columnHeader1 = new ColumnHeader();
            SuspendLayout();
            // 
            // columnHeader1
            // 
            resources.ApplyResources(columnHeader1, "columnHeader1");
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            label1.Name = "label1";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.ForeColor = System.Drawing.Color.Transparent;
            label2.Name = "label2";
            // 
            // txtName
            // 
            resources.ApplyResources(txtName, "txtName");
            txtName.Name = "txtName";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.ForeColor = System.Drawing.Color.Transparent;
            label3.Name = "label3";
            // 
            // txtPrice
            // 
            resources.ApplyResources(txtPrice, "txtPrice");
            txtPrice.Name = "txtPrice";
            // 
            // btnAdd
            // 
            resources.ApplyResources(btnAdd, "btnAdd");
            btnAdd.ForeColor = System.Drawing.SystemColors.HotTrack;
            btnAdd.Name = "btnAdd";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click_1;
            // 
            // btnRemove
            // 
            resources.ApplyResources(btnRemove, "btnRemove");
            btnRemove.ForeColor = System.Drawing.SystemColors.HotTrack;
            btnRemove.Name = "btnRemove";
            btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            resources.ApplyResources(btnExit, "btnExit");
            btnExit.ForeColor = System.Drawing.SystemColors.HotTrack;
            btnExit.Name = "btnExit";
            btnExit.UseVisualStyleBackColor = true;
            // 
            // btnCheckout
            // 
            resources.ApplyResources(btnCheckout, "btnCheckout");
            btnCheckout.ForeColor = System.Drawing.SystemColors.HotTrack;
            btnCheckout.Name = "btnCheckout";
            btnCheckout.UseVisualStyleBackColor = true;
            // 
            // lstView
            // 
            resources.ApplyResources(lstView, "lstView");
            lstView.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            lstView.FullRowSelect = true;
            lstView.GridLines = true;
            lstView.Name = "lstView";
            lstView.UseCompatibleStateImageBehavior = false;
            lstView.View = View.Details;
            // 
            // columnHeader2
            // 
            resources.ApplyResources(columnHeader2, "columnHeader2");
            // 
            // lblTotal
            // 
            resources.ApplyResources(lblTotal, "lblTotal");
            lblTotal.BackColor = System.Drawing.Color.Transparent;
            lblTotal.ForeColor = System.Drawing.Color.White;
            lblTotal.Name = "lblTotal";
            lblTotal.Click += lblTotal_Click;
            // 
            // lblAmount
            // 
            resources.ApplyResources(lblAmount, "lblAmount");
            lblAmount.BackColor = System.Drawing.Color.Transparent;
            lblAmount.ForeColor = System.Drawing.Color.White;
            lblAmount.Name = "lblAmount";
            // 
            // btnMinus
            // 
            resources.ApplyResources(btnMinus, "btnMinus");
            btnMinus.Name = "btnMinus";
            btnMinus.UseVisualStyleBackColor = true;
            // 
            // btnPlus
            // 
            resources.ApplyResources(btnPlus, "btnPlus");
            btnPlus.Name = "btnPlus";
            btnPlus.UseVisualStyleBackColor = true;
            btnPlus.Click += button1_Click;
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.ForeColor = System.Drawing.Color.White;
            label4.Name = "label4";
            label4.Click += label4_Click;
            // 
            // lblQty
            // 
            resources.ApplyResources(lblQty, "lblQty");
            lblQty.ForeColor = System.Drawing.Color.White;
            lblQty.Name = "lblQty";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.SteelBlue;
            Controls.Add(lblQty);
            Controls.Add(label4);
            Controls.Add(btnPlus);
            Controls.Add(btnMinus);
            Controls.Add(lblAmount);
            Controls.Add(lblTotal);
            Controls.Add(lstView);
            Controls.Add(btnExit);
            Controls.Add(btnCheckout);
            Controls.Add(btnRemove);
            Controls.Add(btnAdd);
            Controls.Add(txtPrice);
            Controls.Add(label3);
            Controls.Add(txtName);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.ListView lstView;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private Label lblTotal;
        private Label lblAmount;
        private Button btnMinus;
        private Button btnPlus;
        private Label label4;
        private Label lblQty;
    }
}

