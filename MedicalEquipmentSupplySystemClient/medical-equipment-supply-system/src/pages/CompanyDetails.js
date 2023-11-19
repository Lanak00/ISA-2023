import { useParams } from "react-router-dom";
import EquipmentList from "../components/equipment/EquipmentList";
import { useEffect, useState } from "react";

function CompanyDetailsPage() {

    const params = useParams();
    console.log(params.id);

    const [isLoading, setIsLoading] = useState(true);
    const [loadedEquipment, setLoadedEquipment] = useState([]);

    useEffect( () => {
        setIsLoading(true);
        fetch(
           
            'https://localhost:7260/equipment?supplyCompanyId='+ params.id // eslint-disable-line
        ).then( (response) => {
            return response.json();
        }).then((data) => {
            setIsLoading(false);
            setLoadedEquipment(data);
            console.log(data)
        });

}, []);
        if(isLoading) { 
            return ( 
        <section> 
            <p>Loading...</p> 
        </section> 
            );
        }


    return (
        <section>
            <EquipmentList equipment = {loadedEquipment}/>
        </section>

    );

}
export default CompanyDetailsPage;