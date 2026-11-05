using System;
using System.Drawing;
using System.Windows.Forms;

namespace CombinedApp
{
    public class LoginForm : Form
    {
        private const string ValidUsername = "admin";
        private const string ValidPassword = "admin123";

        private readonly TextBox usernameBox;
        private readonly TextBox passwordBox;
        private readonly Label errorLabel;

        public LoginForm()
        {
            Text = "Login - Mushroom & Bicycle System";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            ClientSize = new Size(380, 290);
            BackColor = Color.WhiteSmoke;
            Font = new Font("Segoe UI", 9F);

            var title = new Label
            {
                Text = "Mushroom & Bicycle System",
                Font = new Font("Segoe UI", 15F, FontStyle.Bold),
                ForeColor = Color.FromArgb(45, 75, 45),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(20, 15),
                Size = new Size(340, 35)
            };

            var subtitle = new Label
            {
                Text = "Sign in to continue",
                ForeColor = Color.DimGray,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(20, 50),
                Size = new Size(340, 20)
            };

            var usernameLabel = new Label
            {
                Text = "Username:",
                Location = new Point(40, 90),
                Size = new Size(80, 20)
            };

            usernameBox = new TextBox
            {
                Location = new Point(130, 87),
                Size = new Size(200, 23)
            };

            var passwordLabel = new Label
            {
                Text = "Password:",
                Location = new Point(40, 125),
                Size = new Size(80, 20)
            };

            passwordBox = new TextBox
            {
                Location = new Point(130, 122),
                Size = new Size(200, 23),
                UseSystemPasswordChar = true
            };

            var showPassword = new CheckBox
            {
                Text = "Show password",
                Location = new Point(130, 150),
                Size = new Size(150, 20)
            };
            showPassword.CheckedChanged += (sender, e) =>
                passwordBox.UseSystemPasswordChar = !showPassword.Checked;

            errorLabel = new Label
            {
                ForeColor = Color.Firebrick,
                Location = new Point(40, 175),
                Size = new Size(300, 20)
            };

            var loginButton = new Button
            {
                Text = "Login",
                Location = new Point(130, 205),
                Size = new Size(100, 32),
                BackColor = Color.FromArgb(45, 75, 45),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                UseVisualStyleBackColor = false
            };
            loginButton.FlatAppearance.BorderSize = 0;
            loginButton.Click += LoginButton_Click;

            var hint = new Label
            {
                Text = "Demo login: admin / admin123",
                ForeColor = Color.Gray,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(20, 250),
                Size = new Size(340, 20)
            };

            AcceptButton = loginButton;

            Controls.Add(title);
            Controls.Add(subtitle);
            Controls.Add(usernameLabel);
            Controls.Add(usernameBox);
            Controls.Add(passwordLabel);
            Controls.Add(passwordBox);
            Controls.Add(showPassword);
            Controls.Add(errorLabel);
            Controls.Add(loginButton);
            Controls.Add(hint);
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = usernameBox.Text.Trim();
            string password = passwordBox.Text;

            if (username.Length == 0 || password.Length == 0)
            {
                errorLabel.Text = "Please enter both username and password.";
                return;
            }

            if (username == ValidUsername && password == ValidPassword)
            {
                Hide();
                var main = new MainForm(username);
                main.FormClosed += (s, args) => Close();
                main.Show();
            }
            else
            {
                errorLabel.Text = "Invalid username or password.";
                passwordBox.Clear();
                passwordBox.Focus();
            }
        }
    }
}
