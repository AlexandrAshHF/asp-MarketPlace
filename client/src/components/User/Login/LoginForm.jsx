import React from 'react';
import classes from "../AuthForm.module.css"
import AuthButton from '../../../UI/Buttons/Auth/AuthButton'
import AuthInput from '../../../UI/Inputs/Auth/AuthInput';

function LoginForm({errorMessege}) {
    return (
      <form className={classes.loginForm}>
        <label className={classes.headForm}>Authorization</label>

        <AuthInput type='email' placeholder='Email'/>
        <AuthInput type='password' placeholder='Password' maxLength="24"/>

        <label className={classes.errorMessege}>{errorMessege}</label>

        <div className={classes.submitBlock}>
          <AuthButton>LogIn</AuthButton>
          <a href='https://github.com/AlexandrAshHF/asp-MarketPlace.git' className={classes.toRegisterText}>Don't have an account?</a>
        </div>
      </form>
    );
  }
  
  export default LoginForm;