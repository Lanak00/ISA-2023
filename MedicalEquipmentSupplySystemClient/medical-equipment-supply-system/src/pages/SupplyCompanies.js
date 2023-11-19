import { useState, useEffect } from "react";

import SupplyCompanyList from "../components/companies/SupplyCompanyList";


function AllSupplyCompaniesPage() {
const [isLoading, setIsLoading] = useState(true);
const [loadedCompanies, setLoadedCompanies] = useState([]);

useEffect(() => {
    setIsLoading(true);
    fetch(
        'https://localhost:7260/supplyCompanies'
    ).then((response) => {
       return response.json();
    }).then((data) => {
        setIsLoading(false);
        setLoadedCompanies(data);
        console.log(data);
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
          <SupplyCompanyList companies = {loadedCompanies}/>
  
        </section>
    );
}

export default AllSupplyCompaniesPage;