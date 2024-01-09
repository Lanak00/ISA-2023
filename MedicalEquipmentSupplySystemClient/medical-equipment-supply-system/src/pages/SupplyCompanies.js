import { useState, useEffect } from "react";

import SupplyCompanyList from "../components/companies/SupplyCompanyList";
import SearchBar from "../components/layout/SearchBar";
import SortComponent from "../components/layout/SortComponent";

function AllSupplyCompaniesPage() {
const [isLoading, setIsLoading] = useState(true);
const [sortedCompanies, setSortedCompanies] = useState([]);
const [searchParams, setSearchParams] = useState({});


useEffect(() => {
    setIsLoading(true);
    console.log(localStorage.getItem('accessToken'));

    const url = 'https://localhost:7260/supplyCompanies';
    const params = new URLSearchParams(searchParams);
    const fullURL = `${url}?${params}`

    fetch(fullURL)
    .then((response) => {
        return response.json();
     })
    .then((data) => {
        setIsLoading(false);
        setSortedCompanies(data);
        console.log(data);
    });
}, [searchParams]);

    const handleSearchParamsChange = (params) => {
        setSearchParams(params);
    };

    const handleSortChange = (key, order) => {
        sortCompanies(key, sortedCompanies, order); 
    };

    const sortCompanies = (key, companies, order) => {
        const sorted = [...companies]; 
        switch (key) {
            case 'name':
                sorted.sort((a, b) => (order === 'asc' ? a.name.localeCompare(b.name) : b.name.localeCompare(a.name)));
                break;
            case 'rating':
                sorted.sort((a, b) => (order === 'asc' ? a.rating - b.rating : b.rating - a.rating));
                break;
            case 'city':
                sorted.sort((a, b) => (order === 'asc' ? a.city.localeCompare(b.city) : b.city.localeCompare(a.city)));
                break;
            default:
                setSortedCompanies(sortedCompanies);
                return;
        }
        setSortedCompanies(sorted);
    };

    const itemSearchCriteria = [
        { label: "Name", value: "name" },
        { label: "City", value: "city" }
    ];

    const itemSortOptions = [
        { label: "Sort by Name", value: "name" },
        { label: "Sort by Rating", value: "rating" },
        { label: "Sort by City", value: "city" },
    ];

    if(isLoading) {
        return (
            <section>
                <p>Loading...</p>
            </section>
        );
    }
  
    return (
        <section>
            <div style = {{display: "flex", justifyContent: "space-between", alignItems: "center"}}>
                <SearchBar onSearchParamsChange={handleSearchParamsChange} searchCriteria={itemSearchCriteria}/>
                <SortComponent onSortChange={handleSortChange} sortOptions={itemSortOptions} />
            </div>
            
            <SupplyCompanyList companies = {sortedCompanies}/>
        </section>
    );
}

export default AllSupplyCompaniesPage;