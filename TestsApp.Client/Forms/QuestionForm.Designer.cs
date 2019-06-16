namespace TestsApp.Client
{
    partial class QuestionForm
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
            this.CheckQuestionButton = new System.Windows.Forms.Button();
            this.QuestionTitleLabel = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.NumLabel = new System.Windows.Forms.Label();
            this.CountLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CheckQuestionButton
            // 
            this.CheckQuestionButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckQuestionButton.Location = new System.Drawing.Point(204, 271);
            this.CheckQuestionButton.Margin = new System.Windows.Forms.Padding(2);
            this.CheckQuestionButton.Name = "CheckQuestionButton";
            this.CheckQuestionButton.Size = new System.Drawing.Size(139, 24);
            this.CheckQuestionButton.TabIndex = 0;
            this.CheckQuestionButton.Text = "Проверить";
            this.CheckQuestionButton.UseVisualStyleBackColor = true;
            this.CheckQuestionButton.Click += new System.EventHandler(this.CheckQuestionButton_Click);
            // 
            // QuestionTitleLabel
            // 
            this.QuestionTitleLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.QuestionTitleLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.QuestionTitleLabel.Location = new System.Drawing.Point(39, 46);
            this.QuestionTitleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.QuestionTitleLabel.Name = "QuestionTitleLabel";
            this.QuestionTitleLabel.Size = new System.Drawing.Size(451, 55);
            this.QuestionTitleLabel.TabIndex = 1;
            this.QuestionTitleLabel.Text = "Question text...";
            // 
            // radioButton1
            // 
            this.radioButton1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(13, 15);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(76, 17);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Вариант 1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.Controls.Add(this.radioButton4);
            this.panel1.Controls.Add(this.radioButton3);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Location = new System.Drawing.Point(38, 104);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(455, 123);
            this.panel1.TabIndex = 6;
            // 
            // radioButton4
            // 
            this.radioButton4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(13, 86);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(76, 17);
            this.radioButton4.TabIndex = 8;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Вариант 4";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(13, 62);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(76, 17);
            this.radioButton3.TabIndex = 7;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Вариант 3";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(13, 38);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(76, 17);
            this.radioButton2.TabIndex = 6;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Вариант 2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // NumLabel
            // 
            this.NumLabel.AutoSize = true;
            this.NumLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.NumLabel.Location = new System.Drawing.Point(39, 23);
            this.NumLabel.Name = "NumLabel";
            this.NumLabel.Size = new System.Drawing.Size(47, 13);
            this.NumLabel.TabIndex = 7;
            this.NumLabel.Text = "Вопрос ";
            // 
            // CountLabel
            // 
            this.CountLabel.AutoSize = true;
            this.CountLabel.Location = new System.Drawing.Point(38, 7);
            this.CountLabel.Name = "CountLabel";
            this.CountLabel.Size = new System.Drawing.Size(104, 13);
            this.CountLabel.TabIndex = 8;
            this.CountLabel.Text = "В базе ... вопросов";
            // 
            // QuestionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 306);
            this.Controls.Add(this.CountLabel);
            this.Controls.Add(this.NumLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.QuestionTitleLabel);
            this.Controls.Add(this.CheckQuestionButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(499, 220);
            this.Name = "QuestionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Question";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosingQuestionForm);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CheckQuestionButton;
        private System.Windows.Forms.Label QuestionTitleLabel;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label NumLabel;
        private System.Windows.Forms.Label CountLabel;
    }
}

