namespace TestsApp.Client
{
    partial class StartForm
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
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonAddQuestion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStart.Location = new System.Drawing.Point(30, 36);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(254, 33);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Начать тест";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.OnStartTest);
            // 
            // buttonAddQuestion
            // 
            this.buttonAddQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddQuestion.Location = new System.Drawing.Point(30, 93);
            this.buttonAddQuestion.Name = "buttonAddQuestion";
            this.buttonAddQuestion.Size = new System.Drawing.Size(254, 34);
            this.buttonAddQuestion.TabIndex = 1;
            this.buttonAddQuestion.Text = "Добавить новый вопрос в базу";
            this.buttonAddQuestion.UseVisualStyleBackColor = true;
            this.buttonAddQuestion.Click += new System.EventHandler(this.OnAddQuestion);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 159);
            this.Controls.Add(this.buttonAddQuestion);
            this.Controls.Add(this.buttonStart);
            this.MinimumSize = new System.Drawing.Size(332, 198);
            this.Name = "StartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StartForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonAddQuestion;
    }
}