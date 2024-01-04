import { useState, useEffect, useCallback } from "react";
import { useNavigate } from "react-router-dom";
import Card from "../components/ui/Card";
import classes from "../components/user/MyProfile.module.css"


function MyProfilePage() {

    const [userData, setUserData] = useState(null);
    const navigate = useNavigate();
    const token = localStorage.getItem('accessToken');

    let userId = null;

    if (token) {
        const payload = JSON.parse(atob(token.split('.')[1]));
        userId = payload['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'];
        console.log(userId);
    }


    const fetchUserData = useCallback(() => {
        fetch(`https://localhost:7260/users/${userId}`)
            .then(response => {
                if (!response.ok) {
                    throw new Error('Failed to fetch user data');
                }
                return response.json();
            })
            .then(data => setUserData(data))
            .catch(error => console.error('Error fetching user data:', error));
    }, [userId]);

    useEffect(() => {
        fetchUserData(); 
    }, [fetchUserData]);

    const handleLogout = () => {
        localStorage.removeItem('accessToken');
        navigate("/login");
    };

    return (
        <Card>
            {userData ? (
                <div className = {classes.content}>
                    <p>Name: {userData.firstName} {userData.lastName}</p>
                    <p>Email: {userData.email}</p>
                    <p>Address: {userData.address}, {userData.city}</p>
                    <p>User Role: {userData.role}</p>
                    <p>Penalties: {userData.penalties}</p>
                    <div className = {classes.actions}>
                        <button onClick={handleLogout}>Log out</button>
                    </div>
                    
                </div>
            ) : (
                <p>Loading user data...</p>
            )}
        </Card>
    );
}


export default MyProfilePage;