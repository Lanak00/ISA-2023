import classes from './ReservationItem.module.css';
import Card from '../ui/Card';

function ReservationItem(props) {
    
    const equipmentReservationId = props.id;

    const token = localStorage.getItem('accessToken');

    let hospitalWorkerId = null;
    if (token) {
        const payload = JSON.parse(atob(token.split('.')[1]));
        hospitalWorkerId = payload['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'];
    }
    
    const handleReservation = async () => {
        try {
            console.log(localStorage.getItem('accessToken'));
            console.log(props);
            console.log(equipmentReservationId);
            console.log(token);
            console.log(hospitalWorkerId);

            const response = await fetch(`https://localhost:7260/reservations/reserve?equipmentReservationId=${equipmentReservationId}&hospitalWorkerId=${hospitalWorkerId}`, {
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
                            <p> Company administrator: {props.administrator}</p>
                        </div>
                    </div>
                    <div className = {classes.actions} >
                        <button onClick={handleReservation}>Reserve</button>
                    </div>
                </div>
            </Card>
        </li>
    );

}

export default ReservationItem;