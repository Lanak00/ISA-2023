import React from "react";
import ReservationList from "../components/reservations/ReservationList";
import classes from "../components/reservations/EquipmentReservations.module.css"

function AllEquipmentReservationsPage({reservations, onClose}) {
    return (
        <div className = {classes.modalOverlay}>
            <div className={classes.modal}>
            <div className="modal-content">
                <h3>Available appointments:</h3>
                <ReservationList reservations={reservations} />
                <button onClick={onClose}>Close</button>
            </div>
        </div>
        </div>
        
    );
}

export default AllEquipmentReservationsPage;