import { Link } from "react-router-dom";

import classes from './MainNavigation.module.css'

function MainNavigation() {
    return (
    <header className={classes.header}>
        <div className={classes.logo}>Medical Equipment Supply System</div>
        <nav>
            <ul>
                <li>
                    <Link to = '/'>Supply Companies</Link>
                </li>
                <li>
                    <Link to = '/login'>Log in</Link>
                </li>
            </ul>
        </nav>
    </header>
    );
}

export default MainNavigation;