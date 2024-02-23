import React from 'react';
import classes from "./LoginForm.module.css"
import AuthButton from '../../../UI/Buttons/Auth/AuthButton'
import AuthInput from '../../../UI/Inputs/Auth/AuthInput';

function LoginForm() {
    return (
      <form className={classes.loginForm}>
        <AuthInput type='email' placeholder='Email'/>
        <AuthInput type='password' placeholder='Password'/>
        <div>
          <AuthButton>LogIn</AuthButton>
        </div>
      </form>
    );
  }
  
  export default LoginForm;