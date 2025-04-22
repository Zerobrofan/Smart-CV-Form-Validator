# Smart CV & Form Validator (With Bonus Task)


## Project Video
https://github.com/user-attachments/assets/23b39504-a1cc-4486-ac77-3e8035ca7295

## Bonus Task
![validator](https://github.com/user-attachments/assets/338c157c-cdce-4a23-9ef4-378aec4b4921)

## Project Description
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

### 3. Bonus Task
- Error Higlighting (Valid input = green 🟩, Invalid input = red 🟥)
- Arabic Regex support
- Saving parsed data into a .txt/.csv file format.

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
### English
```
Name: Sarah Johnson  
Email: sarah@example.com  
Phone: +12345678901  

Professional Summary:  
A highly motivated software engineer with 3 years of experience in developing enterprise-level applications. 

Skills:  
Java,, Python,, JavaScript  

Work Experience:  
Software Developer at Tech Solutions Inc.  
March 2021 – Present  
- Managed databases using SQL Server  
- Collaborated with cross-functional teams  

Education:  
Bachelor of Computer Science  
University of Technology – 2018

Languages:  
English, French
```
### Arabic
```
الاسم: أحمد محمد
الايميل: ahmed@gmail.com
رقم الهاتف: +201234567890
المهارات: C#, Java, Python, JavaScript
الخبرة: 3 سنوات في تطوير البرمجيات
التعليم: بكاليريوس في علوم الكمبيوتر من جامعة القاهرة
العنوان: 123 شارع النيل، القاهرة، مصر
الرمز البريدي: 12345
```
