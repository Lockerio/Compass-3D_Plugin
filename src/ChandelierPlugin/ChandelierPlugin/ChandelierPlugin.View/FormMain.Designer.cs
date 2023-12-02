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
            this.buttonBuild = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_ParameterMultiplier = new System.Windows.Forms.TextBox();
            this.textBox_LayersAmount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label_ParameterMultiplier = new System.Windows.Forms.Label();
            this.label_LayersAmount = new System.Windows.Forms.Label();
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
            this.label2.Location = new System.Drawing.Point(45, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Внутренний радиус основания:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(212, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Радиус крепежного основания:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Толщина основания:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Количество лампочек:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 261);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Радиус лампочки:";
            // 
            // textBox_RadiusOuterCircle
            // 
            this.textBox_RadiusOuterCircle.BackColor = System.Drawing.Color.White;
            this.textBox_RadiusOuterCircle.Location = new System.Drawing.Point(274, 38);
            this.textBox_RadiusOuterCircle.Name = "textBox_RadiusOuterCircle";
            this.textBox_RadiusOuterCircle.Size = new System.Drawing.Size(144, 22);
            this.textBox_RadiusOuterCircle.TabIndex = 6;
            this.textBox_RadiusOuterCircle.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // textBox_RadiusInnerCircle
            // 
            this.textBox_RadiusInnerCircle.Location = new System.Drawing.Point(274, 82);
            this.textBox_RadiusInnerCircle.Name = "textBox_RadiusInnerCircle";
            this.textBox_RadiusInnerCircle.Size = new System.Drawing.Size(144, 22);
            this.textBox_RadiusInnerCircle.TabIndex = 7;
            this.textBox_RadiusInnerCircle.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // textBox_FoundationThickness
            // 
            this.textBox_FoundationThickness.Location = new System.Drawing.Point(274, 170);
            this.textBox_FoundationThickness.Name = "textBox_FoundationThickness";
            this.textBox_FoundationThickness.Size = new System.Drawing.Size(144, 22);
            this.textBox_FoundationThickness.TabIndex = 9;
            this.textBox_FoundationThickness.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // textBox_RadiusBaseCircle
            // 
            this.textBox_RadiusBaseCircle.Location = new System.Drawing.Point(274, 126);
            this.textBox_RadiusBaseCircle.Name = "textBox_RadiusBaseCircle";
            this.textBox_RadiusBaseCircle.Size = new System.Drawing.Size(144, 22);
            this.textBox_RadiusBaseCircle.TabIndex = 8;
            this.textBox_RadiusBaseCircle.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // textBox_LampRadius
            // 
            this.textBox_LampRadius.Location = new System.Drawing.Point(274, 258);
            this.textBox_LampRadius.Name = "textBox_LampRadius";
            this.textBox_LampRadius.Size = new System.Drawing.Size(144, 22);
            this.textBox_LampRadius.TabIndex = 11;
            this.textBox_LampRadius.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // textBox_LampsAmount
            // 
            this.textBox_LampsAmount.Location = new System.Drawing.Point(274, 214);
            this.textBox_LampsAmount.Name = "textBox_LampsAmount";
            this.textBox_LampsAmount.Size = new System.Drawing.Size(144, 22);
            this.textBox_LampsAmount.TabIndex = 10;
            this.textBox_LampsAmount.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // label_LampRadius
            // 
            this.label_LampRadius.AutoSize = true;
            this.label_LampRadius.Location = new System.Drawing.Point(429, 261);
            this.label_LampRadius.Name = "label_LampRadius";
            this.label_LampRadius.Size = new System.Drawing.Size(0, 16);
            this.label_LampRadius.TabIndex = 17;
            // 
            // label_LampsAmount
            // 
            this.label_LampsAmount.AutoSize = true;
            this.label_LampsAmount.Location = new System.Drawing.Point(428, 217);
            this.label_LampsAmount.Name = "label_LampsAmount";
            this.label_LampsAmount.Size = new System.Drawing.Size(0, 16);
            this.label_LampsAmount.TabIndex = 16;
            // 
            // label_FoundationThickness
            // 
            this.label_FoundationThickness.AutoSize = true;
            this.label_FoundationThickness.Location = new System.Drawing.Point(428, 173);
            this.label_FoundationThickness.Name = "label_FoundationThickness";
            this.label_FoundationThickness.Size = new System.Drawing.Size(0, 16);
            this.label_FoundationThickness.TabIndex = 15;
            // 
            // label_RadiusBaseCircle
            // 
            this.label_RadiusBaseCircle.AutoSize = true;
            this.label_RadiusBaseCircle.Location = new System.Drawing.Point(428, 129);
            this.label_RadiusBaseCircle.Name = "label_RadiusBaseCircle";
            this.label_RadiusBaseCircle.Size = new System.Drawing.Size(0, 16);
            this.label_RadiusBaseCircle.TabIndex = 14;
            // 
            // label_RadiusInnerCircle
            // 
            this.label_RadiusInnerCircle.AutoSize = true;
            this.label_RadiusInnerCircle.Location = new System.Drawing.Point(428, 85);
            this.label_RadiusInnerCircle.Name = "label_RadiusInnerCircle";
            this.label_RadiusInnerCircle.Size = new System.Drawing.Size(0, 16);
            this.label_RadiusInnerCircle.TabIndex = 13;
            // 
            // label_RadiusOuterCircle
            // 
            this.label_RadiusOuterCircle.AutoSize = true;
            this.label_RadiusOuterCircle.Location = new System.Drawing.Point(428, 41);
            this.label_RadiusOuterCircle.Name = "label_RadiusOuterCircle";
            this.label_RadiusOuterCircle.Size = new System.Drawing.Size(0, 16);
            this.label_RadiusOuterCircle.TabIndex = 12;
            // 
            // buttonBuild
            // 
            this.buttonBuild.Location = new System.Drawing.Point(741, 378);
            this.buttonBuild.Name = "buttonBuild";
            this.buttonBuild.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.buttonBuild.Size = new System.Drawing.Size(100, 32);
            this.buttonBuild.TabIndex = 18;
            this.buttonBuild.Text = "Построить";
            this.buttonBuild.UseVisualStyleBackColor = true;
            this.buttonBuild.Click += new System.EventHandler(this.ButtonBuild_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(429, 349);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 16);
            this.label7.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(428, 305);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 16);
            this.label8.TabIndex = 23;
            // 
            // textBox_ParameterMultiplier
            // 
            this.textBox_ParameterMultiplier.Location = new System.Drawing.Point(274, 346);
            this.textBox_ParameterMultiplier.Name = "textBox_ParameterMultiplier";
            this.textBox_ParameterMultiplier.Size = new System.Drawing.Size(144, 22);
            this.textBox_ParameterMultiplier.TabIndex = 22;
            // 
            // textBox_LayersAmount
            // 
            this.textBox_LayersAmount.Location = new System.Drawing.Point(274, 302);
            this.textBox_LayersAmount.Name = "textBox_LayersAmount";
            this.textBox_LayersAmount.Size = new System.Drawing.Size(144, 22);
            this.textBox_LayersAmount.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(45, 349);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(167, 16);
            this.label9.TabIndex = 20;
            this.label9.Text = "Множитель параметров:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(45, 308);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(130, 16);
            this.label10.TabIndex = 19;
            this.label10.Text = "Количество слоев:";
            // 
            // label_ParameterMultiplier
            // 
            this.label_ParameterMultiplier.AutoSize = true;
            this.label_ParameterMultiplier.Location = new System.Drawing.Point(428, 349);
            this.label_ParameterMultiplier.Name = "label_ParameterMultiplier";
            this.label_ParameterMultiplier.Size = new System.Drawing.Size(0, 16);
            this.label_ParameterMultiplier.TabIndex = 25;
            // 
            // label_LayersAmount
            // 
            this.label_LayersAmount.AutoSize = true;
            this.label_LayersAmount.Location = new System.Drawing.Point(428, 305);
            this.label_LayersAmount.Name = "label_LayersAmount";
            this.label_LayersAmount.Size = new System.Drawing.Size(0, 16);
            this.label_LayersAmount.TabIndex = 26;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 422);
            this.Controls.Add(this.label_LayersAmount);
            this.Controls.Add(this.label_ParameterMultiplier);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox_ParameterMultiplier);
            this.Controls.Add(this.textBox_LayersAmount);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.buttonBuild);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
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
        private System.Windows.Forms.Button buttonBuild;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_ParameterMultiplier;
        private System.Windows.Forms.TextBox textBox_LayersAmount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label_ParameterMultiplier;
        private System.Windows.Forms.Label label_LayersAmount;
    }
}

