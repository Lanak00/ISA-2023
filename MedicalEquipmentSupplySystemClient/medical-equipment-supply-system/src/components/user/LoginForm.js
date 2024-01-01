import {useRef} from 'react';
import { useState } from 'react';

import Card from '../ui/Card';
import classes from './LoginForm.module.css'

function LoginForm(props) {

    const [isDisabled, setDisable] = useState(false);
    
    const emailInputRef = useRef();
    const passwordInputRef = useRef();

    function submitHandler(event) {
        event.preventDefault();

        setDisable(true);

        const enteredEmail = emailInputRef.current.value;
        const enteredPassword = passwordInputRef.current.value;

        const loginData = {
            email: enteredEmail,
            password: enteredPassword,
        };

        props.onRegistration(loginData);
    }

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