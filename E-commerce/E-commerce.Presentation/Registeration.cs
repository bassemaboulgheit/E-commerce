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
            // 2. Create DTO
            //User dto = new User
            //{
            //    Name = textBox1.Text.Trim(),
            //    Email = textBox3.Text.Trim(),
            //    Password = textBox2.Text.Trim()
            //};

            var result = await _userService.RegisterAsync(
                   textBox1.Text,
                   textBox3.Text,
                   textBox2.Text,
                   textBox4.Text
               );

            if (!result.Success)
            {
                MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(result.Message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var loginForm = new Login();
            loginForm.Show();
            this.Close();
        }
    }
}
