namespace CVValidator
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private TextBox txtName, txtEmail, txtPhone, txtPassword, txtAddress, txtPostal, txtCV;
        private Button btnValidateForm, btnParseCV, btnSaveResults;
        private Label lblTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtName = new TextBox();
            txtEmail = new TextBox();
            txtPhone = new TextBox();
            txtPassword = new TextBox();
            txtAddress = new TextBox();
            txtPostal = new TextBox();
            txtCV = new TextBox();
            btnValidateForm = new Button();
            btnParseCV = new Button();
            lblTitle = new Label();
            btnSaveResults = new Button();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(20, 50);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Name";
            txtName.Size = new Size(200, 23);
            txtName.TabIndex = 1;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(20, 80);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email";
            txtEmail.Size = new Size(200, 23);
            txtEmail.TabIndex = 2;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(20, 110);
            txtPhone.Name = "txtPhone";
            txtPhone.PlaceholderText = "Phone Number";
            txtPhone.Size = new Size(200, 23);
            txtPhone.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(20, 140);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Password";
            txtPassword.Size = new Size(200, 23);
            txtPassword.TabIndex = 4;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(20, 170);
            txtAddress.Name = "txtAddress";
            txtAddress.PlaceholderText = "Address";
            txtAddress.Size = new Size(200, 23);
            txtAddress.TabIndex = 5;
            // 
            // txtPostal
            // 
            txtPostal.Location = new Point(20, 200);
            txtPostal.Name = "txtPostal";
            txtPostal.PlaceholderText = "Postal Code";
            txtPostal.Size = new Size(200, 23);
            txtPostal.TabIndex = 6;
            // 
            // txtCV
            // 
            txtCV.Location = new Point(250, 50);
            txtCV.Multiline = true;
            txtCV.Name = "txtCV";
            txtCV.Size = new Size(300, 175);
            txtCV.TabIndex = 7;
            // 
            // btnValidateForm
            // 
            btnValidateForm.Location = new Point(20, 240);
            btnValidateForm.Name = "btnValidateForm";
            btnValidateForm.Size = new Size(200, 30);
            btnValidateForm.TabIndex = 8;
            btnValidateForm.Text = "Validate Form";
            btnValidateForm.Click += btnValidateForm_Click;
            // 
            // btnParseCV
            // 
            btnParseCV.Location = new Point(250, 240);
            btnParseCV.Name = "btnParseCV";
            btnParseCV.Size = new Size(300, 30);
            btnParseCV.TabIndex = 9;
            btnParseCV.Text = "Parse CV";
            btnParseCV.Click += btnParseCV_Click;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(149, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(277, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Smart CV and Form Validator";
            // 
            // btnSaveResults
            // 
            btnSaveResults.Location = new Point(20, 280);
            btnSaveResults.Name = "btnSaveResults";
            btnSaveResults.Size = new Size(530, 30);
            btnSaveResults.TabIndex = 10;
            btnSaveResults.Text = "Save Results to File";
            btnSaveResults.Click += btnSaveResults_Click;
            // 
            // Form1
            // 
            ClientSize = new Size(580, 320);
            Controls.Add(btnSaveResults);
            Controls.Add(lblTitle);
            Controls.Add(txtName);
            Controls.Add(txtEmail);
            Controls.Add(txtPhone);
            Controls.Add(txtPassword);
            Controls.Add(txtAddress);
            Controls.Add(txtPostal);
            Controls.Add(txtCV);
            Controls.Add(btnValidateForm);
            Controls.Add(btnParseCV);
            Name = "Form1";
            Text = "Smart CV & Form Validator";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}