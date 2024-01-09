import { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import classes from './MainNavigation.module.css';

function MainNavigation() {
    const [isLoggedIn, setIsLoggedIn] = useState(false);

    useEffect(() => {
        const token = localStorage.getItem('accessToken');
        setIsLoggedIn(!!token); // Update isLoggedIn based on token presence
    }, []);

    useEffect(() => {
        const checkTokenChange = () => {
            const storedToken = localStorage.getItem('accessToken');
            const tokenExists = !!storedToken;
            setIsLoggedIn(tokenExists);
        };

        const interval = setInterval(checkTokenChange, 200);

        return () => clearInterval(interval);
    }, []);

    let userId = null;
    const token = localStorage.getItem('accessToken');

    if (token) {
        const payload = JSON.parse(atob(token.split('.')[1]));
        userId = payload['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'];
    }

    return (
        <header className={classes.header}>
            <div className={classes.logo}>Medical Equipment Supply System</div>
            <nav>
                <ul>
                    <li>
                        <Link to="/">Supply Companies</Link>
                    </li>
                    {isLoggedIn && (
                        <>
                            <li>
                                <Link to={`/reservations/${userId}`}>Reservations</Link>
                            </li>
                            <li>
                                <Link to={`/myprofile/${userId}`}>My Profile {}</Link>
                            </li>
                        </>
                    )}
                    {!isLoggedIn && (
                        <li>
                            <Link to="/login">Log in</Link>
                        </li>
                    )}
                </ul>
            </nav>
        </header>
    );
}

export default MainNavigation;