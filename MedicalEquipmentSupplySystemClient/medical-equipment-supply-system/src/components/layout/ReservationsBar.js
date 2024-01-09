import classes from './ReservationsBar.module.css'
import { useState } from 'react';

function ReservationsBar({ setSelectedOption }) {
    
    const [activeButton, setActiveButton] = useState('history'); 

    const handleButtonClick = (option) => {
        setSelectedOption(option); 
        setActiveButton(option); 
    };

    return (
        <header className={classes.header}>
            <nav>
                <ul>
                    <li>
                        <button
                            className={`${classes.button} ${
                                activeButton === 'history' ? classes.active : ''
                            }`}
                            onClick={() => handleButtonClick('history')}
                        >
                            History
                        </button>
                    </li>
                    <li>
                        <button
                            className={`${classes.button} ${
                                activeButton === 'upcoming' ? classes.active : ''
                            }`}
                            onClick={() => handleButtonClick('upcoming')}
                        >
                            Upcoming
                        </button>
                    </li>
                </ul>
            </nav>
        </header>
    );
}

export default ReservationsBar;