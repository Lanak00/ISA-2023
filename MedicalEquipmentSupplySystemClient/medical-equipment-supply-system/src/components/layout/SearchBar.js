import classes from './SearchBar.module.css'
import { useState } from 'react';

const SearchBar = ({ onSearchParamsChange }) => {

    const [searchName, setSearchName] = useState('');
    const [searchCity, setSearchCity] = useState('');

    const handleSearch = () => {
        // Construct the parameters based on user input
        const params = {};
        if (searchName) {
            params.name = searchName;
        }
        if (searchCity) {
            params.city = searchCity;
        }
        
        // Pass the parameters back to the parent component
        onSearchParamsChange(params);
        console.log(params)
    };

    return (
        <div className={classes.header}>
            <input className={classes.input}
                type="text"
                placeholder="Search by name"
                value={searchName}
                onChange={(e) => setSearchName(e.target.value)}
            />
            <input className={classes.input}
                type="text"
                placeholder="Search by city"
                value={searchCity}
                onChange={(e) => setSearchCity(e.target.value)}
            />
            <button className={classes.input}
                onClick={handleSearch}>Search</button>
        </div>
        
    );
}

export default SearchBar;