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
            this.label_LampRadius = new System.Windows.Forms.Label();
            this.label_LampsAmount = new System.Windows.Forms.Label();
            this.label_FoundationThickness = new System.Windows.Forms.Label();
            this.label_RadiusBaseCircle = new System.Windows.Forms.Label();
            this.label_RadiusInnerCircle = new System.Windows.Forms.Label();
            this.label_RadiusOuterCircle = new System.Windows.Forms.Label();
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
            this.textBox_RadiusOuterCircle.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // textBox_RadiusInnerCircle
            // 
            this.textBox_RadiusInnerCircle.Location = new System.Drawing.Point(262, 67);
            this.textBox_RadiusInnerCircle.Name = "textBox_RadiusInnerCircle";
            this.textBox_RadiusInnerCircle.Size = new System.Drawing.Size(144, 22);
            this.textBox_RadiusInnerCircle.TabIndex = 7;
            this.textBox_RadiusInnerCircle.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // textBox_FoundationThickness
            // 
            this.textBox_FoundationThickness.Location = new System.Drawing.Point(262, 124);
            this.textBox_FoundationThickness.Name = "textBox_FoundationThickness";
            this.textBox_FoundationThickness.Size = new System.Drawing.Size(144, 22);
            this.textBox_FoundationThickness.TabIndex = 9;
            this.textBox_FoundationThickness.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // textBox_RadiusBaseCircle
            // 
            this.textBox_RadiusBaseCircle.Location = new System.Drawing.Point(262, 95);
            this.textBox_RadiusBaseCircle.Name = "textBox_RadiusBaseCircle";
            this.textBox_RadiusBaseCircle.Size = new System.Drawing.Size(144, 22);
            this.textBox_RadiusBaseCircle.TabIndex = 8;
            this.textBox_RadiusBaseCircle.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // textBox_LampRadius
            // 
            this.textBox_LampRadius.Location = new System.Drawing.Point(262, 181);
            this.textBox_LampRadius.Name = "textBox_LampRadius";
            this.textBox_LampRadius.Size = new System.Drawing.Size(144, 22);
            this.textBox_LampRadius.TabIndex = 11;
            this.textBox_LampRadius.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // textBox_LampsAmount
            // 
            this.textBox_LampsAmount.Location = new System.Drawing.Point(262, 152);
            this.textBox_LampsAmount.Name = "textBox_LampsAmount";
            this.textBox_LampsAmount.Size = new System.Drawing.Size(144, 22);
            this.textBox_LampsAmount.TabIndex = 10;
            this.textBox_LampsAmount.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // label_LampRadius
            // 
            this.label_LampRadius.AutoSize = true;
            this.label_LampRadius.Location = new System.Drawing.Point(412, 184);
            this.label_LampRadius.Name = "label_LampRadius";
            this.label_LampRadius.Size = new System.Drawing.Size(96, 16);
            this.label_LampRadius.TabIndex = 17;
            this.label_LampRadius.Text = "от 15 до 25 мм";
            // 
            // label_LampsAmount
            // 
            this.label_LampsAmount.AutoSize = true;
            this.label_LampsAmount.Location = new System.Drawing.Point(412, 155);
            this.label_LampsAmount.Name = "label_LampsAmount";
            this.label_LampsAmount.Size = new System.Drawing.Size(67, 16);
            this.label_LampsAmount.TabIndex = 16;
            this.label_LampsAmount.Text = "n < 109 шт";
            // 
            // label_FoundationThickness
            // 
            this.label_FoundationThickness.AutoSize = true;
            this.label_FoundationThickness.Location = new System.Drawing.Point(412, 127);
            this.label_FoundationThickness.Name = "label_FoundationThickness";
            this.label_FoundationThickness.Size = new System.Drawing.Size(96, 16);
            this.label_FoundationThickness.TabIndex = 15;
            this.label_FoundationThickness.Text = "от 40 до 80 мм";
            // 
            // label_RadiusBaseCircle
            // 
            this.label_RadiusBaseCircle.AutoSize = true;
            this.label_RadiusBaseCircle.Location = new System.Drawing.Point(412, 98);
            this.label_RadiusBaseCircle.Name = "label_RadiusBaseCircle";
            this.label_RadiusBaseCircle.Size = new System.Drawing.Size(110, 16);
            this.label_RadiusBaseCircle.TabIndex = 14;
            this.label_RadiusBaseCircle.Text = "от 100 до 200 мм";
            // 
            // label_RadiusInnerCircle
            // 
            this.label_RadiusInnerCircle.AutoSize = true;
            this.label_RadiusInnerCircle.Location = new System.Drawing.Point(412, 70);
            this.label_RadiusInnerCircle.Name = "label_RadiusInnerCircle";
            this.label_RadiusInnerCircle.Size = new System.Drawing.Size(110, 16);
            this.label_RadiusInnerCircle.TabIndex = 13;
            this.label_RadiusInnerCircle.Text = "от 150 до 750 мм";
            // 
            // label_RadiusOuterCircle
            // 
            this.label_RadiusOuterCircle.AutoSize = true;
            this.label_RadiusOuterCircle.Location = new System.Drawing.Point(412, 41);
            this.label_RadiusOuterCircle.Name = "label_RadiusOuterCircle";
            this.label_RadiusOuterCircle.Size = new System.Drawing.Size(117, 16);
            this.label_RadiusOuterCircle.TabIndex = 12;
            this.label_RadiusOuterCircle.Text = "от 400 до 1000 мм";
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
            this.Controls.Add(this.label_LampRadius);
            this.Controls.Add(this.label_LampsAmount);
            this.Controls.Add(this.label_FoundationThickness);
            this.Controls.Add(this.label_RadiusBaseCircle);
            this.Controls.Add(this.label_RadiusInnerCircle);
            this.Controls.Add(this.label_RadiusOuterCircle);
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
        private System.Windows.Forms.Label label_LampRadius;
        private System.Windows.Forms.Label label_LampsAmount;
        private System.Windows.Forms.Label label_FoundationThickness;
        private System.Windows.Forms.Label label_RadiusBaseCircle;
        private System.Windows.Forms.Label label_RadiusInnerCircle;
        private System.Windows.Forms.Label label_RadiusOuterCircle;
        private System.Windows.Forms.Button button1;
    }
}

