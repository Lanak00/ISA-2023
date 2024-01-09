import { useEffect, useState } from "react";
import React from "react";
import UserReservationList from "./UserReservationList";

function HistoryReservationsComponent() {

    const token = localStorage.getItem('accessToken');

    let userId = null;

    if (token) {
        const payload = JSON.parse(atob(token.split('.')[1]));
        userId = payload['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'];
        console.log(userId);
    }

    const [isLoading, setIsLoading] = useState(true);
    const [loadedReservations, setLoadedReservations] = useState([]);

    useEffect( () => {
        setIsLoading(true);
        fetch(
            `https://localhost:7260/reservations/history?hospitalWorkerId=${userId}`
        ).then( (response) => {
            return response.json();
        }).then((data) => {
            setIsLoading(false);
            setLoadedReservations(data);
            console.log(data)
        });

}, [userId]);

        if(isLoading) { 
            return ( 
        <section> 
            <p>Loading...</p> 
        </section> 
            );
        }


    return (
        <section>
            <UserReservationList reservations = {loadedReservations} isUpcoming={false}/>
        </section>

    );
}

export default HistoryReservationsComponent;



