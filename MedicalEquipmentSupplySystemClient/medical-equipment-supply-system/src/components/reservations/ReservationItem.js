import classes from './ReservationItem.module.css';
import Card from '../ui/Card';

function ReservationItem(props) {
    return(
        <li className={classes.item}>
            <Card>
                <div className={classes.allcont}>
                    <div className={classes.content}>
                        <div>
                            <h2>Date: {props.date}</h2>
                            <h2>Time: {props.time}</h2>
                        </div>
                        <h3>Duration: {props.duration}</h3>
                        <p> Company administrator: {props.administrator}</p>
                    </div>
                </div>
            </Card>
        </li>
    );

}

export default ReservationItem;