import React from "react";
import classes from './AuthInput.module.css';

const AuthInput = (props) => {
    return(
        <input placeholder={props.placeholder} type={props.type} className={classes.AuthInput}/>
    );
}

export default AuthInput;