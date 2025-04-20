# Smart CV & Form Validator

A C# Windows Forms application for validating user form input and parsing CV content using Regular Expressions (Regex).

## 🚀 Features

### 1. Manual Form Entry
- User can enter:
  - Name
  - Email
  - Phone Number
  - Password
  - Address
  - Postal Code
- Each input is validated using Regex
- Feedback is shown in a message box

### 2. CV Text Parsing
- Paste or upload plain-text CV content
- Automatically extracts:
  - Full Name
  - Email Address
  - Phone Number
  - Skills (e.g., C#, Java, SQL)
  - Years of Experience (e.g., "3 years")
- Results are displayed in a message box

## 💻 Tech Stack

- C#
- .NET Windows Forms
- Regex (System.Text.RegularExpressions)

## 📂 How to Use

1. Clone the repository
2. Open the solution in Visual Studio
3. Run the project
4. Test form validation and CV parsing

## ✅ Example CV Input
```
Name: John Doe
Email: John.doe@example.com
Phone: +12345678901
Skills: C#, Java, SQL
Experience: 3 years
```
This input format should be parsed corroectly.
