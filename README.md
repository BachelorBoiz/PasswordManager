<h1>PasswordManager - Security Mini Project</h1>

<h3>Instructions to run the application:</h3>

 1. ```docker compose build```
 2. ```docker compose up```
 3. Go to ```http://localhost:8001/```

<h3>How to use:</h3>

 - For this demo version of the password manager, we use the master password: ```123456```
 - Add new passwords to the list by filling the form.
 - You will only be able to view the list of passwords, if you know the master password.

<h3>Screenshots of the product.</h3>

<picture>
<img src="https://i.imgur.com/BNntXfH.png">
</picture>
<br>
<picture>
<img src="https://i.imgur.com/bPEXHIN.png">
</picture>
<br>
<picture>
<img src="https://i.imgur.com/YkzUaVF.png">
</picture>

<h3>Discussion about security of your product.</h3>

#### AES
<p>We developed a password manager using AES encryption to ensure the security of stored passwords. While we understood the importance of strong master passwords, for the sake of our demo, we temporarily used "123456" as the master password. This allowed us to showcase the functionality of our application effectively. Our primary focus was on implementing AES encryption, creating a user-friendly interface, and demonstrating how the password manager securely stores and retrieves passwords. This project laid a solid foundation for potential future developments and improvements in password security.</p>
