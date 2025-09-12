namespace E_commerce.Presentation
{
    partial class Registeration
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
            UserName = new Label();
            Email = new Label();
            Password = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            ConfirmPassword = new Label();
            textBox4 = new TextBox();
            Register = new Button();
            SuspendLayout();
            // 
            // UserName
            // 
            UserName.AutoSize = true;
            UserName.Location = new Point(161, 75);
            UserName.Name = "UserName";
            UserName.Size = new Size(82, 20);
            UserName.TabIndex = 0;
            UserName.Text = "User Name";
            // 
            // Email
            // 
            Email.AutoSize = true;
            Email.Location = new Point(161, 141);
            Email.Name = "Email";
            Email.Size = new Size(46, 20);
            Email.TabIndex = 1;
            Email.Text = "Email";
            // 
            // Password
            // 
            Password.AutoSize = true;
            Password.Location = new Point(161, 205);
            Password.Name = "Password";
            Password.Size = new Size(70, 20);
            Password.TabIndex = 2;
            Password.Text = "Password";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(320, 72);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(285, 27);
            textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(320, 202);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(285, 27);
            textBox2.TabIndex = 4;
            textBox2.UseSystemPasswordChar = true;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(320, 138);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(285, 27);
            textBox3.TabIndex = 5;
            // 
            // ConfirmPassword
            // 
            ConfirmPassword.AutoSize = true;
            ConfirmPassword.Location = new Point(161, 271);
            ConfirmPassword.Name = "ConfirmPassword";
            ConfirmPassword.Size = new Size(127, 20);
            ConfirmPassword.TabIndex = 6;
            ConfirmPassword.Text = "Confirm Password";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(320, 268);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(285, 27);
            textBox4.TabIndex = 7;
            textBox4.UseSystemPasswordChar = true;
            // 
            // Register
            // 
            Register.Location = new Point(409, 359);
            Register.Name = "Register";
            Register.Size = new Size(94, 29);
            Register.TabIndex = 8;
            Register.Text = "Register";
            Register.UseVisualStyleBackColor = true;
            Register.Click += this.Register_Click;
            // 
            // Registeration
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Register);
            Controls.Add(textBox4);
            Controls.Add(ConfirmPassword);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(Password);
            Controls.Add(Email);
            Controls.Add(UserName);
            Name = "Registeration";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label UserName;
        private Label Email;
        private Label Password;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label ConfirmPassword;
        private TextBox textBox4;
        private Button Register;
    }
}
