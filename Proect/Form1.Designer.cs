namespace Proect
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            label1 = new Label();
            label2 = new Label();
            button6 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button1.ForeColor = SystemColors.ActiveCaptionText;
            button1.Location = new Point(12, 78);
            button1.Name = "button1";
            button1.Size = new Size(252, 51);
            button1.TabIndex = 0;
            button1.Text = "Сотрудники";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button2.ForeColor = SystemColors.ActiveCaptionText;
            button2.Location = new Point(12, 135);
            button2.Name = "button2";
            button2.Size = new Size(252, 51);
            button2.TabIndex = 1;
            button2.Text = "Товары";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button3.ForeColor = SystemColors.ActiveCaptionText;
            button3.Location = new Point(12, 192);
            button3.Name = "button3";
            button3.Size = new Size(252, 51);
            button3.TabIndex = 2;
            button3.Text = "Поставки";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button4.ForeColor = SystemColors.ActiveCaptionText;
            button4.Location = new Point(12, 249);
            button4.Name = "button4";
            button4.Size = new Size(252, 51);
            button4.TabIndex = 3;
            button4.Text = "Корректировки";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button5.ForeColor = SystemColors.ActiveCaptionText;
            button5.Location = new Point(12, 306);
            button5.Name = "button5";
            button5.Size = new Size(252, 51);
            button5.TabIndex = 4;
            button5.Text = "Бухгалтерия";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label1
            // 
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(12, 360);
            label1.Name = "label1";
            label1.Size = new Size(248, 112);
            label1.TabIndex = 5;
            label1.Text = resources.GetString("label1.Text");
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(12, 5);
            label2.Name = "label2";
            label2.Size = new Size(252, 34);
            label2.TabIndex = 6;
            label2.Text = "УПРАВЛЕНИЕ СКЛАДОМ";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // button6
            // 
            button6.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button6.ForeColor = SystemColors.ActiveCaptionText;
            button6.Location = new Point(70, 536);
            button6.Name = "button6";
            button6.Size = new Size(124, 46);
            button6.TabIndex = 7;
            button6.Text = "Выход";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(269, 594);
            Controls.Add(button6);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            ForeColor = SystemColors.ControlLightLight;
            Name = "Form1";
            Text = "Управление Склада";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Label label1;
        private Label label2;
        private Button button6;
    }
}
