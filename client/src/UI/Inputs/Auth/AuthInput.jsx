import React from "react";
import classes from './AuthInput.module.css';

const AuthInput = (props) => {
    return(
        <input placeholder={props.placeholder} type={props.type} maxLength={props.maxLength} className={classes.AuthInput}/>
    );
}

export default AuthInput;