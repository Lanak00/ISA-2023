import UserReservationItem from "./UserReservationItem";
import classes from '../ReservationList.module.css'

function UserReservationList(props) {
    const isUpcoming = props.isUpcoming;
    return (
        <ul className={classes.list}>
            {props.reservations.map(res=> <UserReservationItem
                key = {res.id}
                id = {res.id}
                date = {res.date}
                time = {res.time}
                duration = {res.duration}
                equipmentId = {res.equipmentId}
                equipmentName = {res.equipmentName}
                administrator = {res.adminId}
                administratorName = {res.administratorName}
                isUpcoming={isUpcoming} 
            />)}
        </ul>
    )
}

export default UserReservationList;