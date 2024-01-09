import ReservationItem from "./ReservationItem";
import classes from './ReservationList.module.css';

function ReservationList(props) {
    return (
        <ul className={classes.list}>
            {props.reservations.map(res=> <ReservationItem
                key = {res.id}
                id = {res.id}
                date = {res.date}
                time = {res.time}
                duration = {res.duration}
                administrator = {res.adminId}
            />)}
        </ul>
    )
}

export default ReservationList;