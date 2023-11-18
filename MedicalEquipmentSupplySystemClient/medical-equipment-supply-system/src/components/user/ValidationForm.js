import { useRef } from 'react';

import Card from '../ui/Card';
import classes from './ValidationForm.module.css';

function ValidationForm(props) {
    const tokenInputRef= useRef();

    function submitHandler(event) {
        event.preventDefault();
        
        const token = tokenInputRef.current.value; 

        props.onSubmit(token);

    }

    return (
        <Card>
            <form className={classes.form} onSubmit={submitHandler}>
            <h2 className={classes.h2}>Registration successfull!</h2>
            <h3 className={classes.h3}>Check your email and insert token to verify your email address.</h3> 
                <div className={classes.control}>
                    <input type="text" placeholder='Insert your token here' required id="token" ref = {tokenInputRef}/>
                </div>
                <div className={classes.actions}>
                    <button>Confirm</button>
                </div>
            </form>
        </Card>
    );
}

export default ValidationForm;