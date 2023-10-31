namespace ChandelierPlugin.View
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_RadiusOuterCircle = new System.Windows.Forms.TextBox();
            this.textBox_RadiusInnerCircle = new System.Windows.Forms.TextBox();
            this.textBox_FoundationThickness = new System.Windows.Forms.TextBox();
            this.textBox_RadiusBaseCircle = new System.Windows.Forms.TextBox();
            this.textBox_LampRadius = new System.Windows.Forms.TextBox();
            this.textBox_LampsAmount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Внешний радиус основания:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Внутренний радиус основания:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(212, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Радиус крепежного основания:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Толщина основания:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Количество лампочек:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Радиус лампочки:";
            // 
            // textBox_RadiusOuterCircle
            // 
            this.textBox_RadiusOuterCircle.BackColor = System.Drawing.Color.White;
            this.textBox_RadiusOuterCircle.Location = new System.Drawing.Point(262, 38);
            this.textBox_RadiusOuterCircle.Name = "textBox_RadiusOuterCircle";
            this.textBox_RadiusOuterCircle.Size = new System.Drawing.Size(144, 22);
            this.textBox_RadiusOuterCircle.TabIndex = 6;
            this.textBox_RadiusOuterCircle.Text = "800";
            this.textBox_RadiusOuterCircle.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // textBox_RadiusInnerCircle
            // 
            this.textBox_RadiusInnerCircle.Location = new System.Drawing.Point(262, 67);
            this.textBox_RadiusInnerCircle.Name = "textBox_RadiusInnerCircle";
            this.textBox_RadiusInnerCircle.Size = new System.Drawing.Size(144, 22);
            this.textBox_RadiusInnerCircle.TabIndex = 7;
            this.textBox_RadiusInnerCircle.Text = "700";
            this.textBox_RadiusInnerCircle.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // textBox_FoundationThickness
            // 
            this.textBox_FoundationThickness.Location = new System.Drawing.Point(262, 124);
            this.textBox_FoundationThickness.Name = "textBox_FoundationThickness";
            this.textBox_FoundationThickness.Size = new System.Drawing.Size(144, 22);
            this.textBox_FoundationThickness.TabIndex = 9;
            this.textBox_FoundationThickness.Text = "60";
            this.textBox_FoundationThickness.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // textBox_RadiusBaseCircle
            // 
            this.textBox_RadiusBaseCircle.Location = new System.Drawing.Point(262, 95);
            this.textBox_RadiusBaseCircle.Name = "textBox_RadiusBaseCircle";
            this.textBox_RadiusBaseCircle.Size = new System.Drawing.Size(144, 22);
            this.textBox_RadiusBaseCircle.TabIndex = 8;
            this.textBox_RadiusBaseCircle.Text = "100";
            this.textBox_RadiusBaseCircle.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // textBox_LampRadius
            // 
            this.textBox_LampRadius.Location = new System.Drawing.Point(262, 181);
            this.textBox_LampRadius.Name = "textBox_LampRadius";
            this.textBox_LampRadius.Size = new System.Drawing.Size(144, 22);
            this.textBox_LampRadius.TabIndex = 11;
            this.textBox_LampRadius.Text = "20";
            this.textBox_LampRadius.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // textBox_LampsAmount
            // 
            this.textBox_LampsAmount.Location = new System.Drawing.Point(262, 152);
            this.textBox_LampsAmount.Name = "textBox_LampsAmount";
            this.textBox_LampsAmount.Size = new System.Drawing.Size(144, 22);
            this.textBox_LampsAmount.TabIndex = 10;
            this.textBox_LampsAmount.Text = "12";
            this.textBox_LampsAmount.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(412, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "от 15 до 25 мм";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(412, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 16);
            this.label8.TabIndex = 16;
            this.label8.Text = "n < 109 шт";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(412, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 16);
            this.label9.TabIndex = 15;
            this.label9.Text = "от 40 до 80 мм";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(412, 98);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 16);
            this.label10.TabIndex = 14;
            this.label10.Text = "от 100 до 200 мм";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(412, 70);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 16);
            this.label11.TabIndex = 13;
            this.label11.Text = "от 150 до 750 мм";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(412, 41);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(117, 16);
            this.label12.TabIndex = 12;
            this.label12.Text = "от 400 до 1000 мм";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(429, 236);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.button1.Size = new System.Drawing.Size(100, 32);
            this.button1.TabIndex = 18;
            this.button1.Text = "Построить";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 283);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBox_LampRadius);
            this.Controls.Add(this.textBox_LampsAmount);
            this.Controls.Add(this.textBox_FoundationThickness);
            this.Controls.Add(this.textBox_RadiusBaseCircle);
            this.Controls.Add(this.textBox_RadiusInnerCircle);
            this.Controls.Add(this.textBox_RadiusOuterCircle);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormMain";
            this.Text = "ChandelierPlugin";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_RadiusOuterCircle;
        private System.Windows.Forms.TextBox textBox_RadiusInnerCircle;
        private System.Windows.Forms.TextBox textBox_FoundationThickness;
        private System.Windows.Forms.TextBox textBox_RadiusBaseCircle;
        private System.Windows.Forms.TextBox textBox_LampRadius;
        private System.Windows.Forms.TextBox textBox_LampsAmount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button1;
    }
}

