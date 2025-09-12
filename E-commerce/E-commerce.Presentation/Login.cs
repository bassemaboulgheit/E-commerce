using Autofac;
using E_commerce.Application.Services;
using E_commerce.Context;
using E_commerce.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace E_commerce.Presentation
{
    public partial class Login : Form
    {
        private MyContext _context;
        public Login()
        {
            InitializeComponent();
            var Builder = AutoFac.Inject();
            _ProductService = Builder.Resolve<IProdectService>();
            _userService = Builder.Resolve<IUserService>();
        }

        IProdectService _ProductService;
        IUserService _userService;
        List<Product> ProductList;
        BindingSource bindingSource;

        private void RegisterLogin_Click(object sender, EventArgs e)
        {
            // Open registration form
            var registerForm = new Registeration();
            registerForm.Show();
            this.Hide();
        }

        private async void Loginbutton_Click(object sender, EventArgs e)
        {
            try
            {
                var result = await _userService.LoginAsync(textBox2.Text, textBox3.Text);

                if (result.Data == null || !result.Success)
                {
                    MessageBox.Show(result.Message ?? "Invalid username or password",
                        "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show(result.Message ?? "Login successful",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var loggedUser = result.Data;

                // تحقق من الدور (Role)
                if (loggedUser.Role == "Admin")
                {
                    this.Text = "Admin Dashboard";
                    // new AdminDashboard(loggedUser).Show();
                }
                else
                {
                    this.Text = "Customer Dashboard";
                    // var customerForm = new CustomerDashboard(loggedUser);
                    // customerForm.DisableAdminControls();
                    // customerForm.Show();
                }

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Exception",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
