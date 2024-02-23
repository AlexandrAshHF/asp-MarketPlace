import React from "react";
import classes from './AuthInput.module.css';

const AuthInput = (children, ...props) => {
    return(
        <input {...props} className={classes.AuthInput}> {children} </input>
    );
}

export default AuthInput;