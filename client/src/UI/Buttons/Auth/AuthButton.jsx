import React from 'react'
import classes from './Button.module.css'

const AuthButton = (children, ...props) => {
    return(
        <button {...props} className={classes.authButton}>
            {children}
        </button>
    );
}

export default AuthButton;