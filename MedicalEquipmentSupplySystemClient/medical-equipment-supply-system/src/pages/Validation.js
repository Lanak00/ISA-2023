import { useNavigate } from "react-router-dom";

import ValidationForm from "../components/user/ValidationForm";


function ValidationPage() {

    const navigate = useNavigate();

    function addTokenHandler(token) {
        console.log(token);
        fetch('https://localhost:7260/auth/verify?token=' + token,
        {
            method: 'POST',
            headers: {
                'accept': '*/*'
            }
        }
    ).then(() => {
        navigate('/', {replace: true});
    });
}

    return (
        <div>
        <ValidationForm onSubmit={addTokenHandler}/>
        </div>
    )
}

export default ValidationPage;