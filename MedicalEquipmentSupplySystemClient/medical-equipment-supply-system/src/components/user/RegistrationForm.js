import {useRef} from 'react';
import { useState } from 'react';

import Card from '../ui/Card';
import classes from './RegistrationForm.module.css'
import { useNavigate } from 'react-router-dom';

function RegistrationForm(props) {

    const [isDisabled, setDisable] = useState(false);
    const [passwordsMatch, setPasswordsMatch] = useState(true);
    const [showErrorPopup, setShowErrorPopup] = useState(false);



    const navigate = useNavigate();
    
    const firstNameInputRef = useRef();
    const lastNameInputRef = useRef();
    const emailInputRef = useRef();
    const passwordInputRef = useRef();
    const addressInputRef = useRef();
    const cityInputRef = useRef();
    const companyInputRef = useRef();
    const confirmPasswordInputRef = useRef();

    function submitHandler(event) {
        event.preventDefault();

        setDisable(true);

        const enteredFirstName = firstNameInputRef.current.value;
        const enteredLastName = lastNameInputRef.current.value;
        const enteredEmail = emailInputRef.current.value;
        const enteredPassword = passwordInputRef.current.value;
        const enteredAddress = addressInputRef.current.value;
        const enteredCity = cityInputRef.current.value;
        const enteredCompany = companyInputRef.current.value;
        const enteredConfirmPassword= confirmPasswordInputRef.current.value;

        const userData = {
            email: enteredEmail,
            password: enteredPassword,
            confirmPassword: enteredConfirmPassword,
            firstName: enteredFirstName,
            lastName: enteredLastName,
            address: enteredAddress,
            city: enteredCity,
            country: "Serbia",
            gender: 0,
            company: enteredCompany,

        };

        fetch('https://localhost:7260/auth/register', {
            method: 'POST',
            body: JSON.stringify(userData),
            headers: {
                'accept': '*/*',
                'Content-Type': 'application/json'
            }
        }).then(response => {
            if (!response.ok) {
                // Handle error response
                if (response.status === 400) {
                        setShowErrorPopup(true);
                        // Handle other error cases if needed
                    };
            } else {
                navigate('/validate', { replace: true });
            }
        }).catch(error => {
            console.error('Error during registration', error);
        });

        emailInputRef.current.value = '';
        passwordInputRef.current.value = '';
        firstNameInputRef.current.value = '';
        lastNameInputRef.current.value = '';
        addressInputRef.current.value = '';
        cityInputRef.current.value = '';
        companyInputRef.current.value = '';
        confirmPasswordInputRef.current.value = '';

    }

    function confirmPwdBlurHandler() {
        const enteredPassword = passwordInputRef.current.value;
        const enteredConfirmPassword = confirmPasswordInputRef.current.value;

        if (enteredPassword !== enteredConfirmPassword) {
            setPasswordsMatch(false);
        } else {
            setPasswordsMatch(true);
        }
    }

    return (
        <Card>
            <h1 className={classes.h1}>Register</h1>
                <form className={classes.form} onSubmit={submitHandler}>
                    <div className={classes.control}>
                        <label htmlFor='firstName'>First Name</label>
                        <input type="text" placeholder='First Name' required id="firstName" ref = {firstNameInputRef}/>
                    </div>
                    <div className={classes.control}>
                        <label htmlFor='lastName'>Last Name</label>
                        <input type="text" placeholder='Last Name' required id="lastName" ref = {lastNameInputRef}/>
                    </div>
                    <div className={classes.control}>
                        <label htmlFor='email'>Email</label>
                        <input type="email" placeholder='Email' required id="email" ref={emailInputRef}/>
                        {showErrorPopup && (
                            <div className={classes.popup}>
                                 <p>User with this email already exists</p>
                                 <button onClick={() => setShowErrorPopup(false)}>Close</button>
                            </div>
                        )}
                    </div>
                    <div className={classes.control}>
                        <label htmlFor='password'>Password</label>
                        <input type="password" placeholder='Password' required id="password" ref={passwordInputRef}/>
                    </div>
                    <div className={classes.control}>
                        <label htmlFor='cpassword'>Confirm Password</label>
                        <input
                            type="password"
                            placeholder='Confirm Password' 
                            required id="cpassword" 
                            ref={confirmPasswordInputRef}
                            onBlur={confirmPwdBlurHandler}/>
                         {!passwordsMatch && (<p style={{ color: 'red' }}>Passwords don't match</p>)}
                    </div>
                    <div className={classes.control}>
                        <label htmlFor='address'>Address</label>
                        <input type="text" placeholder='Addres' required id="address" ref={addressInputRef}/>
                    </div>
                    <div className={classes.control}>
                        <label htmlFor='city'>City</label>
                        <input type="text" placeholder='City' required id="city" ref={cityInputRef}/>
                    </div>
                    <div className={classes.control}>
                        <label htmlFor='company'>Company Name</label>
                        <input type="text" placeholder='Company' required id="company" ref={companyInputRef}/>
                    </div>
                    <div className={classes.actions}>
                        <button disabled={isDisabled}>Sign Up</button>
                    </div>
                </form>
        </Card>
    );
}

export default RegistrationForm;