import React from "react";
import SupplyCompanyItem from "./SupplyCompanyItem"; 
import classes from './SupplyCompanyList.module.css';

function SupplyCompanyList(props) {
return (
 <ul className = {classes.list}>
     {props.companies.map(company=> <SupplyCompanyItem
        key = {company.id}
        id = {company.id}
        name = {company.name}
        image = {company.image}
        address = {company.address}
        city = {company.city}
        description = {company.description}   
        rating = {company.rating}   
     />)} 
</ul>
)
}
export default SupplyCompanyList;