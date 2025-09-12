using Autofac;
using E_commerce.Application.Services;
using E_commerce.Models;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace E_commerce.Presentation
{
    public partial class Registeration : Form
    {
        public Registeration()
        {
            InitializeComponent();
            var Builder = AutoFac.Inject();
            _userService = Builder.Resolve<IUserService>();


        }

        IUserService _userService;
        BindingSource bindingSource;



        private async void Register_Click(object sender, EventArgs e)
        {
            // 1. Validation
            if (string.IsNullOrWhiteSpace(UserName.Text))
            {
                MessageBox.Show("Please enter a username", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(Email.Text))
            {
                MessageBox.Show("Please enter an email", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //if (!Regex.IsMatch(Email.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            //{
            //    MessageBox.Show("Invalid email format", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //if (string.IsNullOrWhiteSpace(Password.Text))
            //{
            //    MessageBox.Show("Please enter a password", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //if (Password.Text != ConfirmPassword.Text)
            //{
            //    MessageBox.Show("Passwords do not match", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            var result = await _userService.RegisterAsync(
                   UserName.Text,
                   Email.Text,
                   Password.Text,
                   ConfirmPassword.Text
               );

            if (!result.Success)
            {
                MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(result.Message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


            // 2. Create DTO
            User dto = new User
            {
                Name = UserName.Text.Trim(),
                Email = Email.Text.Trim(),
                Password = Password.Text.Trim()
            };

            // 3. Call Service
            //var result = await _userService.RegisterAsync(dto);

            //if (!result)
            //{
            //    MessageBox.Show("Registration failed. Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //MessageBox.Show("Registration successful! You can now log in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 4. بعد التسجيل ارجع لفورم اللوجين

            await _userService.AddAsync(dto);
         
            _userService.saveChanges();

            var loginForm = new Login();
            loginForm.Show();


            this.Close();


        }
    }
}
