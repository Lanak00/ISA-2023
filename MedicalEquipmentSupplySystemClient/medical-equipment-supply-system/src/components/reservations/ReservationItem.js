import { useState } from 'react';
import classes from './ReservationItem.module.css';
import Card from '../ui/Card';

function ReservationItem(props) {
    const [isReserved, setIsReserved] = useState(false);
    
    const equipmentReservationId = props.id;

    const token = localStorage.getItem('accessToken');

    let hospitalWorkerId = null;
    let email = null;

    if (token) {
        const payload = JSON.parse(atob(token.split('.')[1]));
        hospitalWorkerId = payload['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'];
        email = payload['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress'];
    }
    
    const handleReservation = async () => {
        try {
            setIsReserved(true);
            const response = await fetch(`https://localhost:7260/reservations/reserve?equipmentReservationId=${equipmentReservationId}&hospitalWorkerId=${hospitalWorkerId}&email=${email}`, {
                method: 'POST',
                headers: {
                    'Authorization': `Bearer ${token}`,
                    'Content-type' : 'aplication/json'
                },
            });

            if (!response.ok) {
                throw new Error('Failed to reserve equipment');
            }

        } catch (error) {
            console.error('Error reserving equipment', error)
            setIsReserved(false);
        }
    } 

    return(
        <li className={classes.item}>
            <Card>
                <div className = {classes.elements}>
                    <div className={classes.allcont}>
                        <div className={classes.content}>
                            <div>
                                <h2>Date: {props.date}</h2>
                                <h2>Time: {props.time}</h2>
                            </div>
                            <h3>Duration: {props.duration} hours</h3>
                        </div>
                    </div>
                    <div className = {classes.actions} >
                    <button onClick={handleReservation} disabled={isReserved} className={isReserved ? classes.disabledButton : classes.enabledButton}>
                        {isReserved ? 'Reserved' : 'Reserve'}
                    </button>
                    </div>
                </div>
            </Card>
        </li>
    );

}

export default ReservationItem;