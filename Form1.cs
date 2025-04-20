using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CVValidator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnValidateForm_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            string password = txtPassword.Text;
            string address = txtAddress.Text;
            string postal = txtPostal.Text;

            string result = "";

            result += ValidateField("Name", name, @"^[a-zA-Z\s]+$");
            result += ValidateField("Email", email, @"^\w+@\w+\.\w{2,3}$");
            result += ValidateField("Phone", phone, @"^\+?\d{10,15}$");
            result += ValidateField("Password", password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{7,16}$");
            result += ValidateField("Address", address, @".+");
            result += ValidateField("Postal Code", postal, @"^\d{5,6}$");

            MessageBox.Show(result, "Validation Results");
        }

        private string ValidateField(string fieldName, string input, string pattern)
        {
            return Regex.IsMatch(input, pattern) ? $"{fieldName}: Valid\n" : $"{fieldName}: Invalid\n";
        }

        private void btnParseCV_Click(object sender, EventArgs e)
        {
            string cvText = txtCV.Text;
            string result = "";

            var nameMatch = Regex.Match(cvText, @"(?<=Name[:\s]*)[A-Z][a-z]+\s[A-Z][a-z]+");
            var emailMatch = Regex.Match(cvText, @"\b\w+@\w+\.\w{2,3}\b");
            var phoneMatch = Regex.Match(cvText, @"\+?\d{10,15}");
            var skillsMatch = Regex.Matches(cvText, @"\b(C#|Java|SQL|Python|JavaScript)\b");
            var expMatch = Regex.Match(cvText, @"\b\d+\s+years?\b");

            result += $"Name: {nameMatch.Value}\n";
            result += $"Email: {emailMatch.Value}\n";
            result += $"Phone: {phoneMatch.Value}\n";

            result += "Skills: ";
            foreach (Match skill in skillsMatch)
                result += $"{skill.Value}, ";
            result = result.TrimEnd(',', ' ') + "\n";

            result += $"Experience: {expMatch.Value}\n";

            MessageBox.Show(result, "CV Parsing Result");
        }
    }
}

