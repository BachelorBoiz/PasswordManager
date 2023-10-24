<h1>PasswordManager - Security Mini Project</h1>

Made by: Christian Lindholm, Julian Petersen, Mathias Kristensen, Mads Harby.

<h3>Improvements to the application:</h3>

- User functionality has been added, with the option to create a new user and login. No more hardcoded passwords.
- Jwt used for authentication. Every method in the backend API (except login and create user) has been marked with [Authorize] Which means it has to have a valid Jwt to function.
- The frontend has an interceptor to use for authentication which makes communication between frontend and backend more secure.
- Password hashing is done with 600.000 iterations of Pbkdf2 instead of 10.000

<h3>Instructions to run the application:</h3>

 1. ```docker compose build```
 2. ```docker compose up```
 3. Go to ```http://localhost:8001/```
 4. Go to ```http://localhost:8000/swagger``` to see the API

<h3>How to use:</h3>

 - A user with email: test@mail.com and password: 123456 has been made.
 - Add new passwords to the list by filling the form.
 - You will only be able to view the list of passwords, if you know the master password.

<h3>Screenshots of the product.</h3>


<img src="https://i.imgur.com/OdiubMs.png" alt="Alt Text">
<br>
<img src="https://i.imgur.com/6Ce0XiJ.png" alt="Alt Text">
<br>
<img src="https://i.imgur.com/YkzUaVF.png" alt="Alt Text">

<h3>Discussion about security of our product.</h3>

<h4>Security Considerations:</h4>
In our project we recognized the importance of data encryption to protect sensitive information (in this case, passwords). We decided to use Advanced Encryption Standard (AES) as our encryption algorithm due to its well established place in security. AES is a symmetric key encryption algorithm that provides a high level of protection against unauthorized access.
We've also opted for PBKDF2 to help with our password hashing. With these choices in mind we tried to achieve a safe password application.

<h4>Key Management:</h4> To ensure the security of our application, we implemented a robust key management system. The strength of AES is in the key used for encryption and decryption, so we placed great emphasis on the protection and handling of encryption keys. The master password functions as the key in our case.

<h4>Password generator:</h4> Our password manager includes a password generation function, which helps create strong and secure passwords with ease. By clicking the “Generate” button, the application fills the form with strong passwords. 

<h4>Strong passwords:</h4> A strong and secure password is a combination of characters, symbols and numbers. A user will often be prompted to type a password with a specific amount of letters, numbers and whatever else the requirement may be. This is because it should be difficult for attackers to guess. Secure passwords are typically complex, long and unpredictable. Avoiding the use of dictionary words or easily obtainable personal information, can help keep an account safe from attackers.


<h4>AES</h4>
<p>We developed the password manager using AES encryption to ensure the security of stored passwords. Our primary focus was on implementing AES encryption, creating a user-friendly interface, and demonstrating how the password manager securely stores and retrieves passwords. This project laid a solid foundation for potential future developments and improvements in password security.</p>

<h4>PBKDF2</h4>
<p>When we create accounts in the application, our passwords are first salted, and then the salted password is processed using PBKDF2. PBKDF2 stands for 'Password-Based Key Derivation Function 2.' It's a special tool that takes the salted password and performs multiple iterations of a cryptographic function (SHA-256 in our case), making it harder for anyone to figure out what our passwords are. The result of these iterations is a derived key, which is the value stored in the database. 
<br><br>
OWASP recommends doing this mixing process 600,000 times.</p>

<h4>Plans for for how a user can access their credentials across devices</h4>

If a user were to access the password manager on other devices, a few improvements should be made:
 - Hosting. The application should be hosted on a cloud provider. Our container is containerized, so any cloud hosting solution should work.

