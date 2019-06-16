namespace TestsApp.Client
{
    partial class AddQuestionForm
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
            this.AddButton = new System.Windows.Forms.Button();
            this.TextVar1 = new System.Windows.Forms.TextBox();
            this.TextVar2 = new System.Windows.Forms.TextBox();
            this.TextVar3 = new System.Windows.Forms.TextBox();
            this.TextVar4 = new System.Windows.Forms.TextBox();
            this.QTextBox = new System.Windows.Forms.TextBox();
            this.QTextLabel = new System.Windows.Forms.Label();
            this.VarsLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.VarComboBox = new System.Windows.Forms.ComboBox();
            this.RightVarLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.Location = new System.Drawing.Point(68, 266);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(225, 23);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "Добавить вопрос в базу";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.OnAddButton);
            // 
            // TextVar1
            // 
            this.TextVar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextVar1.Location = new System.Drawing.Point(30, 104);
            this.TextVar1.MaxLength = 100;
            this.TextVar1.Name = "TextVar1";
            this.TextVar1.Size = new System.Drawing.Size(308, 20);
            this.TextVar1.TabIndex = 1;
            // 
            // TextVar2
            // 
            this.TextVar2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextVar2.Location = new System.Drawing.Point(30, 130);
            this.TextVar2.MaxLength = 100;
            this.TextVar2.Name = "TextVar2";
            this.TextVar2.Size = new System.Drawing.Size(308, 20);
            this.TextVar2.TabIndex = 2;
            this.TextVar2.TextChanged += new System.EventHandler(this.OnChangeVar2);
            // 
            // TextVar3
            // 
            this.TextVar3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextVar3.Enabled = false;
            this.TextVar3.Location = new System.Drawing.Point(30, 156);
            this.TextVar3.MaxLength = 100;
            this.TextVar3.Name = "TextVar3";
            this.TextVar3.Size = new System.Drawing.Size(308, 20);
            this.TextVar3.TabIndex = 3;
            this.TextVar3.TextChanged += new System.EventHandler(this.OnChangeVar3);
            // 
            // TextVar4
            // 
            this.TextVar4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextVar4.Enabled = false;
            this.TextVar4.Location = new System.Drawing.Point(30, 182);
            this.TextVar4.MaxLength = 100;
            this.TextVar4.Name = "TextVar4";
            this.TextVar4.Size = new System.Drawing.Size(308, 20);
            this.TextVar4.TabIndex = 4;
            this.TextVar4.TextChanged += new System.EventHandler(this.OnChangeVar4);
            // 
            // QTextBox
            // 
            this.QTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.QTextBox.Location = new System.Drawing.Point(12, 48);
            this.QTextBox.MaxLength = 400;
            this.QTextBox.Name = "QTextBox";
            this.QTextBox.Size = new System.Drawing.Size(326, 20);
            this.QTextBox.TabIndex = 5;
            // 
            // QTextLabel
            // 
            this.QTextLabel.AutoSize = true;
            this.QTextLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.QTextLabel.Location = new System.Drawing.Point(12, 32);
            this.QTextLabel.Name = "QTextLabel";
            this.QTextLabel.Size = new System.Drawing.Size(256, 13);
            this.QTextLabel.TabIndex = 6;
            this.QTextLabel.Text = "Введите текст вопроса (не более 400 символов):";
            // 
            // VarsLabel
            // 
            this.VarsLabel.AutoSize = true;
            this.VarsLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.VarsLabel.Location = new System.Drawing.Point(12, 85);
            this.VarsLabel.Name = "VarsLabel";
            this.VarsLabel.Size = new System.Drawing.Size(326, 13);
            this.VarsLabel.TabIndex = 7;
            this.VarsLabel.Text = "Введите варианты ответа на вопрос (не более 100 символов): ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "1. ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "2. ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "3. ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "4. ";
            // 
            // VarComboBox
            // 
            this.VarComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VarComboBox.FormattingEnabled = true;
            this.VarComboBox.Location = new System.Drawing.Point(12, 231);
            this.VarComboBox.Name = "VarComboBox";
            this.VarComboBox.Size = new System.Drawing.Size(121, 21);
            this.VarComboBox.TabIndex = 12;
            // 
            // RightVarLabel
            // 
            this.RightVarLabel.AutoSize = true;
            this.RightVarLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.RightVarLabel.Location = new System.Drawing.Point(12, 215);
            this.RightVarLabel.Name = "RightVarLabel";
            this.RightVarLabel.Size = new System.Drawing.Size(195, 13);
            this.RightVarLabel.TabIndex = 13;
            this.RightVarLabel.Text = "Введите номер правильного ответа: ";
            // 
            // AddQuestionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 301);
            this.Controls.Add(this.RightVarLabel);
            this.Controls.Add(this.VarComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.VarsLabel);
            this.Controls.Add(this.QTextLabel);
            this.Controls.Add(this.QTextBox);
            this.Controls.Add(this.TextVar4);
            this.Controls.Add(this.TextVar3);
            this.Controls.Add(this.TextVar2);
            this.Controls.Add(this.TextVar1);
            this.Controls.Add(this.AddButton);
            this.MinimumSize = new System.Drawing.Size(353, 340);
            this.Name = "AddQuestionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddQuestionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.TextBox TextVar1;
        private System.Windows.Forms.TextBox TextVar2;
        private System.Windows.Forms.TextBox TextVar3;
        private System.Windows.Forms.TextBox TextVar4;
        private System.Windows.Forms.TextBox QTextBox;
        private System.Windows.Forms.Label QTextLabel;
        private System.Windows.Forms.Label VarsLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox VarComboBox;
        private System.Windows.Forms.Label RightVarLabel;
    }
}