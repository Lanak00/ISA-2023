import ReservationsBar from "../components/layout/ReservationsBar";
import { useState } from 'react';
import HistoryReservationsComponent from "../components/reservations/userReservations/HistoryReservations";
import UpcomingReservationsComponent from "../components/reservations/userReservations/UpcomingReservations";


function ReservationsPage() {
    const [selectedOption, setSelectedOption] = useState('history'); 

    return (
        <div>
            <ReservationsBar setSelectedOption={setSelectedOption}></ReservationsBar>
            {selectedOption === 'history' ? (
                <HistoryReservationsComponent />
            ) : (
                <UpcomingReservationsComponent />
            )}
        </div>
    );
}

export default ReservationsPage;