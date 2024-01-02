import {useRef} from 'react';
import { useState } from 'react';

import Card from '../ui/Card';
import classes from './RegistrationForm.module.css'

function RegistrationForm(props) {

    const [isDisabled, setDisable] = useState(false);
    
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

        emailInputRef.current.value = '';
        passwordInputRef.current.value = '';
        firstNameInputRef.current.value = '';
        lastNameInputRef.current.value = '';
        addressInputRef.current.value = '';
        cityInputRef.current.value = '';
        companyInputRef.current.value = '';
        confirmPasswordInputRef.current.value = '';

        props.onRegistration(userData);

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
                    </div>
                    <div className={classes.control}>
                        <label htmlFor='password'>Password</label>
                        <input type="password" placeholder='Password' required id="password" ref={passwordInputRef}/>
                    </div>
                    <div className={classes.control}>
                        <label htmlFor='cpassword'>Confirm Password</label>
                        <input type="password" placeholder='Confirm Password' required id="cpassword" ref={confirmPasswordInputRef}/>
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