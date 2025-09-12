namespace E_commerce.Presentation
{
    partial class Login
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
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            Password = new Label();
            UserName = new Label();
            Loginbutton = new Button();
            RegisterLogin = new Button();
            SuspendLayout();
            // 
            // textBox3
            // 
            textBox3.Location = new Point(337, 188);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(285, 27);
            textBox3.TabIndex = 9;
            textBox3.UseSystemPasswordChar = true;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(337, 122);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(285, 27);
            textBox2.TabIndex = 8;
            // 
            // Password
            // 
            Password.AutoSize = true;
            Password.Location = new Point(178, 191);
            Password.Name = "Password";
            Password.Size = new Size(70, 20);
            Password.TabIndex = 7;
            Password.Text = "Password";
            // 
            // UserName
            // 
            UserName.AutoSize = true;
            UserName.Location = new Point(178, 125);
            UserName.Name = "UserName";
            UserName.Size = new Size(82, 20);
            UserName.TabIndex = 6;
            UserName.Text = "User Name";
            // 
            // Loginbutton
            // 
            Loginbutton.Location = new Point(528, 335);
            Loginbutton.Name = "Loginbutton";
            Loginbutton.Size = new Size(94, 29);
            Loginbutton.TabIndex = 10;
            Loginbutton.Text = "Login";
            Loginbutton.UseVisualStyleBackColor = true;
            Loginbutton.Click += Loginbutton_Click;
            // 
            // RegisterLogin
            // 
            RegisterLogin.Location = new Point(337, 335);
            RegisterLogin.Name = "RegisterLogin";
            RegisterLogin.Size = new Size(94, 29);
            RegisterLogin.TabIndex = 11;
            RegisterLogin.Text = "Register";
            RegisterLogin.UseVisualStyleBackColor = true;
            RegisterLogin.Click += RegisterLogin_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(RegisterLogin);
            Controls.Add(Loginbutton);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(Password);
            Controls.Add(UserName);
            Name = "Login";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox3;
        private TextBox textBox2;
        private Label Password;
        private Label UserName;
        private Button Loginbutton;
        private Button RegisterLogin;
    }
}