import React from "react";
import classes from './HoverCard.module.css';

function HoverCard(props) {
 return (
 <div className={classes.card}>
    {props.children}
 </div>)
}
export default HoverCard;