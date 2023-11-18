import {useNavigate} from 'react-router-dom';

import RegistrationForm from "../components/user/RegistrationForm";

function RegistrationPage() {
    const navigate = useNavigate();


    function addUserHandler(userData) {
        console.log(userData);
        console.log(JSON.stringify(userData));
        fetch('https://localhost:7260/auth/register',
        {
            method: 'POST',
            body: JSON.stringify(userData),
            headers: {
                'accept': '*/*',
                'Content-Type': 'application/json'
            }
        }
    ).then(() => {
        navigate('/validate', {replace: true})
    });
}

    return (
        <section>
            <RegistrationForm onRegistration={addUserHandler} />
        </section>
    );
}

export default RegistrationPage;