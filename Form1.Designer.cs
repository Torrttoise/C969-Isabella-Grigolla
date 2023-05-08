namespace C969_Isabella_Grigolla
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.formTitle = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.userName = new System.Windows.Forms.Label();
            this.passWord = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // formTitle
            // 
            resources.ApplyResources(this.formTitle, "formTitle");
            this.formTitle.Name = "formTitle";
            this.formTitle.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // textBox2
            // 
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.Name = "textBox2";
            // 
            // userName
            // 
            resources.ApplyResources(this.userName, "userName");
            this.userName.Name = "userName";
            // 
            // passWord
            // 
            resources.ApplyResources(this.passWord, "passWord");
            this.passWord.Name = "passWord";
            // 
            // submitButton
            // 
            resources.ApplyResources(this.submitButton, "submitButton");
            this.submitButton.Name = "submitButton";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // exitButton
            // 
            resources.ApplyResources(this.exitButton, "exitButton");
            this.exitButton.Name = "exitButton";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.passWord);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.formTitle);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label formTitle;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label userName;
        private System.Windows.Forms.Label passWord;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button exitButton;
    }
}

