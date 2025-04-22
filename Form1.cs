using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;

namespace CVValidator
{
    public partial class Form1 : Form
    {
        private string lastValidationResults = "";
        private string lastParsingResults = "";
        private bool hasValidationData = false;
        private bool hasParsingData = false;

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

            StringBuilder result = new StringBuilder();

            result.Append(ValidateField("Name", name, @"^[a-zA-Z\s]+$|^[\u0621-\u064A\s]+$"));
            result.Append(ValidateField("Email", email, @"^\w+@\w+\.\w{2,3}$"));
            result.Append(ValidateField("Phone", phone, @"^\+?\d{10,15}$"));
            result.Append(ValidateField("Password", password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{7,16}$"));
            result.Append(ValidateField("Address", address, @".+"));
            result.Append(ValidateField("Postal Code", postal, @"^\d{5,6}$"));

            lastValidationResults = result.ToString();
            hasValidationData = true;
            hasParsingData = false;

            MessageBox.Show(lastValidationResults, "Validation Results");
        }

        private string ValidateField(string fieldName, string input, string pattern)
        {
            bool isValid = Regex.IsMatch(input, pattern);
            // Color the textbox based on validation result
            if (fieldName == "Name")
                txtName.BackColor = isValid ? System.Drawing.Color.LightGreen : System.Drawing.Color.LightCoral;
            if (fieldName == "Email")
                txtEmail.BackColor = isValid ? System.Drawing.Color.LightGreen : System.Drawing.Color.LightCoral;
            if (fieldName == "Phone")
                txtPhone.BackColor = isValid ? System.Drawing.Color.LightGreen : System.Drawing.Color.LightCoral;
            if (fieldName == "Password")
                txtPassword.BackColor = isValid ? System.Drawing.Color.LightGreen : System.Drawing.Color.LightCoral;
            if (fieldName == "Address")
                txtAddress.BackColor = isValid ? System.Drawing.Color.LightGreen : System.Drawing.Color.LightCoral;
            if (fieldName == "Postal Code")
                txtPostal.BackColor = isValid ? System.Drawing.Color.LightGreen : System.Drawing.Color.LightCoral;

            return isValid ? $"{fieldName}: Valid\n" : $"{fieldName}: Invalid\n";
        }

        private void btnParseCV_Click(object sender, EventArgs e)
        {
            string cvText = txtCV.Text;
            StringBuilder result = new StringBuilder();

            // استخراج الاسم من السيرة الذاتية
            var nameMatch = Regex.Match(cvText, @"(?<=Name[:\s]*)[A-Z][a-z]+\s[A-Z][a-z]+|(?<=الاسم[:\s]*)[أ-ي]+(\s[أ-ي]+)*");
            var emailMatch = Regex.Match(cvText, @"\b\w+@\w+\.\w{2,3}\b");
            var phoneMatch = Regex.Match(cvText, @"\+?\d{10,15}");
            var skillsMatch = Regex.Matches(cvText, @"\b(C#|Java|SQL|Python|JavaScript)\b");
            var expMatch = Regex.Match(cvText, @"\b\d+\s+years?\b|\b\d+\s+سنوات\b");

            result.Append($"Name: {nameMatch.Value}\n");
            result.Append($"Email: {emailMatch.Value}\n");
            result.Append($"Phone: {phoneMatch.Value}\n");

            result.Append("Skills: ");
            foreach (Match skill in skillsMatch)
                result.Append($"{skill.Value}, ");
            result = result.Remove(result.Length - 2, 2).Append("\n");

            result.Append($"Experience: {expMatch.Value}\n");

            lastParsingResults = result.ToString();
            hasParsingData = true;
            hasValidationData = false;

            MessageBox.Show(lastParsingResults, "CV Parsing Result");
        }

        private void btnSaveResults_Click(object sender, EventArgs e)
        {
            if (!hasValidationData && !hasParsingData)
            {
                MessageBox.Show("No results to save. Please validate a form or parse a CV first.", "No Data");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|CSV files (*.csv)|*.csv";
            saveFileDialog.Title = "Save Results";
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string dataToSave = hasValidationData ? lastValidationResults : lastParsingResults;
                    string filePath = saveFileDialog.FileName;

                    if (filePath.EndsWith(".csv"))
                    {
                        // Convert to CSV format
                        StringBuilder csvBuilder = new StringBuilder();
                        string[] lines = dataToSave.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                        if (hasValidationData)
                        {
                            csvBuilder.AppendLine("Field,Status");
                            foreach (string line in lines)
                            {
                                string[] parts = line.Split(new[] { ':' }, 2);
                                if (parts.Length == 2)
                                {
                                    csvBuilder.AppendLine($"\"{parts[0].Trim()}\",\"{parts[1].Trim()}\"");
                                }
                            }
                        }
                        else // Parsing data
                        {
                            csvBuilder.AppendLine("Category,Value");
                            foreach (string line in lines)
                            {
                                string[] parts = line.Split(new[] { ':' }, 2);
                                if (parts.Length == 2)
                                {
                                    string value = parts[1].Trim();
                                    if (parts[0].Trim() == "Skills")
                                    {
                                        string[] skills = value.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                        foreach (string skill in skills)
                                        {
                                            csvBuilder.AppendLine($"\"Skill\",\"{skill.Trim()}\"");
                                        }
                                    }
                                    else
                                    {
                                        csvBuilder.AppendLine($"\"{parts[0].Trim()}\",\"{value}\"");
                                    }
                                }
                            }
                        }
                        dataToSave = csvBuilder.ToString();
                    }

                    File.WriteAllText(filePath, dataToSave);
                    MessageBox.Show($"Results saved successfully to:\n{filePath}", "Success");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving file: {ex.Message}", "Error");
                }
            }
        }
    }
}