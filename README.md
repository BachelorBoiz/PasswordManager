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


<img src="https://i.imgur.com/BNntXfH.png" alt="Alt Text">
<br>
<img src="https://i.imgur.com/bPEXHIN.png" alt="Alt Text">
<br>
<img src="https://i.imgur.com/YkzUaVF.png" alt="Alt Text">

<h3>Discussion about security of our product.</h3>

<h4>Security Considerations:</h4>
In our project we recognized the importance of data encryption to protect sensitive information (in this case, passwords). We decided to use Advanced Encryption Standard (AES) as our encryption algorithm due to its well established place in security.
AES is a symmetric key encryption algorithm that provides a high level of protection against unauthorized access.

<h4>Key Management:</h4> To ensure the security of our application, we implemented a robust key management system. The strength of AES is in the key used for encryption and decryption, so we placed great emphasis on the protection and handling of encryption keys. The master password functions as the key in our case.

<h4>Password Complexity:</h4> While we used the simple master password "123456" for the demo, we stressed the importance of strong, complex passwords for real-world applications. In the backend, we have implemented a password hashing functionality, so we hash the master password, and verify that it is correct.



<h4>Password generator:</h4> Our password manager includes a password generation function, which helps create strong and secure passwords with ease. By clicking the “Generate” button, the application fills the form with strong passwords. 

<h4>Strong passwords:</h4> A strong and secure password is a combination of characters, symbols and numbers. A user will often be prompted to type a password with a specific amount of letters, numbers and whatever else the requirement may be. This is because it should be difficult for attackers to guess. Secure passwords are typically complex, long and unpredictable. Avoiding the use of dictionary words or easily obtainable personal information, can help keep an account safe from attackers.


<h4>AES</h4>
<p>We developed the password manager using AES encryption to ensure the security of stored passwords. While we understood the importance of strong master passwords, for the sake of our demo, we temporarily used "123456" as the master password. This allowed us to showcase the functionality of our application effectively. Our primary focus was on implementing AES encryption, creating a user-friendly interface, and demonstrating how the password manager securely stores and retrieves passwords. This project laid a solid foundation for potential future developments and improvements in password security.</p>

<h4>Plans for for how a user can access their credentials across devices</h4>

If a user were to access the password manager on other devices, a few improvements should be made:

 - Implementing a user service. Right now the password manager only works as one user. A user service could for example contain a user password that stores email and the hashed password.
 - Implementing JWT tokens. When a user tries to login, a request will be sent to the backend with the user's email and hashed password. The backend verifies that the hashed password is correct, and generates a JWT token with the relevant user information.The frontend should implement guards and interceptors to verify the JWT token.
 - Hosting. The application should be hosted on a cloud provider. Our container is containerized, so any cloud hosting solution should work.

