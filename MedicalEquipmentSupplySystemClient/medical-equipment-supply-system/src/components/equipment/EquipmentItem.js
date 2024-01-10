import classes from './EquipmentItem.module.css';
import Card from '../ui/Card';
import { useState } from 'react';
import AllEquipmentReservationsPage from '../../pages/EquipmentReservations';


function EquipmentItem(props) {
    const [showReservations, setShowReservations] = useState(false);
    const [reservations, setReservations] = useState([]);
    const isLoggedIn = !!localStorage.getItem('accessToken');

    const handleShowReservations = () => {
        fetchReservationsForItem();
        setShowReservations(true);
    };

    const fetchReservationsForItem = async () => {
        try {
            console.log(localStorage.getItem('accessToken'));
            const response = await fetch(`https://localhost:7260/reservations/available?equipmentId=${props.id}`);
            if(!response.ok) {
                throw new Error('Failed to fetch reservation');
            }
            const data = await response.json();
            setReservations(data);
        } catch (error) {
            console.error('Error fetching reservations:', error)
        }
    };

    const handleCloseReservations = () => {
        setShowReservations(false);
    };

    return(
        <div > 
            <div >
                <li className={classes.item}>
                    <Card>
                            <div className={classes.allcont}>
                                <div className={classes.content}>
                                    <h2>{props.name}</h2>
                                    <h3>Type: {props.type}</h3>
                                    <p>Description: {props.description}</p>
                                </div>
                            <div className = {classes.actions} >
                            {isLoggedIn && (  
                                    <button onClick={handleShowReservations}>See Appointments</button>
                                )}
                                    {showReservations && (
                                    <AllEquipmentReservationsPage reservations={reservations} onClose={handleCloseReservations} />
                                    )}
                            </div>
                        </div>
                    </Card>
                </li>
            </div>
        </div>
    );

}

export default EquipmentItem;