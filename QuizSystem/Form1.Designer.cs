
namespace QuizSystem
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
            this.questionLabel = new System.Windows.Forms.Label();
            this.optionsListBox = new System.Windows.Forms.ListBox();
            this.nextButton = new System.Windows.Forms.Button();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // questionLabel
            // 
            this.questionLabel.AutoSize = true;
            this.questionLabel.Location = new System.Drawing.Point(149, 29);
            this.questionLabel.Name = "questionLabel";
            this.questionLabel.Size = new System.Drawing.Size(35, 13);
            this.questionLabel.TabIndex = 0;
            this.questionLabel.Text = "label1";
            // 
            // optionsListBox
            // 
            this.optionsListBox.FormattingEnabled = true;
            this.optionsListBox.Location = new System.Drawing.Point(146, 86);
            this.optionsListBox.Name = "optionsListBox";
            this.optionsListBox.Size = new System.Drawing.Size(588, 95);
            this.optionsListBox.TabIndex = 1;
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(389, 201);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(78, 41);
            this.nextButton.TabIndex = 2;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Location = new System.Drawing.Point(414, 303);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(35, 13);
            this.scoreLabel.TabIndex = 3;
            this.scoreLabel.Text = "Score";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.optionsListBox);
            this.Controls.Add(this.questionLabel);
            this.Name = "Form1";
            this.Text = "Quiz System";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label questionLabel;
        private System.Windows.Forms.ListBox optionsListBox;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Label scoreLabel;
    }
}

