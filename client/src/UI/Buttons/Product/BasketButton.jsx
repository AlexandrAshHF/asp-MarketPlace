import React from "react";
import classes from './BasketButton.module.css'

const BasketButton = ({imgLink, ...props}) => {
    return(
        <button {...props} className={classes.basketButton}>
            <img alt="shopCard" src={imgLink}/>
        </button>
    );
}

export default BasketButton;