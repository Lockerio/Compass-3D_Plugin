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
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            textBox_RadiusOuterCircle = new System.Windows.Forms.TextBox();
            textBox_RadiusInnerCircle = new System.Windows.Forms.TextBox();
            textBox_FoundationThickness = new System.Windows.Forms.TextBox();
            textBox_RadiusBaseCircle = new System.Windows.Forms.TextBox();
            textBox_LampRadius = new System.Windows.Forms.TextBox();
            textBox_LampsAmount = new System.Windows.Forms.TextBox();
            label_LampRadius = new System.Windows.Forms.Label();
            label_LampsAmount = new System.Windows.Forms.Label();
            label_FoundationThickness = new System.Windows.Forms.Label();
            label_RadiusBaseCircle = new System.Windows.Forms.Label();
            label_RadiusInnerCircle = new System.Windows.Forms.Label();
            label_RadiusOuterCircle = new System.Windows.Forms.Label();
            buttonBuild = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(45, 41);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(191, 16);
            label1.TabIndex = 0;
            label1.Text = "Внешний радиус основания:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(45, 85);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(213, 16);
            label2.TabIndex = 1;
            label2.Text = "Внутренний радиус основания:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(45, 129);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(212, 16);
            label3.TabIndex = 2;
            label3.Text = "Радиус крепежного основания:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(45, 173);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(141, 16);
            label4.TabIndex = 3;
            label4.Text = "Толщина основания:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(45, 217);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(155, 16);
            label5.TabIndex = 4;
            label5.Text = "Количество лампочек:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(45, 261);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(125, 16);
            label6.TabIndex = 5;
            label6.Text = "Радиус лампочки:";
            // 
            // textBox_RadiusOuterCircle
            // 
            textBox_RadiusOuterCircle.BackColor = System.Drawing.Color.White;
            textBox_RadiusOuterCircle.Location = new System.Drawing.Point(274, 38);
            textBox_RadiusOuterCircle.Name = "textBox_RadiusOuterCircle";
            textBox_RadiusOuterCircle.Size = new System.Drawing.Size(144, 22);
            textBox_RadiusOuterCircle.TabIndex = 6;
            textBox_RadiusOuterCircle.TextChanged += new System.EventHandler(TextBox_TextChanged);
            // 
            // textBox_RadiusInnerCircle
            // 
            textBox_RadiusInnerCircle.Location = new System.Drawing.Point(274, 82);
            textBox_RadiusInnerCircle.Name = "textBox_RadiusInnerCircle";
            textBox_RadiusInnerCircle.Size = new System.Drawing.Size(144, 22);
            textBox_RadiusInnerCircle.TabIndex = 7;
            textBox_RadiusInnerCircle.TextChanged += new System.EventHandler(TextBox_TextChanged);
            // 
            // textBox_FoundationThickness
            // 
            textBox_FoundationThickness.Location = new System.Drawing.Point(274, 170);
            textBox_FoundationThickness.Name = "textBox_FoundationThickness";
            textBox_FoundationThickness.Size = new System.Drawing.Size(144, 22);
            textBox_FoundationThickness.TabIndex = 9;
            textBox_FoundationThickness.TextChanged += new System.EventHandler(TextBox_TextChanged);
            // 
            // textBox_RadiusBaseCircle
            // 
            textBox_RadiusBaseCircle.Location = new System.Drawing.Point(274, 126);
            textBox_RadiusBaseCircle.Name = "textBox_RadiusBaseCircle";
            textBox_RadiusBaseCircle.Size = new System.Drawing.Size(144, 22);
            textBox_RadiusBaseCircle.TabIndex = 8;
            textBox_RadiusBaseCircle.TextChanged += new System.EventHandler(TextBox_TextChanged);
            // 
            // textBox_LampRadius
            // 
            textBox_LampRadius.Location = new System.Drawing.Point(274, 258);
            textBox_LampRadius.Name = "textBox_LampRadius";
            textBox_LampRadius.Size = new System.Drawing.Size(144, 22);
            textBox_LampRadius.TabIndex = 11;
            textBox_LampRadius.TextChanged += new System.EventHandler(TextBox_TextChanged);
            // 
            // textBox_LampsAmount
            // 
            textBox_LampsAmount.Location = new System.Drawing.Point(274, 214);
            textBox_LampsAmount.Name = "textBox_LampsAmount";
            textBox_LampsAmount.Size = new System.Drawing.Size(144, 22);
            textBox_LampsAmount.TabIndex = 10;
            textBox_LampsAmount.TextChanged += new System.EventHandler(TextBox_TextChanged);
            // 
            // label_LampRadius
            // 
            label_LampRadius.AutoSize = true;
            label_LampRadius.Location = new System.Drawing.Point(429, 261);
            label_LampRadius.Name = "label_LampRadius";
            label_LampRadius.Size = new System.Drawing.Size(0, 16);
            label_LampRadius.TabIndex = 17;
            // 
            // label_LampsAmount
            // 
            label_LampsAmount.AutoSize = true;
            label_LampsAmount.Location = new System.Drawing.Point(428, 217);
            label_LampsAmount.Name = "label_LampsAmount";
            label_LampsAmount.Size = new System.Drawing.Size(0, 16);
            label_LampsAmount.TabIndex = 16;
            // 
            // label_FoundationThickness
            // 
            label_FoundationThickness.AutoSize = true;
            label_FoundationThickness.Location = new System.Drawing.Point(428, 173);
            label_FoundationThickness.Name = "label_FoundationThickness";
            label_FoundationThickness.Size = new System.Drawing.Size(0, 16);
            label_FoundationThickness.TabIndex = 15;
            // 
            // label_RadiusBaseCircle
            // 
            label_RadiusBaseCircle.AutoSize = true;
            label_RadiusBaseCircle.Location = new System.Drawing.Point(428, 129);
            label_RadiusBaseCircle.Name = "label_RadiusBaseCircle";
            label_RadiusBaseCircle.Size = new System.Drawing.Size(0, 16);
            label_RadiusBaseCircle.TabIndex = 14;
            // 
            // label_RadiusInnerCircle
            // 
            label_RadiusInnerCircle.AutoSize = true;
            label_RadiusInnerCircle.Location = new System.Drawing.Point(428, 85);
            label_RadiusInnerCircle.Name = "label_RadiusInnerCircle";
            label_RadiusInnerCircle.Size = new System.Drawing.Size(0, 16);
            label_RadiusInnerCircle.TabIndex = 13;
            // 
            // label_RadiusOuterCircle
            // 
            label_RadiusOuterCircle.AutoSize = true;
            label_RadiusOuterCircle.Location = new System.Drawing.Point(428, 41);
            label_RadiusOuterCircle.Name = "label_RadiusOuterCircle";
            label_RadiusOuterCircle.Size = new System.Drawing.Size(0, 16);
            label_RadiusOuterCircle.TabIndex = 12;
            // 
            // buttonBuild
            // 
            buttonBuild.Location = new System.Drawing.Point(726, 289);
            buttonBuild.Name = "buttonBuild";
            buttonBuild.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            buttonBuild.Size = new System.Drawing.Size(100, 32);
            buttonBuild.TabIndex = 18;
            buttonBuild.Text = "Построить";
            buttonBuild.UseVisualStyleBackColor = true;
            buttonBuild.Click += new System.EventHandler(buttonBuild_Click);
            // 
            // FormMain
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(838, 333);
            Controls.Add(buttonBuild);
            Controls.Add(label_LampRadius);
            Controls.Add(label_LampsAmount);
            Controls.Add(label_FoundationThickness);
            Controls.Add(label_RadiusBaseCircle);
            Controls.Add(label_RadiusInnerCircle);
            Controls.Add(label_RadiusOuterCircle);
            Controls.Add(textBox_LampRadius);
            Controls.Add(textBox_LampsAmount);
            Controls.Add(textBox_FoundationThickness);
            Controls.Add(textBox_RadiusBaseCircle);
            Controls.Add(textBox_RadiusInnerCircle);
            Controls.Add(textBox_RadiusOuterCircle);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormMain";
            Text = "ChandelierPlugin";
            Load += new System.EventHandler(FormMain_Load);
            ResumeLayout(false);
            PerformLayout();

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
        private System.Windows.Forms.Button buttonBuild;
    }
}

