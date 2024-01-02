import {useRef} from 'react';
import { useState } from 'react';

import Card from '../ui/Card';
import classes from './LoginForm.module.css'

function LoginForm(props) {

    const [isDisabled, setDisable] = useState(false);
    const [errorMessage, setErrorMessage] = useState('');
    
    const emailInputRef = useRef();
    const passwordInputRef = useRef();

    async function submitHandler(event) {
        event.preventDefault();

        setDisable(true);

        const enteredEmail = emailInputRef.current.value;
        const enteredPassword = passwordInputRef.current.value;

        const loginData = {
            email: enteredEmail,
            password: enteredPassword,
        };

        console.log(loginData);

        console.log(JSON.stringify(loginData));
        try {
        const response = await fetch(`https://localhost:7260/auth/login`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(loginData),
      });

      if (response.ok) {
        const data = await response.json();
        const token = data.token;

        console.log(token);
      
        // Save the token to local storage
        localStorage.setItem('accessToken', token);

        // Reset form and enable login button
        emailInputRef.current.value = '';
        passwordInputRef.current.value = '';
        setDisable(false);

      } else {
        // Handle login failure
        console.error('Login failed');
        setErrorMessage('Invalid username or password');
        setDisable(false);
      }
    } catch (error) {
      console.error('Error during login', error);
      setDisable(false);
    } }
        
    

    return (
        <Card>
            <h1 className={classes.h1}>Log in</h1>
                <form className={classes.form} onSubmit={submitHandler}>
                    <div className={classes.control}>
                        <label htmlFor='email'>Email</label>
                        <input type="email" placeholder='Email' required id="email" ref={emailInputRef}/>
                    </div>
                    <div className={classes.control}>
                        <label htmlFor='password'>Password</label>
                        <input type="password" placeholder='Password' required id="password" ref={passwordInputRef}/>
                        {errorMessage && <p style={{ color: 'red' }}>{errorMessage}</p>}
                    </div>
                    <div className={classes.actions}>
                        <button disabled={isDisabled}>Log in</button>
                    </div>
                </form>
                <div className= {classes.regdivlink}>
                    <h4>Don't have an account yet? </h4>
                    <a href="http://localhost:3000/register" >
                        <h4>Register here</h4>
                    </a>
                </div>
                
        </Card>
    );
}

export default LoginForm;