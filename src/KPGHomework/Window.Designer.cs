namespace KPGHomework
{
    partial class Window
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
            this.components = new System.ComponentModel.Container();
            this.activeCanvas = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.r_ext_textbox = new System.Windows.Forms.TextBox();
            this.r_int_textbox = new System.Windows.Forms.TextBox();
            this.d_len_textbox = new System.Windows.Forms.TextBox();
            this.draw_hypotrochoid_button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.clear_button = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.activeCanvas)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // activeCanvas
            // 
            this.activeCanvas.BackColor = System.Drawing.SystemColors.Control;
            this.activeCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.activeCanvas.Location = new System.Drawing.Point(0, 0);
            this.activeCanvas.Name = "activeCanvas";
            this.activeCanvas.Size = new System.Drawing.Size(802, 448);
            this.activeCanvas.TabIndex = 0;
            this.activeCanvas.TabStop = false;
            this.activeCanvas.Click += new System.EventHandler(this.activeCanvas_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(602, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 448);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.r_ext_textbox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.r_int_textbox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.d_len_textbox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.draw_hypotrochoid_button, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.clear_button, 0, 6);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(190, 442);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nastavení pro Hypotrochoid";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(3, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Poloměr R:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(3, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Poloměr r:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(3, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Délka d:";
            // 
            // r_ext_textbox
            // 
            this.r_ext_textbox.Location = new System.Drawing.Point(98, 33);
            this.r_ext_textbox.Name = "r_ext_textbox";
            this.r_ext_textbox.Size = new System.Drawing.Size(88, 20);
            this.r_ext_textbox.TabIndex = 4;
            // 
            // r_int_textbox
            // 
            this.r_int_textbox.Location = new System.Drawing.Point(98, 63);
            this.r_int_textbox.Name = "r_int_textbox";
            this.r_int_textbox.Size = new System.Drawing.Size(88, 20);
            this.r_int_textbox.TabIndex = 5;
            // 
            // d_len_textbox
            // 
            this.d_len_textbox.Location = new System.Drawing.Point(98, 93);
            this.d_len_textbox.Name = "d_len_textbox";
            this.d_len_textbox.Size = new System.Drawing.Size(88, 20);
            this.d_len_textbox.TabIndex = 6;
            // 
            // draw_hypotrochoid_button
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.draw_hypotrochoid_button, 2);
            this.draw_hypotrochoid_button.Location = new System.Drawing.Point(3, 153);
            this.draw_hypotrochoid_button.Name = "draw_hypotrochoid_button";
            this.draw_hypotrochoid_button.Size = new System.Drawing.Size(183, 24);
            this.draw_hypotrochoid_button.TabIndex = 7;
            this.draw_hypotrochoid_button.Text = "Nakreslit hypotrochoid";
            this.draw_hypotrochoid_button.UseVisualStyleBackColor = true;
            this.draw_hypotrochoid_button.Click += new System.EventHandler(this.Draw_Hypotrochoid_Button_Click);
            // 
            // button1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.button1, 2);
            this.button1.Location = new System.Drawing.Point(3, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(183, 24);
            this.button1.TabIndex = 8;
            this.button1.Text = "Nakreslit kružnice";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Draw_Circle_Button_Click);
            // 
            // clear_button
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.clear_button, 2);
            this.clear_button.Location = new System.Drawing.Point(3, 183);
            this.clear_button.Name = "clear_button";
            this.clear_button.Size = new System.Drawing.Size(183, 24);
            this.clear_button.TabIndex = 9;
            this.clear_button.Text = "Vyčistit plátno";
            this.clear_button.UseVisualStyleBackColor = true;
            this.clear_button.Click += new System.EventHandler(this.Clear_Button_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 448);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.activeCanvas);
            this.Name = "Window";
            this.Text = "KPG - A16B0176P - Pavel Zelenka";
            this.Load += new System.EventHandler(this.Window_Load);
            this.Resize += new System.EventHandler(this.Window_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.activeCanvas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox activeCanvas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox r_ext_textbox;
        private System.Windows.Forms.TextBox r_int_textbox;
        private System.Windows.Forms.TextBox d_len_textbox;
        private System.Windows.Forms.Button draw_hypotrochoid_button;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button clear_button;
    }
}



