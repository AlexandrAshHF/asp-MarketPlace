import React from 'react'
import classes from './Button.module.css'

const AuthButton = (props) => {
    return(
        <button className={classes.authButton}>
            {props.children}
        </button>
    );
}

export default AuthButton;