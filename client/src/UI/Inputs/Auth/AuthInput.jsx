import React from "react";
import classes from './AuthInput.module.css';

const AuthInput = ({props}) => {
    return(
        <input {...props} className={classes.AuthInput}/>
    );
}

export default AuthInput;