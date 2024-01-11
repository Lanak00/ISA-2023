import { useState } from 'react'; 
import classes from '../ReservationItem.module.css'
import Card from '../../ui/Card';

function UserReservationItem(props) {

    const [isCanceled, setIsCanceled] = useState(false);
    const token = localStorage.getItem('accessToken');
    const isUpcoming = props.isUpcoming;

    const cancelReservation = () => {

        const equipmentReservationId = props.id; 

        try {

            console.log(equipmentReservationId);

            const response = fetch(`https://localhost:7260/reservations/cancel?equipmentReservationId=${equipmentReservationId}`, {
                method: 'POST',
                headers: {
                    'Authorization': `Bearer ${token}`,
                    'Content-type' : 'aplication/json'
                },
            });
            setIsCanceled(true);

            if (!response.ok) {
                throw new Error('Failed to cancel reservation');
            }

        } catch (error) {
            console.error('Error canceling reservation', error)
        }
    
    };

    return(
        <li className={classes.item}>
            <Card>
                <div className = {classes.elements}>
                    <div className={classes.allcont}>
                        <div className={classes.content}>
                            <div>
                                <h2>{props.equipmentName}</h2>
                                <h2>Date: {props.date}</h2>
                                <h2>Time: {props.time}</h2>
                            </div>
                            <h3>Duration: {props.duration} hours</h3>
                        </div>
                    </div>
                    {isUpcoming && (
                    <div className={classes.actions}>
                        <button onClick={cancelReservation} disabled={isCanceled} className={isCanceled ? classes.disabledButton : classes.enabledButton}>
                                {isCanceled ? 'Canceled' : 'Cancel'}
                        </button>
                    </div>
                    )}
                </div>
            </Card>
        </li>
    );

}

export default UserReservationItem;