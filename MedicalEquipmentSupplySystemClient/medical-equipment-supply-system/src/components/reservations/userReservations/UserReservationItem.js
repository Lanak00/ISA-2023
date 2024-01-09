import classes from '../ReservationItem.module.css'
import Card from '../../ui/Card';

function UserReservationItem(props) {

    const isUpcoming = props.isUpcoming;

    const cancelReservation = () => {
        // Logic for the action when the button is clicked
    };

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
                    {isUpcoming && (
                    <div className={classes.actions}>
                        <button onClick={cancelReservation}>Cancel</button>
                    </div>
                    )}
                </div>
            </Card>
        </li>
    );

}

export default UserReservationItem;